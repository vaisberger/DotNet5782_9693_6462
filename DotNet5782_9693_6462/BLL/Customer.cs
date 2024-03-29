﻿using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    public class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Phone { get; set; }
        public Location location { get; set; }
        List<ParcelCustomer> SendParcels { get; set; }
        List<ParcelCustomer> Parcels { get; set; }
        public override string ToString()//print
        {
            return "ID: " + Id + " Name: " + Name + " Phone " + Phone + "Location:" + location + "List of packages at the customer - from the customer:" + SendParcels + "List of packages at the customer - to the customer:" + Parcels;
        }


    }
}

