using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class TestMessage : IMessage
  {
    public string Data { get; set; }
  }
}