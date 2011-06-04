using NHibernate.Validator.Constraints;
using SharpArch.Domain.DomainModel;
using SharpArchitecture.MultiTenant.Framework.Contracts;

namespace SharpArchitecture.MultiTenant.Core
{
  public class Customer : Entity, IMultiTenantEntity
  {
    [DomainSignature]
    [NotNullNotEmpty]
    public virtual string Code { get; set; }

    [DomainSignature]
    [NotNullNotEmpty]
    public virtual string Name { get; set; }
  }
}