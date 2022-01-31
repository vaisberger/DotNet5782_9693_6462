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
    /// Interaction logic for BaseStationWindow.xaml
    /// </summary>
    public partial class BaseStationWindow : Window
    {
        IBl bl;
        BO.BaseStation baseStation;
      
        public BaseStationWindow(IBl BL)//Add
        {
            baseStation = new BO.BaseStation();
            this.bl = bl;
            DataContext = baseStation;
            InitializeComponent();
            ButtonUpdate.Visibility = Visibility.Collapsed;


        }
       
        public BaseStationWindow(BO.BaseStationList b, IBl BL)//Update
        {
            baseStation = b;
            DataContext = baseStation;
            this.bl = BL;
            InitializeComponent();
            ButtonAdd.Visibility = Visibility.Collapsed;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            grid1.DataContext = baseStation;
            MessageBox.Show("Station was updated");
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddBaseStation(baseStation);
            }
            catch (Exception)
            {

                MessageBox.Show("couldn't add the Station because this Id allready exists in the system");
            }
            MessageBox.Show(baseStation.ToString());
            Close();
        }
    }
}
