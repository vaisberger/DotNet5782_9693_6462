using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class ParcelToList
    {
        public int Id { get; set; }
        public int SenderId { set; get; }
        public int TargetId { set; get; }
        public Weights? weight { get; set; }
        public Priorities? priority { get; set; }
        public Status status { get; set; }
        public override string ToString()
        {
            return "ID" + Id;
        }
    }
}
