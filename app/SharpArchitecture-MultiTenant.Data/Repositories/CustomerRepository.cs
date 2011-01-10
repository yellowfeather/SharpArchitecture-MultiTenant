using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;
using SharpArchitecture.MultiTenant.Framework.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Data.Repositories
{
  public class CustomerRepository : MultiTenantRepository<Customer>, ICustomerRepository
  {
    public CustomerRepository(ITenantContext tenantContext) : base(tenantContext)
    {
    }
  }
}