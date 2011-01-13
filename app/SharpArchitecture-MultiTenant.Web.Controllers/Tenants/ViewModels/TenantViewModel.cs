using SharpArchitecture.MultiTenant.Core;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels
{
  public class TenantViewModel
  {
    public TenantViewModel(Tenant tenant)
    {
      Id = tenant.Id;
      Name = tenant.Name;
      Domain = tenant.Domain;
      ConnectionString = tenant.ConnectionString;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Domain  { get; set; }
    public string ConnectionString { get; set; }
  }
}