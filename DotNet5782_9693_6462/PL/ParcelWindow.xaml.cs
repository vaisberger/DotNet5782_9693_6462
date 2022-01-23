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
            priortyComboBox.ItemsSource= Enum.GetValues(typeof(BO.Priorities));
            weightComboBox.ItemsSource = Enum.GetValues(typeof(BO.Weights));
        }
        public ParcelWindow(BO.ParcelToList p)
        {
            InitializeComponent();
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
    }
}
