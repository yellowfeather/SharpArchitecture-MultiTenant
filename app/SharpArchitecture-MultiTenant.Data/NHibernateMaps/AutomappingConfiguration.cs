using System;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using SharpArch.Core.DomainModel;
using SharpArchitecture.MultiTenant.Framework.Contracts;

namespace SharpArchitecture.MultiTenant.Data.NHibernateMaps
{
  /// <summary>
  /// 
  /// </summary>
  public class AutomappingConfiguration : DefaultAutomappingConfiguration
  {
    public override bool ShouldMap(Type type)
    {
      var isMultiTenantEntity = IsMultiTenantEntity(type);
      return type.GetInterfaces().Any(x =>
                                      x.IsGenericType && x.GetGenericTypeDefinition() == typeof (IEntityWithTypedId<>) &&
                                      !isMultiTenantEntity);
    }

    public override bool ShouldMap(Member member)
    {
      return base.ShouldMap(member) && member.CanWrite;
    }

    public override bool AbstractClassIsLayerSupertype(Type type)
    {
      return type == typeof (EntityWithTypedId<>) || type == typeof (Entity);
    }

    public override bool IsId(Member member)
    {
      return member.Name == "Id";
    }

    public bool IsMultiTenantEntity(Type type)
    {
      return type.GetInterfaces().Any(x => x == typeof (IMultiTenantEntity));
    }
  }
}