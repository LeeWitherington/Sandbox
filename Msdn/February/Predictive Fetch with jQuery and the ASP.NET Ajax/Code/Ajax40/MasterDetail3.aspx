<%@ Page Language="C#" MasterPageFile="~/DinoPlex.master" AutoEventWireup="true" 
    CodeFile="MasterDetail3.aspx.cs" 
    Inherits="Samples.Ajax40.MasterDetail3" Title="AJAX 4.0 Master/Detail"
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
    
    <script type="text/javascript">
        var currentQuery = { Selection: "A" };

        function pageLoad() {
            // Build the button bar to select customers by initial
            for(var i=0; i<26; i++) {
                var newButton = $('<input type="button" onclick="filterQuery(this)" />');
                var text = String.fromCharCode('A'.charCodeAt(0) + i);
                newButton.attr("value", text).appendTo("#menuBar").show();
            }

            // Make the current query object observable so that live binding can update
            // the displayed selection string 
            Sys.Observer.makeObservable(currentQuery);
               
            // Refresh the list of customers
            fillMasterView(currentQuery);
        }
        function filterQuery(button) {
            // Enables live binding on the internal object that contains 
            // the current filter.
            Sys.Observer.setValue(currentQuery, "Selection", button.value);

            // Updates the master view
            fillMasterView(currentQuery);
        }
        function fillMasterView(query) {
            // Check cache first: if not, go thorugh the data provider
            if (!reloadFromCache(query))
                reloadFromSource(query);
        }
        function reloadFromCache(query) {
            // Using the query string as the cache key
            var filterString = query.Selection; 
            
            // Check the jQuery cache and update
            var cachedInfo = $('#viewOfCustomers').data(filterString);

    //            // Low-level API
    //            var cachedInfo ;
    //            if (jQuery.cache["Dino"])
    //                cachedInfo = jQuery.cache["Dino"][filterString];
            
            if (typeof (cachedInfo) !== 'undefined') {
                var dv = $find("masterView");
                dv.set_data(cachedInfo);
                dv.refresh();
                return true;
            }

            return false;       
        }
        function reloadFromSource(query) {
            // Set the query string for the provider
            var filterString = query.Selection;
            
            // Tell the DataView to fetch
            var dv = $find("masterView");
            dv.set_fetchParameters({ query: filterString });
            dv.fetchData(cacheOnFetchCompletion, null, null, filterString);
         }
         function cacheOnFetchCompletion(fetchedData, filterString) {
            if (fetchedData !== null) {
                $('#viewOfCustomers').data(filterString, fetchedData);

    //            // Low-level API
    //            if (!jQuery.cache["Dino"])
    //                 jQuery.cache["Dino"] = {};
    //            jQuery.cache["Dino"][filterString] = fetchedData;
            }
        }
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
    <div id="viewOfCustomers">
        <ul class="sys-template" sys:attach="dataview" id="masterView"
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
    <div id="detailView" class="sys-template" sys:attach="dataview"
        dataview:data="{binding selectedData, source=$masterView}">
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

