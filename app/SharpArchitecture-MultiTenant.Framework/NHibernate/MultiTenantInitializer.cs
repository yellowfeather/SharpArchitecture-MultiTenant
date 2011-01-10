using System.Collections.Generic;
using NHibernate.Cfg;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Data.NHibernate;
using SharpArch.Data.NHibernate.FluentNHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace SharpArchitecture.MultiTenant.Framework.NHibernate
{
  public class MultiTenantInitializer : IMultiTenantInitializer
  {
    private readonly IRepository<Tenant> _tenantRepository;

    public MultiTenantInitializer(IRepository<Tenant> tenantRepository)
    {
      _tenantRepository = tenantRepository;
    }

    public void Initialize(string[] mappingAssemblies, IAutoPersistenceModelGenerator modelGenerator, string tenantConfigFile)
    {
      var tenants = _tenantRepository.GetAll();
      foreach (var tenant in tenants) {
        Initialize(mappingAssemblies, modelGenerator, tenantConfigFile, tenant);
      }
    }

    private static void Initialize(string[] mappingAssemblies, IAutoPersistenceModelGenerator modelGenerator, string tenantConfigFile, Tenant tenant)
    {
      var properties = new Dictionary<string, string>
                         {
                           { "connection.connection_string", tenant.ConnectionString }
                         };
      AddTenantConfiguration(tenant.Domain, mappingAssemblies, modelGenerator, tenantConfigFile, properties);
    }

    private static Configuration AddTenantConfiguration(string factoryKey, string[] mappingAssemblies, IAutoPersistenceModelGenerator modelGenerator, string cfgFile, IDictionary<string, string> cfgProperties)
    {
      return NHibernateSession.AddConfiguration(factoryKey,
        mappingAssemblies,
        modelGenerator.Generate(),
        cfgFile,
        cfgProperties, 
        null, null);
    }
  }
}