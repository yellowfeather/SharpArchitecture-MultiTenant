using System.IO;
using System.Web;
using System.Web.Hosting;

namespace SharpArchitecture.MultiTenant.ApplicationServices
{
  public class DiskFileStore : IFileStore
  {
    private readonly string _uploadsFolder = HostingEnvironment.MapPath("~/App_Data");

    public string SaveUploadedFile(string destinationFileName, HttpPostedFileBase fileBase)
    {
      var path = Path.Combine(_uploadsFolder, destinationFileName);
      fileBase.SaveAs(path);
      return path;
    }
  }
}