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
            drones.Add(new Drone { Id = r.Next(1000000,10000000), Model = "x400", status = DroneStatus.Available , Battery = r.Next(5,100),weight=Weights.Heavy });
            drones.Add(new Drone { Id = r.Next(1000000, 10000000), Model = "x401", status = DroneStatus.Maitenance, Battery = r.Next(5, 100), weight= Weights.Light });
            drones.Add(new Drone { Id = r.Next(1000000, 10000000), Model = "x402", status = DroneStatus.Shipment, Battery = r.Next(5, 100), weight= Weights.Medium });
            drones.Add(new Drone { Id = r.Next(1000000, 10000000), Model = "x403", status = DroneStatus.Available, Battery = r.Next(5, 100), weight= Weights.Heavy });
            drones.Add(new Drone { Id = r.Next(1000000, 10000000), Model = "x404", status = DroneStatus.Maitenance, Battery = r.Next(5, 100), weight= Weights.Light });

            station.Add(new BaseStation { Id = r.Next(1000,10000),Name=1212,Longitude=r.Next(10000,100000), Latitude = r.Next(10000, 100000),ChargeSlots=r.Next(0,6) });
            station.Add(new BaseStation { Id = r.Next(1000, 10000), Name = 1313, Longitude = r.Next(10000, 100000), Latitude = r.Next(10000, 100000), ChargeSlots = r.Next(0, 6) });

            parcels.Add(new Parcel { Id =1+ r.Next(100, 10000)});
            customers.Add(new Customer { Id =0000000, Name = "aaaa", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude= r.Next(0, 25), Latitude = r.Next(0,61) });
            customers.Add(new Customer { Id = 00000000, Name = "bbbb", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id =0000000, Name = "gggg", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "dddd", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "eeee", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "ffff", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "gggg", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "hhhh", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "iiii", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });
            customers.Add(new Customer { Id = 0000000, Name = "jjjj", Phone = "$0{r.Next(51,58)}{r.Next(1000000,9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });

        }

    }

}
