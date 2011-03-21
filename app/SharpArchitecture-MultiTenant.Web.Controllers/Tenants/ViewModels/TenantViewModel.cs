namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels
{
  public class TenantViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Domain  { get; set; }
    public string ConnectionString { get; set; }
  }
}