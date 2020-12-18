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
    public partial class LoginForm : Form
    {
        #region Attributes
        private EmployeeController employeeController;
        //private Collection<Employee> employees;
        public bool loginFormClosed = false;   
        #endregion

        #region Constructor
        public LoginForm(EmployeeController anEmployeeController)
        {
            InitializeComponent();
            employeeController = anEmployeeController;
            errorLabel.Visible = false;
        }
        #endregion

        #region Form Events
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginFormClosed = true;
        }
        #endregion

        #region Button clicked events
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            
            Collection<Employee> allEmployees = employeeController.AllEmployees;
            Employee emp = null;
            bool employeeFound = false;

            foreach (Employee eachEmployee in allEmployees)  // searching through all employees to check for the entered user
            {
                if(eachEmployee.EmployeeID.Equals(usernameTextBox.Text.ToUpper()))
                {
                    employeeFound = true;
                    emp = eachEmployee;
                    break;
                }
            }


            if (employeeFound==true)   // user does exist
            {
                if (emp.Password.Equals(passwordTextBox.Text))
                {
                    if (emp.RoleValue == Employee.Role.pickingClerk)   // if the user is a picking clerk
                    {
                        ((PoppelMDIParent)this.MdiParent).pickClerkLogin();
                    }
                    else
                    {
                        ((PoppelMDIParent)this.MdiParent).TellerSellerLogin();  // if user is a packing clerk
                    }

                    this.Close();
                }

                else
                {
                    passwordTextBox.Text = "";
                    errorLabel.Text = "The password that you've entered is incorrect.";
                    errorLabel.Visible = true;
                }
            }

            else //if user doesn't exist
            {
                passwordTextBox.Text = "";
                errorLabel.Text = "The username or password you entered is incorrect.Please try again.";
               errorLabel.Visible = true;
            }

           
        }
        #endregion

        
    }
}
