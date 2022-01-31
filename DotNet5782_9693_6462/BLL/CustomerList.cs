using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CustomerList
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int ParcelSentAndDelivered { get; set; }
        public int ParcelSentAndNotDelivered { get; set; }
        public int ParceloReceived{ get; set; }
        public int ParcelWayToCustomeer { get; set; }
    }
}
