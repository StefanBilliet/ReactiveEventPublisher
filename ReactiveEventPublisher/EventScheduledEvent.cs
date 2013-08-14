using System;

namespace ReactiveEventPublisher
{
  public class EventScheduledEvent : AbstractEvent
  {
    public EventScheduledEvent(Guid id) : base(id)
    {
    }
  }
}