using MvcContrib.Pagination;
using NHibernate.Criterion;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Data.Repositories
{
  public class CustomerRepository : MultiTenantRepository<Customer>, ICustomerRepository
  {
    public CustomerRepository(ITenantContext tenantContext) : base(tenantContext)
    {
    }

    public IPagination<Customer> GetPagedList(int pageIndex, int pageSize)
    {
      var firstResult = (pageIndex - 1) * pageSize;
      var customers = Session.QueryOver<Customer>()
        .OrderBy(customer => customer.Code).Asc
        .Skip(firstResult)
        .Take(pageSize)
        .Future<Customer>();

      var totalCount = Session.QueryOver<Customer>()
        .Select(Projections.Count<Customer>(customer => customer.Code))
        .FutureValue<int>();

      return new CustomPagination<Customer>(customers, pageIndex, pageSize, totalCount.Value);
    }
  }
}