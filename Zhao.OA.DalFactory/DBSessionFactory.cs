using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.IDAL;

namespace Zhao.OA.DalFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession dbSession = (IDBSession)CallContext.GetData("dbSession");
            if (dbSession == null)
            {
                dbSession = new DalFactory.DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}
