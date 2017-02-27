<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfterToken.aspx.cs" Inherits="Vitaminder.AfterToken" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vitaminder</title>
</head>
<body>
    <form id="frmMain" runat="server">

        <h1>Vitaminder AfterToken</h1>

        <p><asp:Literal ID="litTokens" runat="server"></asp:Literal></p>

        <asp:Button ID="btnReplenish" runat="server" Text="Replenish Vitamins" />

        <p><asp:Literal ID="litResult" runat="server"></asp:Literal></p>

    </form>
</body>
</html>