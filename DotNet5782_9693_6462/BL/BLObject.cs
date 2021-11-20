using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL.BO;
namespace BL
{
    public class BLObject
    {
        IDAL.DO.IDal mydale;
        public BLObject()
        {
            mydale = new DalObject.DalObject();
        }
        public Customer GetCustomer(int id)
        {

        }
    }
}
