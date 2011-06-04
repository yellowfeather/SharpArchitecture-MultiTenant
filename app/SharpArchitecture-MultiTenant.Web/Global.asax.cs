using System.Collections.Generic;
using System.Web.Routing;
using System.Web.Security;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Web.Mvc;
using SharpArch.Web.Mvc.Castle;
using SharpArch.Web.Mvc.ModelBinder;
using System;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Web.Controllers;
using SharpArchitecture.MultiTenant.Data.NHibernateMaps;
using SharpArchitecture.MultiTenant.Web.CastleWindsor;

namespace SharpArchitecture.MultiTenant.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            // ViewEngines.Engines.Clear();

            ModelBinders.Binders.DefaultBinder = new SharpModelBinder();

            ModelValidatorProviders.Providers.Add(new ClientDataTypeModelValidatorProvider());

            InitializeServiceLocator();

            AreaRegistration.RegisterAllAreas();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from
        /// WindsorController to the container.  Also associate the Controller
        /// with the WindsorContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            container.RegisterControllers(typeof(HomeController).Assembly);
            ComponentRegistrar.AddComponentsTo(container);

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        public override void Init()
        {
            base.Init();

            // The WebSessionStorage must be created during the Init() to tie in HttpApplication events
            _webSessionStorage = new WebSessionStorage(this);
        }

        /// <summary>
        /// Due to issues on IIS7, the NHibernate initialization cannot reside in Init() but
        /// must only be called once.  Consequently, we invoke a thread-safe singleton class to
        /// ensure it's only initialized once.
        /// </summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            NHibernateInitializer.Instance().InitializeNHibernateOnce(InitializeNHibernateSession);

            const string authParamName = "token";
            if (HttpContext.Current.Request.Form[authParamName] == null) {
              return;
            }

            // required for uploading files 
            var authCookieName = FormsAuthentication.FormsCookieName;
            UpdateCookie(authCookieName, HttpContext.Current.Request.Form[authParamName]);
        }

        private static void UpdateCookie(string cookieName, string cookieValue)
        {
          var cookie = HttpContext.Current.Request.Cookies.Get(cookieName) ?? new HttpCookie(cookieName);
          cookie.Value = cookieValue;
          HttpContext.Current.Request.Cookies.Set(cookie);
        }
        /// <summary>
        /// If you need to communicate to multiple databases, you'd add a line to this method to
        /// initialize the other database as well.
        /// </summary>
        private void InitializeNHibernateSession()
        {
          var mappingAssemblies = new [] { Server.MapPath("~/bin/SharpArchitecture.MultiTenant.Data.dll") };

          var configFile = Server.MapPath("~/NHibernate.config");
          NHibernateSession.Init(
                _webSessionStorage,
                mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(),
                configFile);

          InitializeMultiTenantNHibernateSessions(mappingAssemblies);
        }

        /// <summary>
        /// Initializes the multi tenant NHibernate sessions.
        /// </summary>
        /// <param name="mappingAssemblies">The mapping assemblies.</param>
        private void InitializeMultiTenantNHibernateSessions(string[] mappingAssemblies)
        {
          var configFile = Server.MapPath("~/NHibernate.tenant.config");

          var tenantRepository = ServiceLocator.Current.GetInstance<IRepository<Tenant>>();
          var tenants = tenantRepository.GetAll();
          foreach (var tenant in tenants) {
            InitializeMultiTenantNHibernateSession(mappingAssemblies, configFile, tenant);
          }
        }

        /// <summary>
        /// Initializes the multi tenant NHibernate session.
        /// </summary>
        /// <param name="mappingAssemblies">The mapping assemblies.</param>
        /// <param name="configFile">The tenant config file.</param>
        /// <param name="tenant">The tenant.</param>
        private static void InitializeMultiTenantNHibernateSession(string[] mappingAssemblies, string configFile, Tenant tenant)
        {
          var configProperties = new Dictionary<string, string>
                                {
                                  {"connection.connection_string", tenant.ConnectionString}
                                };

          NHibernateSession.AddConfiguration(tenant.Domain,
                                             mappingAssemblies,
                                             new MultiTenantAutoPersistenceModelGenerator().Generate(),
                                             configFile,
                                             configProperties,
                                             null, null);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            var ex = Server.GetLastError();
            var reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }

        private WebSessionStorage _webSessionStorage;
    }
}