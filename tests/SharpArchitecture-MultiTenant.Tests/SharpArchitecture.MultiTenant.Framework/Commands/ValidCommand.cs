using System.ComponentModel.DataAnnotations;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace Tests.SharpArchitecture.MultiTenant.Framework.Commands
{
  public class ValidCommand : CommandBase
  {
    public ValidCommand()
    {
      Valid = true;
    }

    [Required]
    public bool? Valid { get; set; }
  }
}