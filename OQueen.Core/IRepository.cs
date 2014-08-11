using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core
{
    /// <summary>
    /// 实体仓储模型的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRepository<TEntity, in TKey> : IDependency where TEntity : EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        /// 获取 当前单元操作对象
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 获取 当前实体类型的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        int Insert(TEntity entity);

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        int Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>操作影响的行数</returns>
        int Delete(TEntity entity);

        /// <summary>
        /// 删除指定编号的实体
        /// </summary>
        /// <param name="key">实体编号</param>
        /// <returns>操作影响的行数</returns>
        int Delete(TKey key);

        /// <summary>
        /// 删除所有符合特定条件的实体
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量删除删除实体
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>操作影响的行数</returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">更新后的实体对象</param>
        /// <returns>操作影响的行数</returns>
        int Update(TEntity entity);

        /// <summary>
        /// 使用附带新值的实体更新指定实体属性的值，此方法不支持事务
        /// </summary>
        /// <param name="propertyExpresion">属性表达式，提供要更新的实体属性</param>
        /// <param name="entities">附带新值的实体属性，必须包含主键</param>
        /// <returns>操作影响的行数</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        int Update(Expression<Func<TEntity, object>> propertyExpresion, params TEntity[] entities);

        /// <summary>
        /// 查找指定主键的实体
        /// </summary>
        /// <param name="key">实体主键</param>
        /// <returns>符合主键的实体，不存在时返回null</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// 使用指定查询条件与筛选器查询实体对象的匿名对象结果集合
        /// </summary>
        /// <typeparam name="TEntity">数据源的项类型</typeparam>
        /// <typeparam name="TResult">查询结果的项类型</typeparam>
        /// <param name="predicate">查询表达式的委托</param>
        /// <param name="keySelector">匿名对象的数据筛选条件</param>
        /// <returns>实体对象的匿名对象结果集合</returns>
        IEnumerable<TResult> GetByCondition<TResult>(Expression<Func<TEntity, bool>> predicate, Func<TEntity, TResult> keySelector);

        #endregion
    }
}
