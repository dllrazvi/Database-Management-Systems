using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace BlockchainDatabaseApp
{
    public partial class MainForm : Form
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter parentAdapter, childAdapter;
        private DataTable parentTable, childTable;
        private DataGridView dgvParent, dgvChild;
        private Button addButton, updateButton, deleteButton;

        // Declare text boxes as class members
        private TextBox txtSenderAddress;
        private TextBox txtReceiverAddress;
        private TextBox txtBlockID;
        private TextBox txtAmount;

        public MainForm()
        {
            InitializeComponents();
            InitializeDatabaseConnection();
            InitializeDynamicComponents();
            LoadInitialData();
        }

        private void InitializeComponents()
        {
            this.Text = "Dynamic Master-Detail Form";
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            dbConnection = new SqlConnection(connectionString);
        }

        private void InitializeDynamicComponents()
        {
            dgvParent = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(450, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvParent);

            dgvChild = new DataGridView
            {
                Location = new System.Drawing.Point(20, 250),
                Size = new System.Drawing.Size(450, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvChild);

            addButton = new Button { Text = "Add", Location = new System.Drawing.Point(500, 20), Size = new System.Drawing.Size(75, 23) };
            addButton.Click += AddButton_Click;
            this.Controls.Add(addButton);

            updateButton = new Button { Text = "Update", Location = new System.Drawing.Point(500, 60), Size = new System.Drawing.Size(75, 23) };
            updateButton.Click += UpdateButton_Click;
            this.Controls.Add(updateButton);

            deleteButton = new Button { Text = "Delete", Location = new System.Drawing.Point(500, 100), Size = new System.Drawing.Size(75, 23) };
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);

            // Initialize text boxes
            txtSenderAddress = new TextBox { Location = new Point(500, 140), Size = new Size(100, 20), Name = "Sender" };
            txtReceiverAddress = new TextBox { Location = new Point(500, 170), Size = new Size(100, 20), Name = "Receiver" };
            txtBlockID = new TextBox { Location = new Point(500, 200), Size = new Size(100, 20), Name = "BlockID" };
            txtAmount = new TextBox { Location = new Point(500, 230), Size = new Size(100, 20), Name = "Amount" };

            // Adding text boxes to the form
            Controls.Add(txtSenderAddress);
            Controls.Add(txtReceiverAddress);
            Controls.Add(txtBlockID);
            Controls.Add(txtAmount);
        }

        private void LoadInitialData()
        {
            parentAdapter = new SqlDataAdapter(ConfigurationManager.AppSettings["ParentQuery"], dbConnection);
            parentTable = new DataTable();
            parentAdapter.Fill(parentTable);
            dgvParent.DataSource = parentTable;

            dgvParent.SelectionChanged += DgvParent_SelectionChanged;
        }

        private void DgvParent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvParent.CurrentRow != null)
            {
                try
                {
                    // Assuming the first column is the ID column and checking for null
                    object value = dgvParent.CurrentRow.Cells[0].Value;
                    /*if (value == DBNull.Value)
                    {
                        MessageBox.Show("Selected row's ID value is null.");
                        return;
                    }*/

                    int parentId = Convert.ToInt32(value);

                    // Correctly access the configuration settings
                    string childQuery = ConfigurationManager.AppSettings["ChildQuery"];
                    if (string.IsNullOrEmpty(childQuery))
                    {
                        MessageBox.Show("ChildQuery setting is not found in App.config");
                        return;
                    }

                    childQuery += parentId; // Appending the parent ID to the query

                    // Execute query and fill the DataTable
                    SqlCommand command = new SqlCommand(childQuery, dbConnection);
                    SqlDataAdapter childAdapter = new SqlDataAdapter(command);
                    DataTable childTable = new DataTable();
                    childAdapter.Fill(childTable);
                    dgvChild.DataSource = childTable;

                    // Update the BlockID or AccountID text box
                    txtBlockID.Text = parentId.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in DgvParent_SelectionChanged: {ex.Message}");
                }
            }
        }




        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSenderAddress.Text) && !string.IsNullOrWhiteSpace(txtReceiverAddress.Text) && !string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                using (var cmd = new SqlCommand(ConfigurationManager.AppSettings["InsertCommand"], dbConnection))
                {
                    cmd.Parameters.AddWithValue("@SenderAddress", txtSenderAddress.Text);
                    cmd.Parameters.AddWithValue("@ReceiverAddress", txtReceiverAddress.Text);
                    cmd.Parameters.AddWithValue("@BlockID", Convert.ToInt32(txtBlockID.Text));
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@TransactionTimestamp", DateTime.Now);

                    ExecuteNonQuery(cmd);
                }
                RefreshChildView();
            }
            else
            {
                MessageBox.Show("Please ensure all fields are filled in.");
            }
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dgvChild.CurrentRow != null)
            {
                using (var cmd = new SqlCommand(ConfigurationManager.AppSettings["UpdateCommand"], dbConnection))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", Convert.ToInt32(dgvChild.CurrentRow.Cells["TransactionID"].Value));
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text)); // Updated value from textbox
                    cmd.Parameters.AddWithValue("@TransactionTimestamp", DateTime.Now); // Updated timestamp

                    ExecuteNonQuery(cmd);
                }
                RefreshChildView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dgvChild.CurrentRow != null)
            {
                using (var cmd = new SqlCommand(ConfigurationManager.AppSettings["DeleteCommand"], dbConnection))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", dgvChild.CurrentRow.Cells["TransactionID"].Value);

                    ExecuteNonQuery(cmd);
                }
                RefreshChildView();
            }
        }

        private void ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                dbConnection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Operation successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during operation: {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private void RefreshChildView()
        {
            if (dgvParent.CurrentRow != null)
            {
                string childQuery = ConfigurationManager.AppSettings["ChildQuery"] + dgvParent.CurrentRow.Cells[0].Value.ToString();
                childAdapter = new SqlDataAdapter(childQuery, dbConnection);
                childTable = new DataTable();
                childAdapter.Fill(childTable);
                dgvChild.DataSource = childTable;
            }
        }
    }
}
/*
 * */