using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  [TestFixture]
  public class BusTests
  {
    private IList<IMessage> _handledMessages;
    private IWindsorContainer _container;
    private IBus _bus;

    [SetUp]
    public void SetUp()
    {
      _handledMessages = new List<IMessage>();
      _container = new WindsorContainer();
      ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(_container));
      _bus = new Bus();
    }

    [TearDown]
    public void TearDown()
    {
      _handledMessages = null;

      _bus = null;

      _container.Dispose();
      _container = null;
    }

    [Test]
    public void CanHandleSingleMessage()
    {
      _container.Register(
        Component.For<IMessageHandler<TestMessage>>()
          .UsingFactoryMethod(CreateMessageHandler<TestMessage>)
          .LifeStyle.Transient);

      var testMessage = new TestMessage();
      _bus.Send(testMessage);

      Assert.AreEqual(1, _handledMessages.Count);
      Assert.AreEqual(testMessage, _handledMessages[0]);
    }

    [Test]
    public void CanHandleMultipleMessages()
    {
      _container.Register(
        Component.For<IMessageHandler<TestMessage>>()
          .UsingFactoryMethod(CreateMessageHandler<TestMessage>)
          .Named("First handler")
          .LifeStyle.Transient);

      _container.Register(
        Component.For<IMessageHandler<TestMessage>>()
          .UsingFactoryMethod(CreateMessageHandler<TestMessage>)
          .Named("Second handler")
          .LifeStyle.Transient);

      var testMessage = new TestMessage();
      _bus.Send(testMessage);

      Assert.AreEqual(2, _handledMessages.Count);
      Assert.AreEqual(testMessage, _handledMessages[0]);
      Assert.AreEqual(testMessage, _handledMessages[1]);
    }

    [Test]
    public void CanHandleCommad()
    {
      _container.Register(
        Component.For<IMessageHandler<TestCommand>>()
          .ImplementedBy<TestCommandHandler>()
          .LifeStyle.Transient);

      var testCommand = new TestCommand();
      _bus.Send(testCommand);

      Assert.IsNotNull(testCommand.Result);
      Assert.IsTrue(testCommand.Result.Success);
    }

    private GenericMessageHandler<TMessage> CreateMessageHandler<TMessage>() where TMessage : IMessage
    {
      return new GenericMessageHandler<TMessage>(OnHandle);
    }

    private void OnHandle<TMessage>(IMessageHandler<TMessage> handler, TMessage message) where TMessage : IMessage
    {
      _handledMessages.Add(message);
    }
  }
}