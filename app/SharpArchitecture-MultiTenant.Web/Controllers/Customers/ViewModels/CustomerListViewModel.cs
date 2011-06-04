using MvcContrib.Pagination;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels
{
  public class CustomerListViewModel
  {
    public IPagination<CustomerViewModel> Customers { get; set; }
  }
}