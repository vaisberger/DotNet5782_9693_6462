﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{

    internal static class DataSource
    {
        internal static List<Customer> customers = new List<Customer>();
        internal static List<BaseStation> stations = new List<BaseStation>();
        internal static List<Drone> drones = new List<Drone>();
        internal static List<Parcel> parcels = new List<Parcel>();
        internal static List<DroneCharge> droneCharges = new List<DroneCharge>();

        public static Random r = new Random();

        internal class Config
        {
            internal static int ParcelSerial = 10000;
            internal static double Avaliable { get => 0;}
            internal static double Light { get => 25;}
            internal static double Medium { get => 60; }
            internal static double Heavy { get => 100; }
            internal static double ChargingRate { get => 15; }
        }
        internal static void Initialize() //Initiating function
        {
            DateTime d = new DateTime(0, 0, 0, 0, 0, 0);
            Random r = new Random();
            //add 5 drones
            drones.Add(new Drone { Id = 0, Model = null, /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Heavy });//1
            drones.Add(new Drone { Id = 0, Model = null, /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Light });//2
            drones.Add(new Drone { Id = 0, Model = null, /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Medium });//3
            drones.Add(new Drone { Id = 0, Model = null, /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/MaxWeight= Weights.Heavy });//4
            drones.Add(new Drone { Id = 0, Model = null, /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Light });//5

            //add 2 stations
            stations.Add(new BaseStation { Id = 0, Name = 0, Longitude = r.Next(10000, 100000), Latitude = r.Next(10000, 100000), ChargeSlots = r.Next(0, 6) });//1
            stations.Add(new BaseStation { Id = 0, Name = 0, Longitude = r.Next(10000, 100000), Latitude = r.Next(10000, 100000), ChargeSlots = r.Next(0, 6) });//2

            //add 10 customer
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//1
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//2
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//3
            customers.Add(new Customer { Id = 0, Name=null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//4
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//5
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//6
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//7
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//8
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//9
            customers.Add(new Customer { Id = 0, Name = null, Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//10

            //add 10 parcels
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d , PickedUp = d, Delivered = d });//1
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//2
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//3
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//4
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//5
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//6
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//7
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//8
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//9
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priority = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = d, PickedUp = d, Delivered = d });//10
        }

    }

}
