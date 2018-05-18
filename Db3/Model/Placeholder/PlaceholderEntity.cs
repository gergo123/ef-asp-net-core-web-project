using Db3.Interfaces.RLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db3.Model.Placeholder
{
    public class PlaceholderEntity : ISecurityEntity
    {
        public long Id { get; set; }

        // Additional props goes here...
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
