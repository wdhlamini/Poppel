using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;  //***W3 
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
//namespaces
using PoppelProject.BusinessLayer;

namespace PoppelProject.DatabaseLayer
{
    public class OrderDB : DB
    {
        //Data members        
        private string table1 = "Orders";
        private string sqlLocal1 = "SELECT * FROM Orders";

        private Collection<Order> orders;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public OrderDB() : base()
        {
            orders = new Collection<Order>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }
        public Collection<Order> AllOrders
        {
            get
            {
                return orders;
            }
        }
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Order anOrder, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anOrder, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrder, dataTable)];
                    FillRow(aRow, anOrder, operation);
                    break;

                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anOrder, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Utility Methods
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Order anOrder;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Employee object
                    anOrder = new Order();

                    anOrder.OrderID = Convert.ToString(myRow["OrderID"]).TrimEnd();
                    anOrder.CustomerID = Convert.ToString(myRow["CustomerID"]).TrimEnd();
                    anOrder.OrderDate = (System.DateTime)(myRow["OrderDate"]);
                    anOrder.TotalCost = Convert.ToInt32(myRow["TotalCost"]);
                    anOrder.SpecialNote = Convert.ToString(myRow["SpecialNote"]).TrimEnd();
                    anOrder.OrderValue = (Order.OrderStatus)(myRow["OrderStatus"]);
                    orders.Add(anOrder);
                }
            }
        }

        private void FillRow(DataRow aRow, Order anOrder, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["OrderID"] = anOrder.OrderID;  //NOTE square brackets to indicate index of collections of fields in row.
            }
           
            aRow["CustomerID"] = anOrder.CustomerID;
            aRow["OrderDate"] = anOrder.OrderDate;
            aRow["TotalCost"] = anOrder.TotalCost;
            aRow["SpecialNote"] = anOrder.SpecialNote;
            aRow["OrderStatus"] = (byte)anOrder.OrderValue;
        }

        //The FindRow method finds the row for a specific employee(by ID)  in a specific table
        private int FindRow(Order anOrder, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it is automatically known to the compiler when used as below
                    if (anOrder.OrderID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["OrderID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Order anOrder)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@OrderID", SqlDbType.NVarChar, 20, "OrderID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.NVarChar, 20, "CustomerID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@OrderDate", SqlDbType.DateTime, 100, "OrderDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@TotalCost", SqlDbType.Money, 6, "TotalCost");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@SpecialNote", SqlDbType.NVarChar, 200, "SpecialNote");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@OrderStatus", SqlDbType.TinyInt, 1, "OrderStatus");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Build_UPDATE_Parameters(Order anOrder)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@CustomerID", SqlDbType.NVarChar, 20, "CustomerID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and EMPID as for Insert 
            param = new SqlParameter("@OrderDate", SqlDbType.DateTime, 100, "OrderDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@TotalCost", SqlDbType.Money, 6, "TotalCost");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@SpecialNote", SqlDbType.NVarChar, 200, "SpecialNote");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@OrderStatus", SqlDbType.TinyInt, 1, "OrderStatus");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_OrderID", SqlDbType.NVarChar, 20, "OrderID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }


        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@OrderID", SqlDbType.NVarChar, 20, "OrderID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Order anOrder)
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Orders (OrderID, CustomerID, OrderDate, TotalCost, SpecialNote, OrderStatus) VALUES (@OrderID, @CustomerID, @OrderDate, @TotalCost, @SpecialNote, @OrderStatus)", cnMain);
            Build_INSERT_Parameters(anOrder);

        }
    
        private void Create_UPDATE_Command(Order anOrder)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Orders SET CustomerID = @CustomerID, OrderDate = @OrderDate, TotalCost = @TotalCost, SpecialNote = @SpecialNote , OrderStatus = @OrderStatus  " + "WHERE OrderID = @Original_OrderID", cnMain);

            Build_UPDATE_Parameters(anOrder);
        }

        private string Create_DELETE_Command(Order anOrder)
        {
            string errorString = null;

            //Create the command that must be used to delete values from the the Customer table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", cnMain);


            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }


        public bool UpdateDataSource(Order anOrder)
        {
            bool success = true;
            Create_INSERT_Command(anOrder);
            Create_UPDATE_Command(anOrder);
            Create_DELETE_Command(anOrder);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

    }
}

     