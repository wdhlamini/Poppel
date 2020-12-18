using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Add namespaces for DATAbase Access (ADO)
using System.Data.SqlClient;
using System.Xml;

//Add namespace for Student Info Entities
using PoppelProject.BusinessLayer;
//Add namespace for Student Info Entities
using PoppelProject.DatabaseLayer;

//including the Visifire libraries
using Visifire.Charts;
using Visifire.Commons;

namespace PoppelProject.PresentationLayer
{
    public partial class ReportingForm : Form
    {

        // Declare a reference to a orderitemDB object
        private OrderItemsDB orderItemsDB;
        //Declare a reference to a productDB object
        private ProductDB productDB;

        public bool reportingFormClosed = false;
        public ReportingForm()
        {
            InitializeComponent();
            //productDB = new ProductDB();
            orderItemsDB = new OrderItemsDB();
            productDB = new ProductDB();
        }

        private void purchaseReportbutton_Click(object sender, EventArgs e)
        {
            DataTable saleReportTable;
            Chart saleReportChart = new Chart();
            DataSeries pop = new DataSeries();
            pop.RenderAs = RenderAs.Pie;
            pop.LegendText = "Sale Report";
            saleReportTable = orderItemsDB.ReadDataOrderItemSpilt();

            foreach (DataRow popRow in saleReportTable.Rows)
            {
                DataPoint aPoint = new DataPoint();
                // Set X & Y Value for a DataPoint
                aPoint.AxisXLabel = (popRow.ItemArray[0]).ToString();
                aPoint.YValue = Convert.ToDouble(popRow.ItemArray[1]);
                // Add dataPoint to DataPoints collection
                pop.DataPoints.Add(aPoint);
            }
            saleReportChart.Series.Add(pop);
            saleReportChart.SmartLabelEnabled = true;
            poppelElementHost.Child = saleReportChart;
        }

        private void QuantityInStockbutton_Click(object sender, EventArgs e)
        {
            //Declare references (for table, reader and command)
            DataTable quantyReportTable;
            Chart quantyReportChart = new Chart();
            DataSeries quant = new DataSeries();
            quant.RenderAs = RenderAs.Doughnut;
            quant.LegendText = "Quantity In Stock";
            quantyReportTable = productDB.ReadDataQuantityInstock();

            foreach (DataRow quantRow in quantyReportTable.Rows)
            {
                DataPoint aPoint = new DataPoint();
                // Set X & Y Value for a DataPoint
                aPoint.AxisXLabel = (quantRow.ItemArray[0].ToString());
                aPoint.YValue = Convert.ToDouble(quantRow.ItemArray[1]);

                // Add dataPoint to DataPoints collection
                quant.DataPoints.Add(aPoint);
            }
            quantyReportChart.Series.Add(quant);
            quantyReportChart.SmartLabelEnabled = true;
            poppelElementHost.Child = quantyReportChart;

            MisterApbutton.Visible = true;
            AppleDrinkbutton.Visible = true;
            OrbitGumbutton.Visible = true;
            RoberWinebutton.Visible = true;
            Liquibutton.Visible = true;

        }

        private void ReportingForm_Load(object sender, EventArgs e)
        {
            MisterApbutton.Visible = false;
            AppleDrinkbutton.Visible = false;
            OrbitGumbutton.Visible = false;
            RoberWinebutton.Visible = false;
            Liquibutton.Visible = false;
        }
    }
}
