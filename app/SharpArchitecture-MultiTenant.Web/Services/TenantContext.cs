using System.Web;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Web.Services
{
  public class TenantContext : ITenantContext
  {
    private const string DefaultStorageKey = "tenant-context-key";

    public string Key
    {
      get
      {
        if (string.IsNullOrEmpty(StoredKey)) {
          StoredKey = KeyFromRequest;
        }
        return StoredKey;
      }

      set { StoredKey = value; }
    }

    public string KeyFromRequest
    {
      get
      {
        var host = HttpContext.Current.Request.Headers["HOST"];
        var domains = host.Split('.');
        return domains.Length >= 3 ? domains[0] : string.Empty;
      }
    }

    protected string StoredKey
    {
      get { return HttpContext.Current.Items[DefaultStorageKey] as string; }
      set { HttpContext.Current.Items[DefaultStorageKey] = value; }
    }
  }

}