<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Pages_Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtdt" runat="server" TabIndex="1" Width="200px" CssClass="txtDate"></asp:TextBox>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () 
        {
            //alert(12);
            $(".txtDate").datepicker
            ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                maxDate:"0D"
            });          
        });
</script>
<link rel="stylesheet" type="text/css" href="../assets/jquery-ui-1.10.0.custom.css" />
<script language="Javascript" type="text/javascript" src="../assets/jquery-1.8.3.js"></script>
<script src="../assets/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
</asp:Content>

