using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payables.Data
{
    public class InvoicesRepository //public
    {
        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoiceList = new List<Invoice>();

            //1) connection object -> PayablesDB.cs
            //2) connection open
            SqlConnection connection = PayablesDB.GetConnection();
            try
            {
                connection.Open();
            }
            catch (SqlException se)
            {

            }
            finally
            {
                connection.Close();
            }
            return invoiceList;
        }
    }
}
