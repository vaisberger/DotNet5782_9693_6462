using IDAL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    public struct DataSource
    {
        internal static List<Customer> customers = new List<Customer>();
        internal static List<BaseStation> station = new List<BaseStation>();
        internal static List<Drone> drones = new List<Drone>();
        internal static List<Parcel> parcels = new List<Parcel>();
        internal static List<DroneCharge> droneCharges = new List<DroneCharge>();
        public static Random r = new Random();
        internal class Config
        {
            internal static int ParcelSerial = 0;
            internal static int NumberId;
        }
        internal static void Initialize()
        {
            Random r = new Random();
            drones.Add(new Drone { Id = r.Next(1111111,10000000), Model = "x400", status = 0, Battery = 0 });
            drones.Add(new Drone { Id = r.Next(1111111, 10000000), Model = "x401", status = 0, Battery = 0 });
            drones.Add(new Drone { Id = r.Next(1111111, 10000000), Model = "x402", status = 0, Battery = 0 });
            drones.Add(new Drone { Id = r.Next(1111111, 10000000), Model = "x403", status = 0, Battery = 0 });
            drones.Add(new Drone { Id = r.Next(1111111, 10000000), Model = "x404", status = 0, Battery = 0 });


        }
    }

}
