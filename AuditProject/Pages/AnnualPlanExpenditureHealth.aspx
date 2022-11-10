<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="AnnualPlanExpenditureHealth.aspx.cs" Inherits="Pages_AnnualPlanExpenditureHealth"  %>
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
                         <div class="card-header">
                            <strong class="card-titlen">ഡി. ആരോഗ്യം വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി</strong>
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
                        
                         <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 490px; height: 28px;" align="left"> <asp:Label ID="label3" runat="server" Text="അംഗങ്ങളുടെ എണ്ണം" Font-Bold="True" /></td>
                        <td style="width: 381px; height: 28px;" align="left" colspan="2"> <asp:TextBox ID="txtnoofMember" runat="server"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  Text= "" Width="80px" OnTextChanged="txtnoofMember_TextChanged" AutoPostBack="True" />
                            <asp:Button ID="btnMember" runat="server" OnClick="btnMember_Click" Text="Show" Width="48px" /></td>
                        
                        </tr>
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td align="left" colspan="3"> 
                           <asp:Label ID="lblnoofMember" onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric" runat="server" Text="2. അംഗങ്ങള്‍(പേര് വിവരം)" Visible="False" Font-Bold="True" /> </td>
                       
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
                            </tr>
                            <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td align="left"> <asp:Label ID="label5" runat="server" Text="കൂടിയ യോഗങ്ങളുടെ എണ്ണം"     Font-Bold="True" Width="224px" /></td>
                        <td align="left" colspan="2"> <asp:TextBox ID="txtnoofMeeting"  onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" AutoPostBack="True" OnTextChanged="txtnoofMeeting_TextChanged" />
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
             <td><asp:Button ID="btnDeleteMeeting" runat="server" Text="X" ForeColor="Red" Width="25px" Height="25px" OnClick="btnDeleteMeeting_Click" /></td>
          
           </tr></ItemTemplate>                       

<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
                        </td>
                        </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td colspan="3">
                                </td>
                            </tr>
                        
                        
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="left"  > 
                            <strong>4. പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം</strong></td>
                              <td style="width: 381px" align="left"> <asp:TextBox ID="txtMotiontot"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   runat="server" Text= "" Width="97px" TextMode="singleLine" /></td>
                        <td style="width: 586px" align="left"> <asp:TextBox ID="txtAuditMotiontot"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text="" Width="130px" TextMode="singleLine" /></td>
                        </tr>
                        
                                   <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 314px; height: 28px;" align="center"  colspan="3" > </td>
                        </tr>
                        <tr>  <td></td>
                                <td colspan="3" style="width: 1000px" align="center">
                                    &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
                                        Text="NEXT" Width="62px" /><br />
                                    <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblStandCommID" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        
                        </table></div></div></div></div></div></div></div>
                        
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

