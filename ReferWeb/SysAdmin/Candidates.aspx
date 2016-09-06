<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="Candidates.aspx.cs" Inherits="SysAdmin_Candidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="hdnUserType" runat="server" Value="2" />
    <asp:HiddenField ID="hdnNumberTypeId" runat="server" Value="1" />
    <table class="tableOutline" style="text-align: left; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td>Add Candidate</td>
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
            <td style="text-align: right; padding: 5px;">Mobile Number:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtPhone" CssClass="txtMedInput" runat="server" /></td>
        </tr>

        <tr>
            <td style="text-align: right; padding: 5px;">Job Title:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtJobTitle" CssClass="txtMedInput" runat="server" /></td>
        </tr>

        <tr>
            <td style="text-align: right; padding: 5px;">Experience:</td>
            <td style="text-align: left;">
                <asp:DropDownList ID="ddlExperience" runat="server" />
            </td>
        </tr>

        <tr>
            <td style="text-align: right; padding: 5px; vertical-align:top;">Preferred Work Location:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtLocation" CssClass="txtMedInput" TextMode="MultiLine" Rows="6" Columns="40" runat="server" /></td>
        </tr>

        <tr>
            <td style="text-align: right; padding: 5px; vertical-align:top;">Additional Comments:</td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtComments" CssClass="txtMedInput" TextMode="MultiLine" Rows="6" Columns="40" runat="server" /></td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="text-align: left;">
                <asp:Button Text="Add Candidate" runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        <asp:GridView ID="grdCandidates" runat="server" AutoGenerateColumns="false" CssClass="tableOutline" OnRowDataBound="grdCandidates_RowDataBound" OnRowCancelingEdit="grdCandidates_RowCancelingEdit" OnRowEditing="grdCandidates_RowEditing" OnRowUpdating="grdCandidates_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label ID="lblUserId" runat="server" Visible="false" Text='<% #Bind("UserId") %>' />
                        <asp:Label CssClass="" ID="txtFirstName" runat="server" Text='<% #Bind("firstName") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" runat="server" Text='<% #Bind("firstName") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="MI">
                    <ItemTemplate>
                        <asp:Label ID="lblMiddleInitialId" runat="server" Text='<% #Bind("MiddleInitialId") %>' Visible="false" />
                        <asp:Label ID="lblMiddleInitial" runat="server" />
                        <asp:DropDownList ID="ddlMiddleInitial" runat="server" Visible="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblMiddleInitialId" runat="server" Text='<% #Bind("MiddleInitialId") %>' Visible="false" />
                        <asp:DropDownList ID="ddlMiddleInitial" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label ID="txtLastName" runat="server" Text='<% #Bind("lastName") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text='<% #Bind("LastName") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Suffix">
                    <ItemTemplate>
                        <asp:Label ID="lblSuffixId" runat="server" Text='<% #Bind("SuffixId") %>' Visible="false" />
                        <asp:Label ID="lblSuffix" runat="server" />
                        <asp:DropDownList ID="ddlSuffix" runat="server" Visible="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblSuffixId" runat="server" Text='<% #Bind("SuffixId") %>' Visible="false" />
                        <asp:DropDownList ID="ddlSuffix" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="txtEmail" runat="server" Text='<% #Bind("Email") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<% #Bind("Email") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Job Title">
                    <ItemTemplate>
                        <asp:Label ID="txtJobTitle" runat="server" Text='<% #Bind("JobTitle") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtJobTitle" runat="server" Text='<% #Bind("JobTitle") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:templatefield>
                    <itemtemplate>
                        <asp:LinkButton 
                            ID="lnkSendCAN" 
                            runat="server" 
                            Text="Tickle" 
                            CommandArgument='<% #Bind("UserID") %>' 
                            CommandName="Tickle" />
                        |
                        <asp:LinkButton 
                            ID="lnkRefer" 
                            runat="server" 
                            Text="Refer" 
                            CommandArgument='<% #Bind("UserID") %>' 
                            CommandName="Refer" />
                    </itemtemplate>
                </asp:templatefield>

                <asp:CommandField  ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>

