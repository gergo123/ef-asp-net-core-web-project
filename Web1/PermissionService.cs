using Db3;
using Db3.Model.RLS;
using Db3.Repositories.RLS;
using Db3.RLS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1
{
    public class PermissionService
    {
        private readonly SecurityIdentityRepository RlsIdentityRepo;
        private CurrentUserProvider CurrentUser;
        private readonly ILogger _logger;
        public PermissionService(SecurityIdentityRepository RlsIdentityRepo, CurrentUserProvider CurrentUser,
            ILogger<PermissionService> _logger)
        {
            this.RlsIdentityRepo = RlsIdentityRepo;
            this.CurrentUser = CurrentUser;
            this._logger = _logger;
        }

        public SecurityIdentity RegisterUserIfNotExists(string identifier)
        {
            var identity = RlsIdentityRepo.Find(x => x.Identifier.Equals(identifier)).SingleOrDefault();

            if (identity == null)
            {
                var newUser = new SecurityIdentity
                {
                    Identifier = identifier
                };
                RlsIdentityRepo.Add(newUser);
                RlsIdentityRepo.SaveChanges();

                return newUser;
            }
            else
            {
                return identity;
            }
        }

        public void AddCurrentUserToAdminGroup()
        {
            var adminGroup = RlsIdentityRepo.GetGroup(DefaultData.AdminGroup.Id);
            var user = RlsIdentityRepo.GetById(int.Parse(CurrentUser.Identity.Id.ToString()));
            if (!user.GroupMemberShips.Where(x => x.Id == adminGroup.Id).Any())
            {
                adminGroup.GroupMembers.Add(user);
                RlsIdentityRepo.SaveChanges();
            }
        }
    }
}
