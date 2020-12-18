namespace PoppelProject.PresentationLayer
{
    partial class PickingListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickingListForm));
            this.orderItemsListView = new System.Windows.Forms.ListView();
            this.doneButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.ordersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomerAddressLabel = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.orderDateLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.orderIdLabel = new System.Windows.Forms.Label();
            this.printpreviewButton = new System.Windows.Forms.Button();
            this.specialnotetextBox = new System.Windows.Forms.TextBox();
            this.PoppelprintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.PoppelprintDocument = new System.Drawing.Printing.PrintDocument();
            this.PoppelprintDialog = new System.Windows.Forms.PrintDialog();
            this.orgprintButton = new System.Windows.Forms.Button();
            this.employeeIDlabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderItemsListView
            // 
            this.orderItemsListView.Location = new System.Drawing.Point(7, 20);
            this.orderItemsListView.Name = "orderItemsListView";
            this.orderItemsListView.Size = new System.Drawing.Size(504, 134);
            this.orderItemsListView.TabIndex = 0;
            this.orderItemsListView.UseCompatibleStateImageBehavior = false;
            this.orderItemsListView.SelectedIndexChanged += new System.EventHandler(this.orderItemsListView_SelectedIndexChanged);
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(371, 447);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(100, 42);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(257, 447);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 42);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ordersComboBox
            // 
            this.ordersComboBox.FormattingEnabled = true;
            this.ordersComboBox.Location = new System.Drawing.Point(246, 26);
            this.ordersComboBox.Name = "ordersComboBox";
            this.ordersComboBox.Size = new System.Drawing.Size(167, 21);
            this.ordersComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please Select Order";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orderItemsListView);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 171);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listing of order items";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "label9";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(455, 26);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(71, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Order Date:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Customer Name:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Customer ID:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Delivery Address:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // CustomerAddressLabel
            // 
            this.CustomerAddressLabel.AutoSize = true;
            this.CustomerAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerAddressLabel.Location = new System.Drawing.Point(243, 195);
            this.CustomerAddressLabel.Name = "CustomerAddressLabel";
            this.CustomerAddressLabel.Size = new System.Drawing.Size(41, 13);
            this.CustomerAddressLabel.TabIndex = 11;
            this.CustomerAddressLabel.Text = "label6";
            this.CustomerAddressLabel.Click += new System.EventHandler(this.CustomerAddressLabel_Click);
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameLabel.Location = new System.Drawing.Point(243, 176);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(41, 13);
            this.CustomerNameLabel.TabIndex = 12;
            this.CustomerNameLabel.Text = "label7";
            this.CustomerNameLabel.Click += new System.EventHandler(this.CustomerNameLabel_Click);
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerIDLabel.Location = new System.Drawing.Point(244, 154);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(41, 13);
            this.CustomerIDLabel.TabIndex = 13;
            this.CustomerIDLabel.Text = "label8";
            this.CustomerIDLabel.Click += new System.EventHandler(this.CustomerIDLabel_Click);
            // 
            // orderDateLabel
            // 
            this.orderDateLabel.AutoSize = true;
            this.orderDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderDateLabel.Location = new System.Drawing.Point(244, 110);
            this.orderDateLabel.Name = "orderDateLabel";
            this.orderDateLabel.Size = new System.Drawing.Size(48, 13);
            this.orderDateLabel.TabIndex = 15;
            this.orderDateLabel.Text = "label10";
            this.orderDateLabel.Click += new System.EventHandler(this.orderDateLabel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Order ID";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // orderIdLabel
            // 
            this.orderIdLabel.AutoSize = true;
            this.orderIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderIdLabel.Location = new System.Drawing.Point(244, 131);
            this.orderIdLabel.Name = "orderIdLabel";
            this.orderIdLabel.Size = new System.Drawing.Size(41, 13);
            this.orderIdLabel.TabIndex = 17;
            this.orderIdLabel.Text = "label7";
            this.orderIdLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // printpreviewButton
            // 
            this.printpreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printpreviewButton.Location = new System.Drawing.Point(490, 447);
            this.printpreviewButton.Name = "printpreviewButton";
            this.printpreviewButton.Size = new System.Drawing.Size(87, 42);
            this.printpreviewButton.TabIndex = 18;
            this.printpreviewButton.Text = "Print Preview";
            this.printpreviewButton.UseVisualStyleBackColor = true;
            this.printpreviewButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // specialnotetextBox
            // 
            this.specialnotetextBox.Location = new System.Drawing.Point(14, 447);
            this.specialnotetextBox.Multiline = true;
            this.specialnotetextBox.Name = "specialnotetextBox";
            this.specialnotetextBox.Size = new System.Drawing.Size(224, 117);
            this.specialnotetextBox.TabIndex = 19;
            // 
            // PoppelprintPreviewDialog
            // 
            this.PoppelprintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PoppelprintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PoppelprintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.PoppelprintPreviewDialog.Enabled = true;
            this.PoppelprintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("PoppelprintPreviewDialog.Icon")));
            this.PoppelprintPreviewDialog.Name = "PoppelprintPreviewDialog";
            this.PoppelprintPreviewDialog.Visible = false;
            // 
            // PoppelprintDocument
            // 
            this.PoppelprintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PoppelprintDocument_PrintPage);
            // 
            // PoppelprintDialog
            // 
            this.PoppelprintDialog.UseEXDialog = true;
            // 
            // orgprintButton
            // 
            this.orgprintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orgprintButton.Location = new System.Drawing.Point(257, 528);
            this.orgprintButton.Name = "orgprintButton";
            this.orgprintButton.Size = new System.Drawing.Size(101, 36);
            this.orgprintButton.TabIndex = 20;
            this.orgprintButton.Text = "Print";
            this.orgprintButton.UseVisualStyleBackColor = true;
            this.orgprintButton.Click += new System.EventHandler(this.orgprintButton_Click);
            // 
            // employeeIDlabel
            // 
            this.employeeIDlabel.AutoSize = true;
            this.employeeIDlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeIDlabel.Location = new System.Drawing.Point(243, 86);
            this.employeeIDlabel.Name = "employeeIDlabel";
            this.employeeIDlabel.Size = new System.Drawing.Size(45, 13);
            this.employeeIDlabel.TabIndex = 21;
            this.employeeIDlabel.Text = "label 9";
            this.employeeIDlabel.Click += new System.EventHandler(this.employeeIDlabel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Cerk ID";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // PickingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(591, 576);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.employeeIDlabel);
            this.Controls.Add(this.orgprintButton);
            this.Controls.Add(this.specialnotetextBox);
            this.Controls.Add(this.printpreviewButton);
            this.Controls.Add(this.orderIdLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.orderDateLabel);
            this.Controls.Add(this.CustomerIDLabel);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.CustomerAddressLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ordersComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.doneButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PickingListForm";
            this.Text = "Picking List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PickingListForm_FormClosed);
            this.Load += new System.EventHandler(this.PickingListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView orderItemsListView;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox ordersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CustomerAddressLabel;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.Label orderDateLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label orderIdLabel;
        private System.Windows.Forms.Button printpreviewButton;
        private System.Windows.Forms.TextBox specialnotetextBox;
        private System.Windows.Forms.PrintPreviewDialog PoppelprintPreviewDialog;
        private System.Drawing.Printing.PrintDocument PoppelprintDocument;
        private System.Windows.Forms.PrintDialog PoppelprintDialog;
        private System.Windows.Forms.Button orgprintButton;
        private System.Windows.Forms.Label employeeIDlabel;
        private System.Windows.Forms.Label label7;
    }
}