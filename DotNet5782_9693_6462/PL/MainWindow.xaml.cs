﻿using System;
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
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        static IBL.BO.IBl mybl;
        static void Main(string[] args) {

            MainWindow New;
        }
        public MainWindow()
        {
            mybl = new BLObject.BLObject();
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ListDroneWindow(mybl).Show();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Drone(mybl).Show();
        }

        /*private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Drone(mybl).Show();
        }*/
    }

}
