<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="BankClosed.aspx.cs" Inherits="Pages_BankClosed"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചിലവിനം
                </div>
                    <div class="card">
                    <div class="card-header">
                            <strong class="card-titlen">ഇ ) പൊതുസുരക്ഷയും ആരോഗ്യവും- പഞ്ചായത്തിന്റെ ഇതരസേവനങ്ങളുടെ വിവരങ്ങള്‍</strong>
                        </div>
                        <div class="card-header">
                           <%-- <strong class="card-titlen">11.    31.03.18 ലെ വിവിധ ഇനങ്ങളിലെ നീക്കിയിരിപ്പ് (40(b)പ്രകാരം)</strong>--%>
                            <strong class="card-titlen">11. വിവിധ ഇനങ്ങളിലെ നീക്കിയിരിപ്പ് (40(b)പ്രകാരം)</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                                  <asp:Repeater ID="grvBalanced" runat="server" OnItemCommand="grvBalanced_ItemCommand" OnItemDataBound="grvBalanced_ItemDataBound"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  style="width: 100px"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 400px" align="center">
                  ബാങ്ക്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                    നീക്കിയിരിപ്പ്

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 400px"  align="center">
                     ബാങ്ക്
                </th>
                   <th scope="col" style="width: 200px" align="center">
                   നീക്കിയിരിപ്പ്

                </th>
                  
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="txtSlno" ReadOnly="true" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>
            <td><asp:TextBox ID="txtBank" ReadOnly="true" Width="400px" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Visible="false" Text='<%# Eval("vchaccountheadcode") %>' />
            </td>
            <td><asp:TextBox ID="txtBalancd" ReadOnly="true"  runat="server" Text='<%# Eval("numCBamount") %>' /></td>
             <td>
                <asp:TextBox ID="txtAuditedBank" Width="400px" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            </td>
            <td>
                <asp:TextBox ID="txtAuditedBalancd" runat="server" Text='<%# Eval("numauditedCBamount") %>' />
                
            </td>
           </tr>
 <%--          <tr>  <td>Total
        </td>
        <td>
            <asp:Label ID="obtot" runat="server" Text='<%# Eval("obtot") %>' />
        </td><td></td><td></td> <td>
            <asp:Label ID="auditobtot" runat="server" Text='<%# Eval("auditobtot") %>' />
        </td></tr>--%>
           
           </ItemTemplate>
             <FooterTemplate>
 <tr>  <td style="font-weight:bold">Total
        </td> <td></td>
        <td  >
            <asp:Label ID="CBtot"  Font-Bold="True"  runat="server" Text='<%# Eval("CBtot") %>' />
        </td><td></td>  <td  >
            <asp:Label ID="auditCBtot"  Font-Bold="True"  runat="server" Text='<%# Eval("auditCBtot") %>' />
        </td></tr>
    </table>
</FooterTemplate>    
     


</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    <asp:Label ID="lblCBAmt" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="lblCBAuditAmt" runat="server" Text="Label" Visible="False"></asp:Label></div> <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>&nbsp;
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     </td></tr></table></div>
<%--<div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>--%>

                </div>
            </div><!-- .animated -->
        </div>
</asp:Content>

