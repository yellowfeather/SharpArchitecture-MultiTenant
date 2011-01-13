<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SharpArchitecture.MultiTenant.Web.Controllers.Tenants.ViewModels.TenantFormViewModel>" %>
<%@ Import Namespace="SharpArchitecture.MultiTenant.Web.Controllers.Tenants" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Delete Tenant</h2>

    <% using (Html.BeginForm()) {%>
      <fieldset>
        <%= Html.AntiForgeryToken() %>
        <ul>
          <li>
            <%= Html.LabelFor(x => x.Name) %>
            <%= Html.TextBoxFor(x => x.Name)%>
            <%= Html.ValidationMessageFor(x => x.Name, "*")%>
          </li>
          <li>
            <%= Html.LabelFor(x => x.Domain) %>
            <%= Html.TextBoxFor(x => x.Domain)%>
            <%= Html.ValidationMessageFor(x => x.Domain, "*")%>
          </li>
          <li>
            <%= Html.LabelFor(x => x.ConnectionString) %>
            <%= Html.TextBoxFor(x => x.ConnectionString)%>
            <%= Html.ValidationMessageFor(x => x.ConnectionString, "*")%>
          </li>
          <li>
            <%= Html.SubmitButton("submit", "Delete") %>
            or <%= Html.ActionLink<TenantsController>(c => c.Index(null), "Cancel")%>
          </li>
        </ul>
      </fieldset>
    <% } %>

</asp:Content>
