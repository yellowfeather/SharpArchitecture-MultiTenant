using System.Web;

namespace SharpArchitecture.MultiTenant.ApplicationServices
{
  public interface IFileStore
  {
    string SaveUploadedFile(string destinationFileName, HttpPostedFileBase file);
  }
}