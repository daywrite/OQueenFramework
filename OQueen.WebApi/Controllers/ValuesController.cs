using OQueen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OQueen.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITestContract _testContract;
        public ValuesController(ITestContract testContract)
        {
            _testContract = testContract;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            string value = _testContract.GetString();
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