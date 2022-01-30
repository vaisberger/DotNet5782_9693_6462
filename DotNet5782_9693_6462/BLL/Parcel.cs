using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    public class Parcel
    {
        public int Id { set; get; }
        public CustomerParcel Sender { get; set; }
        public CustomerParcel Getting { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public DroneParcel droneParcel { get; set; }
        public DateTime? Scheduled { set; get; }
        public DateTime? PickedUp { set; get; }
        public DateTime? Delivered { set; get; }
        public DateTime? Requsted { set; get; }
        public override string ToString()//print
        {
            return "ID:" + Id + " SenderId: " + Sender + " TargetId: " + Getting + " weight: " + weight + " priorty: " + priority + " Requsted " + Requsted + "droane Parcel:" + droneParcel + " Scheduled: " + Scheduled + " PickedUp: " + PickedUp + " Delivered: " + Delivered;
        }
    }
}

