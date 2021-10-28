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
            public static void Tostring(int Id, int Name,)
            {
                Console.WriteLine("Droneld: {0} Statioin ID: {1} ", Droneld, StationId);
            }

        }
    }
}
