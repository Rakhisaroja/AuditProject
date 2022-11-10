<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_Crematorium, App_Web_yasbjxhy" title="Untitled Page" %>
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
           
1. പൊതുശ്മശാനം/ പവര്‍ ക്രിമറ്റോറിയം വിശദവിവരങ്ങള്‍
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
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
                       
                       
                           <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                       
                       
                       <tr>
                       <td style="font-size: 20px;font-family: Meera;" colspan="3" align="center"> നിലവിലുള്ള വിവരങ്ങള്‍ </td> <td style="font-size: 20px;font-family: Meera;"  colspan="3" align="center">   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ </td>
                       </tr>
                       
                       <tr>
                       <td style="font-size: 20px;font-family: Meera;" align="center">നിലവിലുള്ളത്</td>
                        <td style="font-size: 20px;font-family: Meera;" align="center">പുരുതായി നിര്‍മ്മിച്ചത്</td>
                         <td style="font-size: 20px;font-family: Meera;" align="center">തന്‍വര്‍ഷ ചെലവ്</td>
                         
                        
                    
                       
                       <td style="font-size: 20px;font-family: Meera;" align="center">നിലവിലുള്ളത്</td>
                        <td style="font-size: 20px;font-family: Meera;" align="center">പുരുതായി നിര്‍മ്മിച്ചത്</td>
                         <td style="font-size: 20px;font-family: Meera;" align="center">തന്‍വര്‍ഷ ചെലവ്</td>
                         
                        
                    
                          </tr>
                          
                          
                          
                          <tr>
                         <td style="width:100px; height: 17px;"> <asp:TextBox ID="intcrematoriumexists"  Text='<%# Eval("intcrematoriumexists") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
                         <asp:Label ID="lblnum"  Text='<%# Eval("numid") %>' runat ="server"></asp:label>
                         
                         </td>
                        <td style="width:100px; height: 17px;"><asp:TextBox ID="intcrematoriumnew" Text='<%# Eval("intcrematoriumnew") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style="width:100px; height: 17px;"><asp:TextBox ID="numamount" Text='<%# Eval("numamount") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        
                        
                            <td style="width:100px; height: 17px;"> <asp:TextBox ID="intcrematoriumexistsaudited"  Text='<%# Eval("intcrematoriumexistsaudited") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        <td style="width:100px; height: 17px;"><asp:TextBox ID="intcrematoriumnewaudited" Text='<%# Eval("intcrematoriumnewaudited") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style="width:100px; height: 17px;"><asp:TextBox ID="numamountaudited"  Text='<%# Eval("numamountaudited") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                       </tr></table>
                       
                       
                       
                       </div>
                       <div> <table width="100%"> <tr>  
                               <td style="width: 1200px; height: 51px;" align="Center">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
                                    <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" />
                               </td></tr> 
                              </table>
                            </div>
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

