using Castle.Windsor;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.Castle;
using Castle.MicroKernel.Registration;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;

namespace SharpArchitecture-MultiTenant.Web.CastleWindsor
{
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddApplicationServicesTo(container);

            container.Register(
                Component
                    .For(typeof(IValidator))
                    .ImplementedBy(typeof(Validator))
                    .Named("validator"));
        }

        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                .FromAssemblyNamed("SharpArchitecture-MultiTenant.ApplicationServices")
                .Pick()
                .WithService.FirstInterface());
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                .FromAssemblyNamed("SharpArchitecture-MultiTenant.Data")
                .Pick()
                .WithService.FirstNonGenericCoreInterface("SharpArchitecture-MultiTenant.Core"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                    Component
                        .For(typeof(IEntityDuplicateChecker))
                        .ImplementedBy(typeof(EntityDuplicateChecker))
                        .Named("entityDuplicateChecker"));

            container.Register(
                    Component
                        .For(typeof(IRepository<>))
                        .ImplementedBy(typeof(Repository<>))
                        .Named("repositoryType"));

            container.Register(
                    Component
                        .For(typeof(INHibernateRepository<>))
                        .ImplementedBy(typeof(NHibernateRepository<>))
                        .Named("nhibernateRepositoryType"));

            container.Register(
                    Component
                        .For(typeof(IRepositoryWithTypedId<,>))
                        .ImplementedBy(typeof(RepositoryWithTypedId<,>))
                        .Named("repositoryWithTypedId"));

            container.Register(
                    Component
                        .For(typeof(INHibernateRepositoryWithTypedId<,>))
                        .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
                        .Named("nhibernateRepositoryWithTypedId"));
        }
    }
}
