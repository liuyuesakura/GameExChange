namespace GameExChange.Events
{
    /// <summary>
    /// 事件处理接口
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        /// <summary>
        /// 处理指定事件
        /// </summary>
        /// <param name="event"></param>
        void Handle(TEvent @event);
    }
}
