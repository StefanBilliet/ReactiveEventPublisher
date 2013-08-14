using System;
using System.Collections.Generic;
using ReactiveEventPublisher.Events;

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
}