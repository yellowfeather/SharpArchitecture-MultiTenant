<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModel.CustomerListViewModel>"%>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<%@ Import Namespace="SharpArchitecture.MultiTenant.Web.Controllers.Customers" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>List of Customers</h2>

    <%= Html.ActionLink<CustomersController>(x => x.Create(), "New Customer", new { @class="medium button" }) %>

    <%= Html.Grid(Model.Customers)
        .Columns(column =>
        {
          column.For(c => c.Code);
          column.For(c => c.Name);
          column.For(c => Html.ActionLink<CustomersController>(x => x.Edit(c.Id), "edit"));
          column.For(c => Html.ActionLink<CustomersController>(x => x.Delete(c.Id), "delete"));
        }) 
    %>
    <%= Html.Pager(Model.Customers)%>

</asp:Content>