using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelProject.BusinessLayer;

namespace PoppelProject
{
    public partial class RegistrationForm : Form
    {
        #region Attributes
        //private string error;
        public bool registrationFormClosed = false;
        public bool registrationFormFormClosed = false;
        private Customer customer;
        private CustomerController customerController;
        #endregion

        #region Constructor
        public RegistrationForm(CustomerController aCustomerConstroller)
        {
            InitializeComponent();
            customerController = aCustomerConstroller; 
        }
        #endregion

        #region Form events
        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            registrationFormFormClosed = true;
        }
        #endregion

        #region Buttion Clicked Events
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (PopulateObject() == true)
            {
                MessageBox.Show("Customer was successfully registered!");
                customerController.DataMaintenance(customer, DatabaseLayer.DB.DBOperation.Add);
                customerController.FinalizeChanges(customer);
                ClearAll();
            }
            else
            {
                MessageBox.Show("Customer was NOT successfully registered");
                
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        #endregion

        #region methods
        private void ClearAll()
        {
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            phoneTextBox.Text = "";
            IDNumberTextBox.Text = "";
            dileveryAddressTextBox.Text = "";
        }

        public string CustomerIDGenetor(string name, string surname, string idNumber)   // this method generates a customer ID
        {
            string customerID = name.ToUpper().Substring(0,1);

            if(surname.Length < 3)
            {
                customerID += surname.ToUpper();
                while (customerID.Length < 3)
                {
                    customerID += "X";
                }

                customerID += name.Substring(0, 3).ToUpper();  
            }

            else 
            {
                customerID += surname.Substring(0, 3).ToUpper();

            }

            customerID += idNumber.Substring(0,6);
            return customerID;
        }

        private Boolean PopulateObject()
        {
            //declare phoneNum variable
            int phoneNum; 

            //determine if phoneNum is int or string
            bool validPhoneNum = int.TryParse(phoneTextBox.Text, out phoneNum);

            long num;
            if (surnameTextBox.Text.Equals("") || nameTextBox.Text.Equals("") || phoneTextBox.Text.Equals("") || IDNumberTextBox.Text.Equals("") || dileveryAddressTextBox.Text.Equals(""))
            {
                MessageBox.Show("One or more of the fields are missing");
                return false;
            }

            else
            {
                if (!long.TryParse(IDNumberTextBox.Text, out num) && !long.TryParse(phoneTextBox.Text, out num))
                {
                    MessageBox.Show("Phone number and ID number must be numeric");
                    return false;
                }

                else if (!long.TryParse(IDNumberTextBox.Text, out num))
                {
                    MessageBox.Show("ID number must be numeric");
                    return false;
                }

                else if (string.IsNullOrEmpty(phoneTextBox.Text) || phoneTextBox.Text.Equals("Enter your Phone number") || validPhoneNum == false || !(phoneTextBox.Text.Length == 10) || !(phoneTextBox.Text.StartsWith("0"))) //start phone number check
                {
                    MessageBox.Show("Phone number MUST be numeric with 0 at the beginning");
                    return false;
                }

                else
                {
                    customer = new Customer();
                    customer.CustomerID = CustomerIDGenetor(nameTextBox.Text, surnameTextBox.Text, IDNumberTextBox.Text) ;                                     ///autoGerate
                    customer.Name = nameTextBox.Text;
                    customer.Surname = surnameTextBox.Text;
                    customer.Phone = phoneTextBox.Text;
                    customer.IDNumber1 = long.Parse(IDNumberTextBox.Text);
                    customer.CurrentCredit = int.Parse("2000");
                    customer.CreditStatus = "1";
                    customer.CustomerAddress = dileveryAddressTextBox.Text;

                    return true;


                }
            }    
        }

        #endregion


    }
}
