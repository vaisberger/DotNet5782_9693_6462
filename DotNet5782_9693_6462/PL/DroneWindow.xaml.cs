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
    /// Interaction logic for DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        BO.IBl bL;
        public DroneWindow(BO.IBl iBL,String str) // the constructer to update the drone 
        {
            this.bL = iBL;
            InitializeComponent();
        }

        public DroneWindow(BO.IBl iBL, char c)  //the constructer to add a drone
        {
            this.bL = iBL;
            InitializeComponent();
        }

    }
}
