using BLApi;
using BO;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            maxWeightComboBox.ItemsSource = Enum.GetValues(typeof(BO.Weights));
            button2.IsEnabled = false;
            batteryTextBox.IsEnabled = false;
            locationTextBox.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            
        }

        public DroneWindow(BO.Drone dr) // the constructer to update the drone 
        {
            InitializeComponent();
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.DroneStatus));
            maxWeightComboBox.ItemsSource = Enum.GetValues(typeof(BO.Weights));
            button.IsEnabled = false;
            idTextBox.IsEnabled = false;
            batteryTextBox.IsEnabled = false;
            maxWeightComboBox.IsEnabled = false;
            statusComboBox.IsEnabled = false;
            drone = dr;
            DataContext = drone;
            parcelgrid.IsEnabled = false;
        }
        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DroneStatus status = (DroneStatus)statusComboBox.SelectedItem;
        }

        public Drone Drone { get => drone; }

        private void button_Click1(object sender, RoutedEventArgs e) // cancel button
        {
            Close();
        }
        private void button_Click(object sender, RoutedEventArgs e) //  adding
        {
          try
           {
                bl.AddDrone(drone);
           }
            catch (Exception)
            {

                MessageBox.Show("couldn't add the drone because this Id allready exists in the system");
          }
            MessageBox.Show(drone.ToString());
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            grid1.DataContext = drone;
            MessageBox.Show("Drone was updated");
            Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.SendDroneToCharge(drone.Id);
            }
            catch
            {
                MessageBox.Show("Drone couldn't be charged");
                return;
            }
            MessageBox.Show($"Drone {drone.Id} was send to charge");
        }


        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int p=0;
            try
            {
                p= bl.MatchDroneToParcel(drone.Id);
            }
            catch
            {
                MessageBox.Show($"Drone {drone.Id} was not matched");
                return;
            }
            parcelgrid.Visibility = Visibility.Visible;
           parcelgrid.DataContext= bl.GetParcel(p);
        }
    }
}
