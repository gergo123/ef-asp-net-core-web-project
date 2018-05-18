using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Db3.Model.Placeholder;

namespace Db3.Repositories
{
    public class SimplePlaceholderRepository : Interfaces.Repositories.Repository<SimplePlaceHolderEntity>, ISimplePlaceholderRepository
    {
        private Model.CoreContext Context;
        public SimplePlaceholderRepository(DbContext context) : base(context)
        {
        }
    }

    public interface ISimplePlaceholderRepository : Interfaces.Repositories.IEntityRepository<SimplePlaceHolderEntity>
    {
    }
}