using System;
using System.Web;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class UploadFileCommand : ICommand
  {
    public UploadFileCommand(Guid groupId, HttpPostedFileBase fileData, string username)
    {
      GroupId = groupId;
      FileData = fileData;
      Username = username;
    }

    public Guid GroupId { get; set; }
    public HttpPostedFileBase FileData { get; set; }
    public string Username { get; set; }
  }
}