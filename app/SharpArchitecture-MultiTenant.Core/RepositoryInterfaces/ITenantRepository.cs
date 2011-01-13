using MvcContrib.Pagination;
using SharpArch.Core.PersistenceSupport;

namespace SharpArchitecture.MultiTenant.Core.RepositoryInterfaces
{
  public interface ITenantRepository : IRepository<Tenant>
  {
    IPagination<Tenant> GetPagedList(int pageIndex, int pageSize);
  }
}