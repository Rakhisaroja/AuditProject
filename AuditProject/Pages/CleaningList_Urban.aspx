<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="CleaningList_Urban.aspx.cs" Inherits="Pages_CleaningList_Urban"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                      <%--  <div class="card-header">
                            <strong class="card-titlen">ഡി. ആരോഗ്യം വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി
</strong>
                        </div>--%><div class="card-header">
                            <strong class="card-titlen">ഖര ദ്രവ മാലിന്യ സംസ്കരണo</strong>
                        </div>
                         <div>
                             &nbsp;</div>
                        <%--BKJKBJK --%>
                          <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="true">
                        <table  >
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:80px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             നിലവിലുള്ള വിവരങ്ങള്‍</th>
                            <th align="center" colspan="1">
                                &nbsp;ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍</th>
                         
                        </tr>
                          
                     
                          
                         
                          
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label18" runat="server" Text="ഖര ദ്രവ മാലിന്യ സംസ്കരണ സംവിധാനങ്ങളുടെ വിവരങ്ങള്‍     ( നഗരസഭ / വിട്ടുകിട്ടിയവ / കമ്മ്യൂണിറ്റി തലത്തിലുള്ളവയുടെ എണ്ണം)" Font-Bold="True" Width="661px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                </td>
                                <td align="center" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; height: 30px;">
                                </td>
                                <td align="left" colspan="2" style="height: 30px">
                                    <asp:Label ID="Label5" runat="server" Text="നിലവിലുള്ളത്" Font-Bold="True" Width="158px" Font-Size="19px" Font-Underline="False" /></td>
                                <td align="left" style="width: 381px; height: 30px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍" Font-Bold="True" Width="200px" /></td>
                                <td align="left" id="TD1" runat="server">
                                    <asp:TextBox ID="txtMechPlantexist"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditMechPlantexist" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="ബയോഗ്യാസ് പ്ലാന്റ്" Font-Bold="True" Width="200px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtBiogasexist" runat="server" Text= ""  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditBiogasexist"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" Text="വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ" Font-Bold="True" Width="200px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtVerni" runat="server"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditvermiexist"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                        
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" colspan="2">
                                   <asp:Label ID="Label25" runat="server" Text="പുതുതായി ആരംഭിച്ചവ" Font-Bold="True" Width="186px" Font-Underline="False" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍" Font-Bold="True" Width="200px" /></td>
                                <td align="left" style="height: 29px">
                                    <asp:TextBox ID="txtMechaNew"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 29px">
                                    <asp:TextBox ID="txtAuditMechaNew"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px; height: 29px;">
                                </td>
                                <td align="right" style="height: 29px">
                                    <asp:Label ID="Label6" runat="server" Text="ബയോഗ്യാസ് പ്ലാന്റ്" Font-Bold="True" Width="200px" /></td>
                                <td align="left" style="height: 29px">
                                    <asp:TextBox ID="txtBiogasNew"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5"  oncopy="return false;" onpaste="return false;"/></td>
                                <td align="left" style="width: 381px; height: 29px">
                                    <asp:TextBox ID="txtAuditBiogasNew"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px; height: 62px;">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" Text="വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ" Font-Bold="True" Width="200px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtVemiNew" runat="server"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 62px">
                                    <asp:TextBox ID="txtAuditVemiNew"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="120px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="center" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label26" runat="server" Text="ഹരിത കര്‍മ്മ സേന രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല" Font-Bold="True" Width="416px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:DropDownList ID="ddlGreen" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:DropDownList ID="ddlAuditGreen" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label3" runat="server" Text="(സര്‍ക്കുലര്‍ നം  576/ഡി.സി1/16/തസ്വഭവ , 24.09.16) പ്രകാരം ശുചിത്വത്തിന് ഫണ്ട് രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല" Font-Bold="True" Width="520px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:DropDownList ID="ddlSanitary" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:DropDownList ID="ddlAuditSanitary" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label27" runat="server" Text="പ്രോജക്ടില്‍ ഉള്‍പ്പെടുതാതെ ചെലവഴിച്ച തുകയുടെ വിവരം" Font-Bold="True" Width="488px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtnoplanAmt" runat="server" CssClass="floatnumbers" Text= "" Width="250px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;"/></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditnoplanAmt" CssClass="floatnumbers" runat="server" Text= "" Width="250px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label28" runat="server" Text="ഉപോത്പ്പന്നങ്ങളുടെ വില്‍പനയില്‍ നിന്നും ലഭിച്ചിട്ടുള്ള വരുമാനത്തിന്റെ വിവരം (വെര്‍മി കമ്പോസ്റ്റ്, മണ്ണിര കമ്പോസ്റ്റ് മുതലായവ)" Font-Bold="True" Width="520px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtByProdDet" runat="server" Text= "" Width="250px" TextMode="MultiLine" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditByProdDet" runat="server" Text= "" Width="250px" TextMode="MultiLine" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label1" runat="server" Text="ഉപോത്പനങ്ങളുടെ വില്‍പനയില്‍ നിന്നും ലഭിച്ചിട്ടുള്ള വരുമാനം  (വെര്‍മി കമ്പോസ്റ്റ്, മണ്ണിര കമ്പോസ്റ്റ് മുതലായവ)" Font-Bold="True" Width="520px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtByProdAmt" runat="server" Text= "" CssClass="floatnumbers" Width="250px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditByProdAmt" runat="server" CssClass="floatnumbers" Text= "" Width="250px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                           
                            <%--<tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right" style="width: 362px; height: 28px">
                                </td>
                                <td align="center" style="width: 381px; height: 28px">
                                    <asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                            </tr>
                        
                           <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                        
                            <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                            <tr>
                                <td style="width: 80px">
                                </td>
                            </tr>
                        <tr>
                         <td   style="width:80px">
                            &nbsp;</td>
                        </tr>--%>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        <div class="card-body">  
                       <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center" valign="middle">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click" Visible="false"
         Text="NEXT" Width="63px" /></td></tr></table></div></div></div>

                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
           </div>





</asp:Content>

