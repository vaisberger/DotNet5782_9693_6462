using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DO
{
    public struct Parcel
    {
        public int Id { set; get; }
        public int SenderId { set; get; }
        public int TargetId { set; get; }

        public Weights weight { set; get; }
        public Priorities priorty { set; get; }
        public DateTime? Requsted { set; get; }
        public int DroneId { set; get; }
        public DateTime? Scheduled { set; get; }
        public DateTime? PickedUp { set; get; }
        public DateTime? Delivered { set; get; }
        public override string ToString()//print
        {
            return "ID:" + Id + " SenderId: " + SenderId + " TargetId: " + TargetId + " weight: " + weight + " priorty: " + priorty + " Requsted " + Requsted + " DroneId: " + DroneId + " Scheduled: " + Scheduled + " PickedUp: " + PickedUp + " Delivered: " + Delivered;
        }

    }

}

