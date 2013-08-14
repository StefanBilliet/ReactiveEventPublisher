using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using ReactiveEventPublisher.ProjectionHandlers;
using Module = Autofac.Module;

namespace ReactiveEventPublisher.Composition
{
  public class PublisherModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(
        Assembly.GetExecutingAssembly()).
        AsClosedTypesOf(typeof(IProjectionHandler<>)).
        AsImplementedInterfaces().
        SingleInstance();
    }
  }
}