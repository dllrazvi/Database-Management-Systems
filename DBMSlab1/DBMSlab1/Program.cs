using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BlockchainDatabaseApp;
namespace DBMSlab1
{
    internal static class Program
    {
    
        [STAThread]
        static void Main()
        {
            /*string connectionString = "Data Source=DESKTOP-5QKQ9R5;Initial Catalog=Blockchain;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
