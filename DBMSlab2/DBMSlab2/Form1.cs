using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BlockchainDatabaseApp
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private DataGridView dataGridViewBlocks;
        private DataGridView dataGridViewTransactions;
        private Button addTransactionButton, removeTransactionButton, updateTransactionButton;

        public Form1()
        {
            InitializeComponents();
            InitializeDatabaseConnection();
            LoadInitialData();
        }

        private void InitializeComponents()
        {
            dataGridViewBlocks = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(776, 150),
                Name = "dataGridViewBlocks"
            };

            dataGridViewTransactions = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(12, 180),
                Size = new System.Drawing.Size(776, 150),
                Name = "dataGridViewTransactions"
            };

            addTransactionButton = CreateButton("Add Transaction", 12, 340);
            removeTransactionButton = CreateButton("Remove Transaction", 212, 340);
            updateTransactionButton = CreateButton("Update Transaction", 412, 340);

            addTransactionButton.Click += addTransactionButton_Click;
            removeTransactionButton.Click += removeTransactionButton_Click;
            updateTransactionButton.Click += updateTransactionButton_Click;

            Controls.Add(dataGridViewBlocks);
            Controls.Add(dataGridViewTransactions);
            Controls.Add(addTransactionButton);
            Controls.Add(removeTransactionButton);
            Controls.Add(updateTransactionButton);

            ClientSize = new System.Drawing.Size(800, 450);
            Text = "Blockchain Database App";
        }

        private Button CreateButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(180, 23)
            };
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True";
            dbConnection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
        }

        private void LoadInitialData()
        {
            LoadData("Blocks", dataGridViewBlocks);
            LoadData("Transactions", dataGridViewTransactions);
        }

        private void LoadData(string tableName, DataGridView gridView)
        {
            dataTable = new DataTable();
            try
            {
                dataAdapter.SelectCommand = new SqlCommand($"SELECT * FROM {tableName}", dbConnection);
                dbConnection.Open();
                dataAdapter.Fill(dataTable);
                gridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private void addTransactionButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                {
                    var cmd = new SqlCommand("INSERT INTO Transactions (SenderAddress, ReceiverAddress, BlockID, Amount, TransactionTimestamp) VALUES (@Sender, @Receiver, @Block, @Amount, @Timestamp)", conn);
                    cmd.Parameters.AddWithValue("@Sender", 1); // Example parameter
                    cmd.Parameters.AddWithValue("@Receiver", 2);
                    cmd.Parameters.AddWithValue("@Block", 1);
                    cmd.Parameters.AddWithValue("@Amount", 100);
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaction Added Successfully!");
                    LoadData("Transactions", dataGridViewTransactions); // Refresh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void removeTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                int transactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells[0].Value);
                var cmdText = "DELETE FROM Transactions WHERE TransactionID = @TransactionID";
                try
                {
                    using (var conn = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                    {
                        var cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transaction Deleted Successfully!");
                        LoadData("Transactions", dataGridViewTransactions); // Refresh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to delete.");
            }
        }


        private void updateTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                int transactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells[0].Value);
                double newAmount = 150.00; // Example of new data
                var cmdText = "UPDATE Transactions SET Amount = @Amount WHERE TransactionID = @TransactionID";
                try
                {
                    using (var conn = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                    {
                        var cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        cmd.Parameters.AddWithValue("@Amount", newAmount);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transaction Updated Successfully!");
                        LoadData("Transactions", dataGridViewTransactions); // Refresh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to update.");
            }
        }

    }
}

/*namespace BlockchainDatabaseApp
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection;
        private DataGridView dataGridViewBlocks;
        private DataGridView dataGridViewTransactions;
        private Button addTransactionButton, removeTransactionButton, updateTransactionButton;

        public Form1()
        {
            InitializeComponents();
            InitializeDatabaseConnection();
            LoadInitialData();
        }

        private void InitializeComponents()
        {
            dataGridViewBlocks = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(776, 150),
                Name = "dataGridViewBlocks"
            };

            dataGridViewTransactions = new DataGridView
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(12, 180),
                Size = new System.Drawing.Size(776, 150),
                Name = "dataGridViewTransactions"
            };

            addTransactionButton = CreateButton("Add Transaction", 12, 340);
            removeTransactionButton = CreateButton("Remove Transaction", 212, 340);
            updateTransactionButton = CreateButton("Update Transaction", 412, 340);

            addTransactionButton.Click += addTransactionButton_Click;
            removeTransactionButton.Click += removeTransactionButton_Click;
            updateTransactionButton.Click += updateTransactionButton_Click;

            Controls.Add(dataGridViewBlocks);
            Controls.Add(dataGridViewTransactions);
            Controls.Add(addTransactionButton);
            Controls.Add(removeTransactionButton);
            Controls.Add(updateTransactionButton);

            ClientSize = new System.Drawing.Size(800, 450);
            Text = "Blockchain Database App";
        }

        private Button CreateButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(180, 23)
            };
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True";
            dbConnection = new SqlConnection(connectionString);
        }

        private void LoadInitialData()
        {
            LoadData("Blocks", dataGridViewBlocks);
            LoadData("Transactions", dataGridViewTransactions);
        }

        private void LoadData(string tableName, DataGridView gridView)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
                connection.Close();
            }
            gridView.DataSource = dt;
        }


        private void addTransactionButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Transactions (SenderAddress, ReceiverAddress, BlockID, Amount, TransactionTimestamp) VALUES (@SenderAddress, @ReceiverAddress, @BlockID, @Amount, @TransactionTimestamp)", connection);

                    // Replace these with actual data collection, e.g., from input fields
                    command.Parameters.AddWithValue("@SenderAddress", 1);
                    command.Parameters.AddWithValue("@ReceiverAddress", 2);
                    command.Parameters.AddWithValue("@BlockID", 1);
                    command.Parameters.AddWithValue("@Amount", 100.00);
                    command.Parameters.AddWithValue("@TransactionTimestamp", DateTime.Now);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Transaction added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add transaction: {ex.Message}");
            }
            finally
            {
                LoadData("Transactions", dataGridViewTransactions); // Refresh data
            }
        }
        private void removeTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this transaction?", "Confirm Deletion!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        int transactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells["TransactionID"].Value);
                        using (var connection = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("DELETE FROM Transactions WHERE TransactionID = @TransactionID", connection);
                            command.Parameters.AddWithValue("@TransactionID", transactionId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Transaction deleted successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete transaction: {ex.Message}");
                    }
                    finally
                    {
                        LoadData("Transactions", dataGridViewTransactions); // Refresh data
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to delete.");
            }
        }
        private void updateTransactionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                try
                {
                    int transactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells["TransactionID"].Value);

                    // Replace these with actual data collection, e.g., from input fields
                    double newAmount = 150.00;  // Example new amount

                    using (var connection = new SqlConnection("Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("UPDATE Transactions SET Amount = @Amount WHERE TransactionID = @TransactionID", connection);
                        command.Parameters.AddWithValue("@TransactionID", transactionId);
                        command.Parameters.AddWithValue("@Amount", newAmount);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Transaction updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update transaction: {ex.Message}");
                }
                finally
                {
                    LoadData("Transactions", dataGridViewTransactions); // Refresh data
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to update.");
            }
        }


    }
}
*/

/*
 * ________________________________________--namespace BlockchainDatabaseApp
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter daBlocks, daTransactions;
        private DataSet dataSet;
        private BindingSource bsBlocks, bsTransactions;
        private DataGridView dataGridViewBlocks;
        private DataGridView dataGridViewTransactions;
        private Button addTransactionButton, removeTransactionButton, updateTransactionButton;

        public Form1()
        {
            InitializeComponent(); 
            InitializeDatabaseComponents();
        }
        private void InitializeDatabaseComponents()
        {
            string connectionString = "Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True";
            this.dbConnection = new SqlConnection(connectionString); // This ensures you are using the class-level variable.
            this.dbConnection.Open();  // Open it here
            string strTransactions = "SELECT * FROM Transactions";
             SqlCommand cmdTransactions = new SqlCommand(strTransactions, dbConnection);
             SqlDataReader reader = cmdTransactions.ExecuteReader();
             while (reader.Read())
             {
                 Console.WriteLine(reader["TransactionID"] + " " + reader["BlockID"] + " " + reader["Amount"] + " " + reader["SenderAddress"] + " " + reader["ReceiverAddress"] + " " + reader["TransactionTimestamp"]);
             }
             reader.Close();
             string strBlocks = "SELECT * FROM Blocks";
             SqlCommand cmdBlocks = new SqlCommand(strBlocks, dbConnection);
             SqlDataReader readerBlocks = cmdBlocks.ExecuteReader();
             while (readerBlocks.Read())
             {
                 Console.WriteLine(readerBlocks["BlockID"] + " " + readerBlocks["Timestamp"]);
             }
             readerBlocks.Close();
        
            string strBlocksTransactions = "SELECT Transactions.TransactionID, Transactions.BlockID, Transactions.Amount, Transactions.SenderAddress,Transactions.ReceiverAddress, Transactions.TransactionTimestamp, Blocks.Timestamp AS BlockTimestamp FROM Transactions INNER JOIN Blocks ON Transactions.BlockID = Blocks.BlockID";
             SqlCommand cmdBlocksTransactions = new SqlCommand(strBlocksTransactions, dbConnection);
            SqlDataReader readerBlocksTransactions = cmdBlocksTransactions.ExecuteReader();
             while (readerBlocksTransactions.Read())
             {
                 Console.WriteLine(readerBlocksTransactions["TransactionID"] + " " + readerBlocksTransactions["BlockID"] + " " + readerBlocksTransactions["Amount"] + " " + readerBlocksTransactions["SenderAddress"] + " " + readerBlocksTransactions["ReceiverAddress"] + " " + readerBlocksTransactions["TransactionTimestamp"] + " " + readerBlocksTransactions["BlockTimestamp"]);
             }
             readerBlocksTransactions.Close();
            // Close the connection
             dbConnection.Close();
             //Initialize the components
            dataGridViewBlocks = new DataGridView();
            dataGridViewTransactions = new DataGridView();
            addTransactionButton = new Button();
            removeTransactionButton = new Button();
            updateTransactionButton = new Button();
            textBox1 = new TextBox();
            // Set up the form
            this.Controls.Add(dataGridViewBlocks);
            this.Controls.Add(dataGridViewTransactions);
            this.Controls.Add(addTransactionButton);
            this.Controls.Add(removeTransactionButton);
            this.Controls.Add(updateTransactionButton);
            this.Controls.Add(textBox1);
            // Set up the DataGridViews
            dataGridViewBlocks.Location = new System.Drawing.Point(10, 10);
            dataGridViewBlocks.Size = new System.Drawing.Size(300, 200);
            dataGridViewTransactions.Location = new System.Drawing.Point(320, 10);
            dataGridViewTransactions.Size = new System.Drawing.Size(300, 200);
            // Set up the buttons
            addTransactionButton.Location = new System.Drawing.Point(10, 220);
            addTransactionButton.Size = new System.Drawing.Size(100, 30);
            addTransactionButton.Text = "Add Transaction";
            addTransactionButton.Click += new System.EventHandler(this.addTransactionButton_Click);
            removeTransactionButton
                .Location = new System.Drawing.Point(120, 220);
            removeTransactionButton.Size = new System.Drawing.Size(100, 30);
            removeTransactionButton.Text = "Remove Transaction";
            removeTransactionButton.Click += new System.EventHandler(this.removeTransactionButton_Click);
            updateTransactionButton
                .Location = new System.Drawing.Point(230, 220);
            updateTransactionButton.Size = new System.Drawing.Size(100, 30);
            updateTransactionButton.Text = "Update Transaction";
            updateTransactionButton.Click += new System.EventHandler(this.updateTransactionButton_Click);
            // Set up the text box
            textBox1.Location = new System.Drawing.Point(340, 220);
            textBox1.Size = new System.Drawing.Size(100, 30);
            // Set up the data components
            InitializeDataComponents();
            LoadData();
            FetchData();
            }
        private void LoadData()
        {
            if (this.dbConnection != null && this.dbConnection.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Transactions", this.dbConnection);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        // Process your data here
                    }
                }
                finally
                {
                    reader.Close();  // Always ensure to close reader
                }
            }
            else
            {
                MessageBox.Show("Database connection is not initialized or is closed.");
            }
        }
        private void FetchData()
        {
            string connectionString = "Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    string query = "SELECT TransactionID, BlockID, Amount, SenderAddress, ReceiverAddress, TransactionTimestamp FROM dbo.Transactions";
                    SqlCommand command = new SqlCommand(query, dbConnection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["TransactionID"]} {reader["BlockID"]} {reader["Amount"]} {reader["SenderAddress"]} {reader["ReceiverAddress"]} {reader["TransactionTimestamp"]}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Error: " + ex.Message);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        private void InitializeDataComponents()
        {
            // Open the connection
            string connectionString = "Data Source=DLLRAZVI;Initial Catalog=Blockchain;Integrated Security=True";
            dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            // Adapters
            daBlocks = new SqlDataAdapter("SELECT * FROM Blocks", dbConnection);
            daTransactions = new SqlDataAdapter("SELECT * FROM Transactions WHERE BlockID = @BlockID", dbConnection);
            daTransactions.SelectCommand.Parameters.Add("@BlockID", SqlDbType.Int);
            try
            {
                // Use parameterized queries to avoid SQL injection and errors
                string query = @"
            SELECT t.TransactionID, t.BlockID, t.Amount, t.SenderAddress, t.ReceiverAddress, t.TransactionTimestamp, b.Timestamp AS BlockTimestamp 
            FROM Transactions t 
            INNER JOIN Blocks b ON t.BlockID = b.BlockID";

                SqlCommand command = new SqlCommand(query, dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TransactionID"]} {reader["BlockID"]} {reader["Amount"]} {reader["SenderAddress"]} {reader["ReceiverAddress"]} {reader["TransactionTimestamp"]} {reader["BlockTimestamp"]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
            // Builders
            SqlCommandBuilder builderTransactions = new SqlCommandBuilder(daTransactions);
            // Data Set
            dataSet = new DataSet();
            // Fill the DataSet with data from Blocks
            daBlocks.Fill(dataSet, "Blocks");
            // Set the primary keys which is important for the DataRelation
            dataSet.Tables["Blocks"].PrimaryKey = new DataColumn[] { dataSet.Tables["Blocks"].Columns["BlockID"] };
            // Binding Sources
            bsBlocks = new BindingSource(dataSet, "Blocks");
            dataGridViewBlocks.DataSource = bsBlocks;
            // Since the Transactions table depends on the selected Block, we initially fill it with a BlockID that does not exist to show an empty grid
            daTransactions.SelectCommand.Parameters["@BlockID"].Value = -1;
            daTransactions.Fill(dataSet, "Transactions");
            bsTransactions = new BindingSource(dataSet, "Transactions");
            dataGridViewTransactions.DataSource = bsTransactions;
        }
        private void dataGridViewBlocks_SelectionChanged(object sender, EventArgs e)
        {
               if (dataGridViewBlocks.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewBlocks.SelectedRows[0];
                int blockID = Convert.ToInt32(selectedRow.Cells["BlockID"].Value);
                // Clear and refill the Transactions DataSet based on the selected Block
                dataSet.Tables["Transactions"].Clear();
                daTransactions.SelectCommand.Parameters["@BlockID"].Value = blockID;
                daTransactions.Fill(dataSet, "Transactions");
            }

        }
        // Helper methods to get data from user inputs
        private int GetCurrentBlockID()
        {
               if (dataGridViewBlocks.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewBlocks.SelectedRows[0].Cells["BlockID"].Value);
            }
               throw new InvalidOperationException("No block selected");

        }
        private decimal GetTransactionAmount()
        {
               // Placeholder for user input retrieval logic
               throw new NotImplementedException();

        }
        private decimal GetUpdatedTransactionAmount()
        {
               // Placeholder for user input retrieval logic
               throw new NotImplementedException();
        }
        private void dataGridViewBlocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void addTransactionButton_Click(object sender, EventArgs e)
        {
               // Add transaction logic

               throw new NotImplementedException();
        }
        private void removeTransactionButton_Click(object sender, EventArgs e)
        {
               // Remove transaction logic

               throw new NotImplementedException();
        }
        private void updateTransactionButton_Click(object sender, EventArgs e)
        {                // Update transaction logic
                         
                                        throw new NotImplementedException();}
        ________________________________________________________________________________*/

/*// Adapters
daBlocks = new SqlDataAdapter("SELECT * FROM Blocks", dbConnection);
daTransactions = new SqlDataAdapter("SELECT * FROM Transactions WHERE BlockID = @BlockID", dbConnection);
daTransactions.SelectCommand.Parameters.Add("@BlockID", SqlDbType.Int);

// Builders
SqlCommandBuilder builderTransactions = new SqlCommandBuilder(daTransactions);

// Data Set
dataSet = new DataSet();

// Fill the DataSet with data from Blocks
daBlocks.Fill(dataSet, "Blocks");

// Set the primary keys which is important for the DataRelation
dataSet.Tables["Blocks"].PrimaryKey = new DataColumn[] { dataSet.Tables["Blocks"].Columns["BlockID"] };

// Binding Sources
bsBlocks = new BindingSource(dataSet, "Blocks");
dataGridViewBlocks.DataSource = bsBlocks;

// Since the Transactions table depends on the selected Block, we initially fill it with a BlockID that does not exist to show an empty grid
daTransactions.SelectCommand.Parameters["@BlockID"].Value = -1;
daTransactions.Fill(dataSet, "Transactions");
bsTransactions = new BindingSource(dataSet, "Transactions");
dataGridViewTransactions.DataSource = bsTransactions;
}

private void dataGridViewBlocks_SelectionChanged(object sender, EventArgs e)
{
if (dataGridViewBlocks.SelectedRows.Count > 0)
{
    DataGridViewRow selectedRow = dataGridViewBlocks.SelectedRows[0];
    int blockID = Convert.ToInt32(selectedRow.Cells["BlockID"].Value);

    // Clear and refill the Transactions DataSet based on the selected Block
    dataSet.Tables["Transactions"].Clear();
    daTransactions.SelectCommand.Parameters["@BlockID"].Value = blockID;
    daTransactions.Fill(dataSet, "Transactions");
}
}

// Helper methods to get data from user inputs
private int GetCurrentBlockID()
{
if (dataGridViewBlocks.SelectedRows.Count > 0)
{
    return Convert.ToInt32(dataGridViewBlocks.SelectedRows[0].Cells["BlockID"].Value);
}
throw new InvalidOperationException("No block selected");
}

private decimal GetTransactionAmount()
{
// Placeholder for user input retrieval logic
throw new NotImplementedException();
}

private decimal GetUpdatedTransactionAmount()
{
// Placeholder for user input retrieval logic
throw new NotImplementedException();
}

private void dataGridViewBlocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void textBox1_TextChanged(object sender, EventArgs e)
{

}

private void addTransactionButton_Click(object sender, EventArgs e)
{
// Add transaction logic
throw new NotImplementedException();
}

private void removeTransactionButton_Click(object sender, EventArgs e)
{
// Remove transaction logic
throw new NotImplementedException();
}

private void updateTransactionButton_Click(object sender, EventArgs e)
{
// Update transaction logic
throw new NotImplementedException();
}

protected override void OnLoad(EventArgs e)
{
base.OnLoad(e);
dataGridViewBlocks.SelectionChanged += new EventHandler(dataGridViewBlocks_SelectionChanged);
// Set up any other event handlers or initialization code here
}
/* private void Form1_Loader(object sender, EventArgs e)
{
 // Assuming you have already created the SqlConnection and opened it.
 SqlDataAdapter adapter = new SqlDataAdapter("SELECT Transactions.TransactionID, Transactions.BlockID, Transactions.Amount, Transactions.SenderAddress, Transactions.ReceiverAddress, Transactions.TransactionTimestamp, Blocks.Timestamp AS BlockTimestamp FROM Transactions INNER JOIN Blocks ON Transactions.BlockID = Blocks.BlockID", dbConnection);
 DataTable dataTable = new DataTable();
 adapter.Fill(dataTable);

 dataGridViewTransactions.DataSource = dataTable;
}
private void dataGridViewTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
 // You can handle cell content click events here if needed
}
}
}*/
