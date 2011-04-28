using Microsoft.Practices.ServiceLocation;

namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public class Bus : IBus
  {
    public void Send<TMessage>(TMessage message) where TMessage : IMessage
    {
      var handlers = ServiceLocator.Current.GetAllInstances<IMessageHandler<TMessage>>();
      foreach (var handler in handlers) {
        handler.Handle(message);
      }
    }
  }
}