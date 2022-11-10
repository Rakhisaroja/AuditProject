<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="CentralFund_Urban.aspx.cs" Inherits="Pages_CentralFund_Urban"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
    
                        <div class="card">
                           <div class="card-header">
                                <strong class="card-titlen">VI. കേന്ദ്ര ഫണ്ട്</strong>
                                
                            </div>
                            
                           <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW  DETAILS" Width="150px" CssClass="btn btn-secondary btn-sm"></asp:Button> 
                            
                            <div class="card-body">
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
                                 കേന്ദ്ര ഫണ്ട്
                                 <span lang="ML"
                                     style="font-size: 12pt;
                                     font-family: 'Meera','sans-serif';
                                     mso-fareast-font-family: Calibri;
                                     mso-ansi-language: EN-GB;
                                     mso-fareast-language: EN-GB;
                                     mso-bidi-language: ML">
                                     വിവരങ്ങള്‍</span></span></th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>         
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text=" ഫണ്ടിനം" Font-Bold="True" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left">
                            <asp:TextBox ID="txtType" runat="server" Text= "" Width="376px" TextMode="MultiLine" /></td>
                        </tr>
                        
                        
                      <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>മുന്നിരിപ്പ്:</strong></td>
                       <td><asp:TextBox ID="txtOB" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                        
                     
                       
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> വരവ് </strong></td>
                       <td><asp:TextBox ID="txtIncm" runat="server" Text= "" CssClass="floatnumbers" Width="176px" oncopy="return false;" onpaste="return false;" />
                      </td>
                       
                        </tr>
                         
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>ചെലവ് </strong></td>
                       <td><asp:TextBox ID="txtexp" runat="server" Text= "" Width="176px"  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;" /></td>
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
                            
                            
                           <asp:Repeater ID="rptCentralFund" runat="server"    >

                       
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
                 ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
               മുന്നിരിപ്പ് 

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                  വരവ്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ചെലവ്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                     ഫണ്ടിനം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മുന്നിരിപ്പ് 
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
                വരവ്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 ചെലവ്

                </th>
                
                 <th scope="col" style="width: 200px"  align="center">
                 നീക്കം ചെയ്യുക 

                </th>
               <%-- <th></th>--%>
                   
                  
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
               <asp:Label ID="chvdescriptionmal" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <p>
           
            <asp:Label ID="lblccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' Visible="false" />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
            <td><asp:TextBox ID= "numprevcb" runat="server" Text='<%# Eval("numprevcb") %>'  CssClass="floatnumbers" ReadOnly="true"  /></td>
             <td>
                <asp:TextBox ID= "numincome" runat="server" Text='<%# Eval("numincome") %>'  CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "numexpenditure" runat="server" Text='<%# Eval("numexpenditure") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
             
            <td>
            
           <%-- <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />--%>
          
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("vchaccounthead") %>' />
           
          
            </td>
             <td>
                 <asp:TextBox ID= "numauditedprevcb" runat="server"  Text='<%# Eval("numauditedprevcb") %>'   CssClass="floatnumbers" ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "numauditedincome" runat="server"  Text='<%# Eval("numauditedincome") %>'   CssClass="floatnumbers" ReadOnly="true"  />
                 <td>
                  <asp:TextBox ID= "numauditedexpenditure" runat="server"  Text='<%# Eval("numauditedexpenditure") %>'   CssClass="floatnumbers" ReadOnly="true" />
                
            
            </td>
            
            <td>
                 <asp:ImageButton id="btndeleteCh" onclick="btnDeleteSr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
                
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        
     <FooterTemplate></table></FooterTemplate>          

</asp:Repeater>


</div></div>
</div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center">
                               <asp:Button
                                    ID="btnSave"
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
           </div></div>

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

