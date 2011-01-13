using System;
using System.Linq;
using SharpArch.Data.NHibernate;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;
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
      return IsMultiTenantRepository(anObject.GetType()) 
        ? GetKey() 
        : NHibernateSession.DefaultFactoryKey;
    }

    public bool IsMultiTenantRepository(Type type)
    {
      return type.GetInterfaces().Any(x => x == typeof(IMultiTenantRepository));
    }

  }
}