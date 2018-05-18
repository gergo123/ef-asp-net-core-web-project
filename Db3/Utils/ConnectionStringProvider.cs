using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Utils
{
    public class ConnectionStringProvider
    {
        public string ConnString { get; }

        public ConnectionStringProvider(string connString)
        {
            ConnString = connString;
        }
    }
}
