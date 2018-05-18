using EFTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Db3.Model.Placeholder;

namespace Core.Rules.rules.Episode
{
    [Rule(typeof(PlaceholderEntity))]
    public class PlaceholderRule : IRule
    {
        public List<DbValidationError> Errors { get; set; } = new List<DbValidationError>();
        public PlaceholderRule()
        {
            // TODO Dependency injection
        }

        public DbEntityValidationResult ExecuteRule(DbEntityEntry entry)
        {
            var entity = entry.Entity as PlaceholderEntity;

            // Validation...

            return new DbEntityValidationResult(entry, Errors);
        }

        public bool ShouldValidate(DbEntityEntry entry)
        {
            if (entry.State == System.Data.Entity.EntityState.Modified || entry.State == System.Data.Entity.EntityState.Added)
            {
                return true;
            }

            return false;
        }
    }
}
