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
    /// Interaction logic for BaseStationListWindow.xaml
    /// </summary>
    public partial class BaseStationListWindow : Window
    {
        IBl bl;

        public BaseStationListWindow(IBl BL)
        {
            InitializeComponent();
            this.bl = BL;
            //ComboBoxFilteringStation.ItemsSource = Enum.GetValues(typeof(Vi));
            baseStationDataGrid.DataContext = bl.DisplayBaseStationlst();
            baseStationDataGrid.IsReadOnly = true;
        }

        /*public ListParcelWindow(IBl BL)
        {
            InitializeComponent();
            this.bl = BL;
            datecmb.ItemsSource = Enum.GetValues(typeof(Date));
            prioritycmb.ItemsSource = Enum.GetValues(typeof(BO.Priorities));
            weightcmb.ItemsSource = Enum.GetValues(typeof(BO.Weights));
            parcelDataGrid.DataContext = bl.DisplayParcellst();
            parcelDataGrid.IsReadOnly = true;
        }
        public ListDroneWindow(IBl iBL)
        {
            InitializeComponent();
            this.bL = iBL;
            cmbStatus.ItemsSource = Enum.GetValues(typeof(BO.DroneStatus));
            cmbMaxWeight.ItemsSource= Enum.GetValues(typeof(BO.Weights));
            droneDataGrid.DataContext = bL.DisplayDronelst();
            droneDataGrid.IsReadOnly = true;
        }*/


        private void AddBaseStation_Click(object sender, RoutedEventArgs e)
        {
            new BaseStationWindow(bl).ShowDialog();
            baseStationDataGrid.ItemsSource = bl.DisplayBaseStationlst();

        }

        private void ButtonCantent_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ComboBoxFilteringStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.BaseStation b = (BO.BaseStation)ComboBoxFilteringStation.SelectedItem;
            baseStationDataGrid.DataContext = bl.DisplayBaseStationlst(baseStation => baseStation.AvailableChargingStations.ToString() == b.ToString());
        }
    }
}
