using System;
using System.Windows;
using System.Windows.Controls;
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
