using System.Linq;
using MvcContrib.Pagination;
using SharpArchitecture.MultiTenant.Core;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels
{
  public class TenantListViewModel
  {
    public TenantListViewModel(IPagination<Tenant> tenants)
    {
      var viewModels = tenants.Select(tenant => new TenantViewModel(tenant));
      Tenants = new CustomPagination<TenantViewModel>(viewModels, tenants.PageNumber, tenants.PageSize, tenants.TotalItems);
    }

    public IPagination<TenantViewModel> Tenants { get; set; }
  }
}