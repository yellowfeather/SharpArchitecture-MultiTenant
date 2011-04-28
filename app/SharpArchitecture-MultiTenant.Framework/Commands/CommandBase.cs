namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public abstract class CommandBase<TResult> : ICommand<TResult> where TResult : ICommandResult
  {
    public TResult Result { get; set; }
  }
}