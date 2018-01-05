using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if (Session["User"]==null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                //filterContext.HttpContext.Response.Write(" <script type='text/javascript'>window.top.location='/Login/Index'; </script>");
                //filterContext.Result = Redirect("/Login/Index");
                filterContext.Result = Content("<script type='text/javascript'>window.top.location='/Login/Index'; </script>");
            }
        }
    }
}