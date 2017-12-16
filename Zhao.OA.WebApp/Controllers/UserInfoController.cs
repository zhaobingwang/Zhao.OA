using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhao.OA.BLL;
using Zhao.OA.IBLL;
using Zhao.OA.Model;

namespace Zhao.OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoService userInfoService = new UserInfoService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserInfo()
        {
            //for (int i = 1; i < 6; i++)
            //{
            //    UserInfo u = new UserInfo();
            //    u.Id = Guid.NewGuid();
            //    u.IsDel = 0;
            //    u.ModifyTime = DateTime.Now;
            //    u.RegTime = DateTime.Now;
            //    u.Remark = $"这是测试备注{i}";
            //    u.UName = $"测试用户{i}";
            //    u.UPwd = "123456";
            //    userInfoService.AddEntity(u);
            //}

            try
            {
                int pageSize = int.Parse(Request["pageSize"] == null ? "10" : Request["pageSize"]);
                int pageIndex = int.Parse(Request["pageIndex"] == null ? "1" : Request["pageIndex"]);
                int totalCount = 0;

                IList<UserInfo> userInfo = userInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount, c => c.IsDel == 0, c => c.UName).ToList();
                if (totalCount == 0)
                    return Json(new { errcode = "未找到记录" });
                return Json(new { errcode = 1, dataLength = totalCount, rowDatas = userInfo });
            }
            catch (Exception ex)
            {
                //TODO:写日志
                return Json(new { errcode = ex.Message });
            }
        }

        public ActionResult DeleteUserInfo()
        {
            bool isSuccess = false;
            string returnMsg = string.Empty;
            string ids = Request["ids"];
            if (ids.Length < 1)
                return Json(new { flag = false, msg = "未选择记录" });
            try
            {
                string[] idArray = ids.Split(',');
                List<string> idList = new List<string>();

                foreach (var item in idArray)
                {
                    idList.Add(item);
                }
                isSuccess = userInfoService.DeleteEntities(idList);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                //TODO:写日志
                returnMsg = ex.InnerException.Message;
            }
            return Json(new { flag = isSuccess, msg = returnMsg });
        }

        public ActionResult Details()
        {
            try
            {
                string id = Request["Id"];
                var _entity = new UserInfo();
                if (id != null)
                {
                    _entity = userInfoService.LoadEntities(u => u.Id.ToString() == id).FirstOrDefault();
                }
                return View(_entity);
            }
            catch (Exception ex)
            {
                //TODO:写日志
                throw ex.InnerException;
            }
        }

        public ActionResult addTest()
        {
            for (int i = 6; i < 10; i++)
            {
                UserInfo u = new UserInfo();
                u.Id = Guid.NewGuid();
                u.IsDel = 0;
                u.ModifyTime = DateTime.Now;
                u.RegTime = DateTime.Now;
                u.Remark = $"这是测试备注{i}";
                u.UName = $"测试用户{i}";
                u.UPwd = "123456";
                userInfoService.AddEntity(u);
            }
            return Json(new { flag = true, msg = "添加成功" });
        }
    }
}