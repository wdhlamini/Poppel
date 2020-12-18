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
    public partial class ExpiredProductsForm : Form
    {
        #region Attributes
        public bool productsFormClosed = false;
        private ProductController productController;
        private Collection<Product> expiredProducts;
        #endregion

        #region Constructor
        public ExpiredProductsForm(ProductController productController)
        {
            InitializeComponent();
            this.productController = productController;
            ItemsListView();
        }
        #endregion

        #region Events
        private void closeButton_Click(object sender, System.EventArgs e)
        {
            productsFormClosed = true;
            this.Close();
        }
        private void ExpiredProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            productsFormClosed = true;
        }

        #endregion

        #region Methods
        public void ItemsListView()
        {
            ListViewItem itemDetails;
            itemsListView.Clear();
            expiredProducts = null;  //employees collection will be filled by role
            expiredProducts = productController.FindByStatus(Product.productStatus.expired);

            //Set Up Columns of List View
            itemsListView.View = View.Details;
            itemsListView.Columns.Insert(0, "Product ID", 85, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(1, "Product Name", 108, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(2, "Expiry Date", 100, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(3, "Quantity", 85, HorizontalAlignment.Left);

            //Add item details to each ListView item 
            foreach (Product product in expiredProducts)
            {
                itemDetails = new ListViewItem();
                itemDetails.Text = product.ProductID.ToString();
                itemDetails.SubItems.Add(product.ProductName);
                itemDetails.SubItems.Add(product.ExpiryDate.ToString().Substring(0,10));
                itemDetails.SubItems.Add(product.QuantityInStock.ToString());
                itemsListView.Items.Add(itemDetails);
            }

            itemsListView.Refresh();
            itemsListView.GridLines = true;
        }

        #endregion

    }
}
