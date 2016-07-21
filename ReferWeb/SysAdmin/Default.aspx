<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SysAdmin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link type="text/css" href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="../Style/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="">
        
        <tr>
            <td>Username</td>
            <td><asp:TextBox ID="txtUser" runat="server" /></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnLogin" Text="Login" CssClass="" runat="server"/></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
