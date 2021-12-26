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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IBL;
using BO;
using BLApi;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBl mybl;
        public MainWindow()
        {
           // mybl = new BlFactory.GetBl();
           InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListDroneWindow wnd = new ListDroneWindow(mybl);
            wnd.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DroneWindow wnd = new DroneWindow();
            bool? result=wnd.ShowDialog();
            if(result != null)
            {
               MessageBox.Show( wnd.Drone.ToString());
            }
        }
    }
}
