using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class TestCommandResult : CommandResultBase
  {
    public TestCommandResult(bool success) : base(success) {}
  }
}