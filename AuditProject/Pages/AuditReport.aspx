<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditReport.aspx.cs" Inherits="Pages_AuditReport" %>
--%>

<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="AuditReport.aspx.cs" Inherits="Pages_AuditReport_Report"   %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

    <div>
        <asp:Button ID="btnAnnulReport" runat="server" Text="വാര്‍ഷിക റിപ്പോര്‍ട്ട്‌" CssClass="btn btn-secondary"  OnClick="btnReport_Click" Width="210px"  />
        <asp:Button id="BtnSurPlus" onclick="BtnSurPlus_Click" runat="server" CssClass="btn btn-secondary" Width="147px"  Text="മിച്ചഫണ്ട്"></asp:Button>
    </div></div></div></div>
  </asp:Content>
