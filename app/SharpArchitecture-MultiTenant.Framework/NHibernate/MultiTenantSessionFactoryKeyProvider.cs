using System;
using System.Linq;
using SharpArch.Data.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Contracts;
using SharpArchitecture.MultiTenant.Framework.Extensions;
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
      var type = anObject.GetType();
      var isMultiTenant = type.IsImplementationOf<IMultiTenantQuery>() ||
                          type.IsImplementationOf<IMultiTenantRepository>() ||
                          IsRepositoryForMultiTenantEntity(type);
      return isMultiTenant
        ? GetKey() 
        : NHibernateSession.DefaultFactoryKey;
    }

    public bool IsRepositoryForMultiTenantEntity(Type type)
    {
      if (!type.IsGenericType) {
        return false;
      }

      var genericTypes = type.GetGenericArguments();
      if (!genericTypes.Any()) {
        return false;
      }

      var firstGenericType = genericTypes[0];
      return firstGenericType.IsImplementationOf<IMultiTenantEntity>();
    }
  }
}