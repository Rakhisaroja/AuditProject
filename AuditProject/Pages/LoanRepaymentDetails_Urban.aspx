<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="LoanRepaymentDetails_Urban.aspx.cs" Inherits="Pages_LoanRepaymentDetails_Urban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
            
                        <div class="card">
                           <div class="card-header">
                                <strong class="card-titlen">   IX. വായ്പ്പ തിരിച്ചടവ്</strong>
                                
                            </div>
                           
                            <div class="card-body">
                            
                             <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW  DETAILS" Width="150px" CssClass="btn btn-secondary btn-sm"></asp:Button>
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
                        <table style="width: 936px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             <span lang="ML"
                                 style="font-size: 12pt;
                                 color: #000000;
                                 font-family: 'Meera','sans-serif';
                                 mso-fareast-font-family: Calibri;
                                 mso-ansi-language: EN-GB;
                                 mso-fareast-language: EN-GB;
                                 mso-bidi-language: ML">
                                 
                                
                                     വായ്പ്പ തിരിച്ചടവിന്‍റെ വിവരങ്ങള്‍</span></th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="ഇനം" Font-Bold="True" />
                            </td>
                        <td style="width: 381px; height: 28px;" align="left"> &nbsp;<asp:TextBox ID="txtType" runat="server" Text= "" Width="176px" /></td>
                        </tr>
                        
                        
                      <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>വർഷാരംഭത്തില്‍
തിരികെ ലഭിക്കാനുണ്ടായിരുന്ന തുക</strong></td>
                       <td><asp:TextBox ID="txtOB" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/></td>
                        </tr>
                        
                     
                       
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>തന്‍വര്‍ഷം നല്‍കിയ തുക </strong></td>
                       <td><asp:TextBox ID="txtrecurrentpayment" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
                      </td>
                       
                        </tr>
                         
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> ലഭിച്ചത് </strong></td>
                       <td><asp:TextBox ID="Txtcurrentreceipt" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/></td>
                        </tr>
                        
                          <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> വര്‍ഷാവസാനം തിരികെ ലഭിക്കുവാന്‍ ബാക്കിയുള്ളത് </strong></td>
                       <td><asp:TextBox ID="TxtBal" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/></td>
                        </tr>
                        
                          <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> Remarks </strong></td>
                       <td><asp:TextBox ID="TxtRem" runat="server" Text= "" Width="176px" /></td>
                        </tr>
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" /></td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        
                        
                            <div class="card-body"> 
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptLoanRepayment" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                  ഇനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                വർഷാരംഭത്തില്‍
തിരികെ ലഭിക്കാനുണ്ടായിരുന്ന തുക

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                   തന്‍വര്‍ഷം നല്‍കിയ തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ലഭിച്ചത്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                    വര്‍ഷാവസാനം തിരികെ ലഭിക്കുവാന്‍ ബാക്കിയുള്ളത്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   Remarks
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
                 ഇനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  വര്ഷികാരംഭത്തില്‍
തിരികെ ലഭിക്കാനുണ്ടായിരുന്ന തുക

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                    തന്‍വര്‍ഷം നല്‍കിയ തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ലഭിച്ചത്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   വര്‍ഷാവസാനം തിരികെ ലഭിക്കുവാന്‍ ബാക്കിയുള്ളത്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   Remarks
                </th>
                  
            </tr>
             
    </HeaderTemplate>
      <%-- <ItemTemplate>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />
            </td>
            
            </ItemTemplate>--%>
    <ItemTemplate>
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            <td>
            
         <%--   <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="lblincometype" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />--%>
            <p>
            <asp:Label ID="lblccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
            <td><asp:TextBox ID= "numob" runat="server" Text='<%# Eval("numob") %>'  CssClass="floatnumbers" ReadOnly="true" oncopy="return false;" onpaste="return false;"/></td>
             <td>
                <asp:TextBox ID= "numrecurrentpayment" runat="server" Text='<%# Eval("numrecurrentpayment") %>'  CssClass="floatnumbers" ReadOnly="true" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "numcurrentreceipt" runat="server" Text='<%# Eval("numcurrentreceipt") %>'  CssClass="floatnumbers" ReadOnly="true" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
               <asp:TextBox ID= "numbalance" runat="server" Text='<%# Eval("numbalance") %>'  CssClass="floatnumbers" ReadOnly="true" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
                <asp:TextBox ID= "chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' ReadOnly="true" />
            </td>
            <td>
            
           <%-- <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />--%>
            <p>
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="Label5" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
             <td>
                 <asp:TextBox ID= "numauditedob" runat="server"  Text='<%# Eval("numauditedob") %>'  CssClass="floatnumbers" ReadOnly="true" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
                <asp:TextBox ID= "numauditedrecurrentpayment" runat="server"  Text='<%# Eval("numauditedrecurrentpayment") %>' ReadOnly="true"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
                 <td>
                  <asp:TextBox ID= "numauditedcurrentreceipt" runat="server"  Text='<%# Eval("numauditedcurrentreceipt") %>'  ReadOnly="true" CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
                 <td>
                <asp:TextBox ID= "numauditedbalance" runat="server"  Text='<%# Eval("numauditedbalance") %>' ReadOnly="true"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
                 <td>
               <asp:TextBox ID= "chvauditedremarks" runat="server"   Text='<%# Eval("chvauditedremarks") %>' ReadOnly="true"/>
            </td>
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        
                        
  <%--   <FooterTemplate></table></FooterTemplate>  --%>
  
    <FooterTemplate>
 <tr>  <td style="font-weight:bold" colspan="2" >Total
        </td> 
        <td  >
            <asp:Label ID="totnumob"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumob") %>' />
        </td>   <td  >
            <asp:Label ID="totnumrecurrentpayment"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumrecurrentpayment") %>' />
        </td>
         <td  >
            <asp:Label ID="totnumcurrentreceipt"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumcurrentreceipt") %>' />
        </td>
       
         <td  >
            <asp:Label ID="totnumbalance"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumbalance") %>' />
        </td> <td></td>  <td></td>  <td  >
            <asp:Label ID="totnumauditedob"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumauditedob") %>' />
        </td>
         <td  >
            <asp:Label ID="totnumauditedrecurrentpayment"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumauditedrecurrentpayment") %>' />
        </td>
         <td  >
            <asp:Label ID="totnumauditedcurrentreceipt"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumauditedcurrentreceipt") %>' />
        </td>
         <td  >
            <asp:Label ID="totnumauditedbalance"  Font-Bold="True"  runat="server" Text='<%# Eval("totnumauditedbalance") %>' />
        </td></tr>
    </table>
</FooterTemplate>    



</asp:Repeater>


</div></div>

</div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
                               </td></tr> 
                              </table>
                            </div>
                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
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

