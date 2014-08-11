using OQueen.Core.Data.Entity;
using OQueen.Core.Data.Migrations;
using OQueen.Core.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.ModelConfigurations.Seed
{
    public class DemoEntitySeedAction : ISeedAction
    {
        public int Order
        {
            get { return 1; }
        }

        public void Action(CodeFirstDbContext context)
        {
            DemoEntity demoEntity = new DemoEntity() { Id = 1, Name = "demo", Remark = "demo" };

            context.Set<DemoEntity>().Add(demoEntity);
            context.SaveChanges();
        }
    
    }
}
