using ReactiveEventPublisher.Events;

namespace ReactiveEventPublisher.ProjectionHandlers
{
  public interface IProjectionHandler<in TEvent> where TEvent : AbstractEvent
  {
    void Handle(TEvent message);
  }
}