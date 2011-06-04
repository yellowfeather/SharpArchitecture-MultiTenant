using Castle.Core;
using Castle.Windsor;
using SharpArch.Domain.Commands;
using Castle.MicroKernel.Registration;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.Web.Mvc.Castle;
using SharpArchitecture.MultiTenant.Framework.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;
using SharpArchitecture.MultiTenant.Web.Services;

namespace SharpArchitecture.MultiTenant.Web.CastleWindsor
{
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddQueriesTo(container);
            AddApplicationServicesTo(container);
            AddCommandHandlersTo(container);
            AddMultiTenantServicesTo(container);
        }

        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                .FromAssemblyNamed("SharpArchitecture.MultiTenant.ApplicationServices")
                .Pick()
                .If(f => !string.IsNullOrEmpty(f.Namespace) && !f.Namespace.Contains(".Commands"))
                .WithService.FirstInterface());
        }

        private static void AddCommandHandlersTo(IWindsorContainer container)
        {
          container.Register(
            AllTypes.FromAssemblyNamed("SharpArchitecture.MultiTenant.ApplicationServices").Pick()
              .If(f => !string.IsNullOrEmpty(f.Namespace) && f.Namespace.Contains(".CommandHandlers"))
              .Configure(c => c.LifeStyle.Is(LifestyleType.Transient))
              .WithService.FirstInterface());
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                .FromAssemblyNamed("SharpArchitecture.MultiTenant.Data")
                .Pick()
                .WithService.FirstNonGenericCoreInterface("SharpArchitecture.MultiTenant.Core"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
          container.Register(
              Component.For(typeof(IQuery<>))
                  .ImplementedBy(typeof(NHibernateQuery<>))
                  .Named("NHibernateQuery"));

          container.Register(
                    Component
                        .For(typeof(IEntityDuplicateChecker))
                        .ImplementedBy(typeof(EntityDuplicateChecker))
                        .Named("entityDuplicateChecker"));

            container.Register(
                    Component
                        .For(typeof(IRepository<>))
                        .ImplementedBy(typeof(NHibernateRepository<>))
                        .Named("nhibernateRepositoryType"));

            container.Register(
                    Component
                        .For(typeof(IRepositoryWithTypedId<,>))
                        .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
                        .Named("nhibernateRepositoryWithTypedId"));

            container.Register(
                    Component
                        .For(typeof(ISessionFactoryKeyProvider))
                        .ImplementedBy(typeof(MultiTenantSessionFactoryKeyProvider))
                        .Named("sessionFactoryKeyProvider"));

            container.Register(
                Component
                    .For(typeof(ICommandProcessor))
                    .ImplementedBy(typeof(CommandProcessor))
                    .Named("CommandProcessor"));
        }

        private static void AddQueriesTo(IWindsorContainer container)
        {
          container.Register(
                 AllTypes.FromAssemblyNamed("SharpArchitecture.MultiTenant.Web").Pick()
                         .If(f => !string.IsNullOrEmpty(f.Namespace) && f.Namespace.Contains(".Queries"))
                         .Configure(c => c.LifeStyle.Is(LifestyleType.Transient))
                         .WithService.FirstNonGenericCoreInterface("SharpArchitecture.MultiTenant.Web.Controllers"));
        }

        private static void AddMultiTenantServicesTo(IWindsorContainer container)
        {
          container.Register(
                  Component
                      .For(typeof(ITenantContext))
                      .ImplementedBy(typeof(TenantContext)));
        }
    }
}
