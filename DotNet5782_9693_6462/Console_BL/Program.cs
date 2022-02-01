using System;
using System.Collections.Generic;
using BLApi;
using BLObject;
using BO;


namespace ConsoleUI__BL
{
    
    class Program
    {
        static IBl data = BlFactory.GetBl();
        public static Random r = new Random();
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
                        Console.WriteLine("0-Update Drone\n 1-Update Base Station\n 2-Update customer\n 3-Match drone to parcel \n 4-Parcel collection\n 5-Parcel delivery\n 6-Charge Drone\n 7-Discharge Drone");
                        int u = Convert.ToInt32(Console.ReadLine());
                        switch (u)
                        {
                            case 0:
                                Console.WriteLine("please enter the ID and the new model name of the drone to update:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                String s = Console.ReadLine();
                                BO.Drone d = new Drone
                                {
                                    Id=id,
                                    Model=s
                                };
                                data.UpdateDrone(d);
                                break;
                            case 1:
                                Console.WriteLine("please enter the ID of station to update");
                                int sid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("if you want to update the name press 1");
                                int name=-1;
                                int ch=-1;
                                int check = Convert.ToInt32(Console.ReadLine());
                                if (check == 1)
                                {
                                    name = Convert.ToInt32(Console.ReadLine());
                                }
                                Console.WriteLine("if you want to update the ChargeSlots press 1");
                                check = Convert.ToInt32(Console.ReadLine());
                                if (check == 1)
                                {
                                    ch = Convert.ToInt32(Console.ReadLine());
                                }
                                data.UpdateBaseStation(sid, name, ch);
                                break;
                            case 2:
                                Console.WriteLine("please enter the ID of customer to update");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("if you want to update the name press 1");
                                String nameC = "";
                                String phone = "";
                                check = Convert.ToInt32(Console.ReadLine());
                                if (check == 1)
                                {
                                    nameC = Console.ReadLine();
                                }
                                Console.WriteLine("if you want to update the ChargeSlots press 1");
                                check = Convert.ToInt32(Console.ReadLine());
                                if (check == 1)
                                {
                                    phone = Console.ReadLine();
                                }
                                data.UpdateCustomer(cid,nameC,phone);
                                break;
                            case 3://Match drone to parcel
                                Console.WriteLine("please enter the ID of the drone to match");
                                int dID = Convert.ToInt32(Console.ReadLine());
                                data.MatchDroneToParcel(dID);
                                break;
                            case 4://Parcel collection
                                Console.WriteLine("please enter the ID of the drone to collect");
                                dID = Convert.ToInt32(Console.ReadLine());
                                data.ParcelCollection(dID);
                                break;
                            case 5://Parcel delivery
                                Console.WriteLine("please enter the ID of the drone to deliver to customer");
                                int cID = Convert.ToInt32(Console.ReadLine());
                                data.ParcelDelivery(cID);
                                break;
                            case 6://Charge Drone
                                Console.WriteLine("please enter the ID of the drone to charge");
                                dID = Convert.ToInt32(Console.ReadLine());
                                data.SendDroneToCharge(dID);
                                break;
                            case 7://Discharge Drone
                                Console.WriteLine("please enter the ID of the drone and time it was charging in hr to discharge");
                                dID = Convert.ToInt32(Console.ReadLine());
                                double chc= Convert.ToInt32(Console.ReadLine());
                                data.DischargeDrone(dID,1.5);
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
                                data.GetBaseStation(IDs);
                                break;
                            case 1:// display drone
                                Console.WriteLine("enter the ID of the drone you would like to display");
                                int IDd = Convert.ToInt32(Console.ReadLine());
                                data.GetDrone(IDd);
                                break;
                            case 2:// display customer
                                Console.WriteLine("enter the ID of the customer you would like to display");
                                int IDc = Convert.ToInt32(Console.ReadLine());
                                data.GetCustomer(IDc);
                                break;
                            case 3:// display parcel
                                Console.WriteLine("enter the ID of the parcel you would like to display");
                                int IDp = Convert.ToInt32(Console.ReadLine());
                                data.GetParcel(IDp);
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
            foreach (BaseStation s in data.DisplayStationsToCharge())
            {
                s.ToString();
            }
        }

        private static void displayparcelunmatched()
        {
            foreach (Parcel p in data.DisplayParcelsUnmatched())
            {
                p.ToString();
            }
        }

        private static void displayparcellist()
        {
            foreach (Parcel p in data.DisplayParcellst())
            {
                p.ToString();
            }
        }

        private static void displaycustomerlist()
        {
            foreach (Customer c in data.DisplayCustomerlst())
            {
                c.ToString();
            }
        }

        private static void displaydronelist()
        {
            foreach (Drone d in data.DisplayDronelst())
            {
                d.ToString();
            }
        }

        private static void displaystationlist()
        {
            foreach (BaseStation s in data.DisplayBaseStationlst())
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
            Location L=new Location();
            L.Latitude = Latitude;
            L.Longitude = Longitued;
            BaseStation NewStation = new BaseStation()
            {
                Id = ID,
                Name = Name,
                location = L,
                AvailableChargingStations = ChargeSlots,
                DroneInChargings = null,
            };

            data.AddBaseStation(NewStation);
        }
        private static void addDrone()
        {

            Weights weights;
            Console.WriteLine("please enter id, model, Max weight,station to charge");
            int ID = Convert.ToInt32(Console.ReadLine());
            String model = Console.ReadLine();
            Weights.TryParse(Console.ReadLine(), out weights);
            int ids = Convert.ToInt32(Console.ReadLine());
            BaseStation b=data.GetBaseStation(ids);
            Location sl = b.location;
            Drone NewDrone = new Drone()
            {
                Id = ID,
                Model = model,
                MaxWeight = weights,
                location1 = sl,
                Battery = r.Next(20, 40),
                status = DroneStatus.Maitenance,
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
            Location L = new Location();
            L.Latitude = latitude;
            L.Longitude = longitued;
            Customer NewCustomer = new Customer()
            {
                Id = ID,
                Name = name,
                Phone = int.Parse(phone),
                location = L,
            };

            data.AddCustomer(NewCustomer);
        }

        private static void addParcel()
        {
            Priorities Priorty;
            Weights Weight;
            Console.WriteLine("please enter Id, Sender ID, Target ID, weight, priorty");
            int ID = Convert.ToInt32(Console.ReadLine());
            int sid= Convert.ToInt32(Console.ReadLine());
            int tid= Convert.ToInt32(Console.ReadLine());
            Weights.TryParse(Console.ReadLine(), out Weight);
            Priorities.TryParse(Console.ReadLine(), out Priorty);
            CustomerParcel pc1 = new CustomerParcel();
            pc1.Id = sid;
            CustomerParcel pc2 = new CustomerParcel();
            pc2.Id = tid;
            DateTime d = new DateTime(0,0,0, 0, 0, 0);
            Parcel NewParcel = new Parcel()
            {
                Id = ID,
                Sender = pc1,
                Getting = pc2,
                weight = Weight,
                priority = Priorty,
                Requsted = DateTime.Now,
                Scheduled=d,
                Delivered=d,
                PickedUp=d,
                droneParcel = null,
            };
          //  data.AddParcel(NewParcel);                                  // לטפל
        }
    }

}
