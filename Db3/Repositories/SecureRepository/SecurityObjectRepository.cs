using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Repositories.RLS
{
    public class SecurityObjectRepository : Interfaces.Repositories.Repository<Model.RLS.SecurityObject>
    {
        public SecurityObjectRepository(DbContext context) : base(context)
        {
        }
    }
}
