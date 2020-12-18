using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelProject.BusinessLayer;

namespace PoppelProject.PresentationLayer
{
    public partial class PickingListForm : Form
    {
        #region Attributes
        public bool listFormClosed = false;
        private OrderItemsController orderItemsController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;
        private EmployeeController employeeController;
        private Order order;
        private Employee employee;

        //private OrderItems orderItem;
        private Collection<OrderItems> orderItems;
        private Collection<Product> products;

        //private FormStates state;

        #endregion

        #region Constructor
        public PickingListForm(ProductController aProductController, CustomerController aCustomerController, EmployeeController anEmployeeController)
        {
            InitializeComponent();
            productController = aProductController;
            customerController = aCustomerController;
            employeeController = anEmployeeController;
            orderItemsController = new OrderItemsController();
            orderController = new OrderController();
            FillCombo();
            ItemsListView();
            HideAll(false);
        }      
        #endregion

        #region Form events
        private void PickingListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;
        }

        #endregion

        #region Button Clicked Events
        private void doneButton_Click(object sender, EventArgs e)  // To finilize that an order has been picked
        {
            printpreviewButton.Visible = true;
            if (order != null)
            {   
                //Ask user if they want to confirm order
                if (MessageBox.Show("Are you sure you want to confirm order as picked?", "Confirming Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    printpreviewButton.Visible = true;
                    // Here we change the order status to be picked and clear the picking list
                    order.OrderValue = Order.OrderStatus.picked;
                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Edit);

                    //if (orderController.FinalizeChanges(order) == true)
                    //{
                    //    ordersComboBox.Items.Remove(ordersComboBox.SelectedItem); //remove item from combo box when picked
                    //}

                    orderController.FinalizeChanges(order);
                    //orderItemsListView.Clear();
                    ItemsListView();
                    //orderItemsListView.Refresh();
                    ordersComboBox.SelectedIndex = -1;
                    ordersComboBox.Text = "";
                    order = null;
                    //HideAll(false);

                }
                else
                {
                    this.Activate();
                }
            }

            else
            {
                MessageBox.Show("Cannot finilaze a order without generating a order list");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close form?", "Closing form", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void okButton_Click(object sender, EventArgs e)   // Selecting an item from the combo box
        {
            order = default(Order);
            employee = default(Employee);
            order = (Order)ordersComboBox.SelectedItem;
            backButton.Visible = true;
            doneButton.Visible = true;
            //Cannot create a list id no order is selected
            if (order == null)
            {
                MessageBox.Show("First select an order to generate a picking list");
            }

            else
            {
                orderDateLabel.Text = Convert.ToString(order.OrderDate);
                Customer customer = customerController.Find(order.CustomerID);
                CustomerIDLabel.Text = customer.CustomerID ;
                CustomerNameLabel.Text = customer.Name + " " + customer.Surname;
                CustomerAddressLabel.Text = customer.CustomerAddress;
                orderIdLabel.Text = order.OrderID;
                employeeIDlabel.Text = "EMP001";
                HideAll(true);
                ItemsListView();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PoppelprintPreviewDialog.Document = PoppelprintDocument;
            PoppelprintPreviewDialog.ShowDialog();
            orgprintButton.Visible = true;        
        }

        private void orgprintButton_Click(object sender, EventArgs e)
        {
            PoppelprintDialog.Document = PoppelprintDocument;
            if (PoppelprintDialog.ShowDialog() == DialogResult.OK)
            {
                PoppelprintDocument.Print();
            }
        }// send the document to the uct server for printing
        #endregion

        #region Methods
        public void HideAll(bool value)
        {
            orderDateLabel.Visible = value;
            CustomerIDLabel.Visible = value;
            CustomerNameLabel.Visible = value;
            CustomerAddressLabel.Visible = value;
            orderIdLabel.Visible = value;
            employeeIDlabel.Visible = value;
     
        }
        public void FillCombo()
        {
             Collection<Order> orders = new Collection<Order>();
             orderController = new OrderController();
             orders = orderController.FindByStatus(Order.OrderStatus.unpicked); 
             //Link the objects in the collection of unpicked orders to every item of the combo box
             foreach (Order eachOrder in orders)
             {
                 ordersComboBox.Items.Add(eachOrder);
             }

             // Allow to search on combo box
            ordersComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ordersComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            //Set the current display of the combobox to nothing
            ordersComboBox.SelectedIndex = -1;
            ordersComboBox.Text = "";
        }
        
        public void ItemsListView()
        {
            ListViewItem itemDetails;
           // order = new Order();
            order = (Order)ordersComboBox.SelectedItem;   // reading from the combo box
            orderItemsListView.Clear();

            if (order == null)  // If nothing has been selected yet on the combo box
            {
                //Set Up Columns of List View
                orderItemsListView.View = View.Details;
                orderItemsListView.Columns.Insert(0, "Product ID", 133, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(1, "Product Name", 140, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(2, "Quantity", 133, HorizontalAlignment.Left);
            }

            else
            {
                orderItemsListView.View = View.Details;
                orderItemsListView.Columns.Insert(0, "Product ID", 133, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(1, "Product Name", 140, HorizontalAlignment.Left);
                orderItemsListView.Columns.Insert(2, "Quantity", 133, HorizontalAlignment.Left);

                orderItems = null;  //employees collection will be filled by role
                orderItems = orderItemsController.FindByOrderID(order.OrderID);

                //Add item details to each ListView item 
                foreach (OrderItems item in orderItems)
                {
                    Product product = productController.Find(item.ProductID);  // get the selected product details
                    itemDetails = new ListViewItem();
                    itemDetails.Text = item.ProductID.ToString();
                    itemDetails.SubItems.Add(product.ProductName);
                    itemDetails.SubItems.Add(item.Quantity.ToString());
                    orderItemsListView.Items.Add(itemDetails);
                }
            }

            orderItemsListView.Refresh();
            orderItemsListView.GridLines = true;
        }

        #endregion

       
        #region When the form has loaded
        private void PickingListForm_Load(object sender, EventArgs e)
        {
            printpreviewButton.Visible = false;
            orgprintButton.Visible = false;
            doneButton.Visible = false;
            backButton.Visible = false;
        }
        #endregion

        #region Print Preview (BASICALLY PRINT CUSTOMER AND ORDER DETAILS)
        private void PoppelprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("******************************************" + 
                                  "\n" +
                                 "            CUSTOMER DETAILS"+
                                  "\n" +
                                  "******************************************"+
                                  "\n" + "\n"+
                                  "Order Number :  " + orderIdLabel.Text +
                                  "\n" + "\n" +
                                  "Order Date   :  " + orderDateLabel.Text +
                                  "\n" + "\n" +
                                  "Clerk ID     :  " + employeeIDlabel.Text +
                                  "\n" + "\n" +
                                  "CustomerID   :  " + CustomerIDLabel.Text +
                                  "\n" + "\n" +
                                  "Customer Name:  " + CustomerNameLabel.Text +
                                  "\n" + "\n" +
                                  "Delivary Address :  " + CustomerAddressLabel.Text +
                                  "\n" + "\n" +
                                "******************************************" +
                                  "\n" +
                                 "           PRODUCT DETAILS" +
                                  "\n" +
                                "******************************************"
                                 , new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(25, 150));

            int x = 60;           
            int y = 500;            
            int offset = 40;
            
            foreach (ListViewItem Itm in orderItemsListView.Items)
            {
                e.Graphics.DrawString("       POPPEL PICKING LIST", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 25, 120 );
                e.Graphics.DrawString("ProductID"  +"             Product Name" + "         Quantity", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 25, 500);
                e.Graphics.DrawString(Itm.Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 25, y + offset); 
                e.Graphics.DrawString(Itm.SubItems[1].Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 250, y + offset); 
                e.Graphics.DrawString(Itm.SubItems[2].Text, new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, 500, y + offset); 
                offset = offset + (int)FontHeight + 10;
               
            }
            offset = offset + 20;
        
        }
        #endregion        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void orderItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void employeeIDlabel_Click(object sender, EventArgs e)
        {

        }

        private void orderDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void CustomerIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void CustomerNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void CustomerAddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }
    }
}
