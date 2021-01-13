/*
 * Jovany Romo
 * 12/15/2020
 * Summray:     Tests SQL commands using a C# windows form application.
 */

using System;
using System.IO;
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
        String SQLAll;
        Button[] btnRolodex = new Button[26];
        public frmBooks()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlCommand resultsCommand = null;
            SqlDataAdapter resultsAdapter = new SqlDataAdapter();
            DataTable resultsTable = new DataTable();
            String SQLStatement;

            Button buttonClicked = (Button)sender;
            switch (buttonClicked.Text)
            {
                case "Show All Records":
                    SQLStatement = SQLAll;
                    break;
                case "Z":
                    SQLStatement = SQLAll + "AND Authors.Author > 'Z'";
                    break;
                default:
                    int index = (int)(Convert.ToChar(buttonClicked.Text)) - 65;
                    SQLStatement = SQLAll + "AND Authors.Author >'" + btnRolodex[index].Text + "'";
                    SQLStatement += "AND Authors.Author <'" + btnRolodex[index + 1].Text + "'";
                    break;
            }
            SQLStatement += "ORDER BY Authors.Author";
            try
            {
                resultsCommand = new SqlCommand(SQLStatement, booksConnection);
                resultsAdapter.SelectCommand = resultsCommand;
                resultsAdapter.Fill(resultsTable);
                grdBooks.DataSource = resultsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Processing SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            resultsCommand.Dispose();
            resultsAdapter.Dispose();
            resultsTable.Dispose();
        }

        private void frmSQLTester_Load(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath,@"Databases");
                openFileDialog.Filter = "mdf files (*.mdf)|*.mdf";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                }
                else
                {
                    string Message = "Please select a valid file to open.",
                        Title = "Error!";

                    MessageBox.Show(Message,
                        Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            booksConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                "AttachDbFilename=" + filePath + ";" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "User Instance=True");
            booksConnection.Open();

            int w, IStart, l, t;
            int buttonHeight = 33;

            w = Convert.ToInt32(this.ClientSize.Width / 14);

            IStart = Convert.ToInt32(0.5 * (this.ClientSize.Width - 13 * w));
            l = IStart;
            t = grdBooks.Top + grdBooks.Height + 2;

            for(int i = 0; i <26; i++)
            {
                btnRolodex[i] = new Button();
                btnRolodex[i].TabStop = false;

                btnRolodex[i].Text = ((char)(65 + i)).ToString();

                btnRolodex[i].Width = w;
                btnRolodex[i].Height = buttonHeight;
                btnRolodex[i].Left = l;
                btnRolodex[i].Top = t;

                btnRolodex[i].BackColor = Color.Blue;
                btnRolodex[i].ForeColor = Color.White;

                this.Controls.Add(btnRolodex[i]);

                btnRolodex[i].Click += new System.EventHandler(this.btnTest_Click);

                l += w;
                if (i == 12)
                {
                    l = IStart;
                    t += buttonHeight;
                }
            }
            SQLAll = "SELECT Authors.Author,Titles.Title,Publishers.Company_Name ";
            SQLAll += "FROM Authors, Titles, Publishers, Title_Author ";
            SQLAll += "WHERE Titles.ISBN = Title_Author.ISBN ";
            SQLAll += "AND Authors.Au_ID = Title_Author.Au_ID ";
            SQLAll += "AND Titles.PubID = Publishers.PubID ";
             
            this.Show();
            btnAll.PerformClick();
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

        private void grdBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
