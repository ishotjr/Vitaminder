<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleLogin.aspx.cs" Inherits="Vitaminder.HandleLogin" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vitaminder</title>
</head>
<body>
    <form id="frmMain" runat="server">

        <h1>Vitaminder Login Handler</h1>

        <p><em>Code: <asp:Literal ID="litCode" runat="server"></asp:Literal></em></p>

        <p><asp:Literal ID="litResult" runat="server"></asp:Literal></p>

    </form>
</body>
</html>