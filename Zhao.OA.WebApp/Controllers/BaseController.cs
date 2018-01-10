using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhao.OA.Common;
using Zhao.OA.Model;

namespace Zhao.OA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 执行控制器中方法前先调用该方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            string sessionId = CookieHandler.GetCookieValue("sessionId");
            if (!string.IsNullOrEmpty(sessionId))
            {
                var redis = new RedisHelper(0);
                var user = redis.StringGet<UserInfo>($"SESSION:{sessionId}");
                if (user == null)
                {
                    filterContext.Result = Content("<script type='text/javascript'>window.top.location='/Login/Index'; </script>");
                }
            }
            else
            {
                filterContext.Result = Content("<script type='text/javascript'>window.top.location='/Login/Index'; </script>");
            }
        }
    }
}