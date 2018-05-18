using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db3.Model.RLS;

namespace Db3
{
    public static class DefaultData
    {
        public static SecurityGroup AdminGroup = new SecurityGroup
        {
            // Assuming this groups gets the first ID in the table
            Id = 1,
            Name = "Administrators"
        };
    }
}
