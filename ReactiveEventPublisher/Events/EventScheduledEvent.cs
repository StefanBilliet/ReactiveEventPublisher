using System;

namespace ReactiveEventPublisher.Events
{
  public class EventScheduledEvent : AbstractEvent
  {
    public EventScheduledEvent(Guid id) : base(id)
    {
    }
  }
}