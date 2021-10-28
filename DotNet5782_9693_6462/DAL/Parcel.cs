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
            public int Senderld { set; get; }
            public int Targetld { set; get; }

            public Weight weight { set; get; }
            public Priorty Priorty { set; get; }
            public DateTime Requsted { set; get; }
            public int Droneld { set; get; }
            public DateTime Scheduled { set; get; }
            public DateTime PickedUp { set; get; }
            public DateTime Delivered { set; get; }
            public static void Topstring(int Id, int SenderId, int TargetId, Weight weight, Priorty priorty, DateTime Requsted, int Droneld , DateTime Scheduled, DateTime PickedUp, DateTime Delivered)
            {
                Console.WriteLine("Id: {0} Senderld : {1} Targetld : {2}  Weight: {3}  Priorty: {4}", Id, Senderld, Targetld, weight, Priorty);
            }
        }

    }
}
