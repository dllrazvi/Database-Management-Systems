using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace DBMSpractic
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter adapterNeighborhoods, adapterSmartHomes;
        private DataSet dataSet;
        private BindingSource bsNeighborhoods, bsSmartHomes;
        private DataGridView dgvNeighborhoods, dgvSmartHomes;
        private Button btnSaveChanges, btnAddSmartHome, btnDeleteSmartHome, btnUpdateSmartHome;

        public Form1()
        {
            InitializeComponents();
            InitializeDatabaseConnection();
            SetupDataAdaptersAndBindings();
        }

        private void InitializeComponents()
        {
            this.dgvNeighborhoods = new DataGridView { Dock = DockStyle.Top };
            this.dgvSmartHomes = new DataGridView { Dock = DockStyle.Fill };
            this.btnSaveChanges = new Button { Text = "Save Changes", Dock = DockStyle.Bottom };
            this.btnAddSmartHome = new Button { Text = "Add Smart Home", Dock = DockStyle.Bottom };
            this.btnDeleteSmartHome = new Button { Text = "Delete Smart Home", Dock = DockStyle.Bottom };
            this.btnUpdateSmartHome = new Button { Text = "Update Smart Home", Dock = DockStyle.Bottom };

            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnAddSmartHome);
            this.Controls.Add(this.btnDeleteSmartHome);
            this.Controls.Add(this.btnUpdateSmartHome);
            this.Controls.Add(this.dgvSmartHomes);
            this.Controls.Add(this.dgvNeighborhoods);

            this.btnSaveChanges.Click += new EventHandler(btnSaveChanges_Click);
            this.btnAddSmartHome.Click += new EventHandler(btnAddSmartHome_Click);
            this.btnDeleteSmartHome.Click += new EventHandler(btnDeleteSmartHome_Click);
            this.btnUpdateSmartHome.Click += new EventHandler(btnUpdateSmartHome_Click);

            this.Text = "Smart Homes Management";
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            dbConnection = new SqlConnection(connectionString);
        }

        private void SetupDataAdaptersAndBindings()
        {
            adapterNeighborhoods = new SqlDataAdapter("SELECT * FROM Neighborhoods", dbConnection);
            adapterSmartHomes = new SqlDataAdapter("SELECT * FROM SmartHomes", dbConnection);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapterSmartHomes);

            dataSet = new DataSet();
            adapterNeighborhoods.Fill(dataSet, "Neighborhoods");
            adapterSmartHomes.Fill(dataSet, "SmartHomes");

            bsNeighborhoods = new BindingSource(dataSet, "Neighborhoods");
            bsSmartHomes = new BindingSource(dataSet, "SmartHomes");

            dgvNeighborhoods.DataSource = bsNeighborhoods;
            dgvSmartHomes.DataSource = bsSmartHomes;

            DataRelation relation = new DataRelation("NeighborhoodSmartHomes",
                dataSet.Tables["Neighborhoods"].Columns["NeighborhoodID"],
                dataSet.Tables["SmartHomes"].Columns["NeighborhoodID"]);
            dataSet.Relations.Add(relation);

            bsSmartHomes.Filter = "NeighborhoodID = -1"; // Initially, no smart homes are shown
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            adapterSmartHomes.Update(dataSet, "SmartHomes");
            MessageBox.Show("Changes saved successfully!");
        }

        private void btnAddSmartHome_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataSet.Tables["SmartHomes"].NewRow();
            newRow["Name"] = "New Home";
            newRow["Address"] = "New Address";
            newRow["NeighborhoodID"] = Convert.ToInt32(dgvNeighborhoods.CurrentRow.Cells["NeighborhoodID"].Value);
            dataSet.Tables["SmartHomes"].Rows.Add(newRow);
        }

        private void btnDeleteSmartHome_Click(object sender, EventArgs e)
        {
            if (dgvSmartHomes.CurrentRow != null)
            {
                dgvSmartHomes.Rows.Remove(dgvSmartHomes.CurrentRow);
            }
        }


        private void btnUpdateSmartHome_Click(object sender, EventArgs e)
        {
            if (dgvSmartHomes.CurrentRow != null)
            {
                dgvSmartHomes.CurrentRow.Cells["Name"].Value = "Updated Home";
            }
        }
    }
}
