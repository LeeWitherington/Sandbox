<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyShop.ReadModel.ShoppingCartItem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditItem
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        EditItem</h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <table>
        <tr>
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
        <tr>
            <td>
                <label for="Quantity">
                    Quantity:</label>
                <%= Html.TextBox("Quantity", Model.Quantity) %>
                <%= Html.ValidationMessage("Quantity", "*") %>
            </td>
            <td>
                <%=Html.Encode(Model.Product.Name)%>
            </td>
            <td>
                <%=Html.Encode(Model.Quantity * Model.Product.UnitPrice)%>
            </td>
        </tr>
    </table>
    <p>
        <input type="submit" value="Save" />
    </p>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
