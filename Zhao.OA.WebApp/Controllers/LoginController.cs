using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhao.OA.Common;

namespace Zhao.OA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        IBLL.IUserInfoService UserInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            string login_remember = CookieHandler.GetCookieValue("login_remember");
            if (!string.IsNullOrEmpty(login_remember))
            {
                login_remember = new AESCryptHandler().Decrypt(login_remember);
                JObject cookieInfo = JObject.Parse(login_remember);
                string cookie_id = cookieInfo["id"].ToString();
                string cookie_name = cookieInfo["username"].ToString();
                string cookie_pwd = cookieInfo["password"].ToString();
                var user = UserInfoService.LoadEntities(u => u.Id.ToString() == cookie_id && u.UName == cookie_name && u.UPwd == cookie_pwd).ToList();
                if (user != null)
                {
                    Session["User"] = user;
                    return Content("<script type='text/javascript'>window.top.location='/Home/Index'; </script>");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            string uName = Request["UName"];
            string uPwd = Request["UPwd"];
            string code = Request["code"];
            string remember_me = Request["remember_me"];

            string validateCode = Session["ValidateCode"] != null ? Session["ValidateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Json(new { Status = "-1", Msg = "验证码错误" });
            }
            Session["ValidateCode"] = null;
            if (!validateCode.Equals(code, StringComparison.InvariantCultureIgnoreCase))
            {
                return Json(new { Status = "-1", Msg = "验证码错误" });
            }

            var user = UserInfoService.LoadEntities(u => u.UName == uName && u.UPwd == uPwd).FirstOrDefault();
            if (user != null)
            {
                Session["User"] = user;
                if (remember_me == "remember-me")
                {
                    //记录用户信息到cookies
                    string cookievalue = "{\"id\":\"" + user.Id + "\",\"username\":\"" + user.UName + "\",\"password\":\"" + user.UPwd + "\",\"Token\":\"" + Session.SessionID + "\"}";
                    CookieHandler.SetCookie("login_remember", new Common.AESCryptHandler().Encrypt(cookievalue),7);
                }

                return Json(new { Status = "1", Msg = "登录成功" });
            }
            else
            {
                return Json(new { Status = "-1", Msg = "登录失败,用户名或密码错误" });
            }
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] codeImgBuffer = validateCode.CreateValidateGraphic(code);
            return File(codeImgBuffer, "image/jpeg");
        }
    }
}