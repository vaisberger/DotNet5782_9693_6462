using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct BaseStation
        {
            public int Id { get; set; }
            public int Name { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public int ChargeSlots { get; set; }

            public static void Tostring(int Id, int Name, double Longitude, double Latitude, int ChargeSlots)//print
            {
                Console.WriteLine("ID: {0} Name: {1} Longitude: {2} Latitude: {3} ChargeSlots: {4} ", Id, Name, Longitude, Latitude, ChargeSlots);
            }

        }

    }

}
