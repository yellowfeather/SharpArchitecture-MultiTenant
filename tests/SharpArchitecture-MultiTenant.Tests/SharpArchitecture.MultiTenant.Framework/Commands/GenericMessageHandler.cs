using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class GenericMessageHandler<TMessage> : IMessageHandler<TMessage> where TMessage : IMessage
  {
    public delegate void OnHandle(IMessageHandler<TMessage> handler, TMessage message);
    public event OnHandle OnHandleEvent;

    public GenericMessageHandler(OnHandle onHandle)
    {
      OnHandleEvent += onHandle;
    }

    public void Handle(TMessage command)
    {
      var onHandleEvent = OnHandleEvent;
      if (onHandleEvent != null) {
        onHandleEvent(this, command);
      }
    }
  }
}