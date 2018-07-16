using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameExChange.Web.Common
{
    public class UserAuthorization : Attribute,IAuthorizationFilter
    {
        private string _method;
        public string Method
        {
            get => (_method ?? "").ToLower();
            set => _method = value;
        }

        private bool _loginRequired;
        public bool LoginRequired
        {
            get => _loginRequired;
            set => _loginRequired = value;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = "";
            context.HttpContext.Request.Cookies.TryGetValue("accesstoken",out token);

            if(string.IsNullOrEmpty(token) && LoginRequired)
                context.Result = new JsonResult(new { error = -1,msg = "请先登录" });
            //throw new NotImplementedException();
        }
    }
}
