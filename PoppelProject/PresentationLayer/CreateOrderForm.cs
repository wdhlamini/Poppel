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
    public partial class CreateOrderForm : Form
    {
        #region Attributes
        public bool createOrderFormClosed = false;
        private CustomerController customerController;
        private Customer aCustomer;
        private Collection<Customer> customers;
        private OrderForm orderForm;
        #endregion

        #region Constructor
        public CreateOrderForm(CustomerController aCustomerController)
        {
            InitializeComponent();
            customerController = aCustomerController;
            FillCombo();
        }
        #endregion

        #region Form events
        private void CreateOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            createOrderFormClosed = true;
        }
        #endregion

        #region Buton Clicked Events
        private void submitButton_Click(object sender, System.EventArgs e)
        {
            aCustomer = null;
            aCustomer = (Customer)customersComboBox.SelectedItem;
            if (aCustomer == null)
            {
                MessageBox.Show("First select a customer to create order for before continuing");
            }
            else
            {
                
                if (CreateNewOrderForm() == true)  // IF credit status is good
                {
                    orderForm.Show();
                    this.Close();
                    createOrderFormClosed = true;
                }

                else // else
                {
                    MessageBox.Show("Cannot create an order for customer with bad credit status");
                }
                
            }
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            customersComboBox.SelectedIndex = -1;
            customersComboBox.Text = "";
        }

        #endregion

        #region Methods
        public void FillCombo()
        {
            customers = new Collection<Customer>();
            customers = customerController.AllCustomers;
            //Link the objects in the collection of unpicked orders to every item of the combo box
            foreach (Customer eachOrder in customers)
            {
                customersComboBox.Items.Add(eachOrder);
            }

            // Allow to be searched in a drop box
            customersComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customersComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            //Set the current display of the combobox to nothing
            customersComboBox.SelectedIndex = -1;
            customersComboBox.Text = "";
        }

        private bool CreateNewOrderForm()
        {
            string creditStatus = aCustomer.CreditStatus;
            if (aCustomer.CreditStatus.Equals("0"))
            {   
                return false;
            }

            else
            {
                orderForm = new OrderForm(customerController,aCustomer);
                orderForm.StartPosition = FormStartPosition.CenterParent;
                return true;
            }    
        }

        #endregion
    }
}
