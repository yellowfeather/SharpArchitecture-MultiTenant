using System;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class ImportCustomersCommand : ICommand
  {
    public ImportCustomersCommand(Guid uploadKey)
    {
      UploadKey = uploadKey;
    }

    public Guid UploadKey { get; private set; }
  }
}