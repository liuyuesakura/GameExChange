using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Domain
{
    /// <summary>
    /// 聚合根接口，继承于该接口的对象是外部唯一操作的对象
    /// </summary>
    public interface IAggregateRoot:IEntity
    {
    }
}
