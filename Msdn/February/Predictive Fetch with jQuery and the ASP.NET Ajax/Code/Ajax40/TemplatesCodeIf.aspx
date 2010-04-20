<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="TemplatesCodeIf.aspx.cs" 
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
    
<script language="javascript" type="text/javascript">
    var dv = null;
    function pageLoad()
    {
       dv = $create(Sys.UI.DataView,
               {
                   autoFetch: true,
                   dataProvider: "/aspnetajax4/mydataservice.asmx",
                   fetchOperation: "LookupAllCustomers"
               },
               {},
               {},
               $get("grid")
       );
    }
</script>  
    
    <script language="javascript" type="text/javascript">
        function refreshTemplate() {
            var theDataView = $find("grid");
            theDataView.refresh();
            //dv.refresh();
        }

        var currentCountry = "";
        function listOfCountries_onchange() {
            // Pick up the currently selected item
            //var dd = $get("listOfCountries");
            var dd = $get("<% = listOfCountries.ClientID %>");  // unless you use 4.0
            currentCountry = dd.options[dd.selectedIndex].value;
            
            // Refresh the template
            refreshTemplate();
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


    <div>
        <asp:DropDownList ID="listOfCountries" runat="server" 
            onchange="listOfCountries_onchange()">
        </asp:DropDownList>
        
        
    <table id="gridLayout" cellpadding="4" cellspacing="2">
        <tr style="background-color:#6B696B;color:White;">
           <th>ID</th>
           <th>COMPANY</th>
           <th>COUNTRY</th>
        </tr>

        <tbody id="grid" class="sys-template">
            <tr sys:if="$dataItem.Country != currentCountry" style="background-color:#F0FAFF;">
                <td align="left">{{ ID }}</td>
                <td align="right">{{ CompanyName }}</td>
                <td align="right">{{ Country }}</td>
            </tr>
            <tr sys:if="$dataItem.Country == currentCountry" style="background-color:#000000;color:Yellow;">
                <td align="left" 
                    sys:codeafter="if($dataItem.Country == 'Sweden') {
                                   $element.style.color = 'orange';
                                   $element.style.fontWeight = 700;
                                }"
                    sys:codebefore="">
                    {{ ID }}</td>
                <td align="right">{{ CompanyName }}</td>
                <td align="right">{{ Country }}</td>
            </tr> 
        </tbody>
    </table> 

    </div>    

</asp:Content>

