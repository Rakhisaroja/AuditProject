<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_TaxNonTaxAcrual, App_Web_cllhm4gw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
            നികുതി നികുതിയേതര
            വരവുകള്‍</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
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
                   <th scope="col" style="width: 100px"  align="center">
                    തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43)
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43, ആര്‍.പി-1)
                </th>
                 <th scope="col" style="width: 100px" align="center">
                    തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance)       (ആര്‍.പി-36)
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   ആകെ തന്‍വര്‍ഷം വരവ് (4+5+6)
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
                  ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  ഇന്‍കം & എക്സപെന്‍ഡിച്ചര്‍ പത്രിക പ്രകാരമുള്ള പ്രതീക്ഷിത വരുമാനം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                    തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43)
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43, ആര്‍.പി-1)
                </th>
                 <th scope="col" style="width: 100px" align="center">
                    തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance)       (ആര്‍.പി-36)
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   ആകെ തന്‍വര്‍ഷം വരവ് (4+5+6)
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
            <td><asp:TextBox ID= "txtincomeExpnditureamount" runat="server" Text='<%# Eval("numincomeExpnditureamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "txtnumCurrentamount" runat="server" Text='<%# Eval("numCurrentamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "txtnumArrearamount" runat="server" Text='<%# Eval("numArrearamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
               <asp:TextBox ID= "txtnumAdvanceamount" runat="server" Text='<%# Eval("numAdvanceamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "txtnumTotalamount" runat="server" Text='<%# Eval("numTotalamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
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
                 <asp:TextBox ID= "txtincomeExpnditureamountAudt" runat="server"  Text='<%# Eval("numincomeExpnditureamountAudt") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "txtnumCurrentamountAudt" runat="server"  Text='<%# Eval("numCurrentamountAudt") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
                  <asp:TextBox ID= "txtnumArrearamountAudt" runat="server"  Text='<%# Eval("numArrearamountAudt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
                <asp:TextBox ID= "txtnumAdvanceamountAudt" runat="server"  Text='<%# Eval("numAdvanceamountAudt") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
               <asp:TextBox ID= "txtnumTotalamountAudt" runat="server"   Text='<%# Eval("numTotalamountAudt") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td colspan="3" style="width: 1000px" align="center">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                     CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="Save" />
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

