<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_TaxNontaxCashDetails, App_Web_yasbjxhy" title="Untitled Page" %>
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
                                <strong class="card-titlen">ബി) കാഷ് അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 100%;height:500px" >
                            
                            
                           <asp:Repeater ID="rptCash" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" width="100%">
        <tr> <th scope="col"  rowspan="2" align="center"   style="WIDTH: 100px;">
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                  ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current)
(റസീറ്റ് ആന്റ് പേമന്റ് അക്കൌണ്ട് പ്രകാരം )

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                    ഫണ്ടിനം
                </th>
                   <th scope="col" style="width: 100px" align="center">
                     തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current)
(റസീറ്റ് ആന്റ് പേമന്റ് അക്കൌണ്ട് പ്രകാരം )
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
            <td><asp:TextBox ID= "numCurrentamount" ReadOnly="true" runat="server" Text='<%# Eval("numCurrentamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
               <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />
            <p>
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="Label5" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
            <td>
                <asp:TextBox ID= "numauditedcurrentamount" ReadOnly="true" runat="server" Text='<%# Eval("numauditedcurrentamount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr>  <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
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

