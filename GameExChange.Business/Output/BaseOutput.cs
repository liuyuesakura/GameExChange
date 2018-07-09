using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Output
{
    public class BaseOutput
    {
        public bool IsSuccess { set; get; }
        public string ErrMessage { set; get; }
    }
}
