using OQueen.Core;
using OQueen.Core.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Application
{
    /// <summary>
    /// 示例业务契约，需继承于IDependency接口，才能被IoC组件识别并与实现类映射
    /// </summary>
    public interface IDemoContract : IDependency
    {
        /// <summary>
        /// 获取 DemoEntity查询数据集
        /// </summary>
        IQueryable<DemoEntity> DemoEntities { get; }

        /// <summary>
        /// 业务功能，此处只获取数据
        /// </summary>
        /// <returns></returns>
        string GetData();

        DemoEntity Add(DemoEntity entity);
    }
}
