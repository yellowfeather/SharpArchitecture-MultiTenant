using MvcContrib.Pagination;
using SharpArchitecture.MultiTenant.Framework.Contracts;
using SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Customers.Queries
{
  public interface ICustomerListQuery : IMultiTenantQuery
  {
    IPagination<CustomerViewModel> GetPagedList(int pageIndex, int pageSize);
  }
}