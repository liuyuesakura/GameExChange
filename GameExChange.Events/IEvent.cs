using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Events
{
    /// <summary>
    /// 事件接口
    /// </summary>
    public interface IEvent
    {
        Guid ID { get; }

        // 获取产生事件的时间
        DateTime TimeStamp { get; }
    }
}
