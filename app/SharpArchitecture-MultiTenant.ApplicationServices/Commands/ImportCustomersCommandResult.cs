using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class ImportCustomersCommandResult : ICommandResult
  {
    public ImportCustomersCommandResult(bool success)
    {
      Success = success;
    }

    public bool Success { get; private set; }
  }
}