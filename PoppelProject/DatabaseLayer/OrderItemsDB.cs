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
    public class OrderItemsDB : DB
    {

        #region Data members        
        private string table1 = "OrderItems";
        private string sqlLocal1 = "SELECT * FROM OrderItems";
        private Collection<OrderItems> orderItems;
        #endregion


        #region properties
        public Collection<OrderItems> AllOrderItems
        {
            get
            {
                return orderItems;
            }

        }
        #endregion

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public OrderItemsDB() : base()
        {
            orderItems = new Collection<OrderItems>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        public void DataSetChange(OrderItems aItem, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aItem, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aItem, dataTable)];
                    FillRow(aRow, aItem, operation);
                    break;

                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aItem, dataTable)];
                    aRow.Delete();
                    break;
            }
        }


        #region Utility Methods
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            OrderItems item;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Customer object
                    item = new OrderItems();
                    //Obtain each customer attribute from the specific field in the row in the table
                    item.OrderItemID = Convert.ToString(myRow["OrderItemID"]).TrimEnd();
                    item.OrderID = Convert.ToString(myRow["OrderID"]).TrimEnd(); ;
                    item.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    item.Quantity = Convert.ToInt32(myRow["Quantity"]);
                    // add to collection
                    orderItems.Add(item);
                }
            }
        }

        private void FillRow(DataRow aRow, OrderItems aItem, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["OrderItemID"] = aItem.OrderItemID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

            aRow["OrderID"] = aItem.OrderID;
            aRow["ProductID"] = aItem.ProductID;
            aRow["Quantity"] = aItem.Quantity;
        }


        //The FindRow method finds the row for a specific employee(by ID)  in a specific table
        private int FindRow(OrderItems item, string table)
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
                    if (item.OrderItemID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["OrderItemID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }

        //ADDED BY TONNY 
        #region Data reader for reporting
        public DataTable ReadDataOrderItemSpilt()
        {
            //Declare references (for table, reader and command)
            DataTable salesReportTable = new DataTable();
            SqlDataReader reader;
            SqlCommand command;
            string selectString = "select OrderItems.ProductID, count(ProductID) as salesGroupTotal from OrderItems group by ProductID ";
            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();  //open the connection
                command.CommandType = CommandType.Text;//Command Type
                reader = command.ExecuteReader(); //Read from table

                //  read data from readerObject and load in table 
                salesReportTable.Load(reader);
                reader.Close();
                cnMain.Close();
                return salesReportTable;
            }


            catch (Exception errObj)
            {
                String errorString = errObj.Message + "  " + errObj.StackTrace;
                return null; 
            }
            
        }

        #endregion


        // Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(OrderItems aItem)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@OrderItemID", SqlDbType.NVarChar, 20, "OrderItemID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@OrderID", SqlDbType.NVarChar, 20, "OrderID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 20, "ProductID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int, 6, "Quantity");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Build_UPDATE_Parameters(OrderItems aItem)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@OrderID", SqlDbType.NVarChar, 20, "OrderID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 20, "ProductID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int, 6, "Quantity");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_OrderItemID", SqlDbType.NVarChar, 20, "OrderItemID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }


        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@OrderItemID", SqlDbType.NVarChar, 20, "OrderItemID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(OrderItems aItem)
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into OrderItems (OrderItemID, OrderID, ProductID, Quantity) VALUES (@OrderItemID, @OrderID, @ProductID, @Quantity)", cnMain);
            Build_INSERT_Parameters(aItem);

        }

        private void Create_UPDATE_Command(OrderItems aItem)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE OrderItems SET OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity " + "WHERE OrderItemID = @Original_OrderItemID", cnMain);

            Build_UPDATE_Parameters(aItem);
        }

        private string Create_DELETE_Command(OrderItems aItem)
        {
            string errorString = null;

            //Create the command that must be used to delete values from the the Customer table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM OrderItems WHERE OrderItemID = @OrderItemID", cnMain);


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

        public bool UpdateDataSource(OrderItems aItem)
        {
            bool success = true;
            Create_INSERT_Command(aItem);
            Create_UPDATE_Command(aItem);
            Create_DELETE_Command(aItem);
            success = UpdateDataSource(sqlLocal1, table1);

            return success;
        }
        #endregion
    }
}
