using System;
using System.Collections.Generic;


namespace IBL.BO
{
    public class BL 
    {
        private IDal dal;
        private List<BO.Drone> drons;
        public BL()
        {
            drons = new List<Drone>();
            dal = new DalObject.DalObject();


        }
        public void AddBaseStation()
        {
            throw new NotImplementedException();
        }
        public int AddDrone()
        {
            throw new NotImplementedException();
        }
        
    }

}
