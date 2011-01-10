using Microsoft.Practices.ServiceLocation;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Framework
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
        var accountContext = ServiceLocator.Current.GetInstance<ITenantContext>();
        return accountContext.Key;
      }
    }
  }
}