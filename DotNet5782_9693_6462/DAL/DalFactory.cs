using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public static class DalFactory
    {
      public static IDal GetDal()
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
            string dlPackageName = dlPackage.PkgName;
            string dlNameSpace = dlPackage.NameSpace;
            string dlClass = dlPackage.ClassName;
            try
            {
                Assembly.Load(dlPackageName);
            }
            catch(KeyNotFoundException ex) {
                throw new DLConfigException($"Cannot load {dlPackageName}", ex);
            }
            DO.IDal dal= (IDal)dlPackage;
            return dal;
        }


    }
}
