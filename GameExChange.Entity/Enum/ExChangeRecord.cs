using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Entity.Enum
{
    public class ExChangeRecord
    {
        public enum Statues
        {
            [EnumDescription(Description = "未知")]
            Unknown = 0,
            [EnumDescription(Description = "交换申请人申请中")]
            BorrowerApplying = 1,
            [EnumDescription(Description = "商议中")]
            Discussing = 2,
            [EnumDescription(Description = "交换中")]
            ExChanging = 4,
            [EnumDescription(Description = "已归还，交换结束")]
            Returned = 8
        }

        public enum Types
        {
            [EnumDescription(Description = "未知")]
            Unknown = 0,
            [EnumDescription(Description = "游戏交换")]
            ExChange = 1,
            [EnumDescription(Description = "仅借游戏")]
            Borrow = 2
        }
    }
}
