using MvcContrib.Pagination;
using SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.Queries
{
  public interface ITenantListQuery
  {
    IPagination<TenantViewModel> GetPagedList(int pageIndex, int pageSize);
  }
}