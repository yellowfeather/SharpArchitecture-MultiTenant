using Microsoft.Practices.ServiceLocation;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Framework.NHibernate
{
  public class TransactionAttribute : SharpArch.Web.NHibernate.TransactionAttribute
  {
    public TransactionAttribute()
      : base(FactoryKey)
    {
    }

    protected static string FactoryKey
    {
      get
      {
        var tenantContext = ServiceLocator.Current.GetInstance<ITenantContext>();
        return tenantContext.Key;
      }
    }
  }
}
