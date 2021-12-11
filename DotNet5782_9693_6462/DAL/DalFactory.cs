using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public static class DalFactory
    {
      public static IDal GetDel()
        {
            string dlType = DLConfig.DLName;
            DLConfig.DLPackage dlPackage;
            try
            {
                dlPackage = DLConfig.DLPackages[dlType];
            }
            catch(KeyNotFoundException xx)
            {
                throw new DLConfigException($"Wrong DL type: {dlType}", xx);
            }
           
        }

    }
}
