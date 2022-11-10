<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="ServiceExpense.aspx.cs" Inherits="Pages_ServiceExpense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവിനം
                                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">II. SERVICE EXPENSE</strong>
                        </div>
                         <div class="card-header">
                            <strong class="card-titlen">a) Civic expenditure</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvGenralAdminService" runat="server" OnItemCommand="grvGenralAdminService_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
      <%--  <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                  Sl.No
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍  
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width:400px;" align="center">
                    HEAD
                </th>
                <th scope="col" style="width: 200px"align="center">
                  Amount
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px"  align="center">
                   HEAD
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 200px"  align="center">
                   Amount
                </th>
                                
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
              <td><asp:Label ID="mainexpendituretype" runat="server" Text='<%# Eval("intmainexpendituretype") %>' Visible="false" />
            <asp:Label ID="subexpendituretype" runat="server" Text='<%# Eval("intsubexpendituretype") %>' Visible="false" />
           
           <asp:TextBox ID="txtHead" runat="server" ReadOnly="true" Width="400px"   Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID="txtexpamounttotal"   CssClass="floatnumbers" runat="server" Text='<%# Eval("numexpamounttotal") %>' /></td>
            <td><asp:TextBox ID="txtAuditHead" Width="400px" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
             
            </td> 
             <td>
                <asp:TextBox ID="txtauditedexpamounttotal" CssClass="floatnumbers" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />
            </td>
           
           </tr></ItemTemplate>
<%--    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>--%>
<FooterTemplate>
        
        <tr><td style="font-weight:bold">Total</td><%--<td></td >--%><td style="font-weight:bold"> 
        <asp:Label ID="amounttotal" runat="server" Text='<%# Eval("amounttotal") %>' />
       </td>
        <td></td>
        <td style="font-weight:bold">
        <asp:Label ID="Auditamounttotal" runat="server" Text='<%# Eval("Auditamounttotal") %>' />       
        </td></tr>
        </table>
        </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="center" colspan="3">
                               <asp:Button
                                    ID="btnSave"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
    <asp:Button
                                    ID="btnNext"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnNext_Click"
                                    TabIndex="10"
                                    Text="NEXT" /></td></tr> 
                              </table>
                            </div>

                </div>
            </div><!-- .animated -->
        </div>
        
          <script type="text/javascript">
    
function isNumberKey(evt)
    {
        if(document.activeElement.className == "txtBoxNumeric"||document.activeElement.className == "txtBoxNumericPhone")
            {
                 var charCode = (evt.which) ? evt.which : event.keyCode
                 if ((charCode < 48 || charCode > 57) && charCode != 8)
                 return false;
                 else
                 return true;
            }
            if(document.activeElement.className == "txtBoxNumericFloat")
            {
                 var charCode = (evt.which) ? evt.which : event.keyCode
                 if ((charCode != 46) && (charCode < 48 || charCode > 57))
                 return false;
                 else
                 return true;
            }
    }
    </script>
        
</asp:Content>

