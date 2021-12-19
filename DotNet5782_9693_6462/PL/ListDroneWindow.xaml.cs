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
using IBL.BO;
using BL;
using BO;

namespace PL
{
    /// <summary>
    /// Interaction logic for ListDroneWindow.xaml
    /// </summary>
    public partial  class ListDroneWindow : Window
    {
        IBl bL;
        public ListDroneWindow(IBl iBL)
        {
            this.bL = iBL;
            InitializeComponent();
            cmbStatus.ItemsSource = Enum.GetValues(typeof(IBl BO.DroneStatus));
        }

       

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
