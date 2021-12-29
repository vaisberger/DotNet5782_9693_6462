using BLApi;
using BO;
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
    /// Interaction logic for DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        IBl bl;
        BO.Drone drone;
        public DroneWindow(IBl Bl) // add a drone 
        {
            drone = new BO.Drone();
            this.bl = Bl;
            DataContext = drone;
            InitializeComponent();
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.DroneStatus));
        }

        public DroneWindow(BO.Drone dr) // the constructer to update the drone 
        {
            this.drone = dr;
            DataContext = drone;
            InitializeComponent();
        }
        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DroneStatus status = (DroneStatus)statusComboBox.SelectedItem;
            MessageBox.Show(statusComboBox.SelectedItem.ToString());
        }

        public Drone Drone { get => drone; }

        private void button_Click1(object sender, RoutedEventArgs e) // add button
        {
            Close();
        }
        private void button_Click(object sender, RoutedEventArgs e) // cancel adding
        {
            bl.AddDrone(drone);
        }
    }
}
