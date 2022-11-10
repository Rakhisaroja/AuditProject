<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PublicWorksAssets_Urban.aspx.cs" Inherits="Pages_PublicWorksAssets_Urban" Title="KSAD-LFA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>
<DIV class="content mt-3"><DIV class="animated fadeIn"><DIV class="row"><DIV class="col-md-12"><DIV class="title-blue-Head">ചിലവ് ഭാഗം </DIV><DIV class="card"><DIV class="card-header"><STRONG class="card-titlen">ഇ) മരാമത്ത്കാര്യം സ്റ്റാന്റിംഗ് കമ്മിറ്റി </STRONG></DIV><DIV class="card-header"><STRONG class="card-titlen">പൊതുമരാമത്ത് </STRONG></DIV><DIV><asp:Button id="btnNew" runat="server" Text="NEW" CssClass="btn btn-secondary btn-sm" Width="63px" OnClick="btnNew_Click"></asp:Button></DIV><DIV class="card-body"><DIV class="table table-striped table-bordered"><asp:Panel id="pnlNewEntry" runat="server" Visible="false"><TABLE style="WIDTH: 936px"><TBODY><TR><%-- <th  >ക്രമ നമ്പര്‍</th>--%><TD style="WIDTH: 50px">&nbsp;</TD><TH align=center colSpan=2>പുതിയ വിവരങ്ങള്‍</TH></TR><TR><TD style="WIDTH: 50px; HEIGHT: 28px">&nbsp;<asp:Label id="lblCommID" runat="server" Visible="False"></asp:Label></TD><%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%><TD style="WIDTH: 362px; HEIGHT: 28px" align=left><asp:Label id="lblAssetType" runat="server" Text="1. തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(തരം)" Width="334px" Font-Bold="True"></asp:Label> <%--<strong><span style="color: #000000">(*)</span></strong>--%></TD><TD style="WIDTH: 381px; HEIGHT: 28px" align=left><asp:TextBox id="txtAssetType" runat="server" Text="" Width="413px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 50px">&nbsp;</TD><%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%><TD style="WIDTH: 362px; HEIGHT: 28px" align=left><asp:Label id="lblAsset" runat="server" Text="2. തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(മൂല്യം)" Width="334px" Font-Bold="True"></asp:Label> <%--<strong><span style="color: #000000">(*)</span></strong>--%></TD><TD style="WIDTH: 381px; HEIGHT: 28px" align=left><asp:TextBox id="txtAsset" runat="server" Text="" Width="413px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 50px">&nbsp;</TD><%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%><TD style="WIDTH: 362px; HEIGHT: 28px" align=left><asp:Label id="lblSCPTSP" runat="server" Text="3. തന്‍വര്‍ഷം നടപ്പിലാക്കിയ എസ്.സി.പി/ ടി.എസ്.പി പ്രോജക്ടുകളുടെ ഫീസിബിളിറ്റി സര്‍ട്ടിഫിക്കറ്റ് / സോഷ്യല്‍ മാപ്പ് ലഭ്യമാക്കിയിട്ടുണ്ട് / ഇല്ല" Width="334px" Font-Bold="True"></asp:Label> <%--<strong><span style="color: #000000">(*)</span></strong>--%></TD><%--<td style="width: 381px; height: 28px;" align="left"> <asp:TextBox ID="txtSCPTSP"  runat="server" Text= "" Width="413px" /></td>--%><TD align=left><asp:DropDownList id="ddlSCPTSP" runat="server" Width="98px">
                            <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 50px">&nbsp;</TD><%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%><TD style="WIDTH: 362px; HEIGHT: 28px" align=left><asp:Label id="lblMtr" runat="server" Text="4. ടാറിംഗ് / കോൺക്രീറ്റിംഗ് പ്രവ്യത്തി വഴി തന്‍ വര്‍ഷം പക്കറോഡുകളാക്കിയവയുടെ വിവരം(മീറ്ററില്‍)" Width="334px" Font-Bold="True"></asp:Label> <%--<strong><span style="color: #000000">(*)</span></strong>--%></TD><TD style="WIDTH: 381px; HEIGHT: 28px" align=left><asp:TextBox id="txtMtr" runat="server" Text="" Width="413px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 50px">&nbsp;</TD><TD align=center colSpan=2>&nbsp;<asp:Button id="btnNewSave" onclick="btnNewSave_Click" runat="server" Text="SAVE" CssClass="btn btn-secondary btn-sm" Width="63px"></asp:Button> <asp:Label id="lblGSNo" runat="server" Text="Label" Visible="False"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </DIV></DIV>
                                        <DIV class="card-body"><DIV class="table table-striped table-bordered"><DIV style="OVERFLOW: scroll; WIDTH: 1200px; HEIGHT: 600px"><asp:Repeater id="grvOther" runat="server">
                            <HeaderTemplate>
                                <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >

                            <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
             <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(തരം)
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(മൂല്യം)
                </th>
               <%-- <th></th>--%>
                   <%-- <th></th>--%>
                   <th scope ="col" style="width: 100px"  align="center">
                   തന്‍വര്‍ഷം നടപ്പിലാക്കിയ എസ്.സി.പി/ ടി.എസ്.പി പ്രോജക്ടുകളുടെ ഫീസിബിളിറ്റി സര്‍ട്ടിഫിക്കറ്റ് / സോഷ്യല്‍ മാപ്പ് ലഭ്യമാക്കിയിട്ടുണ്ട് / ഇല്ല
                </th>
                  
                <th scope ="col" style="width: 100px"  align="center">
                    ടാറിംഗ് / കോൺക്രീറ്റിംഗ് പ്രവ്യത്തി വഴി തന്‍ വര്‍ഷം പക്കറോഡുകളാക്കിയവയുടെ വിവരം(മീറ്ററില്‍)
                </th> 
                 
                
                        
                     <th scope="col" style="width: 200px" align="center">
                  തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(തരം)
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  തന്‍വര്‍ഷം ആര്‍ജിച്ച ആസ്തികളുടെ വിവരം(മൂല്യം)
                </th>
               <%-- <th></th>--%>
                   <th scope ="col" style="width: 90px"  align="center">
                    തന്‍വര്‍ഷം നടപ്പിലാക്കിയ എസ്.സി.പി/ ടി.എസ്.പി പ്രോജക്ടുകളുടെ ഫീസിബിളിറ്റി സര്‍ട്ടിഫിക്കറ്റ് / സോഷ്യല്‍ മാപ്പ് ലഭ്യമാക്കിയിട്ടുണ്ട് / ഇല്ല
                </th>
                  
                <th scope ="col" style="width: 100px"  align="center">
                    ടാറിംഗ് / കോൺക്രീറ്റിംഗ് പ്രവ്യത്തി വഴി തന്‍ വര്‍ഷം പക്കറോഡുകളാക്കിയവയുടെ വിവരം(മീറ്ററില്‍)
                </th> 
                 
                
              
                  
            </tr>

                        
                        </HeaderTemplate> 
                         <ItemTemplate>
                       
                         <tr>
                         <td>
                                 <asp:Label ID="intAssetID" runat="server"  Visible="false" Text='<%# Eval("intAssetID") %>' />
                                
                                <asp:TextBox ID="chvAssetType" runat="server" Text='<%# Eval("chvAssetType") %>' />
                                </td>
                                <td>
                                 <asp:TextBox ID="chvAssetValue" runat="server" Text='<%# Eval("chvAssetValue") %>' />
                                </td>
                                <td><asp:DropDownList ID="chvSCPTSPFeecibitystatus" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="tnyAuditmonitoringreport" runat="server" Text='<%# Eval("tnyAuditmonitoringreport") %>' />--%>
                                </td>
                                <td>
                                 <asp:TextBox ID="chvMeter" runat="server" Text='<%# Eval("chvMeter") %>' />
                                </td>
                                
                                
                             <td>
                                
                                <asp:TextBox ID="chvAssetTypeAud" runat="server" Text='<%# Eval("chvAssetTypeAud") %>' />
                                </td>
                                <td>
                                 <asp:TextBox ID="chvAssetValueAud" runat="server" Text='<%# Eval("chvAssetValueAud") %>' />
                                </td>
                                <td><asp:DropDownList ID="chvSCPTSPFeecibitystatusAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                 <asp:TextBox ID="chvMeterAud" runat="server" Text='<%# Eval("chvMeterAud") %>' />
                                </td>    
                         </tr>
                         
                         </ItemTemplate> 

                        <FooterTemplate></table></FooterTemplate>
                        
                        </asp:Repeater> </DIV>
                        <DIV style="WIDTH: 100%">
                        <TABLE style="WIDTH: 1218px"><TBODY><TR><TD style="WIDTH: 58px; HEIGHT: 51px" align=center>
                        <asp:Button id="btnPrev" runat="server" Text="BACK" CssClass="btn btn-secondary btn-sm" OnClick="btnPrev_Click" Width="63px"></asp:Button> 
                        <asp:Button id="btnSave" runat="server" Text="SAVE" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click" Width="63px"></asp:Button>&nbsp; 
                        <asp:Button id="btnNxt" runat="server" Text="NEXT" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click" Width="62px"></asp:Button> </TD></TR></TBODY></TABLE></DIV></DIV></DIV></DIV></DIV></DIV></DIV></DIV>
</ContentTemplate> 
</asp:UpdatePanel> 
<asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinanceWrkgrp">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
</asp:Content>

