<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="RecruiterList.aspx.cs" Inherits="SysAdmin_RecruiterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnUserType" runat="server" Value="3" />
    <table style="text-align: left; border-collapse: collapse; width:920px;">
        <tr>
            <td class="pageTitle"><asp:LinkButton ID="lnkAdmin" runat="server" Text="Admin" PostBackUrl="~/SysAdmin/Switchboard.aspx" /></td>
        </tr>
    </table>

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: left; border-collapse: collapse; width: 920px; margin: 5px;">
        <tr>
            <td>Select Recruiters</td>
        </tr>
    </table>

    <div style="height: 10px;">&nbsp;</div>

    <table style="border-collapse: collapse;">
        <tr>
            <td>
                <asp:GridView
                    ID="grdRecruiters"
                    runat="server"
                    AutoGenerateColumns="false"
                    OnRowDataBound="grdRecruiters_RowDataBound"
                    CssClass="tableOutline">
                    <Columns>

                        <asp:TemplateField HeaderText="Select Recruiter">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRecruiter" runat="server" />
                                <asp:Label ID="lblRecruiterId" runat="server" Visible="false" Text='<% #Bind("UserId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label CssClass="" ID="txtFirstName" runat="server" Text='<% #Bind("firstName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MI">
                            <ItemTemplate>
                                <asp:Label ID="lblMiddleInitialId" runat="server" Text='<% #Bind("MiddleInitialId")%>' Visible="false" />
                                <asp:Label ID="lblMiddleInitial" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="txtLastName" runat="server" Text='<% #Bind("lastName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Suffix">
                            <ItemTemplate>
                                <asp:Label ID="lblSuffixId" runat="server" Text='<% #Bind("SuffixId")%>' Visible="false" />
                                <asp:Label ID="lblSuffix" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label ID="txtCompany" runat="server" Text='<% #Bind("company")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="txtEmail" runat="server" Text='<% #Bind("Email")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;">
                <asp:Button
                    ID="btnReferCandidate"
                    runat="server"
                    Text="Refer Candidate" OnClick="btnReferCandidate_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

