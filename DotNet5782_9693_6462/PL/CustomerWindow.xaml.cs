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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        IBl bl;
       
        BO.CustonerList customer;
        public CustomerWindow( IBl BL)//Add
        {
            customer = new BO.CustonerList();
            this.bl = BL;
            DataContext = customer;
            InitializeComponent();
            ButtonUpdate.Visibility = Visibility.Collapsed;
           
        }
       
        public CustomerWindow(BO.CustonerList c ,IBl BL)//Update
        {
            customer = c;
            DataContext = customer;
            this.bl = BL;
            InitializeComponent();
            ButtonAdd.Visibility = Visibility.Collapsed;

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bl.AddCustomer(customer);
            }
            catch
            {
                MessageBox.Show("couldn't add the Customer because this Id allready exists in the system");
            }
            MessageBox.Show(customer.ToString());

            Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //bl.UpdateCustomer(customer);
            }
            catch
            {
                return;
            }

            MessageBox.Show("yes");
        }
    }
}
