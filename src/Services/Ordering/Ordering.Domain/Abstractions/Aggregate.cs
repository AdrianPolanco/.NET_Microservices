namespace Ordering.Domain.Abstractions
{
    public class Aggregate<TId> : IAggregate<TId>
    {
        public TId Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequedDomainEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequedDomainEvents;
        }
    }
}
