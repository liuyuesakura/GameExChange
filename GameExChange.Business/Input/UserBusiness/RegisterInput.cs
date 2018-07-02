using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Input.UserBusiness
{
    public class RegisterInput
    {
        public string Mobile { get; set; }

        public string Password { get; set; }

        public string SmsCode { get; set; }
    }
}
