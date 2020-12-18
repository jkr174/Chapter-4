/*
 * Jovany Romo
 * 12/15/2020
 * Summray:     Tests SQL commands using a C# windows form application.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLTesterProject4_1
{
    public partial class frmBooks : Form
    {
        SqlConnection booksConnection;
        public frmBooks()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlCommand resultsCommand = null;
            SqlDataAdapter resultsAdapter = new SqlDataAdapter();
            DataTable resultsTable = new DataTable();
            try
            {
                resultsCommand = new SqlCommand(txtSQLTester.Text, booksConnection);
                resultsAdapter.SelectCommand = resultsCommand;
                resultsAdapter.Fill(resultsTable);
                grdBooks.DataSource = resultsTable;
                lblRecords.Text = resultsTable.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    "Error in Processing SQL",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            resultsCommand.Dispose();
            resultsAdapter.Dispose();
            resultsTable.Dispose();
        }

        private void frmSQLTester_Load(object sender, EventArgs e)
        {
            booksConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                "AttachDbFilename=c:\\VCSDB\\Working\\SQLBooksDB.mdf;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "User Instance=True");
        }

        private void frmSQLTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            booksConnection.Close();
            booksConnection.Dispose();
        }
        // Coulmn automatically gets removed if the user tries to scroll to far to the right.
        private void grdSQLTester_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.CellType == typeof(DataGridViewImageCell))
                grdBooks.Columns.Remove(e.Column);
        }
    }
}
