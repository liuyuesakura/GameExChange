using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Input.GameBusniess
{
    public class GetListInput
    {
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public string GameName { set; get; }
        public string GameType { set; get; }
    }
}
