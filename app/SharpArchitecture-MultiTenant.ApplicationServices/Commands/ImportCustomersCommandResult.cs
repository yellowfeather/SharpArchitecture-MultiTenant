using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class ImportCustomersCommandResult : CommandResultBase
  {
    public ImportCustomersCommandResult(bool success) 
      : base(success) {}
  }
}