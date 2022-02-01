using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BaseStation
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int ChargeSlots { get; set; }
        public override string ToString()//print
        {
            return "ID: " + Id  + " ChargeSlots: " + ChargeSlots + " Name: " + Name;
        }

    }

}

