<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="Directbeneficiary.aspx.cs" Inherits="Pages_PensionDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">വരവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">X   കേന്ദ്ര സംസ്ഥാന സര്‍ക്കാരുകള്‍ ഗുണഭോക്താക്കള്‍ക്ക് നേരിട്ട് കൈമാറ്റം ചെയ്യുന്ന തുകകളുടെ വിവരങ്ങള്‍</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvPensionDetails" runat="server" OnItemCommand="grvPensionDetails_ItemCommand"   >
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
                    ഇനം
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
                    ഇനം
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
                 <asp:Label ID="vchaccountheadcode" runat="server" Visible="false" Text='<%# Eval("vchaccountheadcode") %>' />
            </td>
 
             <td>
                <asp:Label ID="numincome" runat="server" Text='<%# Eval("numincome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="numexpenditure" runat="server" Text='<%# Eval("numexpenditure") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="intexistingcount" runat="server" Text='<%# Eval("intexistingcount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
             <td>
                <asp:Label ID="intadditioncount" runat="server" Text='<%# Eval("intadditioncount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="intdeletioncount" runat="server" Text='<%# Eval("intdeletioncount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="intbalancecount" runat="server" Text='<%# Eval("intbalancecount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
         
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("intFoundType") %>' />
                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("intFoundTypeID") %>' />
            </td>

             <td>
                <asp:TextBox ID="txtAuditIncome" runat="server" Text='<%# Eval("intAuditIncome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID="txtAuditExpenditure" runat="server" Text='<%# Eval("intAuditExpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID="intauditedexistingcount" runat="server" Text='<%# Eval("intauditedexistingcount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
             <td>
                <asp:TextBox ID="intauditedadditioncount" runat="server" Text='<%# Eval("intauditedadditioncount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID="intauditeddeletioncount" runat="server" Text='<%# Eval("intauditeddeletioncount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID="intauditedbalancecount" runat="server" Text='<%# Eval("intauditedbalancecount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
        </tr> 
    </ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
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

