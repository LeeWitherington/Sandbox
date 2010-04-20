<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Code_Ajax40_Test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .sys-template { display:none; }
    </style>
    
    <script type="text/javascript">
    var imageArray = [
       { Name: "Crashing water", Description: "A splash of waves captured." },
       { Name: "Dazed", Description: "Mid-day heat?" },
       { Name: "Close Zoom on Giraffe", Description: "Closeup of a Giraffe at Wild Animal Park." },
       { Name: "Pier", Description: "A pier in Morro Bay." },
       { Name: "Seagull reflections", Description: "Seagulls at peace." },
       { Name: "Spain", Description: "In Balboa Park, in downtown San Diego." },
       { Name: "Sumatran Tiger", Description: "Restful." }
    ];
    </script>
</head>
<body xmlns:sys="javascript:Sys" xmlns:dataview="javascript:Sys.UI.DataView">

    <form runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1">
            <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
            </Scripts>
        </asp:ScriptManager>

<div >
        <ul id="imageListView" class="sys-template" sys:attach="dataview" 
            dataview:data="{{ imageArray }}">
            <li>
                <span class="name">{{ Name }}</span>
                <span class="value">{{ Description }}</span>
            </li>
        </ul>
</div>        
    </form>
</body>
</html>
