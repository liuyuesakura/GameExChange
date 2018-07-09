using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Input.UserBusiness
{
    public class DetailModifyInput
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string QQ { set; get; }
    }
}
