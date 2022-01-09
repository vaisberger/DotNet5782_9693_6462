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
        IBl mybl;
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
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
        }
    }

        

        
}
