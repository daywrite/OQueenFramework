using OQueen.Core.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.ModelConfigurations.Seed
{
    public static class SeedAction 
    {
        public static void Seed()
        {
            CreateDatabaseIfNotExistsWithSeed.SeedActions.Add(new DemoEntitySeedAction());
        }
    }
}
