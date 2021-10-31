using System;
using System.Collections.Generic;
using IDAL.DO;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int c;
            do
            {
                Console.WriteLine("Please select an action from options below:");
                Console.WriteLine("0-Add\n 1-Update\n 2-Display item\n 3-Display list\n 4-Exit ");
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
                                Console.WriteLine("please insert id, name, longitude, latitude, charge slotes");
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
                                Console.WriteLine("please insert id, model, weight,status, battery");
                                ID = Convert.ToInt32(Console.ReadLine());
                                Model = Console.ReadLine();
                                Weights.TryParse(Console.ReadLine(), out weights);
                                DroneStatus.TryParse(Console.ReadLine(), out status);
                                battery = Convert.ToDouble(Console.ReadLine());
                                NewDrone.Id = ID;
                                NewDrone.Model = Model;
                                NewDrone.weight = weights;
                                NewDrone.status = status;
                                NewDrone.Battery = battery;
                                DalObject.DalObject.AddDrone(NewDrone);
                                break;
                            case 2:// add customer
                                String name;
                                String Phone;
                                Console.WriteLine("please insert id, name, phone, longitude, latitude");
                                ID= Convert.ToInt32(Console.ReadLine());
                                name = Console.ReadLine();
                                Phone= Console.ReadLine();

                                break;
                            case 3:// add parcel
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
                                break;
                            case 1:// display drone
                                break;
                            case 2:// display customer
                                break;
                            case 3:// display parcel
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
                                break;
                            case 1:// display list of drones
                                break;
                            case 2:// display list of customers
                                break;
                            case 3:// display list of parcels
                                break;
                            case 4: // display list of parcels unmatched
                                break;
                            case 5: // display list of available charging station
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
