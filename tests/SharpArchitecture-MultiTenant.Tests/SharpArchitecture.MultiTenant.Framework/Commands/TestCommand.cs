using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class TestCommand : ICommand
  {
    public string Data { get; set; }
  }
}