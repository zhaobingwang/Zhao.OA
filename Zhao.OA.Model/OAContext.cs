using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhao.OA.Model
{
    public class OAContext : DbContext
    {
        public OAContext() : base("name=OAConn")
        {

        }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
