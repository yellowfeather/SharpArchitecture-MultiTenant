using SharpArch.Core.DomainModel;

namespace SharpArchitecture.MultiTenant.Core
{
  public class Tenant : Entity
  {
    public virtual string Name { get; set; }

    [DomainSignature]
    public virtual string Domain { get; set; }

    public virtual string ConnectionString { get; set; }
  }
}