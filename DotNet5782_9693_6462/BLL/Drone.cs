using BL;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Drone
    {
        public int Id { get; set; }
        public String Model { get; set; }
        public Weights MaxWeight { get; set; }
        public DroneStatus status { get; set; }
        public double Battery { get; set; }
        public ParcelInTransfer ParcelIntransfer { get; set; }
        public Location location1 { get; set; }
        public override string ToString()//print
        {
            return "Id: " + Id + " Model: " + Model + " Max Weight: " + MaxWeight + " Status: " + status + "Battey: " + Battery + "Parcel In Transfer:" + ParcelIntransfer + "Location:" + location1;
        }
    }
}
