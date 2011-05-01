using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public class CommandProcessor : ICommandProcessor
  {
    public ICommandResults Process<TCommand>(TCommand command) where TCommand : ICommand
    {
      var results = new CommandResults();

      var handlers = ServiceLocator.Current.GetAllInstances<ICommandHandler<TCommand>>();
	  if (handlers == null || !handlers.Any()) {
		throw new CommandHandlerNotFoundException();
	  }
			
      foreach (var result in handlers.Select(handler => handler.Handle(command))) {
        results.AddResult(result);
      }

      return results;
    }
  }
}