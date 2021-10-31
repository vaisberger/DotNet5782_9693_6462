using System;
using System.Collections.Generic;
using IDAL.DO;
using DalObject;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSource data;
            int c;
            do
            {
                Console.WriteLine("Please select an action from options below:");
                Console.WriteLine(" 0-Add\n 1-Update\n 2-Display item\n 3-Display list\n 4-Exit ");
                c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 0://add
                        Console.WriteLine("please select the item you would like to add:");
                        Console.WriteLine("0-Station \n 1-Drone\n 2-Customer\n 3-Parcel");
                        int a = Convert.ToInt32(Console.ReadLine());
                        switch (a)
                        {
                            case 0:// add station
                                BaseStation NewStation = new BaseStation();
                                int ID;
                                int Name;
                                double Longitued;
                                double Latitude;
                                int ChargeSlots;
                                Console.WriteLine("please enter id, name, longitude, latitude, charge slotes");
                                ID = Convert.ToInt32(Console.ReadLine());
                                Name = Convert.ToInt32(Console.ReadLine());
                                Longitued = Convert.ToDouble(Console.ReadLine());
                                Latitude = Convert.ToDouble(Console.ReadLine());
                                ChargeSlots = Convert.ToInt32(Console.ReadLine());
                                NewStation.Id = ID;
                                NewStation.Name = Name;
                                NewStation.Longitude = Longitued;
                                NewStation.Latitude = Latitude;
                                NewStation.ChargeSlots = ChargeSlots;
                                DalObject.DalObject.AddStation(NewStation);
                                break;
                            case 1:// add drone
                                Drone NewDrone = new Drone();
                                String Model;
                                Weights weights;
                                DroneStatus status;
                                double battery;
                                Console.WriteLine("please enter id, model, Max weight,status, battery");
                                ID = Convert.ToInt32(Console.ReadLine());
                                Model = Console.ReadLine();
                                Weights.TryParse(Console.ReadLine(), out weights);
                                DroneStatus.TryParse(Console.ReadLine(), out status);
                                battery = Convert.ToDouble(Console.ReadLine());
                                NewDrone.Id = ID;
                                NewDrone.Model = Model;
                                NewDrone.MaxWeight = weights;
                                NewDrone.status = status;
                                NewDrone.Battery = battery;
                                DalObject.DalObject.AddDrone(NewDrone);
                                break;
                            case 2:// add customer
                                Customer NewCustomer = new Customer();
                                String name;
                                String Phone;
                                Console.WriteLine("please enter id, name, phone, longitude, latitude");
                                ID= Convert.ToInt32(Console.ReadLine());
                                name = Console.ReadLine();
                                Phone= Console.ReadLine();
                                Longitued = Convert.ToDouble(Console.ReadLine());
                                Latitude = Convert.ToDouble(Console.ReadLine());
                                NewCustomer.Id = ID;
                                NewCustomer.Name =name;
                                NewCustomer.Phone = Phone;
                                NewCustomer.Longitude = Longitued;
                                NewCustomer.Latitude = Latitude;
                                DalObject.DalObject.AddCustomer(NewCustomer);
                                break;
                            case 3:// add parcel
                                Parcel NewParcel = new Parcel();
                                Priorities priorty;
                                DateTime Scheduled;
                                DateTime PickedUp;
                                DateTime Delivered;
                                Console.WriteLine("please enter Id, Sender ID, Target ID, weight, priorty, Requsted, Drone ID, Scheduled, Picked Up, Delivered ");
                                ID = Convert.ToInt32(Console.ReadLine());
                                Weights.TryParse(Console.ReadLine(), out weights);
                                Priorities.TryParse(Console.ReadLine(), out priorty);
                                DateTime.TryParse(Console.ReadLine(), out Scheduled);
                                DateTime.TryParse(Console.ReadLine(), out PickedUp);
                                DateTime.TryParse(Console.ReadLine(), out Delivered);
                                NewParcel.Id = ID;
                                NewParcel.SenderId=0;
                                NewParcel.TargetId=0;
                                NewParcel.weight = weights;
                                NewParcel.priorty = priorty;
                                NewParcel.Requsted =DateTime.Now;
                                NewParcel.DroneId = 0;
                                NewParcel.Scheduled = Scheduled;
                                NewParcel.PickedUp = PickedUp;
                                NewParcel.Delivered = Delivered;
                                DalObject.DalObject.AddParcel(NewParcel);
                                break;
                        }
                        break;
                    case 1://update
                        Console.WriteLine("please select the item you would like to update:");
                        Console.WriteLine("0-Match drone to parcel \n 1-Parcel collection\n 2-Parcel delivery\n 3-Charge Drone\n 4-Discharge Drone");
                        int u = Convert.ToInt32(Console.ReadLine());
                        switch (u)
                        {
                            case 0://Match drone to parcel
                                Console.WriteLine("please enter the ID of the parcel to match");
                                int pID= Convert.ToInt32(Console.ReadLine());
                                
                                break;
                            case 1://Parcel collection
                                break;
                            case 2://Parcel delivery
                                break;
                            case 3://Charge Drone
                                break;
                            case 4://Discharge Drone
                                break;
                        }
                        break;
                    case 2:// display item
                        Console.WriteLine("please select the item you would like to display:");
                        Console.WriteLine("0-Station \n 1-Drone\n 2-Customer\n 3-Parcel");
                        int di = Convert.ToInt32(Console.ReadLine());
                        switch (di)
                        {
                            case 0:// display station
                                Console.WriteLine("enter the ID of the station you would like to display");
                                int IDs= Convert.ToInt32(Console.ReadLine());
                                DalObject.DalObject.DisplayStation(IDs);
                                break;
                            case 1:// display drone
                                Console.WriteLine("enter the ID of the drone you would like to display");
                                int IDd = Convert.ToInt32(Console.ReadLine());
                                DalObject.DalObject.DispalyDrone(IDd);
                                break;
                            case 2:// display customer
                                Console.WriteLine("enter the ID of the customer you would like to display");
                                int IDc = Convert.ToInt32(Console.ReadLine());
                                DalObject.DalObject.DisplayCustomer(IDc);
                                break;
                            case 3:// display parcel
                                Console.WriteLine("enter the ID of the parcel you would like to display");
                                int IDp = Convert.ToInt32(Console.ReadLine());
                                DalObject.DalObject.DisplayParcel(IDp);
                                break;
                        }
                        break;
                    case 3:// display list
                        Console.WriteLine("please select the list of items you would like to display:");
                        Console.WriteLine("0-Stations \n 1-Drones\n 2-Customers\n 3-Parcels\n 4-Parcels unmatched\n 5-Available charging station");
                        int dl = Convert.ToInt32(Console.ReadLine());
                        switch (dl)
                        {
                            case 0:// display list of stations
                                DalObject.DalObject.DisplayStationList();
                                break;
                            case 1:// display list of drones
                                DalObject.DalObject.DisplayDroneList();
                                break;
                            case 2:// display list of customers
                                DalObject.DalObject.DisplayCustomerList();
                                break;
                            case 3:// display list of parcels
                                DalObject.DalObject.DisplayParcelList();
                                break;
                            case 4: // display list of parcels unmatched
                                DalObject.DalObject.DisplayParcelUnmatched();
                                break;
                            case 5: // display list of available charging station
                                DalObject.DalObject.DisplayAvailableStation();
                                break;
                        }

                        break;
                    case 4:// exit
                        break;
                    default:// input not valid
                        Console.WriteLine("Input not valid please enter a valid number");
                        break;
                }
            } while (c != 4);


        }
    }
}
