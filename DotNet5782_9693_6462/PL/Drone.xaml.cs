using BO;
using System.Windows;

namespace PL
{
    /// <summary>
    /// Interaction logic for Drone.xaml
    /// </summary>
    public partial class Drone : Window
    {
        private IBl mybl;

        public Drone()
        {
            InitializeComponent();
        }

        public Drone(IBl mybl)
        {
            this.mybl = mybl;
        }
    }
}
