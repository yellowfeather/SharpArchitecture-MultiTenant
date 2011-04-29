namespace SharpArchitecture.MultiTenant.Framework.Commands
{
  public interface ICommandResults
  {
    bool Success { get; }
    ICommandResult[] Results { get; }
  }
}