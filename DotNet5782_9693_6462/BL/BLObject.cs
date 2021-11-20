using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DalObject;
using IDAL.DO;
namespace BL
{
    class BLObject
    {
        IDal dAL;
        public BLObject()
        {
            dAL = new DalObject.DalObject();
        }
    }
}
