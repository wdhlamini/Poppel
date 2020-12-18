using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject.BusinessLayer
{
    public class Product
    {
        #region attributes
        private string productID;
        private string productName;
        private DateTime expiryDate;
        private int quantityInStock;
        private double price;

        private productStatus productValue;

        public enum productStatus
        {
            notExpired = 0,
            expired = 1
        }
        #endregion

        #region Properties
        public string ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return expiryDate;
            }

            set
            {
                expiryDate = value;
            }
        }

        public int QuantityInStock
        {
            get
            {
                return quantityInStock;
            }

            set
            {
                quantityInStock = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public productStatus ProductValue
        {
            get
            {
                return productValue;
            }

            set
            {
                productValue = value;
            }
        }

        #endregion

        #region constructors
        public Product()
        {
            productID = "";
            productName = "";
            expiryDate = default(System.DateTime);
            quantityInStock = 0;
            price = 0;
            productValue = 0;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return this.productID +": " + productName ;
        }
        #endregion

    }
}