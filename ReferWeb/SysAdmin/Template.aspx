<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="SysAdmin_Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableOutline" style="text-align: left; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td><asp:Label ID="lblPageTitle" runat="server" /></td>
        </tr>
    </table>

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        
        <tr>
            <td style="text-align: right; padding: 5px; width:300px;"></td>
            <td style="text-align: left; width:620px;"></td>
        </tr>

    </table>
</asp:Content>

