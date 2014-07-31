using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.Models.Entities
{
    public class DemoDetail : EntityBase<Guid>
    {
        public string Content { get; set; }

        public bool IsLocked { get; set; }

        public virtual DemoEntity DemoEntity { get; set; }
    }
}
