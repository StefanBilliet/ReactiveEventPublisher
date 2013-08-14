using System;

namespace ReactiveEventPublisher.Events
{
  [Serializable]
  public abstract class AbstractEvent {
    public Guid AggregateRootId { get; private set; }

    public AbstractEvent(Guid id) {
      AggregateRootId = id;
    }
  }
}