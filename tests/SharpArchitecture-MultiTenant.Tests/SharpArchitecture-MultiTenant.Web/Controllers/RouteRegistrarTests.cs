using NUnit.Framework;
using SharpArchitecture.MultiTenant.Web.Controllers;
using MvcContrib.TestHelper;
using System.Web.Routing;

namespace Tests.SharpArchitecture.MultiTenant.Controllers
{
    [TestFixture]
    public class RouteRegistrarTests
    {
        [SetUp]
        public void SetUp()
        {
            RouteTable.Routes.Clear();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        [Test]
        public void CanVerifyRouteMaps()
        {
            "~/".Route().ShouldMapTo<HomeController>(x => x.Index());
        }
    }
}
