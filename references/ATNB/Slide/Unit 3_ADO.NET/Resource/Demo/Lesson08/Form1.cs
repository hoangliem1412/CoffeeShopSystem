using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lesson08
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter daOrders;
        private SqlDataAdapter daOrderDetail;
        private DataSet datasetOrders;
        private const string tableNameOrders = "Orders";
        private const string tableNameOrderDetails = "OrderDetails";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // fill dataset
            Initdata();

            // set up datagrid
            dataGridViewOrders.DataSource = datasetOrders;
            dataGridViewOrders.DataMember = "Orders";

            dataGridViewOrderDetails.DataSource = datasetOrders;
            dataGridViewOrderDetails.DataMember = "Orders.Order_OrderDetails";
        }

        private void Initdata()
        {
            // instantiate the connection
            connection = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");

            // 1. instantiate a new DataSet
            datasetOrders = new DataSet();

            // 2. init SqlDataAdapter with select command and connection
            daOrders = new SqlDataAdapter(@"SELECT * FROM ORDERS", connection);
            daOrderDetail = new SqlDataAdapter("SELECT * FROM [Order Details]", connection);

            // 3. fill in insert, update, and delete commands
            SqlCommandBuilder cmdBldrdaOrders = new SqlCommandBuilder(daOrders);
            SqlCommandBuilder cmdBldrdaOrderDetail = new SqlCommandBuilder(daOrderDetail);


            // 4. fill the dataset
            daOrders.Fill(datasetOrders, tableNameOrders);
            daOrderDetail.Fill(datasetOrders, tableNameOrderDetails);

            DataTable OrderDetailTable = datasetOrders.Tables[tableNameOrderDetails];
            DataTable OrderTable = datasetOrders.Tables[tableNameOrders];
            DataRelation relation = new DataRelation("Order_OrderDetails", 
                                                    OrderTable.Columns["OrderID"], 
                                                    OrderDetailTable.Columns["OrderID"]);
            datasetOrders.Relations.Add(relation);
           

           

        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            daOrders.Update(datasetOrders, tableNameOrders);
            daOrderDetail.Update(datasetOrders, tableNameOrderDetails);
        }
    }
}
