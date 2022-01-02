﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalApi
{
    static class DLConfig
    {
        internal static string dlname;
        internal static Dictionary<string, string> dlpackages;
        static DLConfig()
        {
           XElement dlConfig = XElement.Load(@"dal_config.xml");
            dlname = dlConfig.Element("dal").Value;
            dlpackages = (from pkg in dlConfig.Element("dal-packages").Elements() select pkg).ToDictionary(p => "" + p.Name, p => p.Value);
        }
    }
    public class DalConfingExeption : Exception
    {
        public DalConfingExeption(string msg) : base(msg) { }
        public DalConfingExeption(string msg,Exception ex) : base(msg, ex) { }
    }
}
