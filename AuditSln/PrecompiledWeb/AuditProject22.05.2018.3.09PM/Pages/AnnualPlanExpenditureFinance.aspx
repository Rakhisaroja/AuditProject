<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_AnnualPlanExpenditureFinance, App_Web_cllhm4gw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <table>
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >നിലവിലുള്ള വിവരങ്ങള്‍</th>
                          <th style="width: 586px">ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍</th>
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. ചെയര്‍മാന്‍(പേര് വിവരം)" Font-Bold="True" /></td>
                        <td style="width: 381px; height: 28px;" align="left"> <asp:TextBox ID="txtChairman" runat="server" Text= "" Width="349px" /></td>
                        <td style="width: 586px; height: 28px;" align="left"> <asp:TextBox ID="txtChairmanmalAudit" runat="server" Text="" Width="450px" /></td>
                        </tr>
                        
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left" colspan="3"> 
                            <strong>2. അംഗങ്ങള്‍(പേര് വിവരം)</strong></td>
                       
                        </tr>
                        <tr><td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="3" style="width:1000px">
                        <asp:Repeater ID="grvMembers" runat="server" OnItemCommand="grvMembers_ItemCommand"   >

                       
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
                          
            </tr>
            
     
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:100px">
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' /> </td>
            <td style="width:400px"> 
            <asp:Label ID="lblMember" runat="server" Text='<%# Eval("chvnameofmembermal") %>' />
            </td >
            <td style="width:400px"><asp:TextBox ID="chvAuditnameofmembermal" runat="server" Text='<%# Eval("chvAuditnameofmembermal") %>' />
            <asp:Label ID="numstandingcommitteeid" runat="server" Text='<%# Eval("numstandingcommitteeid") %>' />
              <asp:Label ID="intstandingcommitteetype" runat="server" Text='<%# Eval("intstandingcommitteetype") %>' />
             <asp:Label ID="intslno" runat="server" Text='<%# Eval("intslno") %>' /></td>
             
           </tr></ItemTemplate>
                        


</asp:Repeater>
                        </td>
                        </tr>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left" colspan="3"> 
                            <strong>3. കൂടിയ യോഗങ്ങളുടെ തീയതി</strong></td>
                       
                        </tr>
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="3" style="width:1000px">
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
                          
            </tr>
            
     
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:100px">
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' /> </td>
            <td style="width:400px"> 
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("intMeetingNo") %>' />
            <asp:Label ID="txtDate" runat="server" Text='<%# Eval("dtMeetingDate") %>' />
            </td >
            <td style="width:400px"><asp:TextBox ID="txtAuditDate" runat="server" Text='<%# Eval("dtAuditMeetingDate") %>' />
             <asp:Label ID="lblAuditMeetingNo" runat="server" Text='<%# Eval("intAuditMeetingNo") %>' /></td>
             
           </tr></ItemTemplate>                       


</asp:Repeater>
                        </td>
                        </tr>
                        
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>4. റവന്യൂ വരവുകള്‍ പരിശോധന വിവരങ്ങള്‍</strong></td>
                              <td style="width: 381px" align="left"> <asp:TextBox ID="txtRevenueinspection" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditRevenueinspection" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                        <td colspan="3" style="width:1000px; height: 28px;">
                            &nbsp;</td>
                        </tr>
                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>5. i) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീരുമാനം നം) </strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolution" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolution" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                  <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>5. ii) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീയതി) </strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolutionDate" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolutionDate" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                  <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>5. iii) പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (ഇനം) </strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtNewrevenueitemresolutionItem" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditNewrevenueitemresolutionItem" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>6. കഴിഞ്ഞ മാസത്തെ ചെലവു വൗച്ചറുകള്‍ പരിശോധിച്ച് അംഗീകരിച്ച തീയതി</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtVoucherinspectiondt" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditVoucherinspectiondt" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>7. പ്രതിമാസ വരവ് ചെലവ് അക്കൗണ്ട് സെക്രട്ടറി തയ്യാറാക്കി സമര്‍പ്പിച്ചതീയതി</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtIEsecretarysubmissiondt" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditIEsecretarysubmissiondt" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
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
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>8. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനത്തിന്റെ പ്രവര്‍ത്തനം വിലയിരുത്തല്‍ - അജണ്ട / തീരുമാനം </strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtFrontofficeresolution" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditFrontofficeresolution" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>9. i) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceproject" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceproject" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                 <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>9. ii) ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (നം)</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceprojectno" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceprojectno" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>9. ii) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (അടങ്കല്‍)</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceprojectAmount" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceprojectAmount" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>9. iv) ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (ചെലവ്)</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtGoodgovernanceExpen" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditGoodgovernanceExpen" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                   <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>10. ഐ.എസ്.ഒ സര്‍ട്ടിഫിക്കറ്റ് നേടിയിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരങ്ങള്‍</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtisodetails" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditisodetails" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                                   <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>11. i) തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (വര്‍ഷം)</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtauditreportpendingyear" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditauditreportpendingyear" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                        
                         <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>11. ii) തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (ഖണ്ഡിക)</strong></td>
                              <td align="left" valign="middle"> <asp:TextBox ID="txtauditreportpendingpara" runat="server" Text= "" Width="349px" TextMode="MultiLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditauditreportpendingpara" runat="server" Text="" Width="450px" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                        <td></td>
                        <td colspan="3" style="width:1000px">
                            &nbsp;</td>
                        </tr>
                            <tr>  <td></td>
                                <td colspan="3" style="width: 1000px" align="center">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="BACK" Width="62px" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="NEXT" Width="62px" /></td>
                            </tr>
                        
                        
                        </table>
                  
                  
                  
                  </div>
                  </div>
                  </div>
                  </div>
                 </div>
                 </div>
                 </div>
</asp:Content>

