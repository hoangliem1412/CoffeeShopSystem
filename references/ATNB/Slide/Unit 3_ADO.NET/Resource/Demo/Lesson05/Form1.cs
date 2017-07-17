using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lesson05
{
    public partial class Form1 : Form
    {

        private SqlConnection conn;
        private SqlDataAdapter daCustomers;
        private DataSet datasetCustomers;
        private const string tableName = "Customers";

        public Form1()
        {
            InitializeComponent();
            DisconnectedDataform();
        }

        /// <summary>
        /// initialize form with DataGrid and Button
        /// </summary>
        private void DisconnectedDataform()
        {
            // fill dataset
            Initdata();

            // set up datagrid
            datagridCustomers.DataSource = datasetCustomers;
            datagridCustomers.DataMember = tableName;

            // create update button
            Update.Click += Update_Click;
            Cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // set up ADO.NET objects
        public void Initdata()
        {
            // instantiate the connection
            conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");

            // 1. instantiate a new DataSet
            datasetCustomers = new DataSet();

            // 2. init SqlDataAdapter with select command and connection
            daCustomers = new SqlDataAdapter("SELECT CUSTOMERID, COMPANYNAME FROM CUSTOMERS", conn);

            // 3. fill in insert, update, and delete commands
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(daCustomers);

            // 4. fill the dataset
            daCustomers.Fill(datasetCustomers, tableName);

        }

        // Update button was clicked
        public void Update_Click(object sender, EventArgs e)
        {
            // write changes back to DataBase
            daCustomers.Update(datasetCustomers, tableName);
        }

    }
}
