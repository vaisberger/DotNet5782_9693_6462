using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public  class DalFactory
    {
      public static IDal GetDal()
        {
            string dlType = DLConfig.dlname;
            string dlPackage=DLConfig.dlpackages[dlType];
            if (dlPackage == null)
            {
                throw new DalConfingExeption($"Package {dlType} is not found in packages list in dal-config.xml");
            }

            try
            {
                Assembly.Load(dlPackage);
            }
            catch(Exception)
            {
                throw new DalConfingExeption($"Faild to load the dal-config.wml file");
            }

            Type type = Type.GetType($"Dal.{dlPackage}, {dlPackage}");
            if (type == null)
            {
                throw new DalConfingExeption($"Class {dlPackage} was not found in the {dlPackage}.dll");
            }
            IDal dal = (IDal)type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null);
            if (dal == null)
            {
                throw new DalConfingExeption($"Class {dlPackage} is not a singleton or wrong propertry name for Instance");
            }
            return dal;
        }


    }
}
