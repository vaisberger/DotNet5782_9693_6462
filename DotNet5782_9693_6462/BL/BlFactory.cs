using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
namespace BL
{
    public static class BlFactory
    {

        public static IBl GetBl()
        {
            BO.IBl ibl;

            return ibl;
        }
    }
}