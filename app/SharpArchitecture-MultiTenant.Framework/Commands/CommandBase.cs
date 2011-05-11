using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public abstract class CommandBase : ICommand
  {
    public virtual bool IsValid()
    {
      return ValidationResults().Count == 0;
    }

    public virtual ICollection<ValidationResult> ValidationResults()
    {
      var validationResults = new List<ValidationResult>();
      Validator.TryValidateObject(this, new ValidationContext(this, null, null), validationResults);
      return validationResults;
    }

  }
}