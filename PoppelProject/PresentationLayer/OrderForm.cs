using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    public partial class OrderForm : Form
    {
        #region Attributes
        // controllers
        private OrderItemsController orderItemsController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;
        private EmployeeController employeeController;

        private Collection<Product> products;
        private PickingListForm pickingListForm;
        private OrderItems changingItem;
        private Customer customer;
        private Product product;
        private Order order;

        private int customerCurrentCredit;
        private bool orderInProgress = false;
        public bool orderFormClosed = false;
        private bool closeDByBack = false;

        #endregion

        #region Constructor
        public OrderForm(CustomerController aCustomerController, Customer aCustomer)
        {
            InitializeComponent();
            customer = aCustomer;
            customerController = aCustomerController;
            orderItemsController = new OrderItemsController();
            productController = new ProductController();
            orderController = new OrderController();
            SetUp();
            FillCombo();
            ShowButtons(false);
            ItemsListView();

        }
        #endregion

        #region Form events
        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)      // If a user exits from creating order then delete order
        {   
            

            if (MessageBox.Show("Are you sure you want cancel the order?", "Canceling Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (closeDByBack == true)
                {
                    CreateOrderForm createOrderForm = new CreateOrderForm(customerController);
                    createOrderForm.Show();
                }

                if (orderInProgress == true) { 
                    Collection<OrderItems> deletingItems = orderItemsController.FindByOrderID(order.OrderID);   // putting all products to be deleted in a collection

                    foreach (OrderItems eachItem in deletingItems)                                 // iterating through items and adding them
                    {
                        Product eachProduct = productController.Find(eachItem.ProductID);        // getting the product object
                        eachProduct.QuantityInStock += eachItem.Quantity;

                        orderItemsController.DataMaintenance(eachItem, DatabaseLayer.DB.DBOperation.Delete);  // deleting each item on the order
                        orderItemsController.FinalizeChanges(changingItem);

                        productController.DataMaintenance(eachProduct, DatabaseLayer.DB.DBOperation.Edit);  // reversing item in stock
                        productController.FinalizeChanges(product);
                    }

                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Delete);  // Now deleting the order
                    orderItemsController.FinalizeChanges(changingItem);
                }
            }

            else
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        #endregion

        #region Button Clicked Events
        private void checkOutButton_Click(object sender, System.EventArgs e)
        {
            if (orderInProgress == false)   // if not items on cart
            {
                MessageBox.Show("Cannot check out an empty order");
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to check out order?", "Checking out Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (customer.CurrentCredit <= 0)   // update customer status after an order
                    {
                        customer.CreditStatus = "0";
                    }

                    {
                        if(CreateNewPickingListForm() == true)
                        {
                            pickingListForm.Show();                            
                            orderFormClosed = true;                          
                        }
                        else
                        {
                            MessageBox.Show("Cannot create an order for a customer with bad credit status");
                        }
                    }

                    customerController.DataMaintenance(customer, DatabaseLayer.DB.DBOperation.Edit);  // To change quantity in stock
                    customerController.FinalizeChanges(customer);  // confirm

                    orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Edit);  // update status and remaining credit
                    orderController.FinalizeChanges(order);  // confirm
                    this.Dispose();
                }

                else
                {
                    this.Activate();
                }
            }
                
        }

        private void itemsListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            changingItem = orderItemsController.Find(itemsListView.SelectedItems[0].Text);   // getting the item seleced
            ButtonsEnabled(false);   // Disabling buttons
            ShowButtons(true);
        }

        private void deleteButton_Click(object sender, System.EventArgs e)
        {
            Product changingProduct = productController.Find(changingItem.ProductID);                   // getting the product for item selected

            changingProduct.QuantityInStock += changingItem.Quantity;  // updating quantity in stock
            customer.CurrentCredit += (int)(changingItem.Quantity* changingProduct.Price);   // updating order total 
            order.TotalCost -= (int)(changingItem.Quantity * changingProduct.Price);


            currentTotalLabel.Text = "R " + (double)order.TotalCost;                // Changing the total label
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;
            qtyNumericUpDown.Value = 0;

            changingItem.OrderID = "Poppel";  // moving this item to a dummy order instead of deleting it from table, just remove from this order
            // update on databases
            orderItemsController.DataMaintenance(changingItem, DatabaseLayer.DB.DBOperation.Edit);  // adding to the database
            orderItemsController.FinalizeChanges(changingItem);

            productController.DataMaintenance(changingProduct, DatabaseLayer.DB.DBOperation.Edit);  // To change quantity in stock
            productController.FinalizeChanges(product);

            //orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Edit);
            //orderController.FinalizeChanges(order);

            ItemsListView();
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
            qtyNumericUpDown.Value = 0;
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void editButton_Click(object sender, System.EventArgs e)
        {   
            ShowButtons(false);
            specialNoteLabel.Visible = false;
            specialNoteTextBox.Visible = false;
            doneButton.Visible = true;
            cancelButton.Visible = true;
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void doneButton_Click(object sender, System.EventArgs e)
        {
             // recording the quantity before editting it 
            Product changingProduct = productController.Find(changingItem.ProductID);                   // getting the product for item selected

            int qtyBeforeEdit = changingItem.Quantity;
            int diffirence = (int)(qtyNumericUpDown.Value - qtyBeforeEdit);

            if ((diffirence * changingProduct.Price) > customer.CurrentCredit)    // if the changes result in total being > than current total
            {
                MessageBox.Show("Cannot make these changes as the total now exceeds the current credit");
            }
            else
            {


                changingItem.Quantity += diffirence;                               // updating quantity
                changingProduct.QuantityInStock += diffirence;


                customer.CurrentCredit -= (int)(diffirence * changingProduct.Price);   // updating order total 
                order.TotalCost += (int)(diffirence * changingProduct.Price);


                currentTotalLabel.Text = "R " + (double)order.TotalCost;                // Changing the total label
                remainingCreditLabel.Text = "R " + customer.CurrentCredit;
                qtyNumericUpDown.Value = 0;

                // update on databases
                orderItemsController.DataMaintenance(changingItem, DatabaseLayer.DB.DBOperation.Edit);  // adding to the database
                orderItemsController.FinalizeChanges(changingItem);

                productController.DataMaintenance(changingProduct, DatabaseLayer.DB.DBOperation.Edit);  // To change quantity in stock
                productController.FinalizeChanges(product);
            }

            ItemsListView();
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
            qtyNumericUpDown.Value = 0;
            ShowButtons(false);
            ButtonsEnabled(true);
        }

        private void addToCartButton_Click(object sender, System.EventArgs e)
        {
            if (productsComboBox.SelectedIndex == -1)  // if nothing is selected on the combo box
            {
                MessageBox.Show("Nothing was selected to add to cart, please select a product from the products box");
            }
            else
            {
                if (qtyNumericUpDown.Value == 0)  // if number of items is less than 1
                {
                    MessageBox.Show("0 products were selected, please select product quantity greater than 0");
                }

                else
                {
                    if (CheckAvailability() == true)  // if item is available
                    {
                        if ((customer.CurrentCredit - ((int)product.Price * qtyNumericUpDown.Value)) < -10) // if customer exceeds credit by R10
                        {
                            MessageBox.Show("Order total now exceeds current credit, remove some items to continue");
                        }

                        else
                        {           
                            CreateOrderItem();
                            ItemsListView();
                            //Reset combo and numeric boxes
                            productsComboBox.SelectedIndex = -1;
                            productsComboBox.Text = "";
                            qtyNumericUpDown.Value = 0;
                        }
                        
                    }

                }
            }

        }
        #endregion

        #region  Set Up Methods
        public void ShowButtons(bool value)
        {
            deleteButton.Visible = value;
            editButton.Visible = value;
            cancelButton.Visible = false;
            doneButton.Visible = false;

            if (value == true)
            {
                specialNoteLabel.Visible = false;
                specialNoteTextBox.Visible = false;
                backButton.Visible = false;
            }

            else
            {
                specialNoteLabel.Visible = true;
                specialNoteTextBox.Visible = true;
                backButton.Visible = true;
            }
        }

        public void ButtonsEnabled(bool value)
        {
            productsComboBox.Enabled = value;
            addToCartButton.Enabled = value;
            checkOutButton.Enabled = value;
            itemsListView.Enabled = value;
        }


        public void SetUp()   // set up customer details when system is ran
        {
            orderIDLabel.Text = generateOrderID();
            customerNumberLabel.Text = customer.CustomerID + "       " + customer.Name.Substring(0, 1) + "." + customer.Surname;
            customerCurrentCredit = customer.CurrentCredit;
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;
            qtyNumericUpDown.Maximum = 5000;
        }

        public void FillCombo()
        {
            products = new Collection<Product>();
            products = productController.AllProducts;//FindByStatus(Product.productStatus.notExpired);
            //Link the objects in the collection of unpicked orders to every item of the combo box
            foreach (Product eachProduct in products)
            {
                if (eachProduct.QuantityInStock != 0)  // Do not add items out of stock on the list
                {
                    productsComboBox.Items.Add(eachProduct);
                }

            }

            // Allow to be searched in a drop box
            productsComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productsComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            //Set the current display of the combobox to nothing
            productsComboBox.SelectedIndex = -1;
            productsComboBox.Text = "";
        }


        public void ItemsListView()
        {
            ListViewItem itemDetails;
            Product productSetUp = (Product)(productsComboBox.SelectedItem);
            itemsListView.Clear();

            if (orderInProgress == false)   // If no item has been selected yet, just make the set up
            {
                //Set Up Columns of List View
                itemsListView.View = View.Details;
                
                itemsListView.Columns.Insert(0, "Order Item ID", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(1, "Product ID", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(2, "Product Name", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(3, "Quantity", 100, HorizontalAlignment.Left);
               
            }

            else
            {

                itemsListView.View = View.Details;
                itemsListView.Columns.Insert(0, "Order Item ID", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(1, "Product ID", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(2, "Product Name", 100, HorizontalAlignment.Left);
                itemsListView.Columns.Insert(3, "Quantity", 100, HorizontalAlignment.Left);
                
                Collection<OrderItems> allItems = orderItemsController.FindByOrderID(order.OrderID);   // putting all products in a collection

                foreach (OrderItems eachItem in allItems)      // iterating through items and adding them
                {
                    Product eachProduct = productController.Find(eachItem.ProductID);        // getting the product object
                    itemDetails = new ListViewItem();
                    itemDetails.Text = eachItem.OrderItemID;
                    itemDetails.SubItems.Add(eachItem.ProductID);
                    itemDetails.SubItems.Add(eachProduct.ProductName);
                    itemDetails.SubItems.Add(eachItem.Quantity.ToString());
                    itemsListView.Items.Add(itemDetails);
                }
            }
            itemsListView.Refresh();
            itemsListView.GridLines = true;

        }

        #endregion

        #region Order Creation Methods
        public bool CheckAvailability() // check if the item is available
        {
            product = (Product)productsComboBox.SelectedItem;

            if (product.QuantityInStock == 0)
            {
                MessageBox.Show("Sorry, the product " + product.ProductName + "is out of stock");
                return false;
            }

            else if (qtyNumericUpDown.Value > product.QuantityInStock)
            {
                MessageBox.Show("We only have " + product.QuantityInStock + " " + product.ProductName + " in stock, please select items less/Equal" + product.QuantityInStock);
                return false;
            }

            else
            {
                return true;
            }
        }

        public string generateOrderID()   // To generate a unique order ID
        {
            int noOfOrders = orderController.AllOrders.Count + 1000;
            return "ORDER " + noOfOrders;
        }

        public string generateOrderItemID()  // To generate a unique order item ID
        {
            int noOfOItems = orderItemsController.AllOrderItems.Count + 1000;
            return "ITEM " + noOfOItems;
        }

        public void CreateOrderItem()
        {
            OrderItems item = new OrderItems();

            if (orderInProgress == false)   // If an order hasn't been created yet
            {
                order = new Order();
                order.OrderID = generateOrderID();
                order.CustomerID = customer.CustomerID;
                order.OrderDate = System.DateTime.Now;
                order.OrderValue = 0;

                orderController.DataMaintenance(order, DatabaseLayer.DB.DBOperation.Add);  // To change quantity in stock
                orderController.FinalizeChanges(order);

                orderInProgress = true;

            }

            // Creating an order item object and adding to cart
            item.OrderItemID = generateOrderItemID();
            item.OrderID = order.OrderID;
            item.ProductID = product.ProductID;
            item.Quantity = (int)qtyNumericUpDown.Value;

            product.QuantityInStock = (int)product.QuantityInStock - item.Quantity; // Updating quantity in stock
            order.TotalCost += (int)(product.Price * item.Quantity);                // incrementing total
            customer.CurrentCredit -= (int)(product.Price * item.Quantity);         // decreasing customer credit

            currentTotalLabel.Text = "R " + (double)order.TotalCost;                // Changing the total label
            remainingCreditLabel.Text = "R " + customer.CurrentCredit;

            orderItemsController.DataMaintenance(item, DatabaseLayer.DB.DBOperation.Add);  // adding to the database
            orderItemsController.FinalizeChanges(item);

            productController.DataMaintenance(product, DatabaseLayer.DB.DBOperation.Edit);  // To change quantity in stock
            productController.FinalizeChanges(product);
        }



        #endregion

        private void backButton_Click(object sender, System.EventArgs e)
        {
            closeDByBack = true;
            this.Close();
        }

        private bool CreateNewPickingListForm()
        {
            int currentstatus = customer.CurrentCredit;
            if(customer.CurrentCredit.Equals("0"))
            {
                return false;
            }
            else
            {
                pickingListForm = new PickingListForm(productController, customerController,employeeController)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
            }
            return true;
        }

        //ADDED BY TONNY
        private void OrderForm_Load(object sender, System.EventArgs e)
        {
            qtyNumericUpDown.Enabled = false;
            itemsListView.Enabled = false;
            specialNoteLabel.Enabled = false;
            addToCartButton.Enabled = false;
            checkOutButton.Enabled = false;
        }

        private void productsComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            qtyNumericUpDown.Enabled = true;
            itemsListView.Enabled = true;
            specialNoteLabel.Enabled = true;
            addToCartButton.Enabled = true;
            checkOutButton.Enabled = true;
        }
    }
}
