using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelProject.DatabaseLayer;

namespace PoppelProject.BusinessLayer
{
    public class OrderItemsController
    {

        OrderItemsDB orderItemsDB;
        ProductDB productDB;
        Collection<OrderItems> orderItems;   //***W3

        #region Properties
        public Collection<OrderItems> AllOrderItems
        {
            get
            {
                return orderItems;
            }
        }
        #endregion
        public OrderItemsController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            orderItemsDB = new OrderItemsDB();
            orderItems = orderItemsDB.AllOrderItems;
        }

        #region Database Communication
        public void DataMaintenance(OrderItems items, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            orderItemsDB.DataSetChange(items, operation);

            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the employee to the Collection
                    orderItems.Add(items);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(items);
                    orderItems[index] = items;  // replace employee at this index with the updated employee
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(items);  // find the index of the specific employee in collection
                    orderItems.RemoveAt(index);  // remove that employee form the collection
                    break;
            }

        }

        //***Commit the changes to the database
        public bool FinalizeChanges(OrderItems item)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return orderItemsDB.UpdateDataSource(item);
        }
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
        public Collection<OrderItems> FindByOrderID(Collection<OrderItems> orderItems, string orderID)
        {
            Collection<OrderItems> matches = new Collection<OrderItems>();

            foreach (OrderItems item in orderItems)
            {
                if (item.OrderID == orderID)
                {
                    matches.Add(item);
                }
            }
            return matches;
        }

        public Collection<OrderItems> FindByOrderID(string orderID)
        {
            Collection<OrderItems> matches = new Collection<OrderItems>();

            foreach (OrderItems item in orderItems)
            {
                if (item.OrderID == orderID)
                {
                    matches.Add(item);
                }
            }
            return matches;
        }
        //This method receives a employee ID as a parameter; finds the employee object in the collection of employees and then returns this object
        public OrderItems Find(string orderItemID)
        {
            int index = 0;
            bool found = (orderItems[index].OrderItemID == orderItemID);  //check if it is the first student
            int count = orderItems.Count;
            while (!(found) && (index < orderItems.Count - 1))  //if not "this" student and you are not at the end of the list 
            {
                index = index + 1;
                found = (orderItems[index].OrderItemID == orderItemID);   // this will be TRUE if found
            }
            return orderItems[index];  // this is the one!  
        }

        public int FindIndex(OrderItems item)
        {
            int counter = 0;
            bool found = false;
            found = (item.OrderItemID == orderItems[counter].OrderItemID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < orderItems.Count - 1)
            {
                counter += 1;
                found = (item.OrderItemID == orderItems[counter].OrderItemID);
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
