<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Code_Ajax40_Test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../../Css/lessantique.css" rel="stylesheet" type="text/css" />
        <link href="../../Css/jq-ui-Themes/sunny/jquery-ui-sunny.css"rel="stylesheet" type="text/css" />   

    <style type="text/css">
        .sys-template { display:none; }
    </style>

    <script type="text/javascript" src="../../Scripts/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jQueryUI/jquery-ui-1.7.2.custom.min.js"></script>
    
 <script type="text/javascript">
    $(document).ready( 
        function() {
            $("#OrdersPanel").tabs();
        }
    );
    </script>
    
    
</head>
<body>
   
<div id="OrdersPanel">
    <ul>
        <li><a href="#tabOrders"><span><b>Orders</b></span></a></li>
    </ul>
    <div id="tabOrders">
        <span style="font-size:150%"><b>#1</b></span>
        <hr style="height: 2px;border-top:solid 1px black;" /> 
    </div>
</div>        


</body>
</html>
