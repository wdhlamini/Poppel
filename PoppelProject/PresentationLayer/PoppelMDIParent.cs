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

namespace PoppelProject.PresentationLayer
{
    public partial class PoppelMDIParent : Form
    {
        private int childFormNumber = 0;

        #region 
        //1a. ***Declare a reference to an EmployeeForm object
        private ExpiredProductsForm expiredProductsForm;
        private RegistrationForm registrationForm;
        private PickingListForm  pickingListForm;
        private CreateOrderForm createOrderForm;
        private CatalogueForm catalogueForm;
        private LoginForm loginForm;
        private ReportingForm reportingForm;
        private OrderItemsController orderItemsController;
        private EmployeeController employeeController;
        private CustomerController customerController;
        private ProductController productController;
        private OrderController orderController;


        public PoppelMDIParent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            orderItemsController = new OrderItemsController();
            employeeController = new EmployeeController();
            customerController = new CustomerController();
            productController = new ProductController();
            orderController = new OrderController();

            HideAll();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        #region Toolstrip
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginForm == null)
            {
                CreateLoginForm();
            }

            if (loginForm.loginFormClosed)
            {
                CreateLoginForm();
            }
            
            loginForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();

        }

        private void viewCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catalogueForm == null)
            {
                CreateNewCatalogueForm();
            }

            if (catalogueForm.catalogueClosed)
            {
                CreateNewCatalogueForm();
            }
          
            catalogueForm.Show();
        }

        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registrationForm == null)
            {
                CreateNewRegistrationForm();
            }

            if (registrationForm.registrationFormFormClosed)
             {
                CreateNewRegistrationForm();
             }

             registrationForm.Show();
        }

        private void pickingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pickingListForm == null)
            {
                CreateNewPickingListForm();
            }

            if (pickingListForm.listFormClosed)
            {
                CreateNewPickingListForm();
            }

            pickingListForm.Show();
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createOrderForm == null)
            {
                CreateNewOrderForm();
            }

            if (createOrderForm.createOrderFormClosed)
            {
                CreateNewOrderForm();
            }

            createOrderForm.Show();
        }

        private void expiredProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (expiredProductsForm == null)
            {
                CreateNewExpiredProductsForm();
            }

            if (expiredProductsForm.productsFormClosed)
            {
                CreateNewExpiredProductsForm();
            }

            expiredProductsForm.Show();
        }
        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reportingForm == null)
            {
                CreateNewReportingForm();
            }

            if (reportingForm.reportingFormClosed)
            {
                CreateNewReportingForm();
            }

            reportingForm.Show();
        }

        #endregion

        #region Method 
        private void CreateLoginForm()
        {
            loginForm = new LoginForm(employeeController);
            loginForm.MdiParent = this;        // Setting the MDI Parent
            loginForm.StartPosition = FormStartPosition.CenterParent;
        }

        public void CreateNewCatalogueForm()
        {
            catalogueForm = new CatalogueForm(productController);
            catalogueForm.MdiParent = this;        // Setting the MDI Parent
            catalogueForm.StartPosition = FormStartPosition.CenterParent;
        }
        private void CreateNewPickingListForm()
        {
            pickingListForm = new PickingListForm(productController,customerController,employeeController);
            pickingListForm.MdiParent = this;        // Setting the MDI Parent
            pickingListForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewRegistrationForm()
        {
            registrationForm = new RegistrationForm(customerController);
            registrationForm.MdiParent = this;        // Setting the MDI Parent
            registrationForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewExpiredProductsForm()
        {
            expiredProductsForm = new ExpiredProductsForm(productController);
            expiredProductsForm.MdiParent = this;        // Setting the MDI Parent
            expiredProductsForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewOrderForm()
        {
            createOrderForm = new CreateOrderForm(customerController);
            createOrderForm.MdiParent = this;        // Setting the MDI Parent
            createOrderForm.StartPosition = FormStartPosition.CenterParent;
        }
        private void CreateNewReportingForm()
        {
            reportingForm = new ReportingForm();
            reportingForm.MdiParent = this;        // Setting the MDI Parent
            reportingForm.StartPosition = FormStartPosition.CenterParent;
        }
        public void pickClerkLogin()
        {
            loginToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = true;
            printToolStripMenuItem1.Visible = true;
            createOrderToolStripMenuItem.Visible = false;
            registerCustomerToolStripMenuItem.Visible = false;
            salesReportToolStripMenuItem.Visible = false;
        }

        public void TellerSellerLogin()
        {
            loginToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = true;
            printToolStripMenuItem1.Visible = false;
            createOrderToolStripMenuItem.Visible = true;
            registerCustomerToolStripMenuItem.Visible = true;
            salesReportToolStripMenuItem.Visible = true;
        }

        public void HideAll()
        {
            registerCustomerToolStripMenuItem.Visible = false;
            createOrderToolStripMenuItem.Visible = false;
            printToolStripMenuItem1.Visible = false;
            logoutToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            salesReportToolStripMenuItem.Visible = false;
        }


        #endregion

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}