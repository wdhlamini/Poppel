namespace PoppelProject.PresentationLayer
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.remainingCreditLabel = new System.Windows.Forms.Label();
            this.remaininhCreditHeading = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.specialNoteLabel = new System.Windows.Forms.Label();
            this.specialNoteTextBox = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.ItemsOnCartLabel = new System.Windows.Forms.Label();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.qtyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.currentTotalLabel = new System.Windows.Forms.Label();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.productLabel = new System.Windows.Forms.Label();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerNumberLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderIDLabel = new System.Windows.Forms.Label();
            this.detailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.backButton);
            this.detailsGroupBox.Controls.Add(this.remainingCreditLabel);
            this.detailsGroupBox.Controls.Add(this.remaininhCreditHeading);
            this.detailsGroupBox.Controls.Add(this.cancelButton);
            this.detailsGroupBox.Controls.Add(this.doneButton);
            this.detailsGroupBox.Controls.Add(this.specialNoteLabel);
            this.detailsGroupBox.Controls.Add(this.specialNoteTextBox);
            this.detailsGroupBox.Controls.Add(this.editButton);
            this.detailsGroupBox.Controls.Add(this.deleteButton);
            this.detailsGroupBox.Controls.Add(this.ItemsOnCartLabel);
            this.detailsGroupBox.Controls.Add(this.itemsListView);
            this.detailsGroupBox.Controls.Add(this.qtyNumericUpDown);
            this.detailsGroupBox.Controls.Add(this.checkOutButton);
            this.detailsGroupBox.Controls.Add(this.currentTotalLabel);
            this.detailsGroupBox.Controls.Add(this.addToCartButton);
            this.detailsGroupBox.Controls.Add(this.productLabel);
            this.detailsGroupBox.Controls.Add(this.productsComboBox);
            this.detailsGroupBox.Controls.Add(this.totalLabel);
            this.detailsGroupBox.Controls.Add(this.quantityLabel);
            this.detailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsGroupBox.Location = new System.Drawing.Point(12, 57);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(455, 427);
            this.detailsGroupBox.TabIndex = 13;
            this.detailsGroupBox.TabStop = false;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(255, 366);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(56, 27);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // remainingCreditLabel
            // 
            this.remainingCreditLabel.AutoSize = true;
            this.remainingCreditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingCreditLabel.Location = new System.Drawing.Point(370, 319);
            this.remainingCreditLabel.Name = "remainingCreditLabel";
            this.remainingCreditLabel.Size = new System.Drawing.Size(52, 13);
            this.remainingCreditLabel.TabIndex = 24;
            this.remainingCreditLabel.Text = "R 00.00";
            // 
            // remaininhCreditHeading
            // 
            this.remaininhCreditHeading.AutoSize = true;
            this.remaininhCreditHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remaininhCreditHeading.Location = new System.Drawing.Point(240, 319);
            this.remaininhCreditHeading.Name = "remaininhCreditHeading";
            this.remaininhCreditHeading.Size = new System.Drawing.Size(107, 13);
            this.remaininhCreditHeading.TabIndex = 23;
            this.remaininhCreditHeading.Text = "Remaining Credit:";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(139, 369);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 28);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(255, 368);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(56, 28);
            this.doneButton.TabIndex = 21;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // specialNoteLabel
            // 
            this.specialNoteLabel.AutoSize = true;
            this.specialNoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialNoteLabel.Location = new System.Drawing.Point(24, 267);
            this.specialNoteLabel.Name = "specialNoteLabel";
            this.specialNoteLabel.Size = new System.Drawing.Size(80, 13);
            this.specialNoteLabel.TabIndex = 20;
            this.specialNoteLabel.Text = "Special Note";
            // 
            // specialNoteTextBox
            // 
            this.specialNoteTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.specialNoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialNoteTextBox.Location = new System.Drawing.Point(25, 283);
            this.specialNoteTextBox.Multiline = true;
            this.specialNoteTextBox.Name = "specialNoteTextBox";
            this.specialNoteTextBox.Size = new System.Drawing.Size(171, 113);
            this.specialNoteTextBox.TabIndex = 19;
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editButton.BackgroundImage")));
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(169, 366);
            this.editButton.Margin = new System.Windows.Forms.Padding(2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(45, 34);
            this.editButton.TabIndex = 18;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(266, 363);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 34);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ItemsOnCartLabel
            // 
            this.ItemsOnCartLabel.AutoSize = true;
            this.ItemsOnCartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsOnCartLabel.Location = new System.Drawing.Point(40, 74);
            this.ItemsOnCartLabel.Name = "ItemsOnCartLabel";
            this.ItemsOnCartLabel.Size = new System.Drawing.Size(84, 13);
            this.ItemsOnCartLabel.TabIndex = 14;
            this.ItemsOnCartLabel.Text = "Items On Cart";
            // 
            // itemsListView
            // 
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.Location = new System.Drawing.Point(25, 100);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(410, 152);
            this.itemsListView.TabIndex = 13;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.SelectedIndexChanged += new System.EventHandler(this.itemsListView_SelectedIndexChanged);
            // 
            // qtyNumericUpDown
            // 
            this.qtyNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyNumericUpDown.Location = new System.Drawing.Point(243, 33);
            this.qtyNumericUpDown.Name = "qtyNumericUpDown";
            this.qtyNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.qtyNumericUpDown.TabIndex = 12;
            // 
            // checkOutButton
            // 
            this.checkOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutButton.Location = new System.Drawing.Point(328, 367);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(107, 30);
            this.checkOutButton.TabIndex = 10;
            this.checkOutButton.Text = "Check Out Cart";
            this.checkOutButton.UseVisualStyleBackColor = true;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // currentTotalLabel
            // 
            this.currentTotalLabel.AutoSize = true;
            this.currentTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTotalLabel.Location = new System.Drawing.Point(367, 286);
            this.currentTotalLabel.Name = "currentTotalLabel";
            this.currentTotalLabel.Size = new System.Drawing.Size(52, 13);
            this.currentTotalLabel.TabIndex = 11;
            this.currentTotalLabel.Text = "R 00.00";
            // 
            // addToCartButton
            // 
            this.addToCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.Location = new System.Drawing.Point(336, 33);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(76, 27);
            this.addToCartButton.TabIndex = 8;
            this.addToCartButton.Text = "Add to Cart";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click);
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabel.Location = new System.Drawing.Point(48, 16);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(51, 13);
            this.productLabel.TabIndex = 3;
            this.productLabel.Text = "Product";
            // 
            // productsComboBox
            // 
            this.productsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(51, 32);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(163, 21);
            this.productsComboBox.TabIndex = 1;
            this.productsComboBox.SelectionChangeCommitted += new System.EventHandler(this.productsComboBox_SelectionChangeCommitted);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(240, 283);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(48, 13);
            this.totalLabel.TabIndex = 5;
            this.totalLabel.Text = "Total : ";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(240, 16);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(32, 13);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "QTY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Customer Details:";
            // 
            // customerNumberLabel
            // 
            this.customerNumberLabel.AutoSize = true;
            this.customerNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNumberLabel.Location = new System.Drawing.Point(178, 41);
            this.customerNumberLabel.Name = "customerNumberLabel";
            this.customerNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.customerNumberLabel.TabIndex = 15;
            this.customerNumberLabel.Text = "ABCDEF001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Order ID:";
            // 
            // orderIDLabel
            // 
            this.orderIDLabel.AutoSize = true;
            this.orderIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderIDLabel.Location = new System.Drawing.Point(178, 9);
            this.orderIDLabel.Name = "orderIDLabel";
            this.orderIDLabel.Size = new System.Drawing.Size(83, 13);
            this.orderIDLabel.TabIndex = 17;
            this.orderIDLabel.Text = "XXXXXX0001";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(491, 539);
            this.Controls.Add(this.orderIDLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerNumberLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detailsGroupBox);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.NumericUpDown qtyNumericUpDown;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.Label currentTotalLabel;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label ItemsOnCartLabel;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label customerNumberLabel;
        private System.Windows.Forms.TextBox specialNoteTextBox;
        private System.Windows.Forms.Label specialNoteLabel;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label orderIDLabel;
        private System.Windows.Forms.Label remainingCreditLabel;
        private System.Windows.Forms.Label remaininhCreditHeading;
        private System.Windows.Forms.Button backButton;
    }
}