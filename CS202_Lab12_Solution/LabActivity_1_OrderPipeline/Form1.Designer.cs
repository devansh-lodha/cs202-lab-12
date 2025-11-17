namespace LabActivity_1_OrderPipeline
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customerNameTextBox = new TextBox();
            productComboBox = new ComboBox();
            quantityNumericUpDown = new NumericUpDown();
            btnProcessOrder = new Button();
            lblStatus = new Label();
            chkExpress = new CheckBox();
            btnShipOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // customerNameTextBox
            // 
            customerNameTextBox.Font = new Font("Segoe UI", 20F);
            customerNameTextBox.Location = new Point(145, 111);
            customerNameTextBox.Name = "customerNameTextBox";
            customerNameTextBox.Size = new Size(530, 43);
            customerNameTextBox.TabIndex = 0;
            customerNameTextBox.TextChanged += customerNameTextBox_TextChanged;
            // 
            // productComboBox
            // 
            productComboBox.Font = new Font("Segoe UI", 20F);
            productComboBox.FormattingEnabled = true;
            productComboBox.Location = new Point(239, 185);
            productComboBox.Name = "productComboBox";
            productComboBox.Size = new Size(324, 45);
            productComboBox.TabIndex = 1;
            // 
            // quantityNumericUpDown
            // 
            quantityNumericUpDown.Font = new Font("Segoe UI", 25F);
            quantityNumericUpDown.Location = new Point(252, 262);
            quantityNumericUpDown.Margin = new Padding(7, 8, 7, 8);
            quantityNumericUpDown.Name = "quantityNumericUpDown";
            quantityNumericUpDown.Size = new Size(291, 52);
            quantityNumericUpDown.TabIndex = 2;
            // 
            // btnProcessOrder
            // 
            btnProcessOrder.Font = new Font("Segoe UI", 20F);
            btnProcessOrder.Location = new Point(33, 333);
            btnProcessOrder.Name = "btnProcessOrder";
            btnProcessOrder.Size = new Size(276, 86);
            btnProcessOrder.TabIndex = 3;
            btnProcessOrder.Text = "Process Order";
            btnProcessOrder.UseVisualStyleBackColor = true;
            btnProcessOrder.Click += btnProcessOrder_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 25F);
            lblStatus.Location = new Point(167, 1);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(496, 98);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status: Awaiting Order";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkExpress
            // 
            chkExpress.AutoSize = true;
            chkExpress.Font = new Font("Segoe UI", 20F);
            chkExpress.Location = new Point(340, 357);
            chkExpress.Name = "chkExpress";
            chkExpress.Size = new Size(236, 41);
            chkExpress.TabIndex = 5;
            chkExpress.Text = "Express Shipping";
            chkExpress.UseVisualStyleBackColor = true;
            chkExpress.Click += chkExpress_CheckedChanged;
            // 
            // btnShipOrder
            // 
            btnShipOrder.Font = new Font("Segoe UI", 20F);
            btnShipOrder.Location = new Point(594, 333);
            btnShipOrder.Name = "btnShipOrder";
            btnShipOrder.Size = new Size(157, 86);
            btnShipOrder.TabIndex = 6;
            btnShipOrder.Text = "Ship Order";
            btnShipOrder.UseVisualStyleBackColor = true;
            btnShipOrder.Click += btnShipOrder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShipOrder);
            Controls.Add(chkExpress);
            Controls.Add(lblStatus);
            Controls.Add(btnProcessOrder);
            Controls.Add(quantityNumericUpDown);
            Controls.Add(productComboBox);
            Controls.Add(customerNameTextBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)quantityNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox customerNameTextBox;
        private ComboBox productComboBox;
        private NumericUpDown quantityNumericUpDown;
        private Button btnProcessOrder;
        private Label lblStatus;
        private CheckBox chkExpress;
        private Button btnShipOrder;
    }
}
