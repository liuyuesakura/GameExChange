using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Output.UserBusiness
{
    public class RegisterOutput
    {
        public int UserID { get; set; }

        public string Name { get; set; }
        
        public bool IsSuccess { get; set; }

        public RegisterOutput()
        {
            if (!this.IsSuccess)
            {
                this.Name = string.Empty;
                this.UserID = 0;
            }
        }
    }
}
