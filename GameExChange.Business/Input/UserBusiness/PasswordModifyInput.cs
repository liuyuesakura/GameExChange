using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Input.UserBusiness
{
    public class PasswordModifyInput
    {
        public int Id { set; get; }
        public string OldPwd { set; get; }
        public string NewPwd { set; get; }
    }
}
