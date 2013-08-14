using System;
using System.Collections.Generic;
using Autofac;
using ReactiveEventPublisher.Events;
using ReactiveEventPublisher.ProjectionHandlers;

namespace ReactiveEventPublisher
{
  public class EventQueueObserver : IObserver<AbstractEvent>
  {
    private readonly IComponentContext _componentContext;

    public EventQueueObserver(IComponentContext componentContext)
    {
      if (componentContext == null) throw new ArgumentNullException("componentContext");
      _componentContext = componentContext;
    }

    public void OnNext(AbstractEvent @event)
    {
      var allProjectionHandlersForEventType = typeof(IEnumerable<>).MakeGenericType(typeof(IProjectionHandler<>).MakeGenericType(@event.GetType()));
      dynamic projectionHandlers = _componentContext.Resolve(allProjectionHandlersForEventType);

      foreach (var projectionHandler in projectionHandlers) {
        projectionHandler.Handle((dynamic)@event);
      }
    }

    public void OnError(Exception error)
    {
      throw new NotImplementedException();
    }

    public void OnCompleted()
    {
      throw new NotImplementedException();
    }
  }
}