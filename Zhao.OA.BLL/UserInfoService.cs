using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.Model;

namespace Zhao.OA.BLL
{
    public class UserInfoService : BaseService<UserInfo>
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }
    }
}
