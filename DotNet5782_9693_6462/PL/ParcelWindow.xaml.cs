﻿
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
    /// Interaction logic for ParcelWindow.xaml
    /// </summary>
    public partial class ParcelWindow : Window
    {
        IBl bl;
        BO.ParcelToList parcel;
        public ParcelWindow(IBl BL)
        {
            parcel = new BO.ParcelToList();
            this.bl = BL;
            DataContext = parcel;
            InitializeComponent();
            showdronebtn.Visibility = Visibility.Collapsed;
            showreciverbtn.Visibility = Visibility.Collapsed;
            showsenderdtn.Visibility = Visibility.Collapsed;
            updatebtn.Visibility = Visibility.Collapsed;
            priortyComboBox.ItemsSource = Enum.GetValues(typeof(BO.Priorities));
            weightComboBox.ItemsSource = Enum.GetValues(typeof(BO.Weights));
            Dronegrid.Visibility= Visibility.Collapsed;
            Customergrid.Visibility= Visibility.Collapsed;
            Parceldalgrid.Visibility = Visibility.Collapsed;
        }
        public ParcelWindow(BO.ParcelToList p, IBl BL)
        {
            parcel = p;
            DataContext = parcel;
            this.bl = BL;
            InitializeComponent();
            priortyComboBox.ItemsSource = Enum.GetValues(typeof(BO.Priorities));
            weightComboBox.ItemsSource = Enum.GetValues(typeof(BO.Weights));
            showdronebtn.Visibility = Visibility.Collapsed;
            showreciverbtn.Visibility = Visibility.Collapsed;
            showsenderdtn.Visibility = Visibility.Collapsed;
            addbtn.Visibility = Visibility.Collapsed;
            senderIdTextBox.IsEnabled = false;
            idTextBox.IsEnabled = false;
            weightComboBox.IsEnabled = false;
            Dronegrid.Visibility = Visibility.Collapsed;
            Customergrid.Visibility = Visibility.Collapsed;
            Parceldalgrid.Visibility = Visibility.Collapsed;
        }

        public ParcelWindow(IBl BL, BO.ParcelToList p)
        {
            parcel = p;
            DataContext = parcel;
            this.bl = BL;
            InitializeComponent();
            addbtn.Visibility = Visibility.Collapsed;
            updatebtn.Visibility = Visibility.Collapsed;
            senderIdTextBox.IsEnabled = false;
            idTextBox.IsEnabled = false;
            weightComboBox.IsEnabled = false;
            targetIdTextBox.IsEnabled = false;
            priortyComboBox.IsEnabled = false;
            Dronegrid.Visibility = Visibility.Collapsed;
            Customergrid.Visibility = Visibility.Collapsed;
            BO.Parcel BOpar = bl.GetParcel(parcel.Id);
            Parceldalgrid.DataContext = BOpar;
        }
        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddParcel(parcel);
            }
            catch
            {
                MessageBox.Show("couldn't add the parcel because this Id allready exists in the system");
            }
            MessageBox.Show(parcel.ToString());
           
            Close();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            try { 
                bl.UpdateParcel(parcel);
            }
            catch
            {
                return;
            }
      
          MessageBox.Show("yes");
        }

        private void showdronebtn_Click(object sender, RoutedEventArgs e)
        {
           
            if (parcel.status == BO.Status.Associated || parcel.status == BO.Status.Collected)
            {
                Dronegrid.Visibility = Visibility.Visible;
                BO.Parcel p=bl.GetParcel(parcel.Id);
                Dronegrid.DataContext = p.droneParcel;
            }
            else if(parcel.status==BO.Status.Provided)
            {
                MessageBox.Show("The parcel was allready delivered ");
            }
            else
            {
                MessageBox.Show("The parcel is not Matched to a drone yet");
            }
        }

        private void showreciverbtn_Click(object sender, RoutedEventArgs e)
        {
            Customergrid.Visibility = Visibility.Visible;
            BO.Parcel p= bl.GetParcel(parcel.Id);
            Customergrid.DataContext = p.Getting;
        }

        private void showsenderdtn_Click(object sender, RoutedEventArgs e)
        {
            Customergrid.Visibility = Visibility.Visible;
            BO.Parcel p = bl.GetParcel(parcel.Id);
            Customergrid.DataContext = p.Sender;
        }
    }
}
