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
using IBL;
using IBL.BO;
namespace PL
{
    /// <summary>
    /// Interaction logic for ListDrone.xaml
    /// </summary>
    public partial class ListDrone : Window
    {
        IBL.IBL bl;
        public ListDrone(IBL.IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
