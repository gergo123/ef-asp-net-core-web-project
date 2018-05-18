using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.RLS
{
    public interface IUserSecurityObjectsHandler
    {
        IEnumerable<long> SecurityObjects { get; }
    }
}
