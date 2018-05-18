using Db3.Model.Placeholder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.SecureRepository.PlaceHolder
{
    public class PlaceholderACLRepository : Interfaces.Repositories.Repository<PlaceholderEntityACL>, IPlaceholderACLRepository
    {
        private Model.CoreContext Context;
        public PlaceholderACLRepository(DbContext context) : base(context)
        {
        }
    }

    public interface IPlaceholderACLRepository : Interfaces.Repositories.IEntityRepository<PlaceholderEntityACL>
    {
    }
}
