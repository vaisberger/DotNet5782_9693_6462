﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IBL.BO
{
    public interface IBL
    {
        public void AddDrone(Drone drone, int id);
        public void AddBaseStation(BaseStation baseStation);
    }
}

