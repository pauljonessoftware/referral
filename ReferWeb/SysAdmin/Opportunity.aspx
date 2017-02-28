<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="Opportunity.aspx.cs" Inherits="SysAdmin_Opportunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="hdnUserType" runat="server" Value="2" />
    <asp:HiddenField ID="hdnNumberTypeId" runat="server" Value="1" />

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: left; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td>Add Opportunity</td>
        </tr>
    </table>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        
        <tr>
            <td style="text-align: right; padding: 5px; width:300px;">Title:</td>
            <td style="text-align: left; width:620px;"><asp:TextBox ID="txtTitle" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        
        <tr>
            <td style="text-align: right; padding: 5px; width:300px;">Description:</td>
            <td style="text-align: left; width:620px;"><asp:TextBox ID="txtDescription" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        
        <tr>
            <td style="text-align: right; padding: 5px; width:300px;">Title:</td>
            <td style="text-align: left; width:620px;"><asp:TextBox ID="TextBox1" CssClass="txtMedInput" runat="server" /></td>
        </tr>
                        
    </table>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        <asp:GridView 
            ID="grdOpportunities" 
            runat="server" 
            AutoGenerateColumns="false" 
            CssClass="tableOutline">

            <Columns>

                <asp:CommandField  ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>

