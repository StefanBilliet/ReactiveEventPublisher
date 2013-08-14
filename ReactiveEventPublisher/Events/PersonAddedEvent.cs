using System;

namespace ReactiveEventPublisher.Events
{
  public class PersonAddedEvent : AbstractEvent
  {
    public PersonAddedEvent(Guid id) : base(id)
    {
    }
  }
}