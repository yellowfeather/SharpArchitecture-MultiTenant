<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SharpArchitecture.MultiTenant.Web.Controllers.Customers.ViewModels.ImportCustomersFormViewModel>" %>
<%@ Import Namespace="SharpArchitecture.MultiTenant.Web.Controllers.Customers" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Import Customers</h2>

    <div class="progress-message">
      <p>The data is being imported.</p>
      <p>Please wait...</p>
    </div>

    <div id="import-customers">
      <% using (Html.BeginForm()) {%>
        <fieldset>
          <%= Html.AntiForgeryToken() %>
          <%= Html.HiddenFor(m => m.UploadKey) %>
          <ul>
            <li>
		          <label for="importfiles">Files</label>
	            <input type="file" id="importfiles" name="importfiles" />
	            <div class="uploadifyLinks">
	              <a href="javascript:$('#importfiles').uploadifyClearQueue();">Clear Queue</a>
	            </div>
            </li>	              
            <li>
              <%= Html.SubmitButton("submit", "Import") %> or <%= Html.ActionLink<CustomersController>(c => c.Index(null), "Cancel")%>
            </li>
          </ul>
        </fieldset>
      <% } %>
    </div>

    <script type="text/javascript">
      $(function () {
        var auth = "<%= Request.Cookies[FormsAuthentication.FormsCookieName]==null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>";
        var uploadKey = $("#UploadKey").val();

        $("#importfiles").uploadify({
          'uploader': '<%= Url.Content("~/Scripts/uploadify.swf") %>',
          'script': '<%= Url.Content("~/Customers/Upload") %>',
          'scriptData': { token: auth, uploadKey: uploadKey },
          'cancelImg': '<%= Url.Content("~/Content/Images/cancel.png") %>',
          'folder': '<%= Url.Content("~/App_Data") %>',
          'multi': true,
          'auto': true,
          'removeCompleted': false,
          'sizeLimit': 20971520,
          'onComplete': function (event, queueID, fileObj, response, data) { return false; },
          'onError': function (event, ID, fileObj, errorObj) { alert(errorObj.type + "::" + errorObj.info); }
        });

        $(".progress-message").hide();
        $("#import-customers form").submit(function (eventObject) {
          $("#submit").attr("disabled", true);
          $(".progress-message").show();
          return true;
        });
      });
    </script>  

</asp:Content>