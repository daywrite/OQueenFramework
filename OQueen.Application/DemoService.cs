using OQueen.Core;
using OQueen.Core.Data.Infrastructure;
using OQueen.Core.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Application
{
    public class DemoService : ServiceBase, IDemoContract
    {
        private readonly IRepository<DemoEntity, int> _demoEntityRepository;
        private readonly IRepository<DemoDetail, Guid> _demoDetailRepository;

        public DemoService(IRepository<DemoEntity, int> demoEntityRepository,
            IRepository<DemoDetail, Guid> demoDetailRepository)
            : base(demoEntityRepository.UnitOfWork)
        {
            _demoEntityRepository = demoEntityRepository;
            _demoDetailRepository = demoDetailRepository;
        }

        /// <summary>
        /// 获取 DemoEntity查询数据集
        /// </summary>
        public IQueryable<DemoEntity> DemoEntities
        {
            get { return _demoEntityRepository.Entities; }
        }

        /// <summary>
        /// 获取 DemoDetail查询数据集
        /// </summary>
        public IQueryable<DemoDetail> DemoDetails
        {
            get { return _demoDetailRepository.Entities; }
        }

        public string GetData()
        {
            return "UnitOfWork 对象的 HashCode：" + UnitOfWork.GetHashCode();
        }

        public DemoEntity Add(DemoEntity entity)
        {
            _demoEntityRepository.Insert(entity);
            return _demoEntityRepository.GetByKey(entity.Id);
        }


    }
}
