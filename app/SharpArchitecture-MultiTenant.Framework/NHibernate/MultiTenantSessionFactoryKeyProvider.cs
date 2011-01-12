using SharpArch.Data.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Framework.NHibernate
{
  public class MultiTenantSessionFactoryKeyProvider : ISessionFactoryKeyProvider
  {
    private readonly ITenantContext _tenantContext;

    public MultiTenantSessionFactoryKeyProvider(ITenantContext tenantContext)
    {
      _tenantContext = tenantContext;
    }

    public string GetKey()
    {
      var key = _tenantContext.Key;
      return string.IsNullOrEmpty(key) ? NHibernateSession.DefaultFactoryKey : key;
    }

    public string GetKeyFrom(object anObject)
    {
      return GetKey();
    }
  }
}