using Db3.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db3.RLS;
using System.Data.Entity;
using Db3.Model.Placeholder;

namespace Db3.SecureRepository.PlaceHolder
{
    public class PlaceholderSecureRepository : RLSRepositoryBase<PlaceholderEntity, PlaceholderEntityACL>, IPlaceholderSecureRepository
    {
        public IPlaceholderACLRepository ACL;
        public PlaceholderSecureRepository(DbContext context, IUserSecurityObjectsHandler securityObjects, IPlaceholderACLRepository aclRepo) :
            base(context, securityObjects)
        {
            ACL = aclRepo;
        }
    }

    public interface IPlaceholderSecureRepository : IRLSRepository<PlaceholderEntity, PlaceholderEntityACL>
    {
    }
}
