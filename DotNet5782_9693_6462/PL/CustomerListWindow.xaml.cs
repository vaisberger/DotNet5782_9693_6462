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
    /// Interaction logic for CustomerListWindow.xaml
    /// </summary>
    public partial class CustomerListWindow : Window
    {
        IBl bl;
        public CustomerListWindow(IBl BL)
        {
           
            InitializeComponent();
            this.bl = BL;
            customerDataGrid.DataContext = bl.DisplayCustomerlst();
            customerDataGrid.IsReadOnly = true;
          

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new CustomerWindow(bl).ShowDialog();
            customerDataGrid.ItemsSource = bl.DisplayCustomerlst();

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonUpdated_Click(object sender, RoutedEventArgs e)
        {
            BO.CustonerList p = (customerDataGrid.SelectedItem as BO.CustonerList);
            if (p != null)
            {
              
                new CustomerWindow(p, bl).ShowDialog();
                customerDataGrid.ItemsSource = bl.DisplayCustomerlst();
            }
        }
    }
   

}
