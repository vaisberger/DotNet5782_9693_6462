using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class IDExistsInTheSystem : Exception
    {
        public int ID;
        public IDExistsInTheSystem(int id) : base() => ID = id;
        public IDExistsInTheSystem(int id, string message) : base(message) => ID = id;
        public IDExistsInTheSystem(int id, string message, Exception exception) : base(message, exception) => ID = id;
        public override string ToString()
        {
            return base.ToString() + $",Exits id:{ID}";
        }



    }
    [Serializable]
    public class IDNotExistsInTheSystem : Exception
    {
        public int ID;
        public IDNotExistsInTheSystem(int id) : base() => ID = id;
        public IDNotExistsInTheSystem(int id, string message) : base(message) => ID = id;
        public IDNotExistsInTheSystem(int id, string message, Exception exception) => ID = id;
        public override string ToString()
        {
            return base.ToString() + $", Doesn't exits id:{ID}";
        }
    }

    [Serializable]
    public class XMLFileLoadCreateException : Exception
    {
        public string File;
        public XMLFileLoadCreateException(string file) : base() => File = file;
        public XMLFileLoadCreateException(string file, string message) : base(message) => File = file;
        public XMLFileLoadCreateException(string file, string message, Exception exception) => File = file;
        public override string ToString()
        {
            return base.ToString() + $", Doesn't exits file:{File}";
        }
    }
}
