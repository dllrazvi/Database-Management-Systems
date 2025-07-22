using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BlockchainDatabaseApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label blockIDLabel;
            System.Windows.Forms.Label timestampLabel;
            System.Windows.Forms.Label previousBlockHashLabel;
            System.Windows.Forms.Label merkleRootLabel;
            System.Windows.Forms.Label nonceLabel;
            System.Windows.Forms.Label transactionIDLabel;
            System.Windows.Forms.Label blockIDLabel1;
            System.Windows.Forms.Label SenderAddressLabel;
            System.Windows.Forms.Label ReceiverAddressLabel;
            System.Windows.Forms.Label amountLabel;
            System.Windows.Forms.Label transactionTimestampLabel;
            this.dataGridViewBlocks = new System.Windows.Forms.DataGridView();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.addTransactionButton = new System.Windows.Forms.Button();
            this.removeTransactionButton = new System.Windows.Forms.Button();
            this.updateTransactionButton = new System.Windows.Forms.Button();
            this.blockchainDataSet = new DBMSlab1.BlockchainDataSet();
            this.blocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.blocksTableAdapter = new DBMSlab1.BlockchainDataSetTableAdapters.BlocksTableAdapter();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new DBMSlab1.BlockchainDataSetTableAdapters.TransactionsTableAdapter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.blockIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousBlockHashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merkleRootDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blockIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTimestampDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableAdapterManager = new DBMSlab1.BlockchainDataSetTableAdapters.TableAdapterManager();
            this.blockIDTextBox = new System.Windows.Forms.TextBox();
            this.timestampDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.previousBlockHashTextBox = new System.Windows.Forms.TextBox();
            this.merkleRootTextBox = new System.Windows.Forms.TextBox();
            this.nonceTextBox = new System.Windows.Forms.TextBox();
            this.transactionIDTextBox = new System.Windows.Forms.TextBox();
            this.blockIDTextBox1 = new System.Windows.Forms.TextBox();
            this.SenderAddressTextBox = new System.Windows.Forms.TextBox();
            this.ReceiverAddressTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.transactionTimestampDateTimePicker = new System.Windows.Forms.DateTimePicker();
            blockIDLabel = new System.Windows.Forms.Label();
            timestampLabel = new System.Windows.Forms.Label();
            previousBlockHashLabel = new System.Windows.Forms.Label();
            merkleRootLabel = new System.Windows.Forms.Label();
            nonceLabel = new System.Windows.Forms.Label();
            transactionIDLabel = new System.Windows.Forms.Label();
            blockIDLabel1 = new System.Windows.Forms.Label();
            SenderAddressLabel = new System.Windows.Forms.Label();
            ReceiverAddressLabel = new System.Windows.Forms.Label();
            amountLabel = new System.Windows.Forms.Label();
            transactionTimestampLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockchainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBlocks
            // 
            this.dataGridViewBlocks.AccessibleName = "Blockchain";
            this.dataGridViewBlocks.AutoGenerateColumns = false;
            this.dataGridViewBlocks.ColumnHeadersHeight = 29;
            this.dataGridViewBlocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transactionIDDataGridViewTextBoxColumn1,
            this.blockIDDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.amountDataGridViewTextBoxColumn1,
            this.transactionTimestampDataGridViewTextBoxColumn1});
            this.dataGridViewBlocks.DataSource = this.transactionsBindingSource;
            this.dataGridViewBlocks.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewBlocks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBlocks.Name = "dataGridViewBlocks";
            this.dataGridViewBlocks.RowHeadersWidth = 51;
            this.dataGridViewBlocks.Size = new System.Drawing.Size(943, 163);
            this.dataGridViewBlocks.TabIndex = 0;
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AutoGenerateColumns = false;
            this.dataGridViewTransactions.ColumnHeadersHeight = 29;
            this.dataGridViewTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.blockIDDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn,
            this.previousBlockHashDataGridViewTextBoxColumn,
            this.merkleRootDataGridViewTextBoxColumn,
            this.nonceDataGridViewTextBoxColumn});
            this.dataGridViewTransactions.DataSource = this.blocksBindingSource;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(0, 380);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.RowHeadersWidth = 51;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(943, 150);
            this.dataGridViewTransactions.TabIndex = 1;
            // 
            // addTransactionButton
            // 
            this.addTransactionButton.Location = new System.Drawing.Point(0, 0);
            this.addTransactionButton.Name = "addTransactionButton";
            this.addTransactionButton.Size = new System.Drawing.Size(75, 23);
            this.addTransactionButton.TabIndex = 2;
            this.addTransactionButton.Text = "Add Transaction";
            // 
            // removeTransactionButton
            // 
            this.removeTransactionButton.Location = new System.Drawing.Point(0, 0);
            this.removeTransactionButton.Name = "removeTransactionButton";
            this.removeTransactionButton.Size = new System.Drawing.Size(75, 23);
            this.removeTransactionButton.TabIndex = 3;
            this.removeTransactionButton.Text = "Remove Transaction";
            // 
            // updateTransactionButton
            // 
            this.updateTransactionButton.Location = new System.Drawing.Point(0, 0);
            this.updateTransactionButton.Name = "updateTransactionButton";
            this.updateTransactionButton.Size = new System.Drawing.Size(75, 23);
            this.updateTransactionButton.TabIndex = 4;
            this.updateTransactionButton.Text = "Update Transaction";
            // 
            // blockchainDataSet
            // 
            this.blockchainDataSet.DataSetName = "BlockchainDataSet";
            this.blockchainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // blocksBindingSource
            // 
            this.blocksBindingSource.DataMember = "Blocks";
            this.blocksBindingSource.DataSource = this.blockchainDataSet;
            this.blocksBindingSource.CurrentChanged += new System.EventHandler(this.blocksBindingSource_CurrentChanged);
            // 
            // blocksTableAdapter
            // 
            this.blocksTableAdapter.ClearBeforeFill = true;
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.blockchainDataSet;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // blockIDDataGridViewTextBoxColumn
            // 
            this.blockIDDataGridViewTextBoxColumn.DataPropertyName = "BlockID";
            this.blockIDDataGridViewTextBoxColumn.HeaderText = "BlockID";
            this.blockIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.blockIDDataGridViewTextBoxColumn.Name = "blockIDDataGridViewTextBoxColumn";
            this.blockIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.blockIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            this.timestampDataGridViewTextBoxColumn.Width = 125;
            // 
            // previousBlockHashDataGridViewTextBoxColumn
            // 
            this.previousBlockHashDataGridViewTextBoxColumn.DataPropertyName = "PreviousBlockHash";
            this.previousBlockHashDataGridViewTextBoxColumn.HeaderText = "PreviousBlockHash";
            this.previousBlockHashDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.previousBlockHashDataGridViewTextBoxColumn.Name = "previousBlockHashDataGridViewTextBoxColumn";
            this.previousBlockHashDataGridViewTextBoxColumn.Width = 125;
            // 
            // merkleRootDataGridViewTextBoxColumn
            // 
            this.merkleRootDataGridViewTextBoxColumn.DataPropertyName = "MerkleRoot";
            this.merkleRootDataGridViewTextBoxColumn.HeaderText = "MerkleRoot";
            this.merkleRootDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.merkleRootDataGridViewTextBoxColumn.Name = "merkleRootDataGridViewTextBoxColumn";
            this.merkleRootDataGridViewTextBoxColumn.Width = 125;
            // 
            // nonceDataGridViewTextBoxColumn
            // 
            this.nonceDataGridViewTextBoxColumn.DataPropertyName = "Nonce";
            this.nonceDataGridViewTextBoxColumn.HeaderText = "Nonce";
            this.nonceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nonceDataGridViewTextBoxColumn.Name = "nonceDataGridViewTextBoxColumn";
            this.nonceDataGridViewTextBoxColumn.Width = 125;
            // 
            // transactionIDDataGridViewTextBoxColumn1
            // 
            this.transactionIDDataGridViewTextBoxColumn1.DataPropertyName = "TransactionID";
            this.transactionIDDataGridViewTextBoxColumn1.HeaderText = "TransactionID";
            this.transactionIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.transactionIDDataGridViewTextBoxColumn1.Name = "transactionIDDataGridViewTextBoxColumn1";
            this.transactionIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.transactionIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // blockIDDataGridViewTextBoxColumn2
            // 
            this.blockIDDataGridViewTextBoxColumn2.DataPropertyName = "BlockID";
            this.blockIDDataGridViewTextBoxColumn2.HeaderText = "BlockID";
            this.blockIDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.blockIDDataGridViewTextBoxColumn2.Name = "blockIDDataGridViewTextBoxColumn2";
            this.blockIDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SenderAddress";
            this.dataGridViewTextBoxColumn1.HeaderText = "SenderAddress";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ReceiverAddress";
            this.dataGridViewTextBoxColumn2.HeaderText = "ReceiverAddress";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // amountDataGridViewTextBoxColumn1
            // 
            this.amountDataGridViewTextBoxColumn1.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.amountDataGridViewTextBoxColumn1.Name = "amountDataGridViewTextBoxColumn1";
            this.amountDataGridViewTextBoxColumn1.Width = 125;
            // 
            // transactionTimestampDataGridViewTextBoxColumn1
            // 
            this.transactionTimestampDataGridViewTextBoxColumn1.DataPropertyName = "TransactionTimestamp";
            this.transactionTimestampDataGridViewTextBoxColumn1.HeaderText = "TransactionTimestamp";
            this.transactionTimestampDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.transactionTimestampDataGridViewTextBoxColumn1.Name = "transactionTimestampDataGridViewTextBoxColumn1";
            this.transactionTimestampDataGridViewTextBoxColumn1.Width = 125;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BlocksTableAdapter = this.blocksTableAdapter;
            this.tableAdapterManager.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UpdateOrder = DBMSlab1.BlockchainDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // blockIDLabel
            // 
            blockIDLabel.AutoSize = true;
            blockIDLabel.Location = new System.Drawing.Point(546, 186);
            blockIDLabel.Name = "blockIDLabel";
            blockIDLabel.Size = new System.Drawing.Size(60, 16);
            blockIDLabel.TabIndex = 6;
            blockIDLabel.Text = "Block ID:";
            // 
            // blockIDTextBox
            // 
            this.blockIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blocksBindingSource, "BlockID", true));
            this.blockIDTextBox.Location = new System.Drawing.Point(687, 183);
            this.blockIDTextBox.Name = "blockIDTextBox";
            this.blockIDTextBox.Size = new System.Drawing.Size(200, 22);
            this.blockIDTextBox.TabIndex = 7;
            // 
            // timestampLabel
            // 
            timestampLabel.AutoSize = true;
            timestampLabel.Location = new System.Drawing.Point(546, 215);
            timestampLabel.Name = "timestampLabel";
            timestampLabel.Size = new System.Drawing.Size(78, 16);
            timestampLabel.TabIndex = 8;
            timestampLabel.Text = "Timestamp:";
            // 
            // timestampDateTimePicker
            // 
            this.timestampDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.blocksBindingSource, "Timestamp", true));
            this.timestampDateTimePicker.Location = new System.Drawing.Point(687, 211);
            this.timestampDateTimePicker.Name = "timestampDateTimePicker";
            this.timestampDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.timestampDateTimePicker.TabIndex = 9;
            // 
            // previousBlockHashLabel
            // 
            previousBlockHashLabel.AutoSize = true;
            previousBlockHashLabel.Location = new System.Drawing.Point(546, 242);
            previousBlockHashLabel.Name = "previousBlockHashLabel";
            previousBlockHashLabel.Size = new System.Drawing.Size(135, 16);
            previousBlockHashLabel.TabIndex = 10;
            previousBlockHashLabel.Text = "Previous Block Hash:";
            // 
            // previousBlockHashTextBox
            // 
            this.previousBlockHashTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blocksBindingSource, "PreviousBlockHash", true));
            this.previousBlockHashTextBox.Location = new System.Drawing.Point(687, 239);
            this.previousBlockHashTextBox.Name = "previousBlockHashTextBox";
            this.previousBlockHashTextBox.Size = new System.Drawing.Size(200, 22);
            this.previousBlockHashTextBox.TabIndex = 11;
            // 
            // merkleRootLabel
            // 
            merkleRootLabel.AutoSize = true;
            merkleRootLabel.Location = new System.Drawing.Point(546, 270);
            merkleRootLabel.Name = "merkleRootLabel";
            merkleRootLabel.Size = new System.Drawing.Size(83, 16);
            merkleRootLabel.TabIndex = 12;
            merkleRootLabel.Text = "Merkle Root:";
            // 
            // merkleRootTextBox
            // 
            this.merkleRootTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blocksBindingSource, "MerkleRoot", true));
            this.merkleRootTextBox.Location = new System.Drawing.Point(687, 267);
            this.merkleRootTextBox.Name = "merkleRootTextBox";
            this.merkleRootTextBox.Size = new System.Drawing.Size(200, 22);
            this.merkleRootTextBox.TabIndex = 13;
            // 
            // nonceLabel
            // 
            nonceLabel.AutoSize = true;
            nonceLabel.Location = new System.Drawing.Point(546, 298);
            nonceLabel.Name = "nonceLabel";
            nonceLabel.Size = new System.Drawing.Size(50, 16);
            nonceLabel.TabIndex = 14;
            nonceLabel.Text = "Nonce:";
            // 
            // nonceTextBox
            // 
            this.nonceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blocksBindingSource, "Nonce", true));
            this.nonceTextBox.Location = new System.Drawing.Point(687, 295);
            this.nonceTextBox.Name = "nonceTextBox";
            this.nonceTextBox.Size = new System.Drawing.Size(200, 22);
            this.nonceTextBox.TabIndex = 15;
            // 
            // transactionIDLabel
            // 
            transactionIDLabel.AutoSize = true;
            transactionIDLabel.Location = new System.Drawing.Point(25, 189);
            transactionIDLabel.Name = "transactionIDLabel";
            transactionIDLabel.Size = new System.Drawing.Size(97, 16);
            transactionIDLabel.TabIndex = 16;
            transactionIDLabel.Text = "Transaction ID:";
            // 
            // transactionIDTextBox
            // 
            this.transactionIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionsBindingSource, "TransactionID", true));
            this.transactionIDTextBox.Location = new System.Drawing.Point(183, 186);
            this.transactionIDTextBox.Name = "transactionIDTextBox";
            this.transactionIDTextBox.Size = new System.Drawing.Size(200, 22);
            this.transactionIDTextBox.TabIndex = 17;
            // 
            // blockIDLabel1
            // 
            blockIDLabel1.AutoSize = true;
            blockIDLabel1.Location = new System.Drawing.Point(25, 217);
            blockIDLabel1.Name = "blockIDLabel1";
            blockIDLabel1.Size = new System.Drawing.Size(60, 16);
            blockIDLabel1.TabIndex = 18;
            blockIDLabel1.Text = "Block ID:";
            // 
            // blockIDTextBox1
            // 
            this.blockIDTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionsBindingSource, "BlockID", true));
            this.blockIDTextBox1.Location = new System.Drawing.Point(183, 214);
            this.blockIDTextBox1.Name = "blockIDTextBox1";
            this.blockIDTextBox1.Size = new System.Drawing.Size(200, 22);
            this.blockIDTextBox1.TabIndex = 19;
            // 
            // SenderAddressLabel
            // 
            SenderAddressLabel.AutoSize = true;
            SenderAddressLabel.Location = new System.Drawing.Point(25, 245);
            SenderAddressLabel.Name = "SenderAddressLabel";
            SenderAddressLabel.Size = new System.Drawing.Size(121, 16);
            SenderAddressLabel.TabIndex = 20;
            SenderAddressLabel.Text = "Sender Account ID:";
            // 
            // SenderAddressTextBox
            // 
            this.SenderAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionsBindingSource, "SenderAddress", true));
            this.SenderAddressTextBox.Location = new System.Drawing.Point(183, 242);
            this.SenderAddressTextBox.Name = "SenderAddressTextBox";
            this.SenderAddressTextBox.Size = new System.Drawing.Size(200, 22);
            this.SenderAddressTextBox.TabIndex = 21;
            // 
            // ReceiverAddressLabel
            // 
            ReceiverAddressLabel.AutoSize = true;
            ReceiverAddressLabel.Location = new System.Drawing.Point(25, 273);
            ReceiverAddressLabel.Name = "ReceiverAddressLabel";
            ReceiverAddressLabel.Size = new System.Drawing.Size(132, 16);
            ReceiverAddressLabel.TabIndex = 22;
            ReceiverAddressLabel.Text = "Receiver Account ID:";
            // 
            // ReceiverAddressTextBox
            // 
            this.ReceiverAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionsBindingSource, "ReceiverAddress", true));
            this.ReceiverAddressTextBox.Location = new System.Drawing.Point(183, 270);
            this.ReceiverAddressTextBox.Name = "ReceiverAddressTextBox";
            this.ReceiverAddressTextBox.Size = new System.Drawing.Size(200, 22);
            this.ReceiverAddressTextBox.TabIndex = 23;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new System.Drawing.Point(25, 301);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new System.Drawing.Size(55, 16);
            amountLabel.TabIndex = 24;
            amountLabel.Text = "Amount:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionsBindingSource, "Amount", true));
            this.amountTextBox.Location = new System.Drawing.Point(183, 298);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(200, 22);
            this.amountTextBox.TabIndex = 25;
            // 
            // transactionTimestampLabel
            // 
            transactionTimestampLabel.AutoSize = true;
            transactionTimestampLabel.Location = new System.Drawing.Point(25, 330);
            transactionTimestampLabel.Name = "transactionTimestampLabel";
            transactionTimestampLabel.Size = new System.Drawing.Size(152, 16);
            transactionTimestampLabel.TabIndex = 26;
            transactionTimestampLabel.Text = "Transaction Timestamp:";
            // 
            // transactionTimestampDateTimePicker
            // 
            this.transactionTimestampDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.transactionsBindingSource, "TransactionTimestamp", true));
            this.transactionTimestampDateTimePicker.Location = new System.Drawing.Point(183, 326);
            this.transactionTimestampDateTimePicker.Name = "transactionTimestampDateTimePicker";
            this.transactionTimestampDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.transactionTimestampDateTimePicker.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 530);
            this.Controls.Add(transactionIDLabel);
            this.Controls.Add(this.transactionIDTextBox);
            this.Controls.Add(blockIDLabel1);
            this.Controls.Add(this.blockIDTextBox1);
            this.Controls.Add(SenderAddressLabel);
            this.Controls.Add(this.SenderAddressTextBox);
            this.Controls.Add(ReceiverAddressLabel);
            this.Controls.Add(this.ReceiverAddressTextBox);
            this.Controls.Add(amountLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(transactionTimestampLabel);
            this.Controls.Add(this.transactionTimestampDateTimePicker);
            this.Controls.Add(blockIDLabel);
            this.Controls.Add(this.blockIDTextBox);
            this.Controls.Add(timestampLabel);
            this.Controls.Add(this.timestampDateTimePicker);
            this.Controls.Add(previousBlockHashLabel);
            this.Controls.Add(this.previousBlockHashTextBox);
            this.Controls.Add(merkleRootLabel);
            this.Controls.Add(this.merkleRootTextBox);
            this.Controls.Add(nonceLabel);
            this.Controls.Add(this.nonceTextBox);
            this.Controls.Add(this.dataGridViewBlocks);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Controls.Add(this.addTransactionButton);
            this.Controls.Add(this.removeTransactionButton);
            this.Controls.Add(this.updateTransactionButton);
            this.Name = "Form1";
            this.Text = "Blockchain";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockchainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void blocksBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Transactions.TransactionID, Transactions.BlockID, Transactions.Amount,  Transactions.TransactionTimestamp, Blocks.Timestamp AS BlockTimestamp FROM Transactions INNER JOIN Blocks ON Transactions.BlockID = Blocks.BlockID", dbConnection);
            DataTable dataTable = new DataTable();
            int v = adapter.Fill(dataTable);

            dataGridViewTransactions.DataSource = dataTable;
        }

        #endregion
        private DBMSlab1.BlockchainDataSet blockchainDataSet;
        private BindingSource blocksBindingSource;
        private DBMSlab1.BlockchainDataSetTableAdapters.BlocksTableAdapter blocksTableAdapter;
        private BindingSource transactionsBindingSource;
        private DBMSlab1.BlockchainDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private DataGridViewTextBoxColumn senderAddressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn receiverAddressDataGridViewTextBoxColumn;
        private ContextMenuStrip contextMenuStrip1;
        private DataGridViewTextBoxColumn blockIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn previousBlockHashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn merkleRootDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nonceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn transactionIDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn blockIDDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn transactionTimestampDataGridViewTextBoxColumn1;
        private DBMSlab1.BlockchainDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private TextBox blockIDTextBox;
        private DateTimePicker timestampDateTimePicker;
        private TextBox previousBlockHashTextBox;
        private TextBox merkleRootTextBox;
        private TextBox nonceTextBox;
        private TextBox transactionIDTextBox;
        private TextBox blockIDTextBox1;
        private TextBox SenderAddressTextBox;
        private TextBox ReceiverAddressTextBox;
        private TextBox amountTextBox;
        private DateTimePicker transactionTimestampDateTimePicker;
    }
}

