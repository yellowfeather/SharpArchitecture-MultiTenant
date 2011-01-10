using System.Linq;
using MvcContrib.Pagination;
using SharpArchitecture.MultiTenant.Core;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModel
{
  public class CustomerListViewModel
  {
    public CustomerListViewModel(IPagination<Customer> customers)
    {
      var viewModels = customers.Select(customer => new CustomerViewModel(customer));
      Customers = new CustomPagination<CustomerViewModel>(viewModels, customers.PageNumber, customers.PageSize, customers.TotalItems);
    }

    public IPagination<CustomerViewModel> Customers { get; set; }
  }
}