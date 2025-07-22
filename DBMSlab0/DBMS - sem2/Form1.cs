using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter daParent, daChild;
        private DataSet ds;
        private SqlCommandBuilder cbChild;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(GetConnectionString());
            daParent = new SqlDataAdapter("SELECT * FROM Blocks", conn);
            daChild = new SqlDataAdapter("SELECT * FROM Transactions", conn);
            ds = new DataSet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadParentTable();
            ConfigureChildDataAdapter();
        }

        private void LoadParentTable()
        {
            ds.Clear();
            daParent.Fill(ds, "Blocks");
            ParentTable.DataSource = ds.Tables["Blocks"];
        }

        private void ConfigureChildDataAdapter()
        {
            // Assuming TransactionID is the primary key and you have a foreign key to Blocks table.
            cbChild = new SqlCommandBuilder(daChild);
            daChild.InsertCommand = cbChild.GetInsertCommand();
            daChild.UpdateCommand = cbChild.GetUpdateCommand();
            daChild.DeleteCommand = cbChild.GetDeleteCommand();
        }

        private void ParentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int blockID = Convert.ToInt32(ParentTable.Rows[e.RowIndex].Cells["BlockID"].Value);
                LoadChildTable(blockID);
            }
        }

        private void LoadChildTable(int blockID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Transactions WHERE BlockID = @BlockID", conn);
            cmd.Parameters.AddWithValue("@BlockID", blockID);

            daChild.SelectCommand = cmd;
            if (ds.Tables.Contains("Transactions"))
            {
                ds.Tables["Transactions"].Clear();
            }
            daChild.Fill(ds, "Transactions");
            ChildTable.DataSource = ds.Tables["Transactions"];
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newTransaction = ds.Tables["Transactions"].NewRow();
                // Assuming you have text boxes for each field
                newTransaction["BlockID"] = Convert.ToInt32(txtBlockID.Text);
                newTransaction["SenderAddress"] = txtSenderAddress.Text;
                newTransaction["ReceiverAddress"] = txtReceiverAddress.Text;
                newTransaction["Amount"] = Convert.ToDecimal(txtAmount.Text);
                newTransaction["TransactionTimestamp"] = DateTime.Parse(txtTransactionTimestamp.Text);

                ds.Tables["Transactions"].Rows.Add(newTransaction);

                daChild.Update(ds, "Transactions");
                MessageBox.Show("Transaction inserted successfully.");

                LoadChildTable(Convert.ToInt32(txtBlockID.Text)); // Refresh the child table view
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert transaction. " + ex.Message);
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChildTable.SelectedRows.Count > 0)
                {
                    DataRow updateRow = ds.Tables["Transactions"].Rows[ChildTable.SelectedRows[0].Index];

                    updateRow["SenderAddress"] = txtSenderAddress.Text;
                    updateRow["ReceiverAddress"] = txtReceiverAddress.Text;
                    updateRow["Amount"] = Convert.ToDecimal(txtAmount.Text);
                    updateRow["TransactionTimestamp"] = DateTime.Parse(txtTransactionTimestamp.Text);

                    daChild.Update(ds, "Transactions");
                    MessageBox.Show("Transaction updated successfully.");

                    LoadChildTable((int)updateRow["BlockID"]); // Refresh the child table view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update transaction. " + ex.Message);
            }
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChildTable.SelectedRows.Count > 0)
                {
                    DataRow deleteRow = ds.Tables["Transactions"].Rows[ChildTable.SelectedRows[0].Index];
                    deleteRow.Delete();

                    daChild.Update(ds, "Transactions");
                    MessageBox.Show("Transaction deleted successfully.");

                    LoadChildTable((int)deleteRow["BlockID"]); // Refresh the child table view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete transaction. " + ex.Message);
            }
        }


        private static string GetConnectionString()
        {
            // Update the connection string according to your environment
            return "Data Source=DESKTOP-B5IS4HU;Initial Catalog=Blockchain;Integrated Security=true;";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSenderAddress.Text) ||
                string.IsNullOrWhiteSpace(txtReceiverAddress.Text) ||
                string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(txtTransactionTimestamp.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            return true;
        }

    }
}
