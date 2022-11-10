<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PreferableGrants.aspx.cs" Inherits="Pages_PreferableGrants"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">വരവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">V. മറ്റ് പ്രത്യേകോദ്ദേശ്യ ഗ്രാന്റുകള്‍/പിരിവുകള്‍</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                          <asp:Repeater ID="grvPreferableGrants" runat="server" OnItemCommand="grvPreferableGrants_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
         <th scope="col" style="text-align:center"  align="center" rowspan="3"  >
                   ക്രമ. നം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="8"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="8"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ഫണ്ടിനം
                </th>
                <th scope="col" style="width: 200px" rowspan="2"align="center">
                  മുന്നിരിപ്പ്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                    വരവ്
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                   ചെലവ്
                </th>
                   <th scope="col" style="width: 300px" colspan="4" align="center">
                   ഗുണഭോക്താക്കളുടെ എണ്ണം
                </th>
                        <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ഫണ്ടിനം
                </th>
                <th scope="col" style="width: 200px" rowspan="2"align="center">
                  മുന്നിരിപ്പ്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                    വരവ്
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                   ചെലവ്
                </th>
                   <th scope="col" style="width: 300px" colspan="4" align="center">
                   ഗുണഭോക്താക്കളുടെ എണ്ണം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 300px" align="center">
                   നിലവിലുണ്ടായിരുന്നവര്‍
                </th>
                <th scope="col" style="width: 300px" align="center">
                   തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്
                </th>
                   <th scope="col" style="width: 300px" align="center">
                    നീക്കം  ചെയ്യപ്പെട്ടവര്‍
                </th>
                   <th scope="col" style="width: 300px" align="center">
                    ബാക്കി ഗുണഭോക്താക്കള്‍
                </th>
                  <th scope="col" style="width: 100px" align="center">
                   നിലവിലുണ്ടായിരുന്നവര്‍
                </th>
                <th scope="col" style="width: 300px" align="center">
                   തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്
                </th>
                   <th scope="col" style="width: 300px" align="center">
                    നീക്കം  ചെയ്യപ്പെട്ടവര്‍
                </th>
                   <th scope="col" style="width: 300px" align="center">
                    ബാക്കി ഗുണഭോക്താക്കള്‍
                </th>
                
               
               
                          
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>
            <td>
                <asp:Label ID="vchaccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' />
                 <asp:Label ID="vchaccountheadcode" Visible="false" runat="server" Text='<%# Eval("vchaccountheadcode") %>' />
            </td>
    <td>
                <asp:TextBox   CssClass="floatnumbers"  ID="numob" runat="server" Text='<%# Eval("numob") %>' />
            </td>
             <td>
                <asp:TextBox ID="numincome"   CssClass="floatnumbers" runat="server" Text='<%# Eval("numincome") %>' />
            </td>
            <td>
                <asp:TextBox ID="numexpenditure"   CssClass="floatnumbers" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>

                <asp:TextBox ID="intexistingcount"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intexistingcount") %>' />
            </td>
             <td>
                <asp:TextBox ID="intadditioncount" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intadditioncount") %>' />
            </td>
            <td>
                <asp:TextBox ID="intdeletioncount"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intdeletioncount") %>' />
            </td>
            <td>
                <asp:TextBox ID="intbalancecount"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intbalancecount") %>' />
            </td>
            <td>
                <asp:Label ID="vchAuditaccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' />
                 
            </td>
    <td>
                <asp:TextBox ID="numauditedob"  CssClass="floatnumbers"  runat="server" Text='<%# Eval("numauditedob") %>' />
            </td>
             <td>
                <asp:TextBox ID="numauditedincome"  CssClass="floatnumbers"  runat="server" Text='<%# Eval("numauditedincome") %>' />
            </td>
            <td>
                <asp:TextBox ID="numauditedexpenditure" runat="server" CssClass="floatnumbers" Text='<%# Eval("numauditedexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID="intauditedexistingcount" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intauditedexistingcount") %>' />
            </td>
             <td>
                <asp:TextBox ID="intauditedadditioncount" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intauditedadditioncount") %>' />
            </td>
            <td>
                <asp:TextBox ID="intauditeddeletioncount" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intauditeddeletioncount") %>' />
            </td>
            <td>
                <asp:TextBox ID="intauditedbalancecount" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intauditedbalancecount") %>' />
            </td>
           
        </tr> 
    </ItemTemplate>
 <FooterTemplate>
 <tr>  <td style="font-weight:bold" colspan="2" >Total
        </td> 
        <td  >
            <asp:Label ID="totob"  Font-Bold="True"  runat="server" Text='<%# Eval("totob") %>' />
        </td>   <td  >
            <asp:Label ID="totincome"  Font-Bold="True"  runat="server" Text='<%# Eval("totincome") %>' />
        </td>
         <td  >
            <asp:Label ID="totexpenditure"  Font-Bold="True"  runat="server" Text='<%# Eval("totexpenditure") %>' />
        </td>
        <td colspan="5"></td>
         <td  >
            <asp:Label ID="totAuditob"  Font-Bold="True"  runat="server" Text='<%# Eval("totAuditob") %>' />
        </td>   <td  >
            <asp:Label ID="totAuditincome"  Font-Bold="True"  runat="server" Text='<%# Eval("totAuditincome") %>' />
        </td>
         <td  >
            <asp:Label ID="totAuditexpenditure"  Font-Bold="True"  runat="server" Text='<%# Eval("totAuditexpenditure") %>' />
        </td></tr>
    </table>
</FooterTemplate>   
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
  <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" Width="63px"></asp:Button>&nbsp;
                        </td></tr></table></div>

                </div>
            </div><!-- .animated -->
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

