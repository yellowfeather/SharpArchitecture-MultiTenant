using MvcContrib.Pagination;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels
{
  public class TenantListViewModel
  {
    public IPagination<TenantViewModel> Tenants { get; set; }
  }
}