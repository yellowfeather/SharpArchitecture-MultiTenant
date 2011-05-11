using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface ICommand
  {
    bool IsValid();
    ICollection<ValidationResult> ValidationResults();
  }
}