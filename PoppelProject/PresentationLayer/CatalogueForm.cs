using System;
using System.Collections.ObjectModel;
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
    public partial class CatalogueForm : Form
    {
        public bool catalogueClosed = false;
        private ProductController productController;
        public CatalogueForm(ProductController aProductController)
        {
            productController = aProductController;
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            ListViewItem itemDetails;
            itemsListView.Clear();

            itemsListView.View = View.Details;
            itemsListView.Columns.Insert(0, "Product ID", 125, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(1, "Product Name", 125, HorizontalAlignment.Left);
            itemsListView.Columns.Insert(2, "Price", 125, HorizontalAlignment.Left);
            Collection<Product> allProducts = productController.AllProducts; //.FindByStatus(Product.productStatus.notExpired);  // putting all products in a collection

            foreach (Product eachProduct in allProducts)      // iterating through items and adding them
            {
                itemDetails = new ListViewItem();
                itemDetails.Text = eachProduct.ProductID;
                itemDetails.SubItems.Add(eachProduct.ProductName);
                itemDetails.SubItems.Add("R " + eachProduct.Price.ToString());
                itemsListView.Items.Add(itemDetails);
            }

            itemsListView.Refresh();
            itemsListView.GridLines = true;
        }
        

        private void closeButton_Click(object sender, EventArgs e)
        {
            catalogueClosed = true;
            this.Close();

        }

    }
}
