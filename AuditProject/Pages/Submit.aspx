<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true"
    CodeFile="Submit.aspx.cs" Inherits="Submit"  %>

<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <b></b>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            Remarks:
                            <asp:TextBox ID="txtRemarks" TextMode="multiLine" runat="server" CssClass="form-control" Width="872px"></asp:TextBox>
                            <div class="row">
                       <table>
                           <tr>
                               <td style="width: 100px">
                               </td>
                               <td style="width: 100px">
                               </td>
                               <td colspan="2" style="width: 126px">
                               </td>
                           </tr>
                           <tr>
                               <td style="width: 100px">
                               </td>
                               <td style="width:100px"></td>
                               <td colspan="2"><asp:Label ID="lblerr" runat="server" ForeColor="Red" Font-Bold="True" Width="100%"></asp:Label>
                               </td>
                                
                           </tr>
                           <tr>
                               <td style="width: 100px">
                               </td>
                               <td style="width: 100px">
                               </td>
                               <td style="width: 126px">
                               </td>
                               <td>
                               </td>
                           </tr>
                       <tr>
                           <td style="width: 100px">
                           </td>
                           <td style="width:100px"></td><td style="width: 126px"><asp:Button ID="btnReturn" Width="120px"  OnClientClick="return confirmdelete(); " runat="server"  Text="Return TO LB"   CssClass="btn btn-primary pull-right" OnClick="btnReturn_Click" />&nbsp;</td>
                       <td><asp:Button ID="btnSubmit" Width="120px" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="btnSubmit_Click" />&nbsp;
                       
                       <%--<asp:Button ID="btnConsolidateReport" Width="120px" runat="server" Text="Consolidation" CssClass="btn btn-primary pull-right" OnClick="btnConsolidateReport_Click"   />--%>
                       </td></tr></table>
                       <%--  <div class="col-sm-11" style="left: 0px; width: 71%; top: 0px">
                         <asp:Label ID="lblerr" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>

                        <asp:Button ID="btnReturn" Width="120px"  OnClientClick="return confirmdelete(); " runat="server"  Text="Return TO LB"   CssClass="btn btn-primary pull-right" OnClick="btnReturn_Click" />
                             </div>
                     <div class="col-sm-1" style="left: 0px; width: 70%; top: 0px">
                            <asp:Button ID="btnSubmit" Width="120px" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="btnSubmit_Click" />
                         &nbsp;
                            </div>--%>
                       
                        
                        </div>
                        </div>
                        </div></div>
                              <div class="form-group">
                    
                    </div>
                </div>
            </div>
        </div>
<script language="javascript" type="text/javascript" >
  function confirmdelete()
            {
                if (confirm("Are you sure to Return all forms?!!")== true)
                 return true;
                   else
                return false;
            }
            
            
            </script>
</asp:Content>
