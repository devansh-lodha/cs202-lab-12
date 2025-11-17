using System;
using System.Windows.Forms;

namespace LabActivity_1_OrderPipeline
{
    public partial class Form1 : Form
    {
        // 2. Declare events for each stage of the pipeline
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler<OrderEventArgs> OrderConfirmed;
        public event EventHandler<OrderEventArgs> OrderRejected;

        public Form1()
        {
            InitializeComponent();

            // Populate ComboBox
            productComboBox.Items.AddRange(new string[] { "Laptop", "Mouse", "Keyboard" });
            productComboBox.SelectedIndex = 0;

            // 5. Subscribe all handlers to define the workflow
            OrderCreated += ValidateOrder; // Subscriber 1 for user feedback
            OrderCreated += DisplayOrderInfo; // Subscriber 2 for logic/chaining

            OrderConfirmed += ShowConfirmation; // Chained event subscriber
            OrderRejected += ShowRejection;     // Chained event subscriber
        }

        // 3. The initial publisher method
        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
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

            // Raise the initial event to start the pipeline
            OrderCreated?.Invoke(this, args);
        }

        // --- SUBSCRIBER METHODS ---

        // 4. This subscriber acts as a gate and a publisher for chained events
        private void ValidateOrder(object sender, OrderEventArgs e)
        {
            if (e.Quantity > 0)
            {
                // Chaining: This subscriber now raises the next event in the chain
                OrderConfirmed?.Invoke(this, e);
            }
            else
            {
                // Chaining: This subscriber raises the rejection event
                OrderRejected?.Invoke(this, e);
            }

            // Force the UI thread to process all pending messages (i.e., repaint the label)
            // before the next subscriber in the chain shows the blocking MessageBox.
            Application.DoEvents();
        }

        // This subscriber gives immediate feedback
        private void DisplayOrderInfo(object sender, OrderEventArgs e)
        {
            string summary = $"Order Summary:\n" +
                             $"Customer: {e.CustomerName}\n" +
                             $"Product: {e.Product}\n" +
                             $"Quantity: {e.Quantity}";
            MessageBox.Show(summary, "Order Details Received");
        }

        // Subscriber for the successful chain
        private void ShowConfirmation(object sender, OrderEventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {e.CustomerName}";
        }

        // Subscriber for the failed chain
        private void ShowRejection(object sender, OrderEventArgs e)
        {
            lblStatus.Text = "Order Invalid – Please retry";
        }
    }
}
