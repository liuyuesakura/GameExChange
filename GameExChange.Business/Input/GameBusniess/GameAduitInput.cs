using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Business.Input.GameBusniess
{
    public class GameAduitInput
    {
        public int GameId { set; get; }

        public bool IsAduit { set; get; }

        /// <summary>
        /// 可空
        /// </summary>
        public string Reason { set; get; }
    }
}
