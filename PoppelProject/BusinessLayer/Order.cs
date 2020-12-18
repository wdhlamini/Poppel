using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject.BusinessLayer
{
    public class Order
    {
        #region attributes
        private string orderID;
        private string customerID;
        private System.DateTime orderDate;
        private int totalCost;
        private string specialNote;

        protected OrderStatus orderVal;

        public enum OrderStatus
        {   
            unpicked =0,
            picked =1
        }
        #endregion


        #region properties
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

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }



        public string SpecialNote
        {
            get
            {
                return specialNote;
            }

            set
            {
                specialNote = value;
            }
        }



        public int TotalCost
        {
            get
            {
                return totalCost;
            }

            set
            {
                totalCost = value;
            }
        }

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public OrderStatus OrderValue
        {
            get
            {
                return orderVal;
            }
            set
            {
                orderVal = value;
            }
        }

        #endregion

        #region constructors
        public Order()
        {
            orderID = "";
            customerID = "";
            orderDate = default(System.DateTime);
            totalCost = 0;
            specialNote = "";
            orderVal = 0;
        }

        public Order(string orderID, string customerID, DateTime orderDate, int totalCost, string specialNote)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.orderDate = orderDate;
            this.totalCost = totalCost;
            this.specialNote = specialNote;
            orderVal = 0;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return this.orderID;
        }
        #endregion
    }
}