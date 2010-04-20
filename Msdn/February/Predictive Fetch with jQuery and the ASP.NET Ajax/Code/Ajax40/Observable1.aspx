<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="Observable1.aspx.cs" 
    Inherits="Samples.Ajax40.Observable1" Title="AJAX 4.0 Bindings"
    Theme="DinoPlex" %>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="PH_Title">
    Live binding in action  
</asp:Content>


<asp:Content ID="PH_ContentTitle_Content" runat="server" ContentPlaceHolderID="PH_ContentTitle">
    <h1>ASP.NET AJAX 4.0 in action::Bindings</h1>
    <p>
        The page gets some data and uses ASP.NET AJAX client templates to bind it to visual elements.
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
        function pageLoad() {
            Sys.Observer.makeObservable(theCustomers);
        }
    </script>
    
    <script type="text/javascript">
        function applyChanges() {
            theCustomers[0].CompanyName = "This is a new name";
            //Sys.Observer.setValue(theCustomers[0], "CompanyName", "This is a new name");
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
        <ul class="sys-template" sys:attach="dataview" dataview:data="{{ theCustomers }}">
            <li>
                <span ><b>{binding ID}</b></span>
                <input type="text" id="TextBox1" sys:value="{binding CompanyName}" /> 
            
                <br />  
                <span>Currently displaying... <b>{binding CompanyName}</b></span>  
            </li>
        </ul>
    </div>

    
    <input type="button" value="Make some changes" onclick="applyChanges()" />
    
</asp:Content>

