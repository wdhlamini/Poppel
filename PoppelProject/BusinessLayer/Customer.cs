using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject.BusinessLayer
{
    public class Customer : Person
    {
        #region attributes
        private string customerID;
        private long IDNumber;
        private int currentCredit;
        private string creditStatus;
        private string customerAddress;
        #endregion

        #region properties
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

        public string CreditStatus
        {
            get
            {
                return creditStatus;
            }

            set
            {
                creditStatus = value;
            }
        }

        public string CustomerAddress
        {
            get
            {
                return customerAddress;
            }

            set
            {
                customerAddress = value;
            }
        }



        public int CurrentCredit
        {
            get
            {
                return currentCredit;
            }

            set
            {
                currentCredit = value;
            }
        }

        public long IDNumber1
        {
            get
            {
                return IDNumber;
            }

            set
            {
                IDNumber = value;
            }
        }
        #endregion

        #region constructors
        public Customer()
        {
            customerID = "";
            IDNumber1 = 0;
            currentCredit = 0;
            creditStatus = "";
            customerAddress = "";
        }

        public Customer(string customerID, int IDNumber, int currentCredit, string creditStatus, string customerAddress)
        {
            this.customerID = customerID;
            this.IDNumber1 = IDNumber;
            this.currentCredit = currentCredit;
            this.creditStatus = creditStatus;
            this.customerAddress = customerAddress;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return this.customerID + ": "  + this.Name + " " + this.Surname;
        }
        #endregion
    }
}
