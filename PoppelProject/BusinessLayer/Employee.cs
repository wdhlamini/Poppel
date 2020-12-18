using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject.BusinessLayer
{
    public class Employee : Person
    {
        #region attributes
        private string employeeID;
        private string password;
        private Role roleValue;

        public enum Role
        {   
            noRole =0,
            teleseller = 1,
            pickingClerk =2
            
        }
        #endregion

        #region properties
        public string EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public Role RoleValue
        {
            get
            {
                return roleValue;
            }

            set
            {
                roleValue = value;
            }
        }

        #endregion

        #region constructors
        public Employee()
        {
            employeeID = "";
            password = "";
            roleValue = Role.noRole;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return this.employeeID;  // return employee username
        }
        #endregion
    }
}
