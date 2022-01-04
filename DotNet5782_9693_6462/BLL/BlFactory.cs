using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BLApi
    {
        public static class BlFactory
        {
        public static IBl GetBl() => BLObject.BLObject.Instance;

        }
    }
