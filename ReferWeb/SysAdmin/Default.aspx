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

            <table style="width:100%;">
                <tr>
                    <td style="width:100%; position:absolute;top:40%;" align="center">
                        <table border="1" >
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: left;">LOGIN</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; padding: 5px;">Email</td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtEmail" CssClass="txtMedInput" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; padding: 5px;">Password</td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtPassword" CssClass="txtMedInput" TextMode="Password" runat="server" /></td>
                            </tr>

                            <tr>
                                <td style="padding: 5px;">&nbsp;</td>
                                <td style="text-align: left;">
                                    <asp:Button ID="btnLogin" Text="Login" CssClass="" runat="server" /></td>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
