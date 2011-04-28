using System;
using SharpArch.Core.PersistenceSupport;
using SharpArchitecture.MultiTenant.ApplicationServices.Commands;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.CommandHandlers
{
  public class UploadFileCommandHandler : IMessageHandler<UploadFileCommand>
  {
    private readonly IFileStore _fileStore;
    private readonly IRepository<Upload> _uploadRepository;

    public UploadFileCommandHandler(IFileStore fileStore, IRepository<Upload> uploadRepository)
    {
      _fileStore = fileStore;
      _uploadRepository = uploadRepository;
    }

    public void Handle(UploadFileCommand command)
    {
      try {
        var upload = new Upload(command.FileData.FileName, command.GroupId, command.Username);
        upload.UploadedPath = _fileStore.SaveUploadedFile(upload.UploadedFilename, command.FileData);
        _uploadRepository.SaveOrUpdate(upload);

        command.Result = new UploadFileCommandResult(true);
      }
      catch (Exception ex) {
        command.Result = new UploadFileCommandResult(false) { Message = "A problem was encountered uploading the file: " + ex.Message };
      }
    }
  }
}