<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyShop.ReadModel.ShoppingCart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Shopping cart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        You shopping cart</h2>
    <table>
        <tr>
            <th></th>
            <th>
                Quantity
            </th>
            <th>
                Product
            </th>
            <th>
                Price
            </th>
        </tr>
        <% foreach (var item in Model.ShoppingCartItems)
           {%>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "EditItem", new { item.ProductId })%>
            </td>
            <td>
                <%=Html.Encode(item.Quantity)%>
            </td>
            <td>
                <%=Html.Encode(item.Product.Name)%>
            </td>
            <td>
                <%=Html.Encode(item.Quantity * item.Product.UnitPrice)%>
            </td>
        </tr>
        <%
            }%>
    </table>
</asp:Content>
