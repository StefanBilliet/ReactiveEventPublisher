using System;
using System.IO;
using System.Text;
using Autofac;
using NUnit.Framework;
using ReactiveEventPublisher.Composition;
using ReactiveEventPublisher.Events;

namespace ReactiveEventPublisher
{
  public class Tests
  {
    [Test]
    public void BasicTest()
    {
      var consoleOutput = new StringBuilder();
      Console.SetOut(new StringWriter(consoleOutput));

      var builder = new ContainerBuilder();
      builder.RegisterModule<PublisherModule>();
      var container = builder.Build();

      var bus = new EventQueue();

      bus.Subscribe(new EventQueueObserver(container));

      bus.Dispatch(new PersonAddedEvent(new Guid("C01DAE2C-E9D8-4766-9F0C-0A2CC2ED6699")));
      bus.Dispatch(new EventScheduledEvent(new Guid("3B817DC0-4FEC-426E-90C5-3A4233FBB129")));

      Assert.That(consoleOutput.ToString(),
        Is.EqualTo(
          new StringBuilder().AppendLine(
            "Added a new PersonItem record with Id 'c01dae2c-e9d8-4766-9f0c-0a2cc2ed6699'")
            .AppendLine(
              "Added a new AgendaItem record with Id '3b817dc0-4fec-426e-90c5-3a4233fbb129'")
            .ToString()));
    }
  }
}