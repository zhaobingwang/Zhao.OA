using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhao.OA.IDAL
{
    public interface IDBSession
    {
        DbContext db { get; }
        IUserInfoDal UserInfoDal { get; set; }
        bool SaveChanges();
    }
}
