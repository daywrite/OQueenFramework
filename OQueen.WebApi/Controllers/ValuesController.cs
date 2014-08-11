using OQueen.Application;
using OQueen.Core;
using OQueen.Core.Data.Entity;
using OQueen.Core.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OQueen.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITestContract _testContract;
        //private static IUnitOfWork u = new CodeFirstDbContext();
        //private static IRepository<DemoEntity, int> _demoEntityRepository = new Repository<DemoEntity, int>(u);
        //private static IRepository<DemoDetail, Guid> _demoDetailRepository = new Repository<DemoDetail, Guid>(u);
        //private IDemoContract _demoContract = new DemoService(_demoEntityRepository, _demoDetailRepository);
        //private readonly IDemoContract _demoContract;
        private readonly ITest _test;
        public ValuesController(ITestContract testContract, ITest test)
        {
            _testContract = testContract;
            //_demoContract = demoContract;
            _test = test;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            string value = _testContract.GetString();
            string v = _test.GetString();
            return new string[] { "value1", value };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        #region Ioc测试
        /// <summary>
        /// Ioc测试接口
        /// </summary>
        public interface ITestContract : IDependency
        {
            string GetString();
        }
        /// <summary>
        /// Ioc测试方法
        /// </summary>
        public class TestService : ITestContract
        {
            public string GetString()
            {
                return "Autofac 的 HelloWorld";
            }
        }
        #endregion
    }
}