using System;
using System.Collections.Generic;
using System.Linq;

namespace Db3.Utils
{
    public class DbValidationException : Exception
    {
        public DbValidationException(string message) : base(message)
        {
        }

        public DbValidationException(IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> validationResult) : base(
                string.Concat(validationResult.Select(x =>
                {
                    //Get the original type from EFProxy
                    var entityType = System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(x.Entry.Entity.GetType());
                    var errors = string.Concat(x.ValidationErrors.Select(y =>
                        $"\nProperty: {Utils.DisplayAttributeUtils.GetDisplayName(entityType, y.PropertyName)}, Error message: {y.ErrorMessage}"));
                    return $"Entity: {entityType.Name} {errors}\n";
                }))
            )
        {
        }
    }
}
