using IBL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bo
{
    public class ParcelInTransfer
    {
        public int Id { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public CustomerParcel Sender { get; set; }
        public CustomerParcel getting { get; set; }
        public Location Collection { get; set; }
        public Location CollectionDestination { get; set; }
        public double TransportDistance { get; set; }

    }
}
