using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Parcel
        {
            public int Id { set; get; }
            public int SenderId { set; get; }
            public int TargetId { set; get; }

            public Weights weight { set; get; }
            public Priorities priorty { set; get; }
            public DateTime Requsted { set; get; }
            public int DroneId { set; get; }
            public DateTime Scheduled { set; get; }
            public DateTime PickedUp { set; get; }
            public DateTime Delivered { set; get; }

            public static void Tostring(int Id, int Senderld, int Targetld, Weights weight, Priorities priorty, DateTime Requsted, int Droneld, DateTime Scheduled, DateTime PickedUp, DateTime Delivered)//print
            {
                Console.WriteLine("ID: {0}   Senderld: {1} Longitude: {2} Targetld: {3}  weight: {4} priorty:{5}  Requsted:{6}  Droneld:{7} Scheduled:{8} PickedUp:{9} Delivered ", Id, Senderld, Targetld, weight, priorty, Requsted, Droneld, Scheduled, PickedUp, Delivered);
            }
        }

    }
}
