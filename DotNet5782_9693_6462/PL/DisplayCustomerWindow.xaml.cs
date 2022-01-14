﻿using BLApi;
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
    /// Interaction logic for DisplayCustomerWindow.xaml
    /// </summary>
    public partial class DisplayCustomerWindow : Window
    {
        IBl bl;
        BO.Customer customer;
        public DisplayCustomerWindow(IBl Bl)//Add a customer
        {
            customer = new BO.Customer();
            this.bl = Bl;
            DataContext = customer;
            InitializeComponent();

        }

       
    }
}