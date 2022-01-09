
using IBL;
using System;
using System.Windows;
using System.Windows.Controls;
using BO;
using BLApi;
using System.Collections.ObjectModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for ListDroneWindow.xaml
    /// </summary>
    public partial class ListDroneWindow : Window
    {
        IBl bL;
        public ListDroneWindow(IBl iBL)
        {
            InitializeComponent();
            this.bL = iBL;
            cmbStatus.ItemsSource = Enum.GetValues(typeof(BO.DroneStatus));
            cmbMaxWeight.ItemsSource= Enum.GetValues(typeof(BO.Weights));
            droneDataGrid.DataContext = bL.DisplayDronelst();
            droneDataGrid.IsReadOnly = true;
        }



        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
        
            }
            else
            {
                DroneStatus status = (DroneStatus)cmbStatus.SelectedItem;
            }

        }

        private void cmbMaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Weights w = (Weights)cmbMaxWeight.SelectedItem;
            MessageBox.Show(cmbMaxWeight.SelectedItem.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e) //button to add a drone
        {
            DroneWindow wnd = new DroneWindow(bL);
            wnd.Show();
        }



        private void droneDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Updateddronebtn_Click(object sender, RoutedEventArgs e)
        {
            Drone d = (droneDataGrid.SelectedItem as Drone);
            if (d != null)
            {
                DroneWindow w = new DroneWindow(d);
                w.Show();
            }
        }

        private void droneDataGrid_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    
