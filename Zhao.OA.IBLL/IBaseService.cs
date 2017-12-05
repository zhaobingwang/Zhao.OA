using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.IDAL;

namespace Zhao.OA.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IDBSession CurrentDBSession { get; }
        IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc = true);
        bool EditEntity(T entity);
        bool DeleteEntity(T entity);
        T AddEntity(T entity);
    }
}
