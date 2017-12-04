using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.DAL;
using Zhao.OA.IDAL;
using Zhao.OA.Model;

namespace Zhao.OA.DalFactory
{
    /// <summary>
    /// 数据会话层
    /// </summary>
    public class DBSession : IDBSession
    {
        //OAContext db = new OAContext();
        public DbContext db
        {
            get
            {
                return DBContextFactory.CreateDbContext();
            }
        }
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    //_UserInfoDal = new UserInfoDal();
                    _UserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set
            {
                _UserInfoDal = value;
            }
        }

        /// <summary>
        /// 工作单元模式
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
