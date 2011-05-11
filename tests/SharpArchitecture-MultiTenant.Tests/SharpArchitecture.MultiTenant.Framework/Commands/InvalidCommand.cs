using System.ComponentModel.DataAnnotations;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class InvalidCommand : CommandBase
  {
    [Required]
    public bool? Invalid { get; set; }
  }
}