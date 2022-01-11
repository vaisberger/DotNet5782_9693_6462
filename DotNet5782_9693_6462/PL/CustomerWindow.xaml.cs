using BLApi;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        IBl mybl;
        //private ObservableCollection<Customer> customers =
          //  new ObservableCollection<Customer>();
        public CustomerWindow(IBl bl)
        {
            InitializeComponent();
            this.mybl = bl;
            customerDataGrid.DataContext = mybl.DisplayCustomerlst();

        }

       

            /* private int counter = 0;
             private void Button_Click(object sender, RoutedEventArgs e)
             {
                 ++counter;
                 _myCollection.Add(
                     new MyData()
                     {
                         FirstName = "item " + counter,
                         LastName = "item " + counter,
                         IsLecturer = counter % 3 == 0
                     });
             }
         }
     }*/
        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)//Add more customer
        {

            //customers.Add(
               // new Customer
               // {
                 //   Id = 7887,
                  //  Name = "bbbb"
               // });
            DisplayCustomerWindow dcw = new DisplayCustomerWindow(mybl);
            dcw.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CustomerDataGrid_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

    /*IBl mybl;
    public CustomerWindow(IBl mybl)
    {
        InitializeComponent();
        /*for (int i = 0; i < 10; ++i)
        {
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = "Item " + i;
            newItem.Content = "";
            listBox.Items.Add(newItem);
        }*/

