<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_JointVentureDetails, App_Web_yasbjxhy" title="Untitled Page" %>
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
           
VII. സംയുക്ത പ്രോജക്റ്റുകള്‍ ക്കുവേണ്ടിയും, മറ്റ് സര്‍ക്കാര്‍ ഏജന്‍സികള്‍ മുതലായവയില്‍ നിന്നും ലഭിച്ച തുകയുടെ വിവരം
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?>
    <?xml namespace=""
        prefix="o" ?>
    <o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptJoint" runat="server"    >

                       
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
                 ഏജന്‍സി
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
                      ഏജന്‍സി
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
            
         <%--   <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />--%>
              <asp:Label ID="intagencylbtypeid" runat="server" Text='<%# Eval("intagencylbtypeid") %>' Visible="false" />
               <asp:Label ID="intagencylbid" runat="server" Text='<%# Eval("intagencylbid") %>' Visible="false" />
               <asp:Label ID="chvlbType" runat="server" Text='<%# Eval("chvlbType") %>' />
          
            </td>
            <td><asp:TextBox ID= "numob" runat="server" ReadOnly="true"  Text='<%# Eval("numob") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "numincome" runat="server" ReadOnly="true" Text='<%# Eval("numincome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "numexpenditure" runat="server"  ReadOnly="true" Text='<%# Eval("numexpenditure") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
            <td>
            
         <%--   <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />--%>
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("intagencylbtypeid") %>' Visible="false" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
               <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvlbType") %>' />
            <p>
           
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("intagencylbid") %>' Visible="false" />
            
           </p>
            </td>
             <td>
                 <asp:TextBox ID= "numauditedob" runat="server" ReadOnly="true"  Text='<%# Eval("numauditedob") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "numauditedincome" runat="server"  ReadOnly="true" Text='<%# Eval("numauditedincome") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
                 <td>
                  <asp:TextBox ID= "numauditedexpenditure" runat="server"  ReadOnly="true"  Text='<%# Eval("numauditedexpenditure") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
                
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
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

