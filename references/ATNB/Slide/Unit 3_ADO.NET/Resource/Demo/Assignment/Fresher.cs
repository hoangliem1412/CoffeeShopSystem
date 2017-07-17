using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Fresher : Form
    {

        private SqlConnection conn;
        private SqlDataAdapter daFreshers;
        private DataSet datasetFreshers;
        private const string tableName = "Fresher";

        public Fresher()
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
            datagridFreshers.DataSource = datasetFreshers;
            datagridFreshers.DataMember = tableName;

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
            conn = new SqlConnection("Server=(local);DataBase=Fsoft;Integrated Security=SSPI");

            // 1. instantiate a new DataSet
            datasetFreshers = new DataSet();

            // 2. init SqlDataAdapter with select command and connection
            daFreshers = new SqlDataAdapter();

            SqlCommand commandRead = new SqlCommand("ReadAllFreshers", conn);
            commandRead.CommandType = CommandType.StoredProcedure;
            daFreshers.SelectCommand = commandRead;

            // 3. fill in insert, update, and delete commands
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(daFreshers);

            // OR manual build
            //Commands();

            // 4. fill the dataset
            daFreshers.Fill(datasetFreshers, tableName);

        }

        // Update button was clicked
        public void Update_Click(object sender, EventArgs e)
        {
            // write changes back to DataBase
            daFreshers.Update(datasetFreshers, tableName);
        }

        /// <summary>
        /// Updates the freshers.
        /// </summary>
        public void Commands()
        {
            SqlCommand commandInsert = new SqlCommand("InsertFresher", conn);
            commandInsert.CommandType = CommandType.StoredProcedure;
            commandInsert.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            commandInsert.Parameters.Add("@Address", SqlDbType.NVarChar, 4, "Address");
            daFreshers.InsertCommand = commandInsert;

            SqlCommand commandUpdate = new SqlCommand("UpdateFresher", conn);
            commandUpdate.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            commandUpdate.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            commandUpdate.Parameters.Add("@Address", SqlDbType.NVarChar, 4, "Address");
            commandUpdate.CommandType = CommandType.StoredProcedure;
            daFreshers.UpdateCommand = commandUpdate;

            SqlCommand commandDelete = new SqlCommand("DeleteFresher", conn);
            commandDelete.CommandType = CommandType.StoredProcedure;
            commandDelete.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            daFreshers.DeleteCommand = commandDelete;
        }

    }
}
