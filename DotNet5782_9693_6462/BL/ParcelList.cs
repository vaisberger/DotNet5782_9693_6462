using IBL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.Bo
{
    class ParcelList
    {
        public int Id { get; set; }
        public string NameSender { get; set; }
        public string NmaeGetting { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public Situation situation { get; set; }

    }
}
