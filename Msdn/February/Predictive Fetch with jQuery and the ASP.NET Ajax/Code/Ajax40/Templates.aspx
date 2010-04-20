<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="Templates.aspx.cs" 
    Inherits="Samples.Ajax40.Templates" Title="AJAX 4.0 Templates"
    Theme="DinoPlex" %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Templates in action
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
        var timer = null;
        var dv = null;
        
        function pageLoad() {
            if (timer === null) {
                timer = new Samples.Components.Timer(5000, getLiveQuotes, true);
            }
           var workingOffline = $get("<%= chkOffline.ClientID %>").checked;
           dv = $create(Sys.UI.DataView,
                   {
                       autoFetch: true,
                       dataProvider: "/aspnetajax4/LiveQuotes.svc",
                       fetchParameters: { isOffline: workingOffline },
                       fetchOperation: "GetQuotesFromConfig"
                   },
                   {},
                   {},
                   $get("grid")
           );

        }
    </script>    
    <script language="javascript" type="text/javascript">
        function startQuoteMonitor() {
            var isActive = timer.get_isActive();
            if (isActive) {
                timer.stop();
                $get("btnMonitor").value = "Start monitor";
            }
            else {
                timer.start();
                $get("btnMonitor").value = "Stop monitor";
            }
        }

        function getLiveQuotes() {
            var workingOffline = $get("<%= chkOffline.ClientID %>").checked;

            $("#gridLayout").fadeOut(1000,
               function() {
                   dv.set_fetchParameters({ isOffline: workingOffline });
                   dv.fetchData();
                   $("#gridLayout").fadeIn(1000);
               }
            );
        }
    </script>    
</asp:Content>    

<asp:Content ID="Content5" ContentPlaceHolderID="PH_Body" runat="server">

    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.debug.js" />
            <asp:ScriptReference Path="~/Scripts/Samples.Components.Timer.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-1.3.2.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
        
    <h2>
        Personal Stock Exchange&nbsp;&nbsp;&nbsp;
        <small><asp:CheckBox runat="server" ID="chkOffline" Text="Offline" Checked="true" /></small>
    </h2>

    <input type="button" id="btnMonitor" value="Start monitor" onclick="startQuoteMonitor()" />
    <input type="button" id="btnRefresh" value="Refresh" onclick="getLiveQuotes()" />
    <br /><br />


    <div>
    <table id="gridLayout" cellpadding="4" cellspacing="2">
        <tr style="background-color:#6B696B;color:White;">
           <th>SYMBOL</th>
           <th>LAST</th>
           <th>CHANGE</th>
        </tr>
        <tbody id="grid" class="sys-template">
        <tr style="background-color:#F0FAFF;">
            <td align="left">{{ Symbol }}</td>
            <td align="right">{{ Quote }}</td>
            <td align="right">{{ Change }}</td>
        </tr> 
        </tbody>
    </table> 
    

    </div>    

</asp:Content>

