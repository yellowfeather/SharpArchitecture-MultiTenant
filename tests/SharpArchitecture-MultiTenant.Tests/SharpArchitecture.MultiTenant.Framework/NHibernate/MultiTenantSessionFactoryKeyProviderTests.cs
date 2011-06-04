using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Domain.DomainModel;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpArch.Testing.NUnit;
using SharpArchitecture.MultiTenant.Framework.Contracts;
using SharpArchitecture.MultiTenant.Framework.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace Tests.SharpArchitecture.MultiTenant.Framework.NHibernate
{
  public class TestEntity : Entity {}
  public class TestMultiTenantEntity : Entity, IMultiTenantEntity {}

  public interface ITestRepository : IRepository<TestEntity> { }
  public interface ITestMultiTenantRepository : IRepository<TestMultiTenantEntity>, IMultiTenantRepository { }

  public class TestRepository : NHibernateRepository<TestEntity>, ITestRepository { }
  public class TestMultiTenantRepository : NHibernateRepository<TestMultiTenantEntity>, ITestMultiTenantRepository { }

  [TestFixture]
  public class MultiTenantSessionFactoryKeyProviderTests
  {
    private MultiTenantSessionFactoryKeyProvider _provider;

    [SetUp]
    public void Setup()
    {
      var tenantContext = MockRepository.GenerateStub<ITenantContext>();
      _provider = new MultiTenantSessionFactoryKeyProvider(tenantContext);
    }

    [Test]
    public void IsRepositoryForMultiTenantEntityReturnsFlaseForRepositoryForEntity()
    {
      var isRepositoryForMultiTenantEntity = _provider.IsRepositoryForMultiTenantEntity(typeof(IRepository<TestEntity>));
      isRepositoryForMultiTenantEntity.ShouldEqual(false);
    }

    [Test]
    public void IsRepositoryForMultiTenantEntityReturnsTrueForRepositoryForMultiTenantEntity()
    {
      var isRepositoryForMultiTenantEntity = _provider.IsRepositoryForMultiTenantEntity(typeof(IRepository<TestMultiTenantEntity>));
      isRepositoryForMultiTenantEntity.ShouldEqual(true);
    }
  }
}