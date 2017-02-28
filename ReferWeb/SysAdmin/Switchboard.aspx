<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SystemAdminMaster.master" AutoEventWireup="true" CodeFile="Switchboard.aspx.cs" Inherits="SysAdmin_Switchboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <table style="text-align: left; border-collapse: collapse; width:920px;">
        <tr>
            <td class="pageTitle"><asp:LinkButton ID="lnkAdmin" runat="server" Text="Admin" PostBackUrl="~/SysAdmin/Switchboard.aspx" /></td>
        </tr>
    </table>--%>

    <div style="height: 10px;">&nbsp;</div>

    <table class="tableOutline" style="text-align: center; border-collapse: collapse; width: 920px; margin: 5px;">
        
        <tr>
            <td style="text-align: left; padding:5px; width:920px;">
                <asp:LinkButton ID="lnkRecruiterAdmin" runat="server" Text="Recruiter Administration" PostBackUrl="~/SysAdmin/Recruiters.aspx"/>
            </td>
        </tr>
        
        <tr>
            <td style="text-align: left; padding:5px; width:920px;">
                <asp:LinkButton ID="lnkCandidateAdmin" runat="server" Text="Candidate Administration" PostBackUrl="~/SysAdmin/Candidates.aspx" />
            </td>
        </tr>
        
        <tr>
            <td style="text-align: left; padding:5px; width:920px;">
                <asp:LinkButton ID="lnkOpportunity" runat="server" Text="Opportunity Administration" PostBackUrl="~/SysAdmin/Opportunity.aspx"/>
            </td>
        </tr>

    </table>
</asp:Content>

