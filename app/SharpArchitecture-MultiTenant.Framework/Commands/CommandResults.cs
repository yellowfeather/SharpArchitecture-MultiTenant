using System.Collections.Generic;
using System.Linq;

namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  class CommandResults : ICommandResults
  {
    private readonly List<ICommandResult> _results = new List<ICommandResult>();

    public bool Success { get { return _results.All(result => result.Success); } }
    public ICommandResult[] Results { get { return _results.ToArray(); } }

    public void AddResult(ICommandResult result)
    {
      _results.Add(result);
    }
  }
}