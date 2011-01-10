using System;

namespace SharpArchitecture.MultiTenant.Data.NHibernateMaps
{
  /// <summary>
  /// 
  /// </summary>
  public class MultiTenantAutomappingConfiguration : AutomappingConfiguration
  {
    public override bool ShouldMap(Type type)
    {
      var shouldMap = IsMultiTenantEntity(type);
      return shouldMap;
    }
  }
}