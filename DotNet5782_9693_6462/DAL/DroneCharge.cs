using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct DroneCharge
        {
            public int Droneld { set; get; }
            public int StatioId{set; get; }
            public static void Tostring(int Droneld,int StationId)
            {
                Console.WriteLine("Droneld: {0} Statioin ID: {1} ", Droneld,StationId);
            }
        }
    }
}
