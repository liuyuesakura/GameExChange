namespace GameExChange.Infrastructure.Interface
{
    /// <summary>
    /// 领域实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 当前领域实体的全局唯一标识
        /// </summary>
        int ID { get; }
    }
}
