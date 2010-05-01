<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<System.Web.Security.MembershipUser>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Username
            </th>
            <th>
                Email
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.UserName }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.UserName })%>
            </td>
            <td>
                <%= Html.Encode(item.ProviderUserKey) %>
            </td>
            <td>
                <%= Html.Encode(item.UserName) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

