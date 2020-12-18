using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelProject.DatabaseLayer;


namespace PoppelProject.BusinessLayer
{
    public class OrderController
    {

        OrderDB orderDB;
        Collection<Order> orders;   //***W3

        #region Properties
        public Collection<Order> AllOrders
        {
            get
            {
                return orders;
            }
        }
        #endregion
        public OrderController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            orderDB = new OrderDB();
            orders = orderDB.AllOrders;
        }

        #region Database Communication
        public void DataMaintenance(Order anOrder , DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            orderDB.DataSetChange(anOrder, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    orders.Add(anOrder);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(anOrder);
                    orders[index] = anOrder;  // replace employee at this index with the updated employee
                    break;
            }     
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Order anOrder)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return orderDB.UpdateDataSource(anOrder);
        }
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
        public Collection<Order> FindByStatus(Collection<Order> orders, Order.OrderStatus orderVal)
        {
            Collection<Order> matches = new Collection<Order>();

            foreach (Order order in orders)
            {
                if (order.OrderValue == orderVal)
                {
                    matches.Add(order);
                }
            }
            return matches;
        }

        public Collection<Order> FindByStatus(Order.OrderStatus orderVal)
        {
            Collection<Order> matches = new Collection<Order>();

            foreach (Order order in orders)
            {
                if (order.OrderValue == orderVal)
                {
                    matches.Add(order);
                }
            }
            return matches;
        }

        //This method receives a employee ID as a parameter; finds the employee object in the collection of employees and then returns this object
        public Order Find(string orderID)
        {
            int index = 0;
            bool found = (orders[index].OrderID == orderID);  //check if it is the first student
            int count = orders.Count;
            while (!(found) && (index < orders.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (orders[index].OrderID == orderID);   // this will be TRUE if found
            }
            return orders[index];  // this is the one!  
        }

        public int FindIndex(Order anOrder)
        {
            int counter = 0;
            bool found = false;
            found = (anOrder.OrderID == orders[counter].OrderID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < orders.Count - 1)
            {
                counter += 1;
                found = (anOrder.OrderID == orders[counter].OrderID);
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