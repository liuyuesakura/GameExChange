using GameExChange.Infrastructure.Interface;
namespace GameExChange.Entity
{
    public abstract class AggregateRoot:IAggregateRoot
    {
        public int ID
        {
            get;
            set;
        }
    }
}
