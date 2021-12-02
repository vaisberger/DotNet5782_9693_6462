﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Customer
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public string Phone { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }

            public override string ToString()//print
            {
                return "ID: " + Id + " Name: " + Name + " Phone " + Phone + " Longitude: " + Longitude + " Latitude: " + Latitude;
            }

        }
    }

}
