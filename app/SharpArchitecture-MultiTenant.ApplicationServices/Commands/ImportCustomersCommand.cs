using System;
using System.ComponentModel.DataAnnotations;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class ImportCustomersCommand : CommandBase
  {
    public ImportCustomersCommand(Guid uploadKey)
    {
      UploadKey = uploadKey;
    }

    [Required]
    public Guid UploadKey { get; private set; }
  }
}