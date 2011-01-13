using SharpArchitecture.MultiTenant.Core;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels
{
  public class CustomerFormViewModel
  {
    public CustomerFormViewModel() {}

    public CustomerFormViewModel(Customer customer)
    {
      Id = customer.Id;
      Code = customer.Code;
      Name = customer.Name;
    }

    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
  }
}