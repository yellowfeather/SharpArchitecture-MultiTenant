namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public class CommandResultBase : ICommandResult
  {
    protected CommandResultBase(bool success)
    {
      Success = success;
    }

    public bool Success { get; protected set; }
  }
}