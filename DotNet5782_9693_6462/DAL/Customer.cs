using System;
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
            public String Phone { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public override void ToString()//print
            {
               return Console.WriteLine("Id: {0} Model: {1} Name: {2} Phone: {3} Longitude:{4} Latitude:{5} ", Id, Name, Phone, Longitude, Latitude);
            }

        }
    }

}
