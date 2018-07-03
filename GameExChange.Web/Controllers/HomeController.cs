using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameExChange.Business.IBusiness;
using GameExChange.Infrastructure;

namespace GameExChange.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserBusiness _userBusiness;

        public HomeController()
        {
            _userBusiness = ServiceLocator.Instance.GetService<IUserBusiness>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public JsonResult Test()
        {
            var input = new Business.Input.UserBusiness.RegisterInput()
            {
                Mobile = "123321",
                Password = "123321",
                SmsCode = "123123"
            };
            var output = _userBusiness.Register(input);
            return Json(output);
           
        }
    }
}
