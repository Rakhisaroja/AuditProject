<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_CentralFund, App_Web_yasbjxhy" title="Untitled Page" %>
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
           VI. കേന്ദ്ര ഫണ്ട്</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml
                        namespace=""
                        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptCentralFund" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 ഫണ്ടിനം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
               മുന്നിരിപ്പ് 

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                  വരവ്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ചെലവ്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                     ഫണ്ടിനം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മുന്നിരിപ്പ് 
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
                വരവ്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 ചെലവ്

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
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            <td>
            
         <%--   <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="lblincometype" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />--%>
               <asp:Label ID="chvdescriptionmal" runat="server" Text='<%# Eval("chvdescriptionmal") %>' />
            <p>
           
            <asp:Label ID="lblccounthead" runat="server" Text='<%# Eval("vchaccounthead") %>' Visible="false" />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>' Visible="false" />
           </p>
            </td>
            <td><asp:TextBox ID= "numprevcb" runat="server" Text='<%# Eval("numprevcb") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"  /></td>
             <td>
                <asp:TextBox ID= "numincome" runat="server" Text='<%# Eval("numincome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "numexpenditure" runat="server" Text='<%# Eval("numexpenditure") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
             
            <td>
            
           <%-- <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvincometypemal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intincometype") %>' Visible="false" />--%>
          
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("chvdescriptionmal") %>' />
           
          
            </td>
             <td>
                 <asp:TextBox ID= "numauditedprevcb" runat="server"  Text='<%# Eval("numauditedprevcb") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "numauditedincome" runat="server"  Text='<%# Eval("numauditedincome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"  />
                 <td>
                  <asp:TextBox ID= "numauditedexpenditure" runat="server"  Text='<%# Eval("numauditedexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
                
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center">
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

