#region 头部注释
// -----------------------------------------------------------------------
//  文件名称： "CodeFirstDbContext.cs"
//  公司名称：北京思路华清信息技术有限公司
//  作者：李文彬
//  创建时间：2014-07-30 12:58
//  版本：V1.0
// -----------------------------------------------------------------------
//          修改人     |       修改时间
// -----------------------------------------------------------------------
//                     |
// -----------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.Entity
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext()
            : base(ConfigurationManager.AppSettings["ConnectionStringName"])
        { }

        /// <summary>
        /// 获取或设置 是否开启事务提交
        /// </summary>
        public bool TransactionEnabled { get; set; }

        /// <summary>
        /// 提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数</returns>
        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        /// <summary>
        /// 提交当前单元操作的更改。
        /// </summary>
        /// <param name="validateOnSaveEnabled">提交保存时是否验证实体约束有效性。</param>
        /// <returns>操作影响的行数</returns>
        internal int SaveChanges(bool validateOnSaveEnabled)
        {
            bool isReturn = Configuration.ValidateOnSaveEnabled != validateOnSaveEnabled;
            try
            {
                Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
                int count = base.SaveChanges();
                TransactionEnabled = false;
                return count;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    //string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    //throw new OSharpException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
            finally
            {
                if (isReturn)
                {
                    Configuration.ValidateOnSaveEnabled = !validateOnSaveEnabled;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //注册实体配置信息
            ICollection<IEntityMapper> entityMappers = DatabaseInitializer.EntityMappers;
            foreach (IEntityMapper mapper in entityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }
    }
}
