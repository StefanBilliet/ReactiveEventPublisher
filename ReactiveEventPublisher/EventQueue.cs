using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using NUnit.Framework;

namespace ReactiveEventPublisher
{
  public class EventQueue : IObservable<AbstractEvent> {
    private readonly List<IObserver<AbstractEvent>> _observers = new List<IObserver<AbstractEvent>>();

    #region IObservable<AbstractEvent> Members

    public IDisposable Subscribe(IObserver<AbstractEvent> observer) {
      if (!_observers.Contains(observer))
        _observers.Add(observer);
      return new Unsubscriber(_observers, observer);
    }

    #endregion

    public virtual void Dispatch(AbstractEvent ev) {
      foreach (var observer in _observers) {
        observer.OnNext(ev);
      }
    }

    public virtual void Dispatch(IEnumerable<AbstractEvent> events) {
      foreach (var ev in events)
        Dispatch(ev);
    }

    #region Nested type: Unsubscriber

    private class Unsubscriber : IDisposable {
      private readonly IObserver<AbstractEvent> _observer;
      private readonly List<IObserver<AbstractEvent>> _observers;

      public Unsubscriber(List<IObserver<AbstractEvent>> observers, IObserver<AbstractEvent> observer) {
        _observers = observers;
        _observer = observer;
      }

      #region IDisposable Members

      public void Dispose() {
        if (_observer != null && _observers.Contains(_observer))
          _observers.Remove(_observer);
      }

      #endregion
    }

    #endregion
  }

  public class EventDispatcher : EventQueue, IObserver<AbstractEvent> {
    public void OnNext(AbstractEvent value) {
      Dispatch(value);
    }

    public void OnError(Exception exception) {
      Dispatch(new ErrorEvent(exception));
    }

    public void OnCompleted() {
    }
  }

  public class blaat
  {
    [Test]
    public void BasicTest() {
      var bus = new EventDispatcher();
      var numCalled = 0;

      bus.Subscribe(@event => Console.WriteLine("Event received: "+@event.GetType().Name));
      bus.Dispatch(new PersonAddedEvent(Guid.NewGuid()));
      bus.Dispatch(new EventScheduledEvent(Guid.NewGuid()));

      //Assert.AreEqual(2, numCalled);
    }
  }
}