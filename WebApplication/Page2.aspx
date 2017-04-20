<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="WebApplication.Page2" %>

<!DOCTYPE html>

<script src="/scripts/jquery-3.1.1.min.js"></script>
<script src="http://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SGCIS Test Page 2</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div>
        <div class="row">
            <div class="col-sm-2">
            </div>
            <div class="col-sm-3 h1">
                <asp:Label ID="name" runat="server"></asp:Label>
            </div>
            <div class="col-sm-3 h1">
                <asp:Label ID="age" runat="server"></asp:Label>
            </div>
            <div class="col-sm-3 h1">
                <asp:Label ID="type" runat="server"></asp:Label>
            </div>

        </div>
    </div>
    <br />
    <br/>
    <div>
        <asp:Literal ID="chrtMyChart" runat="server"></asp:Literal>
    </div>

</body>
</html>
