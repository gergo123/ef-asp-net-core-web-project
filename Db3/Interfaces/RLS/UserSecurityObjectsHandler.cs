using Db3.Repositories.RLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.RLS
{
    public class UserSecurityObjectsHandler : IUserSecurityObjectsHandler
    {
        private IEnumerable<long> securityObjects;
        public IEnumerable<long> SecurityObjects
        {
            get
            {
                // TODO refresh if user security object list changes
                if (securityObjects == null)
                {
                    // Get current user SecurityObjects
                    // Current identity id, and group ids
                    var secIdentity = SecIdentityRepo.Find(x => x.Identifier.Equals(CurrentUserProvider.CurrentUserIdentifier)).Single();
                    var secGroupIds = secIdentity.GroupMemberShips.Select(x => x.Id);

                    var ls = new List<long>() { secIdentity.Id };
                    ls.AddRange(secGroupIds);
                    securityObjects = ls;
                }

                return securityObjects;
            }
        }

        private CurrentUserProvider CurrentUserProvider;
        private SecurityIdentityRepository SecIdentityRepo;

        public UserSecurityObjectsHandler(
            CurrentUserProvider currentUserProvider,
            SecurityIdentityRepository secIdentityRepo)
        {
            CurrentUserProvider = currentUserProvider;
            SecIdentityRepo = secIdentityRepo;
        }
    }
}
