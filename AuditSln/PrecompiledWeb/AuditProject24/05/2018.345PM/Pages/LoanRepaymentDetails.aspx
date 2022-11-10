<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_LoanRepaymentDetails, App_Web_yasbjxhy" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           IX. വായ്പ്പ തിരിച്ചടവ്</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml
                        namespace=""
                        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
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
            <td><asp:TextBox ID= "numob" runat="server" Text='<%# Eval("numob") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "numrecurrentpayment" runat="server" Text='<%# Eval("numrecurrentpayment") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "numcurrentreceipt" runat="server" Text='<%# Eval("numcurrentreceipt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
               <asp:TextBox ID= "numbalance" runat="server" Text='<%# Eval("numbalance") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
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
                 <asp:TextBox ID= "numauditedob" runat="server"  Text='<%# Eval("numauditedob") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "numauditedrecurrentpayment" runat="server"  Text='<%# Eval("numauditedrecurrentpayment") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
                  <asp:TextBox ID= "numauditedcurrentreceipt" runat="server"  Text='<%# Eval("numauditedcurrentreceipt") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
                <asp:TextBox ID= "numauditedbalance" runat="server"  Text='<%# Eval("numauditedbalance") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
               <asp:TextBox ID= "chvauditedremarks" runat="server"   Text='<%# Eval("chvauditedremarks") %>'/>
            </td>
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
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

