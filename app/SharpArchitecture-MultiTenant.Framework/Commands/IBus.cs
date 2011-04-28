namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface IBus
  {
    void Send<TMessage>(TMessage message) where TMessage : IMessage;
  }
}