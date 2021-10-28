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

             Weight weight { set; get; }
            public Priorty priorty { set; get; }
            public DateTime Requsted { set; get; }
            public int Droneld { set; get; }
            public DateTime Scheduled { set; get; }
            public DateTime PickedUp { set; get; }
            public DateTime Delivered { set; get; }

        }
    }
}
