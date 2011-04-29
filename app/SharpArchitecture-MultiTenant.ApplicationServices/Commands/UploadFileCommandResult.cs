using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class UploadFileCommandResult : CommandResultBase
  {
    public UploadFileCommandResult(bool success) 
      : base(success) {}

    public string Message { get; set; }
  }
}