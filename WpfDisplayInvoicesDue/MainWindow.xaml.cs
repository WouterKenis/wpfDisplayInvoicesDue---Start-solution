using System;
using System.Collections.Generic;
using System.Windows;
using Payables.Data;

namespace WpfDisplayInvoicesDue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                //TODO: retrieve invoices due from data layer

                //TODO: show a message box when no invoiced are due and close the application              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                Close();
            }
        }
    }
}
