using OQueen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Application
{
    public interface ITest : IDependency
    {
        string GetString();
    }
}
