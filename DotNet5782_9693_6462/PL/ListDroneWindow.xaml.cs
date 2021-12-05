using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IBL.BO;
using BL;


namespace PL
{
    /// <summary>
    /// Interaction logic for ListDrone.xaml
    /// </summary>

    public partial class ListDroneWindow : Window
    {
        IBL.IBL bl;
        public ListDroneWindow(IBL.IBL THBL)
        {
            this.bl = THBL;
            
            
        }

    }
}
