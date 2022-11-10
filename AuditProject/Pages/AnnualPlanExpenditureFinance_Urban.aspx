<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="AnnualPlanExpenditureFinance_Urban.aspx.cs" Inherits="Pages_AnnualPlanExpenditureFinance_Urban"  %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanelFinance" runat="server" UpdateMode="always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">III. വാര്‍ഷിക പദ്ധതി ചെലവുകള്‍</strong>
                        </div>
                          <div class="card-header">
                            <strong class="card-titlen">എ) ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                      
                        <table> 
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <td colspan="2" align="center" ><asp:Label ID="label34" runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍" Font-Bold="True" />
                         </td>
                          <td style="width: 586px"><asp:Label ID="labelhg1" runat="server" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍" Font-Bold="True" /></td>
                        </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" style="width: 490px; height: 28px">
                                </td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                                <td align="left" style="width: 586px; height: 28px">
                                </td>
                            </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 490px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. ചെയര്‍മാന്‍(പേര് വിവരം)" Font-Bold="True" /></td>
                        <td style="width: 381px; height: 28px;" align="left"> <asp:TextBox ID="txtChairman" runat="server" Text= "" Width="350px" /></td>
                        <td align="left"> <asp:TextBox ID="txtChairmanmalAudit" runat="server" Text="" Width="350px" /></td>
                        </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" style="width: 490px; height: 28px">
                                </td>
                                <td align="left" colspan="2">
                                </td>
                            </tr>
                         <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 490px; height: 28px;" align="left"> <asp:Label ID="label3" runat="server" Text="അംഗങ്ങളുടെ എണ്ണം" Font-Bold="True" /></td>
                        <td style="width: 381px; height: 28px;" align="left" colspan="2"> <asp:TextBox ID="txtnoofMember" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" OnTextChanged="txtnoofMember_TextChanged" AutoPostBack="True" />
                            <asp:Button ID="btnMember" runat="server" OnClick="btnMember_Click" Text="Show" Width="48px" /></td>
                        
                        </tr>
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td align="left" colspan="3"> 
                           <asp:Label ID="lblnoofMember" runat="server" Text="2. അംഗങ്ങള്‍(പേര് വിവരം)" Visible="False" Font-Bold="True" /> </td>
                       
                        </tr>
                        <tr><td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="3">
                        <asp:Repeater ID="grvMembers" runat="server" OnItemCommand="grvMembers_ItemCommand" Visible="False"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  style="width:100px"  align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center; width:400px"  align="center"   >
                    അംഗത്തിന്റെ പേര്
                </th>
                  <th scope="col"  style="text-align:center; width:400px"  align="center"   >
                    അംഗത്തിന്റെ പേര് (ഓഡിറ്റില്‍ കണ്ടെത്തിയത്)
                </th>
                    <th scope="col"  style="text-align:center; width:80px"  align="center"   >
                    
                </th>
                          
            </tr>
            
     
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:100px">
                <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' /> 
                 <asp:Label ID="intslno"  Visible="false" runat="server" Text='<%# Eval("intslno") %>' /> </td>
            <td style="width:400px"> 
            <asp:TextBox ID="chvnameofmembermal" runat="server" Text='<%# Eval("chvnameofmembermal") %>' />
            </td >
            <td style="width:400px"><asp:TextBox ID="chvAuditnameofmembermal" runat="server" Text='<%# Eval("chvAuditnameofmembermal") %>' />
            <asp:Label ID="numstandingcommitteeid"  Visible="false" runat="server" Text='<%# Eval("numstandingcommitteeid") %>' />
              <asp:Label ID="intstandingcommitteetype" Visible="false"  runat="server" Text='<%# Eval("intstandingcommitteetype") %>' />
          <%--   <asp:Label ID="intslno" runat="server" Text='<%# Eval("intslno") %>' />--%></td>
         <td><asp:Button ID="btnDeleteMem" runat="server" Text="X" ForeColor="Red" Width="25px" Height="25px" OnClick="btnDeleteMem_Click" /></td>
          
             
           </tr></ItemTemplate>
           <FooterTemplate></table></FooterTemplate>
                        


</asp:Repeater>
                        </td>
                        </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td colspan="3" align="center"><asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinance">
                                    <ProgressTemplate>
                                        <div id="Div2">
                                            <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 2px; top: 9px;" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                            </tr>
                            <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td align="left"> <asp:Label ID="label5" runat="server" Text="കൂടിയ യോഗങ്ങളുടെ എണ്ണം" Font-Bold="True" Width="224px" /></td>
                        <td align="left" colspan="2"> <asp:TextBox ID="txtnoofMeeting" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" AutoPostBack="True" OnTextChanged="txtnoofMeeting_TextChanged" />
                            <asp:Button ID="btnMeeting" runat="server" OnClick="btnMeeting_Click" Text="Show"
                                Width="48px" /></td>
                        
                        </tr>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td align="left" colspan="3"> 
                            <asp:Label ID="lblnoofMeetingDate" runat="server" Text="3. കൂടിയ യോഗങ്ങളുടെ തീയതി" Font-Bold="True" Visible="False" /> </td>
                       
                        </tr>
                        <tr>
                         <td   style="width:50px; height: 215px;">
                            &nbsp;</td>
                        <td colspan="3" style="width:1000px; height: 215px;">
                        <asp:Repeater ID="grvMeetingDate" runat="server" OnItemCommand="grvMeetingDate_ItemCommand"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  style="width:100px"  align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center; width:400px"  align="center"   >
                    തീയതി
                </th>
                  <th scope="col"  style="text-align:center; width:400px"  align="center"   >
                    തീയതി (ഓഡിറ്റില്‍ കണ്ടെത്തിയത്)
                </th>
                          <th scope="col"  style="text-align:center; width:80px"  align="center"   >
                    
                </th>       
            </tr>
            
     
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:100px">
                <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' /> </td>
            <td style="width:400px"> 
            <asp:Label ID="intMeetingNo" runat="server" Visible="false" Text='<%# Eval("intMeetingNo") %>' />
            <asp:TextBox ID="dtdate" runat="server" CssClass="txtDate" Text='<%# Eval("dtdate") %>' />
            </td >
            <td style="width:400px"><asp:TextBox ID="dtAuditDate" runat="server" CssClass="txtDate" Text='<%# Eval("dtAuditDate") %>' />
             <asp:Label ID="intAuditMeetingNo" runat="server"  Visible="false"  Text='<%# Eval("intAuditMeetingNo") %>' />
              <asp:Label ID="numstandingcommitteeid" runat="server"  Visible="false"  Text='<%# Eval("numstandingcommitteeid") %>' />
              <asp:Label ID="intstandingcommitteetype" runat="server" Visible="false"  Text='<%# Eval("intstandingcommitteetype") %>' /></td>
             <td>
             <asp:Button ID="btnDeleteMeeting" runat="server" Text="X" ForeColor="Red" Width="25px" Height="25px" OnClick="btnDeleteMeeting_Click" />
            <%--<asp:ImageButton id="btndeleteCh" onclick="btnDeleteSr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> --%>
                
             </td>
          
           </tr></ItemTemplate>                       

<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
                        </td>
                        </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td colspan="3" align="center"><asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinance">
                                    <ProgressTemplate>
                                        <div id="Div1">
                                            <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 9px; top: 10px;" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                    &nbsp;</td>
                            </tr>
                        
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label7" runat="server" Text="4. റവന്യൂ വരവുകള്‍ പരിശോധന വിവരങ്ങള്‍" Font-Bold="True" Width="400px" />
                           </td>
                              <td style="width: 381px" align="left"> <asp:TextBox ID="txtRevenueinspection" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditRevenueinspection" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label8" runat="server" Text="5. i) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീരുമാനം നം)" Font-Bold="True" Width="400px" />
                           </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolution" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolution" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                  <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label9" runat="server" Text="5. ii) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീയതി)" Font-Bold="True" Width="400px" />
                           </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolutionDate"  runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolutionDate"   runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                  <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label10" runat="server" Text="5. iii) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (ഇനം)" Font-Bold="True" Width="400px" />
                            </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolutionItem" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolutionItem" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label11" runat="server" Text="6. കഴിഞ്ഞ മാസത്തെ ചെലവു വൗച്ചറുകള്‍ പരിശോധിച്ച് അംഗീകരിച്ച തീയതി" Font-Bold="True" Width="400px" />
                            </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtVoucherinspectiondt" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditVoucherinspectiondt" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px; height: 42px;">
                            &nbsp;</td>
                        <td style="width: 490px; height: 42px;" align="left"  > 
                        <asp:Label ID="label12" runat="server" Text="7. പ്രതിമാസ വരവ് ചെലവ് അക്കൗണ്ട് സെക്രട്ടറി തയ്യാറാക്കി സമര്‍പ്പിച്ചതീയതി" Font-Bold="True" Width="400px" />
                             </td>
                              <td align="left" valign="middle" style="height: 42px"> <asp:TextBox ID="txtIEsecretarysubmissiondt" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px; height: 42px;" align="left"> <asp:TextBox ID="txtAuditIEsecretarysubmissiondt" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                 <%--                <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 286px; height: 28px;" align="left"  > 
                            <strong>5. പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീരുമാനം നം, തീയതി,ഇനം) </strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="TextBox9" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="TextBox10" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>--%>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label13" runat="server" Text="8. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനത്തിന്റെ പ്രവര്‍ത്തനം വിലയിരുത്തല്‍ - അജണ്ട / തീരുമാനം " Font-Bold="True" Width="400px" />
                            </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtFrontofficeresolution" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditFrontofficeresolution" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label14" runat="server" Text="9. i) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍" Font-Bold="True" Width="400px" />
                            </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceproject" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceproject" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label15" runat="server" Text="9. ii) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (നം)" Font-Bold="True" Width="400px" />
                            </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceprojectno" runat="server"  onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric"  Text= "" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceprojectno"   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text="" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  >
                        <asp:Label ID="label16" runat="server" Text="9. ii) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (അടങ്കല്‍)" Font-Bold="True" Width="400px" />
                             </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceprojectAmount" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumericFloat" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceprojectAmount" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumericFloat"  Text="" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label17" runat="server" Text="9. iv) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (ചെലവ്)" Font-Bold="True" Width="400px" />
                             </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceExpen"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumericFloat" runat="server" Text= "" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceExpen"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumericFloat"  runat="server" Text="" Width="300px" TextMode="MultiLine" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                                   <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  >
                        <asp:Label ID="label18" runat="server" Text="10. ഐ.എസ്.ഒ സര്‍ട്ടിഫിക്കറ്റ് നേടിയിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരങ്ങള്‍" Font-Bold="True" Width="400px" /> 
                             </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtisodetails" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditisodetails" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                                   <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label19" runat="server" Text="11. i) തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (വര്‍ഷം)" Font-Bold="True" Width="400px" />
                             </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtauditreportpendingyear" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditauditreportpendingyear" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                        
                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 490px; height: 28px;" align="left"  > 
                        <asp:Label ID="label20" runat="server" Text="11. ii) തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (ഖണ്ഡിക)" Font-Bold="True" Width="400px" />
                             </td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtauditreportpendingpara" runat="server" Text= "" Width="300px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditauditreportpendingpara" runat="server" Text="" Width="300px" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                        <td></td>
                        <td colspan="3" style="width:1000px" align="left">
                            &nbsp;</td>
                        </tr>
                            <tr>  <td></td>
                                <td colspan="3" style="width: 1000px" align="center">
                                    &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
                                        Text="NEXT" Width="62px" /><br />
                                    <asp:Label ID="lblStandCommID" runat="server" Text="Label" Visible="False"></asp:Label>
                                    <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinance">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        
                        </table>
                  
                  
                  
                  
                  </div>
                  </div>
                  </div>
                  </div>
                 </div>
                 </div>
                 </div>  </ContentTemplate></asp:UpdatePanel><script type="text/javascript">
    
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
    <script type="text/javascript" language ="javascript">
 $('.floatnumbers').keypress(function(eve) {
  if ((eve.which != 46 || $(this).val().indexOf('.') != -1) && (eve.which < 48 || eve.which > 57) || (eve.which == 46 && $(this).caret().start == 0)) {
    eve.preventDefault();
  }

  // this part is when left part of number is deleted and leaves a . in the leftmost position. For example, 33.25, then 33 is deleted
  $('.floatnumbers').keyup(function(eve) {
    if ($(this).val().indexOf('.') == 0) {
      $(this).val($(this).val().substring(1));
    }
  });
});
</script>​
                
</asp:Content>

