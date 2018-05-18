using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Model.RLS
{
    public class SecurityGroup : SecurityObject
    {
        public string Name { get; set; }

        public virtual List<SecurityIdentity> GroupMembers { get; set; }
    }
}
