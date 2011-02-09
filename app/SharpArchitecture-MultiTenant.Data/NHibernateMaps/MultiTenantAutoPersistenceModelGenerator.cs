using FluentNHibernate.Automapping;

namespace SharpArchitecture.MultiTenant.Data.NHibernateMaps
{
  public class MultiTenantAutoPersistenceModelGenerator : AutoPersistenceModelGenerator
  {
    protected override IAutomappingConfiguration GetAutomappingConfiguration()
    {
      return new MultiTenantAutomappingConfiguration();
    }
  }
}