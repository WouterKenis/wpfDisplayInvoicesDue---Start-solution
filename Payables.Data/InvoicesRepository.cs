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
            //3) sqlcommand
            //4) execute sqlcommand
            SqlConnection connection = PayablesDB.GetConnection();

            string selectInvoices = "SELECT * FROM Invoices"; // kan nog een ander select statement achter
                                                              // met ; na 'invoices'


            //ExecuteReader geeft verschillende records
            //ExecuteScalar geeft een getal
            //ExecuteNonQuery past iets aan
            SqlCommand selectInvoicesCommand = new SqlCommand(selectInvoices, connection);

            SqlDataReader reader = null;
            
            try
            {
                connection.Open();
                
                reader = selectInvoicesCommand.ExecuteReader();

                int indexInvoiceNumber = reader.GetOrdinal("InvoiceNumber");
                int indexInvoiceDate = reader.GetOrdinal("InvoiceDate");
                int indexInvoiceDueDate = reader.GetOrdinal("InvoiceDueDate");
                int indexCreditTotal = reader.GetOrdinal("CreditTotal");
                int indexPaymentTotal = reader.GetOrdinal("PaymentTotal");
                int indexInvoiceTotal = reader.GetOrdinal("InvoiceTotal");

                while (reader.Read())
                {

                    Invoice invoice = new Invoice();
                    invoice.InvoiceNumber = reader[indexInvoiceNumber].ToString();
                    // of reader.GetString(indexInvoiceNumber);
                    // of reader["InvoiceNumber"].ToString()
                    invoice.InvoiceDate = reader.GetDateTime(indexInvoiceDate);
                    invoice.DueDate = reader.GetDateTime(indexInvoiceDueDate);
                    invoice.CreditTotal = reader.GetDecimal(indexCreditTotal);
                    invoice.PaymentTotal = reader.GetDecimal(indexPaymentTotal);
                    invoice.InvoiceTotal = reader.GetDecimal(indexInvoiceTotal);

                    invoiceList.Add(invoice);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return invoiceList;
        }
    }
}
