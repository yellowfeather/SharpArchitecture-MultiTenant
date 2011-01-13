using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.DomainModel;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NUnit;
using SharpArchitecture.MultiTenant.Core.Contracts;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;
using SharpArchitecture.MultiTenant.Framework.NHibernate;
using SharpArchitecture.MultiTenant.Framework.Services;

namespace Tests.SharpArchitecture.MultiTenant.Framework.NHibernate
{
  public class TestEntity : Entity {}
  public class TestMultiTenantEntity : Entity, IMultiTenantEntity {}

  public interface ITestRepository : IRepository<TestEntity> { }
  public interface ITestMultiTenantRepository : IRepository<TestMultiTenantEntity>, IMultiTenantRepository { }

  public class TestRepository : Repository<TestEntity>, ITestRepository { }
  public class TestMultiTenantRepository : Repository<TestMultiTenantEntity>, ITestMultiTenantRepository { }

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
    public void IsMultiTenantRepositoryReturnsFalseForRepository()
    {
      var isMultiTenantRepository = _provider.IsMultiTenantRepository(typeof(ITestRepository));
      isMultiTenantRepository.ShouldEqual(false);
    }

    [Test]
    public void IsMultiTenantRepositoryReturnsTrueForMultiTenantRepository()
    {
      var isMultiTenantRepository = _provider.IsMultiTenantRepository(typeof(ITestMultiTenantRepository));
      isMultiTenantRepository.ShouldEqual(true);
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