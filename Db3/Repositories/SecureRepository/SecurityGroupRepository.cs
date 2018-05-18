using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Repositories.RLS
{
    public class SecurityGroupRepository : Interfaces.Repositories.Repository<Model.RLS.SecurityGroup>
    {
        public SecurityGroupRepository(DbContext context) : base(context)
        {
        }
    }
}
