using NHibernate;
using SharpArch.Data.NHibernate;

namespace SharpArchitecture.MultiTenant.Data.NHibernate
{
  public class NHibernateQuery
  {
    protected virtual ISession Session
    {
      get
      {
        var factoryKey = SessionFactoryKeyHelper.GetKey(this);
        return NHibernateSession.CurrentFor(factoryKey);
      }
    }
  }
}