<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels.TenantListViewModel>"%>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<%@ Import Namespace="SharpArchitecture.MultiTenant.Web.Controllers.Tenants" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>List of Tenants</h2>

    <%= Html.ActionLink<TenantsController>(x => x.Create(), "New Tenant", new { @class = "medium button" })%>

    <%= Html.Grid(Model.Tenants)
        .Columns(column =>
        {
          column.For(c => c.Name);
          column.For(c => c.Domain);
          column.For(c => c.ConnectionString);
          column.For(c => Html.ActionLink<TenantsController>(x => x.Edit(c.Id), "edit"));
          column.For(c => Html.ActionLink<TenantsController>(x => x.Delete(c.Id), "delete"));
        }) 
    %>
    <%= Html.Pager(Model.Tenants)%>

</asp:Content>