using NHibernate;
using SharpArch.Data.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Data.Repositories
{
  public class MultiTenantRepository<T> : Repository<T>
  {
    private readonly ITenantContext _tenantContext;

    public MultiTenantRepository(ITenantContext tenantContext)
    {
      _tenantContext = tenantContext;
    }

    protected override ISession Session
    {
      get
      {
        var key = _tenantContext.Key;
        return string.IsNullOrEmpty(key) ? base.Session : NHibernateSession.CurrentFor(key);
      }
    }
  }
}