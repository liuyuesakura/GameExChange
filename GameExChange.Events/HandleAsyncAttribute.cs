using System;

namespace GameExChange.Events
{
    /// <summary>
    /// 异步方式处理特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HandleAsyncAttribute:Attribute
    {
    }
}
