using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DO
{
    public class DroneCharge
    {
        public int DroneId { set; get; }
        public int StatioId { set; get; }
        public DateTime startcharge { set; get; } 
        public override string ToString()
        {
            return "Droneld: " + DroneId + "StatioId: " + StatioId;
        }
    }
}

