using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Payables.Data
{
    public class PayablesDB
    {
        public static SqlConnection GetConnection()
        {
            //string connectionString = 
            //  "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Payables;Integrated Security=true";
            //SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            //stringBuilder.DataSource = "(localdb)\\mssqllocaldb";
            //stringBuilder.InitialCatalog = "Payables";
            //stringBuilder.IntegratedSecurity = true;

            string connectionString = 
                System.Configuration.ConfigurationManager.ConnectionStrings["payablesConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
