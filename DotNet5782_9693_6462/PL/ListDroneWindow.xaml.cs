
using IBL;
using System;
using System.Windows;
using System.Windows.Controls;
using BO;
using BLApi;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

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
            DroneStatus status = (DroneStatus)cmbStatus.SelectedItem;
            MessageBox.Show(cmbStatus.SelectedItem.ToString());
            droneDataGrid.DataContext = bL.DisplayDronelst(drone=>drone.status==status);
        }

        private void cmbMaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Weights w = (Weights)cmbMaxWeight.SelectedItem;
            MessageBox.Show(cmbMaxWeight.SelectedItem.ToString());
            droneDataGrid.DataContext = bL.DisplayDronelst(drone => drone.MaxWeight == w);
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
                DroneWindow w = new DroneWindow(d,bL);
                w.Show();
            }
        }

        private void droneDataGrid_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Clearfilterbtn_Click(object sender, RoutedEventArgs e)
        {
            droneDataGrid.DataContext = bL.DisplayDronelst();
        }

        private void groupbtn_Click(object sender, RoutedEventArgs e)
        {
            droneDataGrid.ItemsSource = bL.DisplayDronelst();
            List<BO.Drone> dr = new List<BO.Drone>();
            foreach (var item in bL.DisplayDronelst())
            {
                dr.Add((BO.Drone)item);
            }

            var groupreciver = (from item in dr
                                group item by item.status into gr
                                select new
                                {
                                    pstr = gr.Key,
                                    grdrone = gr
                                });

            List<BO.Drone> datasender = new List<BO.Drone>();
            foreach (var item in groupreciver)
            {
                foreach (var dro in item.grdrone)
                {
                    datasender.Add(dro);
                }
            }
            droneDataGrid.ItemsSource = datasender.ToList();
        }
    }
}
    
