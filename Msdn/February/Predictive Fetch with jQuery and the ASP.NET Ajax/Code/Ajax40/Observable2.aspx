<%@ Page Language="C#" AutoEventWireup="true" 
    CodeFile="Observable2.aspx.cs" 
    Inherits="Samples.Ajax40.Observable2" Title="AJAX 4.0 Bindings"
    Theme="DinoPlex" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        .sys-template { display:none; }
    </style>
    

    
    <script type="text/javascript">
        var theCustomers = [
                { ID: "ALFKI", CompanyName: "Alfred Futterkiste" },
                { ID: "CONTS", CompanyName: "Contoso" }
            ];    
        function pageLoad() {
            Sys.Observer.makeObservable(theCustomers);
        }
        
        function onInsert() {
            var newCustomer = { ID: "ANYNA", CompanyName: "AnyNameThatWorks Inc" };
            theCustomers.add(newCustomer);
        }
    </script>
    
</head>
<body xmlns:sys="javascript:Sys" xmlns:dataview="javascript:Sys.UI.DataView" >

    <form id="Form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="false">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" Path="~/Scripts/Ajax40/Preview6/MicrosoftAjax.js" />
            <asp:ScriptReference Path="~/Scripts/Ajax40/Preview6/MicrosoftAjaxTemplates.js" />
        </Scripts>
        </asp:ScriptManager>

        <div >
            <ul class="sys-template" sys:attach="dataview" 
                dataview:data="{{ theCustomers }}">
                <li>
                    <span>{{ ID }}</span>
                    <span>{{ CompanyName }}</span>
                </li>
            </ul>
        </div>       
        
        <input type="button" value="Insert" onclick="onInsert()" /> 
    </form>
</body>
</html>
