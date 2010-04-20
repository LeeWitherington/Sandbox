<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="MasterDetail2.aspx.cs" 
    Inherits="Samples.Ajax40.MasterDetail2" Title="AJAX 4.0 Master/Detail"
    Theme="DinoPlex" %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Master/Detail blocks in action  
</asp:Content>


<asp:Content ID="PH_ContentTitle_Content" runat="server" ContentPlaceHolderID="PH_ContentTitle">
    <h1>ASP.NET AJAX 4.0 in action::master/detail</h1>
    <p>
        The page gets some data and uses ASP.NET AJAX client templates to 
        bind it to visual elements in a master/detail fashion.
    </p>    
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="PH_Head">
    
    <link rel="stylesheet" type="text/css" href="../../Css/lessantique.css" />
    <style type="text/css">
        .sys-template { display:none; }
        .selecteditem { color:lightgreen; background-color:black; } 
        .normalitem { cursor:pointer; margin:5px; margin-bottom:10px; }
    </style>
    
    <script type="text/javascript" src="MasterDetail2.aspx.js">
    </script>
       
</asp:Content>    

<asp:Content ID="Content5" ContentPlaceHolderID="PH_Body" runat="server">

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-1.3.2.min.js" />
       </Scripts>
    </asp:ScriptManagerProxy>

    <h3>
        Selected customers: <span sys:innerhtml="{binding Selection, source={{currentQuery}}}"></span>
    </h3>
    <div id="menuBar"></div>
    
    <!--Master View-->
    <div id="masterView">
        <ul class="sys-template" sys:attach="dataview" id="masterDataView"
            dataview:dataprovider="/aspnetajax4/mydataservice.asmx"
            dataview:fetchoperation="LookupCustomers"
            dataview:selecteditemclass="selecteditem"             
            dataview:initialselectedindex="0">
            <li>
                <span sys:command="Select" id="itemCustomer" class="normalitem">
                    &nbsp;
                    <span><b>{binding CompanyName}</b></span>,&nbsp;&nbsp;
                    <span>{binding Country}</span>
                </span>        
            </li>
        </ul>
    </div>

    <!--Detail View-->
    <div class="sys-template" sys:attach="dataview"
        dataview:data="{binding selectedData, source=$masterDataView}">
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
    </div>
    
    
</asp:Content>

