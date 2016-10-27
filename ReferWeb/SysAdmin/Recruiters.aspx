<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="Recruiters.aspx.cs" Inherits="SysAdmin_Recruiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:HiddenField ID="hdnUserType" runat="server" Value="3" />

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: left; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td>Add Recruiter</td>
        </tr>
    </table>

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td style="text-align: right; padding: 5px;">First Name:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtFirstName" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">Middle Initial:</td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlMiddleInitial" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">Last Name:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtLastName" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">Suffix:</td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlSuffix" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">Company Name:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtCompanyName" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">URL:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtURL" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;" class="auto-style1">Email:</td>
            <td style="text-align: left;" class="auto-style1">
                <asp:TextBox ID="txtEmail" CssClass="txtMedInput" runat="server" /></td>
        </tr>
        <tr>
            <td style="text-align: right; padding: 5px;">Password:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtPassword" CssClass="txtMedInput" TextMode="Password" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: left;">
                <asp:Button Text="Add" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        <asp:GridView ID="grdRecruiters" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdRecruiters_RowDataBound" CssClass="tableOutline">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label CssClass="" ID="txtFirstName" runat="server" Text='<% #Bind("firstName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="MI">
                    <ItemTemplate>
                        <asp:Label ID="lblMiddleInitialId" runat="server" Text='<% #Bind("MiddleInitialId") %>' Visible="false" />
                        <asp:Label ID="lblMiddleInitial" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label ID="txtLastName" runat="server" Text='<% #Bind("lastName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Suffix">
                    <ItemTemplate>
                        <asp:Label ID="lblSuffixId" runat="server" Text='<% #Bind("SuffixId") %>' Visible="false" />
                        <asp:Label ID="lblSuffix" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label ID="txtCompany" runat="server" Text='<% #Bind("company") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="txtEmail" runat="server" Text='<% #Bind("Email") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="URL">
                    <ItemTemplate>
                        <asp:Label ID="txtURL" runat="server" Text='<% #Bind("URL") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </table>

</asp:Content>

