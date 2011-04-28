using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class TestCommandHandler : IMessageHandler<TestCommand>
  {
    public void Handle(TestCommand command)
    {
      command.Result = new TestCommandResult(true);
    }
  }
}