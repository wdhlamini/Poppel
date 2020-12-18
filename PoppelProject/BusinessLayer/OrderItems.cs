using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject.BusinessLayer
{
    public class OrderItems
    {
        #region attributes
        private string orderItemID;
        private string orderID;
        private string productID;
        private string productName;
        private int quantity;
        #endregion

        #region properties
        public string OrderItemID
        {
            get
            {
                return orderItemID;
            }

            set
            {
                orderItemID = value;
            }
        }

        public string OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }

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

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        #endregion

        #region constructors
        public OrderItems()
        {
            orderItemID = "";
            orderID = "";
            productID = "";
            productName = "";
            quantity = 0;
        }

        public OrderItems(string orderItemNumber, string OrderID, string productID, int quantity, string productName)
        {
            this.orderItemID = orderItemNumber;
            this.orderID = OrderID;
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
        }
        #endregion

    }
}
