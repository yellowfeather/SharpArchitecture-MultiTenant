using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Data.NHibernateMaps.Conventions;
using ForeignKeyConvention = SharpArchitecture.MultiTenant.Data.NHibernateMaps.Conventions.ForeignKeyConvention;
using ManyToManyTableNameConvention = SharpArchitecture.MultiTenant.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention;

namespace SharpArchitecture.MultiTenant.Data.NHibernateMaps
{
  public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
  {
    #region IAutoPersistenceModelGenerator Members

    public AutoPersistenceModel Generate()
    {
      return AutoMap.AssemblyOf<Customer>(GetAutomappingConfiguration())
        .Conventions.Setup(GetConventions())
        .IgnoreBase<Entity>()
        .IgnoreBase(typeof (EntityWithTypedId<>))
        .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
    }

    #endregion

    protected virtual IAutomappingConfiguration GetAutomappingConfiguration()
    {
      return new AutomappingConfiguration();
    }

    private Action<IConventionFinder> GetConventions()
    {
      return c =>
               {
                 c.Add<ForeignKeyConvention>();
                 c.Add<HasManyConvention>();
                 c.Add<HasManyToManyConvention>();
                 c.Add<ManyToManyTableNameConvention>();
                 c.Add<PrimaryKeyConvention>();
                 c.Add<ReferenceConvention>();
                 c.Add<TableNameConvention>();
               };
    }
  }
}