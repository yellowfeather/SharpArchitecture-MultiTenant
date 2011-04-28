namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface ICommand<out TResult> : IMessage where TResult : ICommandResult
  {
    TResult Result { get; }
  }
}