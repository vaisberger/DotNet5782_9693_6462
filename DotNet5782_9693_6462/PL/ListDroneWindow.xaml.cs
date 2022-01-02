
using IBL;
using System;
using System.Windows;
using System.Windows.Controls;
using BO;
using BLApi;

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
        }



        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DroneStatus status = (DroneStatus)cmbStatus.SelectedItem;
            this.listView.ItemsSource = bL.DisplayDronelst(x => x.status == status);
            MessageBox.Show(cmbStatus.SelectedItem.ToString());
        }

        private void cmbMaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Weights w = (Weights)cmbMaxWeight.SelectedItem;
            this.listView.ItemsSource = bL.DisplayDronelst(x => x.MaxWeight == w);
            MessageBox.Show(cmbMaxWeight.SelectedItem.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e) //button to add a drone
        {
            DroneWindow wnd = new DroneWindow(bL);
            wnd.Show();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.ItemsSource = bL.DisplayDronelst();   // להוסיף אופציה שבלחיצה ברחפן יהיה אפשר לעדכן
        }
    }
}
    
