using SharpArch.Data.NHibernate.FluentNHibernate;

namespace SharpArchitecture.MultiTenant.Framework.Services
{
  public interface IMultiTenantInitializer
  {
    void Initialize(string[] mappingAssemblies, IAutoPersistenceModelGenerator modelGenerator, string tenantConfigFile);
  }
}