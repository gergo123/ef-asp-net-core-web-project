using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Rules
{
    public interface IRule
    {
        /// <summary>
        /// Collection for errors during ExecuteRule.
        /// </summary>
        List<System.Data.Entity.Validation.DbValidationError> Errors { get; set; }

        /// <summary>
        /// Validation logic.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        System.Data.Entity.Validation.DbEntityValidationResult ExecuteRule(System.Data.Entity.Infrastructure.DbEntityEntry entry);

        /// <summary>
        /// Returns whether the rule should be executed depending on the entry (ex.: entry's state).
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        bool ShouldValidate(System.Data.Entity.Infrastructure.DbEntityEntry entry);
    }
}
