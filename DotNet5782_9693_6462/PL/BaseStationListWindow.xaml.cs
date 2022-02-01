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
           // baseStationDataGrid.DataContext = bl.DisplayBaseStationlst(baseStation => baseStation.AvailableChargingStations.ToString() == b.ToString());
        }
    }
}
