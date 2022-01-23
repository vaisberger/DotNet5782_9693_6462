using BLApi;
using Microsoft.VisualBasic;
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
    /// Interaction logic for ListParcelWindow.xaml
    /// </summary>
    public partial class ListParcelWindow : Window
    {
        IBl bl;
        public ListParcelWindow(IBl BL)
        {
            this.bl = BL;
            InitializeComponent();
            datecmb.ItemsSource = Enum.GetValues(typeof(Date));
            prioritycmb.ItemsSource = Enum.GetValues(typeof(BO.Priorities));
            weightcmb.ItemsSource= Enum.GetValues(typeof(BO.Weights));
            parcelDataGrid.DataContext = bl.DisplayParcellst();
        }
        public enum Date {Scheduled=0,PickedUp,Delivered,Requsted };

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date d = (Date)datecmb.SelectedItem;
            switch ((int)d)
            {
                case 0: string sc = "Enter the date and time of scheduled parcel you would like to filter :";  //Scheduled
                    DateTime date0 = DateTime.Parse(Interaction.InputBox(sc, "get date", "01 - january - 0001 00: 00"));
                    parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.Scheduled == date0);
                    break;
                case 1:  string pu = "Enter the date and time of picked parcel you would like to filter :";   //PickedUp
                    DateTime date1 = DateTime.Parse(Interaction.InputBox(pu, "get date", "01 - january - 0001 00: 00"));
                    parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.PickedUp == date1);
                    break;
                case 2:
                    string de = "Enter the date and time of delivered parcel you would like to filter :";    //Delivered
                    DateTime date2 = DateTime.Parse(Interaction.InputBox(de, "get date", "01 - january - 0001 00: 00"));
                    parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.Delivered == date2);
                    break;
                case 3: string re = "Enter the date and time of requested parcel you would like to filter :";    //Requsted
                    DateTime date3 = DateTime.Parse(Interaction.InputBox(re, "get date", "01 - january - 0001 00: 00"));
                    parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.Requsted == date3);
                    break;
            }
        }

        private void parcellDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            BO.Priorities p = (BO.Priorities)prioritycmb.SelectedItem;
            parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.priorty.ToString() == p.ToString());
        }

        private void comboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            BO.Weights w = (BO.Weights)prioritycmb.SelectedItem;
            parcelDataGrid.DataContext = bl.DisplayParcellst(parcel => parcel.weight.ToString() == w.ToString());
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            ParcelWindow w = new ParcelWindow(bl);
            w.Show();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            BO.ParcelToList p = (parcelDataGrid.SelectedItem as BO.ParcelToList);
            if (p != null)
            {
                ParcelWindow w = new ParcelWindow(p);
                w.Show();
            }
        }
    }
}
