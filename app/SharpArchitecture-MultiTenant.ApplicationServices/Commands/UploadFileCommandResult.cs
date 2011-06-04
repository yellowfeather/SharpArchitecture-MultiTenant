using SharpArch.Domain.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class UploadFileCommandResult : CommandResult
  {
    public UploadFileCommandResult(bool success) 
      : base(success) {}

    public string Message { get; set; }
  }
}