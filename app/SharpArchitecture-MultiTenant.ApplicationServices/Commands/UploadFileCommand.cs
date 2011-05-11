using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.Commands
{
  public class UploadFileCommand : CommandBase
  {
    public UploadFileCommand(Guid groupId, HttpPostedFileBase fileData, string username)
    {
      GroupId = groupId;
      FileData = fileData;
      Username = username;
    }

    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public HttpPostedFileBase FileData { get; set; }

    [Required]
    public string Username { get; set; }
  }
}