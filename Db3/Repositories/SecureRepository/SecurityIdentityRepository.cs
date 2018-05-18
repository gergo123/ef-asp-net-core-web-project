using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db3.Model;
using Db3.Model.RLS;

namespace Db3.Repositories.RLS
{
    public class SecurityIdentityRepository : Interfaces.Repositories.Repository<Model.RLS.SecurityIdentity>
    {
        private CoreContext Context { get; }

        public SecurityIdentityRepository(DbContext context) : base(context)
        {
            Context = context as CoreContext;
        }

        public SecurityGroup GetGroup(long id)
        {
            return Context.SecurityObjects.OfType<SecurityGroup>().Where(x => x.Id == id).Single();
        }
    }
}
