using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.Model;

namespace Zhao.OA.DAL
{
    /// <summary>
    /// EF上下文实例创建，保证线程内唯一
    /// </summary>
    public class DBContextFactory
    {
        /// <summary>
        /// EF上下文实例创建,如果不存在则创建，存在则使用已有对象。
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext==null)
            {
                dbContext = new OAContext();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
