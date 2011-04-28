namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface IMessageHandler<in TMessage> where TMessage : IMessage
  {
    void Handle(TMessage command);
  }
}