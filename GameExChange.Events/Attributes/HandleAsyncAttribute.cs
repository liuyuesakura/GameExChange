using System;
using System.Collections.Generic;
using System.Text;

namespace GameExChange.Events.Attributes
{
    /// <summary>
    /// 异步方式处理特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HandleAsyncAttribute:Attribute
    {
    }
}
