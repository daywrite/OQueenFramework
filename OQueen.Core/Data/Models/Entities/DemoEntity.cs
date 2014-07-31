using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQueen.Core.Data.Models.Entities
{
    public class DemoEntity : EntityBase<int>
    {
        /// <summary>
        /// 获取或设置 名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        public virtual ICollection<DemoDetail> DemoDetails { get; set; }
    }
}
