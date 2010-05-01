<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MyShop.ReadModel.Product>>" %>

<%@ Import Namespace="MyShop.UI.Web.MainSite.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        All products</h2>
    <p>
        Here you'll find all the great products we offer!
    </p>
    <% if (Model.Count() > 0)
       { %>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                UnitPrice
            </th>
            <th>
                Image
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <% if (User.IsInRole(MyShopRoles.Administrator))
                   { %>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id })%>
                |
                <% } %>
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Description)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.UnitPrice))%>
            </td>
            <td>
                <% if (String.IsNullOrEmpty(item.ImageFilename))
                   { %>
                <img src="../../Content/ProductImages/default.png" width="25px" height="25px" />
                <% }
                   else
                   { %>
                <img src="../../Content/ProductImages/<%=item.ImageFilename %>" width="25px" height="25px" />
                <% } %>
            </td>
        </tr>
        <% } %>
    </table>
    <% }
       else
       {%>
    <%
        if (User.IsInRole(MyShopRoles.Administrator))
        {%>
    <p class="info">
        There are not products at the moment. Please us the <i>Create New</i> link below
        and add one or more products.</p>
    <%
        }
        else
        {%>
    <p class="info">
        There are no products at the moment. Please login as <i>admin</i> and add one or
        more products.</p>
    <%
        }
       }
       if (User.IsInRole(MyShopRoles.Administrator))
       {
    %>
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    <%
        }
    %>
</asp:Content>
