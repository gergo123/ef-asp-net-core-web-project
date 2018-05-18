using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Interfaces.RLS
{
    public interface IACLEntity
    {
        long EntityID { get; set; }
        PermissionEnum Permission { get; set; }
        long SecurityObjectID { get; set; }
    }
}
