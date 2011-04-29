using SharpArch.Core.PersistenceSupport;
using SharpArchitecture.MultiTenant.ApplicationServices.Commands;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Framework.Commands;

namespace SharpArchitecture.MultiTenant.ApplicationServices.CommandHandlers
{
  public class ImportCustomersCommandHandler : ICommandHandler<ImportCustomersCommand>
  {
    private readonly IRepository<Customer> _customerRepository;

    public ImportCustomersCommandHandler(IRepository<Customer> customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public ICommandResult Handle(ImportCustomersCommand command)
    {
      // get uploaded files by command.UploadKey

      // foreach uploaded file
      //   import file

      _customerRepository.SaveOrUpdate(new Customer { Code = "ABC", Name = "ABC" });
      _customerRepository.SaveOrUpdate(new Customer { Code = "DEF", Name = "DEF" });
      _customerRepository.SaveOrUpdate(new Customer { Code = "XYZ", Name = "XYZ" });

      return new ImportCustomersCommandResult(true);
    }
  }
}