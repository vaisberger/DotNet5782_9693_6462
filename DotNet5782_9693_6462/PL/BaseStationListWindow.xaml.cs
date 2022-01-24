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
        BO.BaseStationList baseStation;
        public BaseStationListWindow()
        {
            InitializeComponent();
        }

        private void FilteringByStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBaseStation_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(baseStation.ToString());
           Close();
        }

        private void ButtonCantent_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
