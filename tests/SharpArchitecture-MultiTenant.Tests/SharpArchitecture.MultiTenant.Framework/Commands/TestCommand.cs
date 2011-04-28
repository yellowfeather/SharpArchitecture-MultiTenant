using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class TestCommand : CommandBase<TestCommandResult>
  {
    public string Data { get; set; }
  }
}