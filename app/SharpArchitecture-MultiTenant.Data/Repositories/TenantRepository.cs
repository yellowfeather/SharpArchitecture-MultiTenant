using MvcContrib.Pagination;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;

namespace SharpArchitecture.MultiTenant.Data.Repositories
{
  public class TenantRepository : Repository<Tenant>, ITenantRepository
  {
    public IPagination<Tenant> GetPagedList(int pageIndex, int pageSize)
    {
      var firstResult = (pageIndex - 1) * pageSize;
      var tenants = Session.QueryOver<Tenant>()
        .OrderBy(customer => customer.Name).Asc
        .Skip(firstResult)
        .Take(pageSize)
        .Future<Tenant>();

      var totalCount = Session.QueryOver<Tenant>()
        .Select(Projections.Count<Tenant>(customer => customer.Name))
        .FutureValue<int>();

      return new CustomPagination<Tenant>(tenants, pageIndex, pageSize, totalCount.Value);
    }
  }
}