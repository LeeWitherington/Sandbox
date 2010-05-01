<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Log
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Log</h2>
    <table>
        <tr>
            <th>Log lines</th>
        </tr>
        <% foreach (var line in Model)
           { %>
        <tr>
            <td>
                <%= Html.Encode(line)%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
