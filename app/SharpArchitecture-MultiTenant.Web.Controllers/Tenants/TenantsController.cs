using System;
using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Filters;
using SharpArch.Web.NHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Core.RepositoryInterfaces;
using SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants
{
  public class TenantsController : Controller
  {
    private const int DefaultPageSize = 20;
    private readonly ITenantRepository _tenantRepository;

    public TenantsController(ITenantRepository tenantRepository)
    {
      _tenantRepository = tenantRepository;
    }

    [HttpGet]
    [Transaction]
    public ActionResult Index(int? page)
    {
      var tenants = _tenantRepository.GetPagedList(page ?? 1, DefaultPageSize);
      var viewModel = new TenantListViewModel(tenants);
      return View(viewModel);
    }

    [HttpGet]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Create()
    {
      var viewModel = TempData.SafeGet<TenantFormViewModel>() ?? new TenantFormViewModel();
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Create(TenantFormViewModel viewModel)
    {
      if (!ViewData.ModelState.IsValid) {
        TempData.SafeAdd(viewModel);
        return this.RedirectToAction(c => c.Create());
      }

      try {
        var tenant = new Tenant { Name = viewModel.Name, Domain = viewModel.Domain, ConnectionString = viewModel.ConnectionString};
        _tenantRepository.SaveOrUpdate(tenant);
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("Successfully created tenant '{0}'", tenant.Name);
      }
      catch (Exception ex) {
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("An error occurred creating the tenant: {0}", ex.Message);
        return this.RedirectToAction(c => c.Create());
      }

      return this.RedirectToAction(c => c.Index(null));
    }

    [HttpGet]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Edit(int id)
    {
      var tenant = _tenantRepository.Get(id);
      var viewModel = new TenantFormViewModel(tenant);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Edit(TenantFormViewModel viewModel)
    {
      if (!ViewData.ModelState.IsValid) {
        return this.RedirectToAction(c => c.Edit(viewModel.Id));
      }

      try {
        var tenant = _tenantRepository.Get(viewModel.Id);
        tenant.Name = viewModel.Name;
        tenant.Domain = viewModel.Domain;
        tenant.ConnectionString= viewModel.ConnectionString;

        _tenantRepository.SaveOrUpdate(tenant);
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("Successfully updated tenant '{0}'", tenant.Name);
      }
      catch (Exception ex) {
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("An error occurred updating the tenant: {0}", ex.Message);
        return this.RedirectToAction(c => c.Edit(viewModel.Id));
      }

      return this.RedirectToAction(c => c.Index(null));
    }

    [HttpGet]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Delete(int id)
    {
      var tenant = _tenantRepository.Get(id);
      var viewModel = new TenantFormViewModel(tenant);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ModelStateToTempData]
    [Transaction]
    public ActionResult Delete(TenantFormViewModel viewModel)
    {
      if (!ViewData.ModelState.IsValid) {
        return this.RedirectToAction(c => c.Edit(viewModel.Id));
      }

      try {
        var tenant = _tenantRepository.Get(viewModel.Id);
        _tenantRepository.Delete(tenant);
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("Successfully deleted tenant '{0}'", tenant.Name);
      }
      catch (Exception ex) {
        TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = string.Format("An error occurred deleting the tenant: {0}", ex.Message);
        return this.RedirectToAction(c => c.Edit(viewModel.Id));
      }

      return this.RedirectToAction(c => c.Index(null));
    }
  }
}