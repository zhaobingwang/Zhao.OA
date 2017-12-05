using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhao.OA.Model
{
    [Table("UserInfo")]
    public class UserInfo
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("名字")]
        public string UName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public string UPwd { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [DisplayName("注册日期")]
        public DateTime RegTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [DisplayName("是否已删除")]
        public int IsDel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Remark { get; set; }
    }
}
