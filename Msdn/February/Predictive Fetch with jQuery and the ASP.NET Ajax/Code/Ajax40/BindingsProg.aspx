<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="BindingsProg.aspx.cs" 
    Inherits="Samples.Ajax40.Templates" Title="AJAX 4.0 Templates"
    Theme="DinoPlex" %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Templates in action (SIMPLE)
</asp:Content>


<asp:Content ID="PH_ContentTitle_Content" runat="server" ContentPlaceHolderID="PH_ContentTitle">
    <h1>ASP.NET AJAX 4.0 in action::Templates</h1>
    <p>
        The page gets some data and uses ASP.NET AJAX client templates to render it out.
    </p>    
        
     <p>&nbsp;</p>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="PH_Head">
    
    <link rel="stylesheet" type="text/css" href="../../Css/lessantique.css" />
    <style type="text/css">
        .sys-template { display:none; }
    </style>
    
    <script type="text/javascript">
        var theCustomers = [
           { ID: "ALFKI", CompanyName: "Alfred Futterkiste" },
           { ID: "CONTS", CompanyName: "Contoso" }
        ];
    </script>
    
    <script type="text/javascript">
        function bind() {
            theDataView = $find("DataView1");
            theDataView.set_data(theCustomers);
        }
    </script>
    
</asp:Content>    

<asp:Content ID="Content5" ContentPlaceHolderID="PH_Body" runat="server">

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
        </Scripts>
    </asp:ScriptManagerProxy>

    <div id="customerList">
        <ul class="sys-template" sys:attach="dataview" id="DataView1">
            <li>
                <span ><b>{{ ID }}</b></span>
                <asp:label runat="server" Text="{{ CompanyName }}"></asp:label> 
            </li>
        </ul>
    </div>

    
    <input type="button" value="Programmatic binding" onclick="bind()" />

</asp:Content>

