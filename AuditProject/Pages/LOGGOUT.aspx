
<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="LOGGOUT.aspx.cs" Inherits="LOGGOUT"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form id="form1" runat="server">
    <div>
  <table width="60%" border="1">
     <tr valign="top">
        <td style="height:23px;background-color:ThreeDDarkShadow; text-align: center;">
        <asp:Label runat="server" ID="lbllog" Text="Log out" Font-Bold="True" Font-Names="Trebuchet MS" ForeColor="White"></asp:Label>
        </td>
     </tr>
     <tr>
        <td style="height:520px" valign="middle"><asp:Label runat="server" ID="lblmsg" Text="You have been Successfully Logged out" Font-Bold="True" Font-Names="Trebuchet MS" ForeColor="Brown"></asp:Label><br />
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Medium" OnClick="LinkButton1_Click" >click here to login  again </asp:LinkButton><br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lmsg" runat="server" Text="Label"></asp:Label><br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
         </td>
     </tr>
     <tr>
     <%--<td style="height:23px; text-align: center; background-color:Gray;" class="copy">Copyright © 2000-2013<a href="http://www.infokerala.org" target="_blank" class="login"><img src="ikmemblem.gif"  border="0" height="12" style="width: 13px" />Information Kerala Mission,Thiruvananthapuram</a></td>--%>
     </tr>
    </table>
        </div>
    </form>
   <%-- <form id="form1" runat="server">
    </form>--%>
</asp:Content>

