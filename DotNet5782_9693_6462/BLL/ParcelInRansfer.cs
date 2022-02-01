using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ParcelInTransfer
    {
        public int Id { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public CustomerParcel Sender { get; set; }
        public CustomerParcel getting { get; set; }
        public Location Collectionstart { get; set; }
        public Location CollectionDestination { get; set; }
        public bool status { get; set; }
        public double TransportDistance { get; set; }

    }
}
