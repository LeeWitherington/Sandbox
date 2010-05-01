<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyShop.ReadModel.Product>" %>
<%@ Import Namespace="MyShop.UI.Web.MainSite.Core" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(Model.Name) %></h2>
    <p style="vertical-align: top;">
        <% if (String.IsNullOrEmpty(Model.ImageFilename))
           { %>
        <img src="../../Content/ProductImages/default.png" style="text-align: left; height: 150px;
            width: 150px;" alt="no product image available" />
        <% }
           else
           { %>
        <img src="../../Content/ProductImages/<%= Model.ImageFilename %>" style="text-align: right;
            width: 150px; height: 150px;" alt="product image" />
        <% } %>
        <%= Model.Description %>
    </p>
    <h3>
        Buy!</h3>
    <p>
        <strong>
            <%= Html.Encode(Model.UnitPrice) %></strong>
    </p>
    <p>
        <%= Html.ActionLink("Add to cart", "AddProduct", "ShoppingCart", new { id = Model.Id }, null)%>
    </p>
    <% if (User.IsInRole(MyShopRoles.Administrator))
       { %>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ })%>
        |
        <%=Html.ActionLink("Back to List", "Index")%>
    </p>
    <% } %>
</asp:Content>
