using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ordering.Infrastructure.Data.Interceptors
{
    public class DispatchDomainEventInterceptor(IMediator mediator) : SaveChangesInterceptor
    {

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEventsAsync(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEventsAsync(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchDomainEventsAsync(DbContext? context)
        {
            if(context == null) return;

            IEnumerable<IAggregate>? aggregates = context.ChangeTracker.Entries<IAggregate>().Where(e => e.Entity.DomainEvents.Any()).Select(e => e.Entity);

            List<IDomainEvent> domainEvents = aggregates.SelectMany(e => e.DomainEvents).ToList();

            aggregates.ToList().ForEach(e => e.ClearDomainEvents());

            foreach (IDomainEvent domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
