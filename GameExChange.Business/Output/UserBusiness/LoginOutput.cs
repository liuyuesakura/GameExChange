using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Output.UserBusiness
{
    public class LoginOutput:BaseOutput
    {
        public int UserId { set; get; }
        public string UserName { set; get; }
    }
}
