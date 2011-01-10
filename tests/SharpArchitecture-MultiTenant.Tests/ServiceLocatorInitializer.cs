using Castle.Windsor;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using SharpArch.Core.PersistenceSupport;
using Tests.SharpArchitecture-MultiTenant.Data.TestDoubles;

namespace Tests
{
    using Castle.MicroKernel.Registration;

    public class ServiceLocatorInitializer
    {
        public static void Init()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(
                     Component
                         .For(typeof(IValidator))
                         .ImplementedBy(typeof(Validator))
                         .Named("validator"));

            container.Register(
                    Component
                        .For(typeof(IEntityDuplicateChecker))
                        .ImplementedBy(typeof(EntityDuplicateCheckerStub))
                        .Named("entityDuplicateChecker"));

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
