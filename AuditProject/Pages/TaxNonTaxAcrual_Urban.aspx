<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="TaxNonTaxAcrual_Urban.aspx.cs" Inherits="Pages_TaxNonTaxAcrual_Urban"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    
                      <div class="card-header">
                                <strong class="card-titlen">  നികുതി നികുതിയേതര
            വരവുകള്‍</strong>
                                
                            </div>
                            
                            
                   
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                             <div class="card-body">
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptAcrual" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                  ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  ഇന്‍കം & എക്സപെന്‍ഡിച്ചര്‍ പത്രിക പ്രകാരമുള്ള പ്രതീക്ഷിത വരുമാനം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px ;text-align:center"  align="center">
                    തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-37)<br /><label> [a]</label>
                </th>
                   <th scope="col" style="width: 100px  ;text-align:center" align="center">
                    തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-37, ആര്‍.പി-1  ) <br /><label>[b]</label>
                </th>
                 <th scope="col" style="width: 100px  ;text-align:center" align="center">
                    തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance)       (ആര്‍.പി-29)<br />[c]
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   ആകെ തന്‍വര്‍ഷം വരവ് <label>(a+b+c)</label> 
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
                  ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  ഇന്‍കം & എക്സപെന്‍ഡിച്ചര്‍ പത്രിക പ്രകാരമുള്ള പ്രതീക്ഷിത വരുമാനം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px  ;text-align:center"  align="center">
                    തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-37)<br /><label>[a]</label>
                </th>
                   <th scope="col" style="width: 100px  ;text-align:center" align="center">
                    തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-37, ആര്‍.പി-1)<br /><label>[b]</label>
                </th>
                 <th scope="col" style="width: 100px  ;text-align:center" align="center">
                    തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance)       (ആര്‍.പി-29)<br /><label>[c]</label>
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   ആകെ തന്‍വര്‍ഷം വരവ്<label>(a+b+c)</label> 
                </th>
                  
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
            
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="lblincometype" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />
            <p>
            <asp:Label ID="lblccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
            <td><asp:TextBox ID= "txtincomeExpnditureamount" ReadOnly="true" runat="server" Text='<%# Eval("numincomeExpnditureamount") %>' CssClass="floatnumbers"/></td>
             <td>
                <asp:TextBox ID= "txtnumCurrentamount" ReadOnly="true"  runat="server" Text='<%# Eval("numCurrentamount") %>' CssClass="floatnumbers"/>
            </td>
            <td>
                <asp:TextBox ID= "txtnumArrearamount" ReadOnly="true" runat="server" Text='<%# Eval("numArrearamount") %>' CssClass="floatnumbers"/>
            </td>
             <td>
               <asp:TextBox ID= "txtnumAdvanceamount" ReadOnly="true" runat="server" Text='<%# Eval("numAdvanceamount") %>' CssClass="floatnumbers"/>
            </td>
             <td>
                <asp:TextBox ID= "txtnumTotalamount" ReadOnly="true" runat="server" Text='<%# Eval("numTotalamount") %>' CssClass="floatnumbers"/>
            </td>
            <td>
            
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />
            <p>
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="Label5" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
             <td>
                 <asp:TextBox ID= "txtincomeExpnditureamountAudt" ReadOnly="true" runat="server"  Text='<%# Eval("numincomeExpnditureamountAudt") %>' CssClass="floatnumbers"/>
            </td>
             <td>
                <asp:TextBox ID= "txtnumCurrentamountAudt" ReadOnly="true" runat="server"  Text='<%# Eval("numCurrentamountAudt") %>' CssClass="floatnumbers"/>
                 <td>
                  <asp:TextBox ID= "txtnumArrearamountAudt" ReadOnly="true"  runat="server"  Text='<%# Eval("numArrearamountAudt") %>'  CssClass="floatnumbers"/>
                 <td>
                <asp:TextBox ID= "txtnumAdvanceamountAudt" ReadOnly="true" runat="server"  Text='<%# Eval("numAdvanceamountAudt") %>' CssClass="floatnumbers"/>
                 <td>
               <asp:TextBox ID= "txtnumTotalamountAudt" ReadOnly="true" runat="server"   Text='<%# Eval("numTotalamountAudt") %>' CssClass="floatnumbers"/>
            </td>
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        

     <FooterTemplate></table></FooterTemplate>  
</asp:Repeater>


</div></div>

</div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="center" colspan="3">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                     CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" Width="75px" />
                                       <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" />
                               </td></tr> 
                              </table>
                            </div>
                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
           </div>
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

