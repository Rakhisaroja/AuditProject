<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="DevelopWorkingGroup.aspx.cs" Inherits="Pages_DevelopWorkingGroup"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ബി. വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി</strong>
                        </div><div class="card-header">
                            <strong class="card-titlen">ബി. (i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍</strong>
                        </div>
                         <div><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW" Width="63px" CssClass="btn btn-secondary btn-sm"></asp:Button></div>
                        <%--BKJKBJK --%>
                          <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
                        <table style="width: 936px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             പുതിയ വിവരങ്ങള്‍</th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 362px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. ഗ്രൂപ്പിന്റെ പേര്" Font-Bold="True" Width="122px" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left"> 
                            <asp:DropDownList ID="ddlWorkingGroup" runat="server"
                                Width="419px" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingGroup_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        </tr>
                        
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left"  > 
                            <strong><span style="font-size: 12pt; font-family: Meera;
                                        mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                        mso-bidi-language: ML"><strong><span style="color: #000000"><span lang="ML"><asp:Label ID="Label2" runat="server" Text="2. ചെയര്‍മാന്‍(പേര് വിവരം)" Font-Bold="True" Width="186px" />(*)</span></span></strong></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtChairMan"  runat="server" Text= "" Width="413px" /></td>
                        </tr>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left" > 
                            <strong>
                                <span style="font-family: Meera"><span style="color: #000000"><span lang="ML"><asp:Label ID="Label3" runat="server" Text="3. കണ്‍വീനര്‍ (പേര് വിവരം)" Font-Bold="True" Width="186px" />(*)</span><o:p></o:p></span></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtConveneor"   runat="server" Text= "" Width="413px" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left"  > 
                            <strong><asp:Label ID="Label4" runat="server" Text="4. കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി" Font-Bold="True" Width="262px" /><span lang="ML" style="font-size: 12pt; color: #000000; font-family: Meera;
                                mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                mso-bidi-language: ML"><strong> (*)</strong></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtnoofMeeting" runat="server"   Text= "" Width="410px" TextMode="MultiLine" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left" > 
                            <strong> <span lang="ML" style="font-size: 12pt; color: #000000; font-family: Meera;
                                mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                mso-bidi-language: ML"><strong><asp:Label ID="Label5" runat="server" Text="5. സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല" Font-Bold="True" Width="262px" />(*)</strong></span></strong></td>
                       <td align="left">
                           <asp:DropDownList ID="ddlStatusreport" runat="server" Width="98px">
                            <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem></asp:DropDownList></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left"  > 
                            <strong> <span lang="ML" style="font-size: 12pt; color: #000000; font-family: Meera;
                                mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                mso-bidi-language: ML"><strong><asp:Label ID="Label6" runat="server" Text="6. മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല" Font-Bold="True" Width="310px" />(*)</strong></span></strong></td>
                       <td align="left">
                           <asp:DropDownList ID="ddlMonitoringCom" runat="server" Width="98px">
                            <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem></asp:DropDownList></td>
                        </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 362px; height: 28px">
                                    <strong> <span lang="ML" style="font-size: 12pt; color: #000000; font-family: Meera;
                                        mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                        mso-bidi-language: ML"><strong><asp:Label ID="Label7" runat="server" Text="7. മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല" Font-Bold="True" Width="310px" />(*)</strong></span></strong></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMonitoringRpt" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <%--<tr>
                                <td style="width: 50px">
                                </td>
                                <td style="width: 362px; height: 28px;" align="left"  >
                                    <strong><span style="font-size: 12pt; font-family: Meera;
                                        mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                        mso-bidi-language: ML"><strong>
                                            <span style="color: #000000"><span lang="ML">
                                                <asp:Label ID="Label8" runat="server" Text="8. ഗ്രാമപഞ്ചായത്ത് തീരപ്രദേശ മേഖലയിലാണോ സ്ഥിതി ചെയ്യുന്നത് ?" Font-Bold="True" Width="345px" />(*)</span></span></strong></span></strong></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlNew" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td style="width: 362px; height: 28px;" align="left" >
                                    <strong><span style="font-family: Meera"><span style="color: #000000"><span lang="ML">
                                        <asp:Label ID="Label9" runat="server" Text="9. ഗ്രാമപഞ്ചായത്തില്‍ ഫിഷറീസ് ഇന്‍പെക്ടര്‍ നിലവിലുണ്ടോ ?" Font-Bold="True" Width="343px" />(*)</span><o:p></o:p></span></span></strong></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlNew2" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td style="width: 362px; height: 28px;" align="left" >
                                    <strong><span style="font-family: Meera"><span style="color: #000000"><span lang="ML">
                                        <asp:Label ID="Label10" runat="server" Text="10. മത്സ്യമേഖല വികസനത്തിന് പ്രത്യേക വര്‍ക്കിംഗ് ഗ്രൂപ്പ് ഉണ്ടോ ?" Font-Bold="True" Width="343px" />(*)</span><o:p></o:p></span></span></strong></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlNew21" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>--%>
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
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="grvFinanceWorking" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="7"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="7"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
              
                   <th scope="col" style="width: 100px"  align="center">
                 ഗ്രൂപ്പിന്റെ പേര്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                 ചെയര്‍മാന്‍(പേര് വിവരം)

                </th>
                 <th scope="col" style="width: 100px" align="center">
                   കണ്‍വീനര്‍(പേര് വിവരം)

                </th>
                 <th scope="col" style="width: 100px" align="center">
                  കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല

                </th>
                 <th scope="col" style="width: 100px" align="center">
                 മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല
                </th>
                   <th scope="col" style="width: 100px" align="center">
                മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല
                </th>
                  
                 
                   <th scope="col" style="width: 100px"  align="center">
                 ഗ്രൂപ്പിന്റെ പേര്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                 ചെയര്‍മാന്‍(പേര് വിവരം)

                </th>
                 <th scope="col" style="width: 100px" align="center">
                   കണ്‍വീനര്‍(പേര് വിവരം)

                </th>
                 <th scope="col" style="width: 100px" align="center">
                  കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല

                </th>
                 <th scope="col" style="width: 100px" align="center">
                 മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല
                </th>
                   <th scope="col" style="width: 100px" align="center">
                മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല
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

        
              <tr>
            <td>
                <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>
            <td><asp:Label ID="txtGroupName" Width="300px" runat="server" Text='<%# Eval("nchvWorkingGroup") %>' />
            <asp:Label ID="intstandingcommitteetype" runat="server" Visible="false" Text='<%# Eval("intstandingcommitteetype") %>' /> 
             <asp:Label ID="intWorkingGroupID" runat="server" Visible="false" Text='<%# Eval("intWorkingGroupID") %>' /></td>
            <td><asp:TextBox ID="chvnameofchairman"  Width="300px"  runat="server" Text='<%# Eval("chvnameofchairmanmal") %>' /></td>
             <td>
                <asp:TextBox ID="chvnameofconvenor"  Width="300px"  runat="server" Text='<%# Eval("chvnameofconvenormal") %>' />
            </td>
            <td>
                <asp:TextBox ID="intnoofmeetings"  Width="300px" TextMode="multiLine" runat="server" Text='<%# Eval("intnoofmeetings") %>' />
            </td>
              <td><asp:DropDownList ID="tnystatusreport" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
            <td><asp:DropDownList ID="tnymonitoringcommittee" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
               <%-- <asp:TextBox ID="tnymonitoringcommittee" runat="server" Text='<%# Eval("tnymonitoringcommittee") %>' />--%>
            </td>
               <td><asp:DropDownList ID="tnymonitoringreport" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
               <%-- <asp:TextBox ID="tnymonitoringreport" runat="server" Text='<%# Eval("tnymonitoringreport") %>' />--%>
            </td>
                 
                   
        <td><asp:Label ID="TextBox1"  Width="300px" runat="server" Text='<%# Eval("nchvWorkingGroup") %>' />
            <td><asp:TextBox ID="chvAuditnameofchairman"  Width="300px"  runat="server" Text='<%# Eval("chvAuditnameofchairmanmal") %>' /></td>
             <td>
                <asp:TextBox ID="chvAuditnameofconvenor"  Width="300px"  runat="server" Text='<%# Eval("chvAuditnameofconvenormal") %>' />
            </td>
            <td>
            
                <asp:TextBox ID="intAuditnoofmeetings"  Width="300px" TextMode="multiLine" runat="server" Text='<%# Eval("intAuditnoofmeetings") %>' />
            </td>
              <td><asp:DropDownList ID="tnyAuditstatusreport" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                <%--<asp:TextBox ID="tnyAuditstatusreport" runat="server" Text='<%# Eval("tnyAuditstatusreport") %>' />--%>
            </td>
            <td><asp:DropDownList ID="tnyAuditmonitoringcommittee" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                <%--<asp:TextBox ID="tnyAuditmonitoringcommittee" runat="server" Text='<%# Eval("tnyAuditmonitoringcommittee") %>' />--%>
            </td>
               <td>
               <asp:DropDownList ID="tnyAuditmonitoringreport" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                <%--<asp:TextBox ID="tnyAuditmonitoringreport" runat="server" Text='<%# Eval("tnyAuditmonitoringreport") %>' />--%>
            </td>
           </tr></ItemTemplate>
   <FooterTemplate></table></FooterTemplate>

</asp:Repeater>


</div></div><div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
         Text="NEXT" Width="63px" /></td></tr></table></div></div></div>

                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
           </div>


<asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinanceWrkgrp">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 54px; top: 4px;" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

</ContentTemplate></asp:UpdatePanel>



</asp:Content>

