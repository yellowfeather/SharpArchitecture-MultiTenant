using SharpArch.Domain.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class ImportCustomersCommandResult : CommandResult
  {
    public ImportCustomersCommandResult(bool success) 
      : base(success) {}
  }
}