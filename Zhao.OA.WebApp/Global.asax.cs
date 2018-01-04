using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Zhao.OA.WebApp.Models;

namespace Zhao.OA.WebApp
{
    public class WebApiApplication : Spring.Web.Mvc.SpringMvcApplication//System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure(); //读取log4net配置信息
            ThreadPool.QueueUserWorkItem((t) =>
            {
                while (true)
                {
                    if (MyExceptionAttribute.queueException.Count <= 0)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                        continue;
                    }
                    Exception ex = MyExceptionAttribute.queueException.Dequeue();
                    if (ex != null)
                    {
                        ILog logger = LogManager.GetLogger("errorMsg");
                        logger.Error(ex.ToString());
                    }
                }
            });
        }
    }
}
