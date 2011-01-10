using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using SharpArchitecture-MultiTenant.Core;
using SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace SharpArchitecture-MultiTenant.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<Class1>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<SharpArchitecture-MultiTenant.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }
    }
}
