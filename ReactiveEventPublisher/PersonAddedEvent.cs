using System;

namespace ReactiveEventPublisher
{
  public class PersonAddedEvent : AbstractEvent
  {
    public PersonAddedEvent(Guid id) : base(id)
    {
    }
  }
}