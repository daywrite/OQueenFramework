using OQueen.Core.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.ModelConfigurations
{
    public class DemoDetailConfiguration : EntityConfigurationBase<DemoDetail, Guid>
    {
        public DemoDetailConfiguration()
        {
            HasRequired(m => m.DemoEntity).WithMany(n => n.DemoDetails);
        }
    }
}
