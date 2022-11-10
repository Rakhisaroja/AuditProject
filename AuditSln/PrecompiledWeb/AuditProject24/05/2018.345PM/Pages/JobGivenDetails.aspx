<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_JobGivenDetails, App_Web_pchds3r-" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >II.കേന്ദ്രഫണ്ട് വിനിയോഗം
                    </div>
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-titlen">തൊഴില്‍ നല്‍കല്‍ പൊതുവിവരങ്ങള്‍</strong>
                                
                            </div>
                            
                            
                          <%--   <div class="card-body">--%>
                    <%--  <div class="table table-striped table-bordered">--%>
                        <table  >
                         <tr><td align="center" >
                            <asp:Panel  ID="pnlRej" runat="server"  BackColor="#EFF3FB">
                            <table> <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                         <tr >
                          <td colspan="2" style="color:Maroon; background-color: #9999cc;"  align="center">
                                    <asp:Label ID="Label7"   runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                                 <td style="width: 400px; color:Maroon;background-color: #9999cc; "  >
                                    <asp:Label ID="Label8"  runat="server" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                         </tr> <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                              <tr>
                            
                             
                                 <td style="width: 400px; height: 21px; " align="left" >
                                    <asp:Label ID="Label5"  runat="server" Text="രജിസ്റ്റര്‍ ചെയ്ത തൊഴിലാളികളുടെ എണ്ണം : " Width="100%" ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtRegempCnt"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox><br />
                                </td>
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtRegEmpCntAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr> 
                              <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px;" >
                                    <asp:Label ID="Label1"  runat="server" Text="തൊഴില്‍ ലഭിച്ച തൊഴിലാളികളുടെ എണ്ണം : " ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtEpGetJobCnt"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox>
                                </td>
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtEpGetJobCntAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px;" >
                                    <asp:Label ID="Label2"  runat="server" Text="ആകെ സൃഷ്ടിച്ച തൊഴില്‍ ദിനങ്ങള്‍ : " ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtTotlJobDays"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox>
                                </td>
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtTotlJobDaysAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px;" >
                                    <asp:Label ID="Label3"  runat="server" Text="തൊഴില്‍ കൂലി ഇനത്തില്‍ ചെലവഴിച്ച തുക : " ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtWageAmt"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox>
                                </td>
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtWageAmtAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px;" >
                                    <asp:Label ID="Label4"  runat="server" Text="നിര്‍മാണ സാമഗ്രഹികള്‍ക്കുളള ചെലവ് : " ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtAmtForMaterialCost"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox>
                                </td>
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtAmtForMaterialCostAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px;" >
                                    <asp:Label ID="Label6"  runat="server" Text="ഭരണ നിര്‍വ്വഹണ ചെലവു്. : " ></asp:Label>
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                     <asp:TextBox ID="txtRuleCost"  runat="server" TabIndex="1" ReadOnly="True" ></asp:TextBox>
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtRuleCostAudt"  runat="server" TabIndex="1" ></asp:TextBox>
                                </td>
                              
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr> <td style="width: 200px; height: 21px;" colspan="3" align="center">
                               <asp:Button
                                    ID="btnsave"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td></tr> 
                              </table>
                                </asp:Panel>
                             
                             
                             
                              </td></tr>
                              </table>
                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         </div>
                </div>   
               </div> 
             </div>  
           </div>   
</asp:Content>

