using System;
using ReactiveEventPublisher.Events;

namespace ReactiveEventPublisher.ProjectionHandlers
{
  public class AgendaItemProjectionHandler : IProjectionHandler<EventScheduledEvent> 
  {
    public void Handle(EventScheduledEvent message)
    {
      Console.WriteLine("Added a new AgendaItem record with Id '{0}'", message.AggregateRootId);
    }
  }
}