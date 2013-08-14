using System;
using ReactiveEventPublisher.Events;

namespace ReactiveEventPublisher.ProjectionHandlers
{
  public class PersonItemProjectionHandler : IProjectionHandler<PersonAddedEvent> {
    public void Handle(PersonAddedEvent message) {
      Console.WriteLine("Added a new PersonItem record with Id '{0}'", message.AggregateRootId);
    }
  }
}