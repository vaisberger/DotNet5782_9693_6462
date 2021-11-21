using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL.BO;


namespace IBL
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
            Customer customer = default;
            try
            {
                IDAL.DO.Customer dalCustomper = mydale.DisplayCustomer(id);
            }
            catch (IDAL.DO.CustomerExeptions custEx)
            {
                throw new BLCustomerExption($"Customer id {id} was not found", custEx);
            }
            return customer;
        }
        public BaseStation GetBaseStation(int id)
        {
            BaseStation baseStation = default;

            try
            {
                IDAL.DO.BaseStation dalStation = mydale.DisplayStation(id);
            }
            catch (IDAL.DO.BaseStationExeptions bex)
            {
                throw new BLBaseStationException(bex.Message + "from dal");
            }
        }


    }
}

