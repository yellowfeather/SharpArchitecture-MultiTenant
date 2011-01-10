using SharpArch.Core.DomainModel;
using SharpArchitecture.MultiTenant.Core.Contracts;

namespace SharpArchitecture.MultiTenant.Core
{
  public class Customer : Entity, IMultiTenantEntity
  {
    [DomainSignature]
    public virtual string Name { get; set; }
  }
}