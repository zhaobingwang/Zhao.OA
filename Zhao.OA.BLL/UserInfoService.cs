using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.IBLL;
using Zhao.OA.Model;

namespace Zhao.OA.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public bool DeleteEntities(List<string> list)
        {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.Id.ToString()));
            foreach (var userInfo in userInfoList)
            {
                userInfo.IsDel = 1;
                this.CurrentDBSession.UserInfoDal.EditEntity(userInfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }

        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }
    }
}
