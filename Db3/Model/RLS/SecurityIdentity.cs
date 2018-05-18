using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Model.RLS
{
    public class SecurityIdentity : SecurityObject
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        // Ex.: Username
        public string Identifier { get; set; }

        public virtual List<SecurityGroup> GroupMemberShips { get; set; }
    }
}
