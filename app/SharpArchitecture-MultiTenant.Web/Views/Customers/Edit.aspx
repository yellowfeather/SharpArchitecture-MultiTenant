<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels.CustomerFormViewModel>" %>
<%@ Import Namespace="SharpArchitecture.MultiTenant.Web.Controllers.Customers" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Edit Customer</h2>

    <% using (Html.BeginForm()) {%>
      <fieldset>
        <%= Html.AntiForgeryToken() %>
        <ul>
          <li>
            <%= Html.LabelFor(x => x.Code) %>
            <%= Html.TextBoxFor(x => x.Code)%>
            <%= Html.ValidationMessageFor(x => x.Code, "*")%>
          </li>
          <li>
            <%= Html.LabelFor(x => x.Name) %>
            <%= Html.TextBoxFor(x => x.Name)%>
            <%= Html.ValidationMessageFor(x => x.Name, "*")%>
          </li>
          <li>
            <%= Html.SubmitButton("submit", "Update") %>
            or <%= Html.ActionLink<CustomersController>(c => c.Index(null), "Cancel")%>
          </li>
        </ul>
      </fieldset>
    <% } %>

</asp:Content>