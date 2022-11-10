<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="MNREGSRegistration.aspx.cs" Inherits="Pages_MNREGSRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
           
                        <div class="card">
                         <div class="card-header">
                                <strong class="card-titlen">8.ദേശീയ ഗ്രാമീണ തൊഴിലുറപ്പ് പദ്ധതി - രജിസ്ട്രേഷന്‍ / തൊഴില്‍കാര്‍ഡ് നല്‍കല്‍ , വേതന വിതരണം  </strong>
                                
                            </div>
                               <div class="card-body"> 
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptMnregs" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 തന്‍വര്‍ഷം തൊഴില്‍കാര്‍ഡിനുവേണ്ടി ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
               സമയബന്ധിതമായി തൊഴില്‍കാര്‍ഡ് നല്‍കിയവയുടെ എണ്ണം

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                 സമയപരിധിക്ക് ശേഷം നല്‍കിയ തൊഴില്‍കാര്‍ഡുകളുടെ എണ്ണം
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ശേഷിക്കുന്നവ
                </th>
                  <th scope="col" style="width: 200px" align="center">
                 തന്‍വര്‍ഷം തൊഴില്‍കാര്‍ഡിനുവേണ്ടി ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
               സമയബന്ധിതമായി തൊഴില്‍കാര്‍ഡ് നല്‍കിയവയുടെ എണ്ണം

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                 സമയപരിധിക്ക് ശേഷം നല്‍കിയ തൊഴില്‍കാര്‍ഡുകളുടെ എണ്ണം
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ശേഷിക്കുന്നവ
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
           
            <td><asp:TextBox ID= "intjobcardapplication" runat="server" Text='<%# Eval("intjobcardapplication") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/></td>
             <td>
                <asp:TextBox ID= "intjobcardissuedwithintimelimit" runat="server" Text='<%# Eval("intjobcardissuedwithintimelimit") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intjobcardissuedaftertimelimit" runat="server" Text='<%# Eval("intjobcardissuedaftertimelimit") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
             
           <td>
                <asp:TextBox ID= "intjobcardissuedbalance" runat="server" Text='<%# Eval("intjobcardissuedbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            
            <td>
                <asp:TextBox ID= "intjobcardapplicationaud" runat="server" Text='<%# Eval("intjobcardapplicationaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intjobcardissuedwithintimelimitaud" runat="server" Text='<%# Eval("intjobcardissuedwithintimelimitaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intjobcardissuedaftertimelimitaud" runat="server" Text='<%# Eval("intjobcardissuedaftertimelimitaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intjobcardissuedbalanceaud" runat="server" Text='<%# Eval("intjobcardissuedbalanceaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
           
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


</div></div>

</div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
                                     <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" />
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

