using MvcContrib.Pagination;
using NHibernate.Transform;
using SharpArch.NHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Customers.Queries.Impl
{
  public class CustomerListQuery : NHibernateQuery, ICustomerListQuery
  {
    public IPagination<CustomerViewModel> GetPagedList(int pageIndex, int pageSize)
    {
      var query = Session.QueryOver<Customer>()
        .OrderBy(customer => customer.Code).Asc;

      var countQuery = query.ToRowCountQuery();
      var totalCount = countQuery.FutureValue<int>();

      var firstResult = (pageIndex - 1) * pageSize;

      CustomerViewModel viewModel = null;
      var viewModels = query.SelectList(list => list
                              .Select(mission => mission.Id).WithAlias(() => viewModel.Id)
                              .Select(mission => mission.Code).WithAlias(() => viewModel.Code)
                              .Select(mission => mission.Name).WithAlias(() => viewModel.Name))
        .TransformUsing(Transformers.AliasToBean(typeof(CustomerViewModel)))
        .Skip(firstResult)
        .Take(pageSize)
        .Future<CustomerViewModel>();

      return new CustomPagination<CustomerViewModel>(viewModels, pageIndex, pageSize, totalCount.Value);
    }
  }
}