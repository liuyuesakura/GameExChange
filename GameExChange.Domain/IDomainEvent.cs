using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Events;

namespace GameExChange.Domain
{
    public interface IDomainEvent:IEvent
    {
        /// <summary>
        /// 获取产生领域事件的事件源对象
        /// </summary>
        IEntity Source { get; }
    }
}
