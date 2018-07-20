using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Entity.Enum
{
    public class Game
    {

        public enum Status
        {
            [EnumDescription(Description ="未知状态")]
            Unknown = 0,
            [EnumDescription(Description ="等待审核")]
            Pending = 1,
            [EnumDescription(Description ="可交换")]
            Available = 2,
            [EnumDescription(Description ="已封禁")]
            Banned = 4,
        }
    }
}
