using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelProject.DatabaseLayer;


namespace PoppelProject.BusinessLayer
{
    public class ProductController
    {

        ProductDB productDB;
        Collection<Product> products;   //***W3

        #region Properties
        public Collection<Product> AllProducts
        {
            get
            {
                return products;
            }
        }
        #endregion
        public ProductController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            productDB = new ProductDB();
            products = productDB.AllProducts;
        }

        #region Database Communication
        public void DataMaintenance(Product aProduct, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            productDB.DataSetChange(aProduct, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    products.Add(aProduct);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aProduct);
                    products[index] = aProduct;  // replace employee at this index with the updated employee
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Product aProduct)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return productDB.UpdateDataSource(aProduct);
        }
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
        public Collection<Product> FindByStatus(Collection<Product> products, Product.productStatus productVal)
        {
            Collection<Product> matches = new Collection<Product>();

            foreach (Product product in products)
            {
                if ( Product.productStatus.expired== productVal)   // if searching for an expied product
                {
                    if (product.ExpiryDate < System.DateTime.Now) { matches.Add(product); }
                    
                }
                else
                {
                    if (product.ExpiryDate > System.DateTime.Now) { matches.Add(product); }
                }
            }
            return matches;
        }

        public Collection<Product> FindByStatus(Product.productStatus productVal)
        {
            Collection<Product> matches = new Collection<Product>();

            foreach (Product product in products)
            {
                if (Product.productStatus.expired == productVal)   // if searching for an expied product
                {
                    if (product.ExpiryDate < System.DateTime.Now) { matches.Add(product); }

                }
                else
                {
                    if (product.ExpiryDate > System.DateTime.Now) { matches.Add(product); }
                }
            }
            return matches;
        }

        //This method receives a employee ID as a parameter; finds the employee object in the collection of employees and then returns this object
        public Product Find(string productID)
        {
            int index = 0;
            bool found = (products[index].ProductID == productID);  //check if it is the first student
            int count = products.Count;
            while (!(found) && (index < products.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (products[index].ProductID == productID);   // this will be TRUE if found
            }
            return products[index];  // this is the one!  
        }

        public int FindIndex(Product aProduct)
        {
            int counter = 0;
            bool found = false;
            found = (aProduct.ProductID == products[counter].ProductID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < products.Count - 1)
            {
                counter += 1;
                found = (aProduct.ProductID == products[counter].ProductID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}