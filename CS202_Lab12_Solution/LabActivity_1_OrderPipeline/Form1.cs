using System;
using System.Windows.Forms;

namespace LabActivity_1_OrderPipeline
{
    public partial class Form1 : Form
    {
        // --- EVENTS ---
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler<OrderEventArgs> OrderConfirmed;
        public event EventHandler<OrderEventArgs> OrderRejected;
        public event EventHandler<ShipEventArgs> OrderShipped; // New event for Task 2

        // --- STATE MANAGEMENT ---
        private bool _isOrderConfirmed = false;
        private string _lastConfirmedProduct = string.Empty;

        public Form1()
        {
            InitializeComponent();
            SetupApplication();
        }

        private void SetupApplication()
        {
            // Populate ComboBox
            productComboBox.Items.AddRange(new string[] { "Laptop", "Mouse", "Keyboard" });
            productComboBox.SelectedIndex = 0;

            // --- EVENT SUBSCRIPTIONS ---
            // Task 1 Event Chain
            OrderCreated += ValidateOrder;
            OrderCreated += DisplayOrderInfo;
            OrderConfirmed += ShowConfirmation;
            OrderRejected += ShowRejection;

            // Task 2 Static Subscription
            OrderShipped += ShowDispatch;
        }

        // --- PUBLISHER METHODS (UI Event Handlers) ---

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            // Reset state for the new order
            _isOrderConfirmed = false;
            _lastConfirmedProduct = string.Empty;
            lblStatus.Text = "Status: Processing...";

            if (string.IsNullOrWhiteSpace(customerNameTextBox.Text))
            {
                MessageBox.Show("Please enter a customer name.", "Input Error");
                return;
            }

            var args = new OrderEventArgs(
                customerNameTextBox.Text,
                productComboBox.SelectedItem.ToString(),
                (int)quantityNumericUpDown.Value
            );
            OrderCreated?.Invoke(this, args);
        }

        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            // 4. Conditional Event Firing: Check state before publishing
            if (!_isOrderConfirmed)
            {
                MessageBox.Show("Please process a valid order first.", "Shipping Error");
                return;
            }

            var args = new ShipEventArgs(_lastConfirmedProduct, chkExpress.Checked);
            OrderShipped?.Invoke(this, args);
        }

        private void chkExpress_CheckedChanged(object sender, EventArgs e)
        {
            // 5. Dynamic Subscription
            if (chkExpress.Checked)
            {
                // Add the subscriber when the box is checked
                OrderShipped += NotifyCourier;
                lblStatus.Text = "Status: Express shipping selected.";
            }
            else
            {
                // Remove the subscriber when the box is unchecked
                OrderShipped -= NotifyCourier;
                lblStatus.Text = "Status: Standard shipping selected.";
            }
        }

        // --- SUBSCRIBER METHODS ---

        // Task 1 Subscribers
        private void ValidateOrder(object sender, OrderEventArgs e)
        {
            if (e.Quantity > 0) { OrderConfirmed?.Invoke(this, e); }
            else { OrderRejected?.Invoke(this, e); }
            Application.DoEvents();
        }

        private void DisplayOrderInfo(object sender, OrderEventArgs e)
        {
            string summary = $"Order Summary:\nCustomer: {e.CustomerName}\nProduct: {e.Product}\nQuantity: {e.Quantity}";
            MessageBox.Show(summary, "Order Details Received");
        }

        private void ShowConfirmation(object sender, OrderEventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {e.CustomerName}";
            // Set state for Task 2
            _isOrderConfirmed = true;
            _lastConfirmedProduct = e.Product;
        }

        private void ShowRejection(object sender, OrderEventArgs e)
        {
            lblStatus.Text = "Order Invalid – Please retry";
        }

        // Task 2 Subscribers
        private void ShowDispatch(object sender, ShipEventArgs e)
        {
            lblStatus.Text = $"Product dispatched: {e.Product}";
        }

        private void NotifyCourier(object sender, ShipEventArgs e)
        {
            // This method only runs if dynamically subscribed
            MessageBox.Show("Express delivery initiated!", "Courier Notification");
        }

        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
