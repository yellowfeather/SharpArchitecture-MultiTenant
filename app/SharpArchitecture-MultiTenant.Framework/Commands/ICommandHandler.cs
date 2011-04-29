namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface ICommandHandler<in TCommand> where TCommand : ICommand
  {
    ICommandResult Handle(TCommand command);
  }
}