namespace GameExChange.Domain.Model
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
