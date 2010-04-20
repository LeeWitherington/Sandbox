<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="MasterDetail4.aspx.cs" 
    Inherits="Samples.Ajax40.MasterDetail4" 
    Title="AJAX 4.0 Master/Detail"
     %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Master/Detail with P-Fetch  
</asp:Content>


<asp:Content ID="PH_ContentTitle_Content" runat="server" ContentPlaceHolderID="PH_ContentTitle">
    <h1>ASP.NET AJAX 4.0 in action::master/detail</h1>
    <p>
        The page gets some data and uses ASP.NET AJAX client templates to 
        bind it to visual elements in a master/detail fashion. It also
        employs predictive fetch capabilities to download orders.
    </p>    
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="PH_Head">
    <style type="text/css">
        .sys-template { display:none; }
        .selecteditem { color:lightgreen; background-color:black; } 
        .normalitem { cursor:pointer; margin:5px; margin-bottom:10px; }
    </style>
        <link href="../../Css/lessantique.css" rel="stylesheet" type="text/css" />
 </asp:Content>    


<asp:Content ID="Content5" ContentPlaceHolderID="PH_Body" runat="server">

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/start.debug.js" />
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
            <asp:ScriptReference Path="~/Code/Ajax40/MasterDetail4.aspx.js" />
       </Scripts>
    </asp:ScriptManagerProxy>

    <h3>
        Selected customers: <span sys:innerhtml="{binding Selection, source={{currentQuery}}}"></span>
    </h3>
 
    <div id="menuBar"></div>
    
    <!--Master View-->
    <div id="viewOfCustomers">
        <ul class="sys-template" sys:attach="dataview" id="masterView"
            dataview:dataprovider="/aspnetajax4/mydataservice.asmx"
            dataview:fetchoperation="LookupCustomers"
            dataview:selecteditemclass="selecteditem" 
            dataview:initialselectedindex="-1">
            <li>
                <span sys:command="Select" sys:commandargument="{binding ID}" onclick="fetchOrders(this)" id="itemCustomer" class="normalitem">
                    &nbsp;
                    <span><b>{binding CompanyName}</b></span>,&nbsp;&nbsp;
                    <span>{binding Country}</span>
                </span>        
            </li>
        </ul>
    </div>

    <!--Detail View-->
    <div id="detailView" class="sys-template" sys:attach="dataview"
        dataview:data="{binding selectedData, source=$masterView}">
        <table>
        <tr>
        <td valign="top">
        <table>
            <tr>
                <td><b>Contact</b></td>
                <td><input id="contact" type="text" sys:value="{binding ContactName}"/></td>
            </tr>
            <tr>
                <td><b>Address</b></td>
                <td><input id="address" type="text" sys:value="{binding Street}"/></td>
            </tr>
            <tr>
                <td><b>City</b></td>
                <td><input id="city" type="text" sys:value="{binding City}"/></td>
            </tr>
            <tr>
                <td><b>Phone</b></td>
                <td><input id="phone" type="text" sys:value="{binding Phone}"/></td>      
            </tr>
        </table>
        </td>
        <td valign="top">
            <div id="OrdersPanel">
                    <input id="btnOrders" type="button" name="btnOrders" value="View orders" onclick="display()" />
                    <span id="listOfOrders"></span>
            </div> 
        </td>
        </tr>
        </table>
    </div>
    
</asp:Content>

