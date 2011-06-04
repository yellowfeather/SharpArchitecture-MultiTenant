using MvcContrib.Pagination;
using NHibernate.Transform;
using SharpArch.NHibernate;
using SharpArchitecture.MultiTenant.Core;
using SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels;

namespace SharpArchitecture.MultiTenant.Web.Controllers.Tenants.Queries.Impl
{
  public class TenantListQuery : NHibernateQuery, ITenantListQuery
  {
    public IPagination<TenantViewModel> GetPagedList(int pageIndex, int pageSize)
    {
      var query = Session.QueryOver<Tenant>()
        .OrderBy(customer => customer.Name).Asc;

      var countQuery = query.ToRowCountQuery();
      var totalCount = countQuery.FutureValue<int>();

      var firstResult = (pageIndex - 1) * pageSize;
      TenantViewModel viewModel = null;
      var viewModels = query.SelectList(list => list
                              .Select(mission => mission.Id).WithAlias(() => viewModel.Id)
                              .Select(mission => mission.Name).WithAlias(() => viewModel.Name)
                              .Select(mission => mission.Domain).WithAlias(() => viewModel.Domain)
                              .Select(mission => mission.ConnectionString).WithAlias(() => viewModel.ConnectionString))
        .TransformUsing(Transformers.AliasToBean(typeof(TenantViewModel)))
        .Skip(firstResult)
        .Take(pageSize)
        .Future<TenantViewModel>();

      return new CustomPagination<TenantViewModel>(viewModels, pageIndex, pageSize, totalCount.Value);
    }
  }
}