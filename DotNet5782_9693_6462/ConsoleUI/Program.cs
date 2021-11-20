//course mini project in windows
// by moria mizrachi and yael vaisberger
using System;
using System.Collections.Generic;
using IDAL.DO;
using DalObject;
namespace ConsoleUI
{
    class Program
    {
        static DalObject.DalObject data = new DalObject.DalObject();

        static void Main(string[] args)
        {


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
                                addStation();
                                break;
                            case 1:// add drone
                                addDrone();
                                break;
                            case 2:// add customer
                                addCustomer();
                                break;
                            case 3:// add parcel
                                addParcel();
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
                                Console.WriteLine("please enter the ID of the parcel and drone to match");
                                int pID = Convert.ToInt32(Console.ReadLine());
                                int dID = Convert.ToInt32(Console.ReadLine());
                                data.UpdateParcelToDrone(pID, dID);
                                break;
                            case 1://Parcel collection
                                Console.WriteLine("please enter the ID of the parcel and drone to collect");
                                pID = Convert.ToInt32(Console.ReadLine());
                                dID = Convert.ToInt32(Console.ReadLine());
                                data.Parcelcollection(pID, dID);
                                break;
                            case 2://Parcel delivery
                                Console.WriteLine("please enter the ID of the parcel and customer to deliver to");
                                pID = Convert.ToInt32(Console.ReadLine());
                                int cID = Convert.ToInt32(Console.ReadLine());
                                data.ParcelDelivery(pID, cID);
                                break;
                            case 3://Charge Drone
                                Console.WriteLine("All the available station:");
                                data.DisplayAvailableStation();
                                Console.WriteLine("please enter the ID of the drone and staition to charge");
                                dID = Convert.ToInt32(Console.ReadLine());
                                int sID = Convert.ToInt32(Console.ReadLine());
                                data.ChargeDrone(dID, sID);
                                break;
                            case 4://Discharge Drone
                                Console.WriteLine("please enter the ID of the drone to discharge");
                                dID = Convert.ToInt32(Console.ReadLine());
                                data.DischargeDrone(dID);
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
                                int IDs = Convert.ToInt32(Console.ReadLine());
                                data.DisplayStation(IDs);
                                break;
                            case 1:// display drone
                                Console.WriteLine("enter the ID of the drone you would like to display");
                                int IDd = Convert.ToInt32(Console.ReadLine());
                                data.DisplayDrone(IDd);
                                break;
                            case 2:// display customer
                                Console.WriteLine("enter the ID of the customer you would like to display");
                                int IDc = Convert.ToInt32(Console.ReadLine());
                                data.DisplayCustomer(IDc);
                                break;
                            case 3:// display parcel
                                Console.WriteLine("enter the ID of the parcel you would like to display");
                                int IDp = Convert.ToInt32(Console.ReadLine());
                                data.DisplayParcel(IDp);
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
                                displaystationlist();
                                break;
                            case 1:// display list of drones
                                displaydronelist();
                                break;
                            case 2:// display list of customers
                                displaycustomerlist();
                                break;
                            case 3:// display list of parcels
                                displayparcellist();
                                break;
                            case 4: // display list of parcels unmatched
                                displayparcelunmatched();
                                break;
                            case 5: // display list of available charging station
                                displayavailablestation();
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

        private static void displayavailablestation()
        {
            foreach (BaseStation s in data.DisplayAvailableStation())
            {
                s.ToString();
            }
        }

        private static void displayparcelunmatched()
        {
            foreach (Parcel p in data.DisplayParcelUnmatched())
            {
                p.ToString();
            }
        }

        private static void displayparcellist()
        {
            foreach (Parcel p in data.DisplayParcelList())
            {
                p.ToString();
            }
        }

        private static void displaycustomerlist()
        {
            foreach (Customer c in data.DisplayCustomerList())
            {
                c.ToString();
            }
        }

        private static void displaydronelist()
        {
            foreach (Drone d in data.DisplayDroneList())
            {
                d.ToString();
            }
        }

        private static void displaystationlist()
        {
            foreach (BaseStation s in data.DisplayStationList())
            {
                s.ToString();
            }
        }

        private static void addStation()
        {
            Console.WriteLine("please enter id, name, longitude, latitude, charge slotes");
            int ID = Convert.ToInt32(Console.ReadLine());
            int Name = Convert.ToInt32(Console.ReadLine());
            double Longitued = Convert.ToDouble(Console.ReadLine());
            double Latitude = Convert.ToDouble(Console.ReadLine());
            int ChargeSlots = Convert.ToInt32(Console.ReadLine());

            BaseStation NewStation = new BaseStation()
            {
                Id = ID,
                Name = Name,
                Longitude = Longitued,
                Latitude = Latitude,
                ChargeSlots = ChargeSlots,
            };

            data.AddStation(NewStation);
        }
        private static void addDrone()
        {

            Weights weights;
            Console.WriteLine("please enter id, model, Max weight,status, battery");
            int ID = Convert.ToInt32(Console.ReadLine());
            String model = Console.ReadLine();
            Weights.TryParse(Console.ReadLine(), out weights);
            double battery = Convert.ToDouble(Console.ReadLine());
            Drone NewDrone = new Drone()
            {
                Id = ID,
                Model = model,
                MaxWeight = weights,
            };
            data.AddDrone(NewDrone);

        }

        private static void addCustomer()
        {
            Console.WriteLine("please enter id, name, phone, longitude, latitude");
            int ID = Convert.ToInt32(Console.ReadLine());
            String name = Console.ReadLine();
            String phone = Console.ReadLine();
            double longitued = Convert.ToDouble(Console.ReadLine());
            double latitude = Convert.ToDouble(Console.ReadLine());
            Customer NewCustomer = new Customer()
            {
                Id = ID,
                Name = name,
                Phone = phone,
                Longitude = longitued,
                Latitude = latitude,
            };

            data.AddCustomer(NewCustomer);
        }

        private static void addParcel()
        {
            Priorities Priorty;
            DateTime scheduled;
            DateTime pickedUp;
            DateTime delivered;
            Weights Weight;
            Console.WriteLine("please enter Id, Sender ID, Target ID, weight, priorty, Requsted, Drone ID, Scheduled, Picked Up, Delivered ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Weights.TryParse(Console.ReadLine(), out Weight);
            Priorities.TryParse(Console.ReadLine(), out Priorty);
            DateTime.TryParse(Console.ReadLine(), out scheduled);
            DateTime.TryParse(Console.ReadLine(), out pickedUp);
            DateTime.TryParse(Console.ReadLine(), out delivered);
            Parcel NewParcel = new Parcel()
            {
                Id = ID,
                SenderId = 0,
                TargetId = 0,
                weight = Weight,
                priorty = Priorty,
                Requsted = DateTime.Now,
                DroneId = 0,
                Scheduled = scheduled,
                PickedUp = pickedUp,
                Delivered = delivered,
            };
            data.AddParcel(NewParcel);
        }
    }
}
