﻿using IDAL.DO;
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
        internal static List<BaseStation> stations = new List<BaseStation>();
        internal static List<Drone> drones = new List<Drone>();
        internal static List<Parcel> parcels = new List<Parcel>();
        internal static List<DroneCharge> droneCharges = new List<DroneCharge>();

        public static Random r = new Random();

        internal class Config
        {
            internal static int ParcelSerial = 10000;
        }
        internal static void Initialize() //Initiating function
        {
            Random r = new Random();
            //add 5 drones
            drones.Add(new Drone { Id = 11, Model = "x400", /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Heavy });//1
            drones.Add(new Drone { Id = 22, Model = "x401", /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Light });//2
            drones.Add(new Drone { Id = 33, Model = "x402", /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Medium });//3
            drones.Add(new Drone { Id = 44, Model = "x403", /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/MaxWeight= Weights.Heavy });//4
            drones.Add(new Drone { Id = 55, Model = "x404", /*status = DroneStatus.Available, Battery = r.Next(5, 100),*/ MaxWeight = Weights.Light });//5

            //add 2 stations
            stations.Add(new BaseStation { Id = 1, Name = 1212, Longitude = r.Next(10000, 100000), Latitude = r.Next(10000, 100000), ChargeSlots = r.Next(0, 6) });//1
            stations.Add(new BaseStation { Id = 2, Name = 1313, Longitude = r.Next(10000, 100000), Latitude = r.Next(10000, 100000), ChargeSlots = r.Next(0, 6) });//2

            //add 10 customer
            customers.Add(new Customer { Id = 111, Name = "aaaa", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//1
            customers.Add(new Customer { Id = 222, Name = "bbbb", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//2
            customers.Add(new Customer { Id = 333, Name = "gggg", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//3
            customers.Add(new Customer { Id = 444, Name = "dddd", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//4
            customers.Add(new Customer { Id = 555, Name = "eeee", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//5
            customers.Add(new Customer { Id = 666, Name = "ffff", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//6
            customers.Add(new Customer { Id = 777, Name = "gggg", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//7
            customers.Add(new Customer { Id = 888, Name = "hhhh", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//8
            customers.Add(new Customer { Id = 999, Name = "iiii", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//9
            customers.Add(new Customer { Id = 101, Name = "jjjj", Phone = $"0{r.Next(51, 58)}{r.Next(1000000, 9999999)}", Longitude = r.Next(0, 25), Latitude = r.Next(0, 61) });//10

            //add 10 parcels
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//1
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//2
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//3
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//4
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//5
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//6
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//7
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//8
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//9
            parcels.Add(new Parcel { Id = Config.ParcelSerial++, SenderId = 0, TargetId = 0, weight = Weights.Light, priorty = Priorities.Normal, Requsted = DateTime.Now, DroneId = 0, Scheduled = DateTime.Now, PickedUp = DateTime.Now, Delivered = DateTime.Now });//10
        }

    }

}
