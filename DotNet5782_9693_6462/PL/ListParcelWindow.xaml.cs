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
        }
        public enum Date {Scheduled=0,PickedUp,Delivered,Requsted };

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date d = (Date)datecmb.SelectedItem;
            switch ((int)d)
            {
                case 0: string sc = "Enter the date and time of scheduled parcel you would like to filter :";  //Scheduled
                  DateTime date0 = DateTime.Parse(Interaction.InputBox(sc, "get date", "dd - mmm - yyyy hh: mm"));
                    break;
                case 1:  string pu = "Enter the date and time of picked parcel you would like to filter :";   //PickedUp
                    DateTime date1 = DateTime.Parse(Interaction.InputBox(pu, "get date", "dd - mmm - yyyy hh: mm"));
                    break;
                case 2:
                    string de = "Enter the date and time of delivered parcel you would like to filter :";    //Delivered
                    DateTime date2 = DateTime.Parse(Interaction.InputBox(de, "get date", "dd - mmm - yyyy hh: mm"));
                    break;
                case 3: string re = "Enter the date and time of requested parcel you would like to filter :";    //Requsted
                    DateTime date3 = DateTime.Parse(Interaction.InputBox(re, "get date", "dd - mmm - yyyy hh: mm"));
                    break;
            }
        }

        private void parcellDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
