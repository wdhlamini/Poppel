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
    public class ProductDB : DB
    {
        //Data members        
        private string table1 = "Products";
        private string sqlLocal1 = "SELECT * FROM Products";


        private Collection<Product> products;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public ProductDB() : base()
        {
            products = new Collection<Product>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }
        public Collection<Product> AllProducts
        {
            get
            {
                return products;
            }
        }
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Product aProduct, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aProduct, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aProduct, dataTable)];
                    FillRow(aRow, aProduct, operation);
                    break;
            }
        }
        #endregion

        #region Utility Methods
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Product aProduct;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Employee object
                    aProduct = new Product();

                    aProduct.ProductID = Convert.ToString(myRow["ProductID"]).TrimEnd();
                    aProduct.ProductName = Convert.ToString(myRow["ProductName"]).TrimEnd();
                    aProduct.ExpiryDate = (System.DateTime)(myRow["ExpiryDate"]);
                    aProduct.QuantityInStock = Convert.ToInt32(myRow["QuantityInStock"]);
                    aProduct.Price = Convert.ToInt32(myRow["Price"]);
                    aProduct.ProductValue = (Product.productStatus)(myRow["ExpiredProduct"]);
                    products.Add(aProduct);
                }
            }
        }

        private void FillRow(DataRow aRow, Product aProduct, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                aRow["ProductID"] = aProduct.ProductID;  //NOTE square brackets to indicate index of collections of fields in row.
            }

            aRow["ProductName"] = aProduct.ProductName;
            aRow["ExpiryDate"] = aProduct.ExpiryDate;
            aRow["QuantityInStock"] = aProduct.QuantityInStock;
            aRow["Price"] = aProduct.Price;
            aRow["ExpiredProduct"] = aProduct.ProductValue;
        }

        //The FindRow method finds the row for a specific employee(by ID)  in a specific table
        private int FindRow(Product aProduct, string table)
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
                    if (aProduct.ProductID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ProductID"]))
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
        private void Build_INSERT_Parameters(Product aProduct)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ProductID", SqlDbType.NVarChar, 20, "ProductID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ProductName", SqlDbType.NVarChar, 50, "ProductName");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@ExpiryDate", SqlDbType.DateTime, 20, "ExpiryDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityInStock", SqlDbType.Money, 6, "QuantityInStock");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.NVarChar, 6, "Price");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ExpiredProduct", SqlDbType.Int, 1, "ExpiredProduct");
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Build_UPDATE_Parameters(Product aProduct)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ProductName", SqlDbType.NVarChar, 50, "ProductName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and EMPID as for Insert 
            param = new SqlParameter("@ExpiryDate", SqlDbType.DateTime, 20, "ExpiryDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@QuantityInStock", SqlDbType.Money, 6, "QuantityInStock");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.NVarChar, 6, "Price");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ExpiredProduct", SqlDbType.Int, 1, "ExpiredProduct");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ProductID", SqlDbType.NVarChar, 20, "ProductID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Product aProduct)
        {
            //Create the command that must be used to insert values into the Books table..
            daMain.InsertCommand = new SqlCommand("INSERT into Products (ProductID, ProductName, ExpiryDate, QuantityInStock, Price, ExpiredProduct) VALUES (@ProductID, @ProductName, @ExpiryDate, @QuantityInStock, @Price, @ExpiredProduct)", cnMain);
            Build_INSERT_Parameters(aProduct);

        }

        private void Create_UPDATE_Command(Product aProduct)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed

            daMain.UpdateCommand = new SqlCommand("UPDATE Products SET ProductName = @ProductName, ExpiryDate = @ExpiryDate, QuantityInStock = @QuantityInStock, Price = @Price , ExpiredProduct = @ExpiredProduct  " + "WHERE ProductID = @Original_ProductID", cnMain);

            Build_UPDATE_Parameters(aProduct);
        }

        public bool UpdateDataSource(Product aProduct)
        {
            bool success = true;
            Create_INSERT_Command(aProduct);
            Create_UPDATE_Command(aProduct);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

        #region Data Reader for reporting
        public DataTable ReadDataQuantityInstock()
        {
            //Declare references (for table, reader and command)
            DataTable quantyReportTable = new DataTable();
            SqlDataReader reader;
            SqlCommand command;
            string selectString = "select Products.QuantityInStock, count(QuantityInStock) as quantyReportTable from Products group by QuantityInStock ";
            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();  //open the connection
                command.CommandType = CommandType.Text;//Command Type
                reader = command.ExecuteReader(); //Read from table

                //  read data from readerObject and load in table 
                quantyReportTable.Load(reader);
                reader.Close();
                cnMain.Close();
                return quantyReportTable;
            }

            catch 
            {
                return (null);
            }
        }


        #endregion

    }
}

