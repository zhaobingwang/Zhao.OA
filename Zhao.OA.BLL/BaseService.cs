using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.DalFactory;
using Zhao.OA.IDAL;

namespace Zhao.OA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                return new DBSession();
            }
        }
        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();
        public BaseService()
        {
            SetCurrentDal();
        }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }
    }
}
