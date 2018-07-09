
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameExChange.Business.Input.UserBusiness
{
    public class LoginInput
    {
        public string UserName { get; set; }
        public string Email { set; get; }
        public string Mobile { get; set; }

        public string Password { get; set; }

        public string VrifyCode { get; set; }
    }
}