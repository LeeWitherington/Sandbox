<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="DataView1.aspx.cs" 
    Inherits="Samples.Ajax40.DataView1" Title="AJAX 4.0 Templates"
    Theme="DinoPlex" %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Templates in action (SIMPLE)
</asp:Content>


<asp:Content ID="PH_ContentTitle_Content" runat="server" ContentPlaceHolderID="PH_ContentTitle">
    <h1>ASP.NET AJAX 4.0 in action</h1>
    <p>
        The page gets some data and uses ASP.NET AJAX client templates to render it out.
    </p>    
        
     <p>&nbsp;</p>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="PH_Head">
    
    <link rel="stylesheet" type="text/css" href="../../Css/lessantique.css" />
    <style type="text/css">
        .sys-template { display:none; visibility:hidden; }
    </style>
    
    <script type="text/javascript">
        function getLiveQuotes() 
        {
            Samples.Services.FinanceInfoService.GetQuotesFromConfig(true, onDataAvailable);
        }

        var dv = null;
        function onDataAvailable(results) {
            if (dv === null)
                dv = new Sys.UI.DataView($get("MyTemplate"));
            dv.set_data(results);
            dv.refresh();
        }
    </script>
    
</asp:Content>    

<asp:Content ID="Content5" ContentPlaceHolderID="PH_Body" runat="server">

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="~/LiveQuotes.svc" />
        </Services>
    </asp:ScriptManagerProxy>

    
    <h2>
        Personal Stock Exchange&nbsp;&nbsp;&nbsp;
    </h2>

    <input type="button" id="btnRefresh" value="Refresh" onclick="getLiveQuotes()" />
    <br /><br />


    <div>
        <ul id="MyTemplate" class="sys-template">
            <li>
            {{ Symbol }}, {{ Quote }}, {{ Change }}
            </li>
        </ul>
    </div>    
    
    <div id="output"></div>

</asp:Content>

