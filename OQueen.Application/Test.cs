using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Application
{
    public class Test : ITest
    {
        public string GetString()
        {
            return "Autofac 的 HelloWorld";
        }
    }
}
