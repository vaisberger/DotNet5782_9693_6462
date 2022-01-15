using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo
{
    class ParcelList
    {
        public int Id { get; set; }
        public string SenderId { set; get; }
        public string TargetId { set; get; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public Status status { get; set; }

    }
}
