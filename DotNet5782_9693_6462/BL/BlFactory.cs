using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BLObject
{
    public static class BlFactory
    {

        public static IBl GetBl()
        {


            return new BLObject();
        }
    }
}