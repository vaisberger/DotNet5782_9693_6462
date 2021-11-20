using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    namespace BO
    {
       public class Customer
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Phone { get; set; }
            public Location Location { get; set; }
            List<ParcelCustomer> SendParcels { get; set; }
            List<ParcelCustomer> Parcels { get; set; }

        }
    }
}
