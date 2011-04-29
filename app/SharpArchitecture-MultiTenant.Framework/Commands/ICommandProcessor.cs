namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface ICommandProcessor
  {
    ICommandResults Process<TCommand>(TCommand command) where TCommand : ICommand;
  }
}