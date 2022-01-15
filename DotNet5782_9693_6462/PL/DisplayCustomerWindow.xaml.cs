using BLApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for DisplayCustomerWindow.xaml
    /// </summary>
    public partial class DisplayCustomerWindow : Window
    {
        IBl bl;
        BO.Customer customer;
        public DisplayCustomerWindow(IBl Bl)
        {
            customer = new BO.Customer();
            this.bl = Bl;
            DataContext = customer;
            InitializeComponent();

        }

        private void Button_Click_cancle(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = customer;
            MessageBox.Show("Customer was updated");
            Close();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(customer.ToString());
            Close();
        }
    }
}
