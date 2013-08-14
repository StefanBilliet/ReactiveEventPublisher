using System;

namespace ReactiveEventPublisher
{
  public class ErrorEvent : AbstractEvent
  {
    public ErrorEvent(Exception exception) : base(Guid.Empty)
    {
      throw new NotImplementedException();
    }
  }
}