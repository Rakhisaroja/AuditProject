<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="Crematorium.aspx.cs" Inherits="Pages_Crematorium"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">ചിലവ് ഭാഗം
                    </div>
             
                        <div class="card">
                        <div class="card-header">
                                <strong class="card-titlen">ഇ ) പൊതുസുരക്ഷയും ആരോഗ്യവും- പഞ്ചായത്തിന്റെ ഇതരസേവനങ്ങളുടെ വിവരങ്ങള്‍
                                </strong>
                                
                            </div>
                          <div class="card-header">
                                <strong class="card-titlen">1. പൊതുശ്മശാനം/ പവര്‍ ക്രിമറ്റോറിയം വിശദവിവരങ്ങള്‍</strong>
                                
                            </div>
                            <div class="card-body">
                       <div class="table table-striped table-bordered">
                       
                       
                           <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                       
                       
                       <tr>
                       <td style="font-size: 20px;font-family: Meera;" colspan="3" align="center"> നിലവിലുള്ള വിവരങ്ങള്‍ </td> <td style="font-size: 20px;font-family: Meera;"  colspan="3" align="center">   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ </td>
                       </tr>
                       
                       <tr>
                       <td style="font-size: 20px;font-family: Meera;" align="center">നിലവിലുള്ളത്</td>
                        <td style="font-size: 20px;font-family: Meera;" align="center">
                            പുതുതായി നിര്‍മ്മിച്ചത്</td>
                         <td style="font-size: 20px;font-family: Meera;" align="center">തന്‍വര്‍ഷ ചെലവ്</td>
                         
                        
                    
                       
                       <td style="font-size: 20px;font-family: Meera;" align="center">നിലവിലുള്ളത്</td>
                        <td style="font-size: 20px;font-family: Meera;" align="center">
                            പുതുതായി നിര്‍മ്മിച്ചത്</td>
                         <td style="font-size: 20px;font-family: Meera;" align="center">തന്‍വര്‍ഷ ചെലവ്</td>
                         
                        
                    
                          </tr>
                          
                          
                          
                          <tr>
                         <td style="width:100px; height: 17px;"> <asp:TextBox ID="intcrematoriumexists"  Text='<%# Eval("intcrematoriumexists") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"></asp:TextBox>
                         <asp:Label ID="lblnum"  Text='<%# Eval("numid") %>' runat ="server" Visible="false"></asp:label>
                         
                         </td>
                        <td style="width:100px; height: 17px;"><asp:TextBox ID="intcrematoriumnew" Text='<%# Eval("intcrematoriumnew") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"></asp:TextBox></td>
                         <td style="width:100px; height: 17px;"><asp:TextBox ID="numamount" Text='<%# Eval("numamount") %>' runat ="server" CssClass="floatnumbers"  ReadOnly="true"></asp:TextBox></td>
                        
                        
                            <td style="width:100px; height: 17px;"> <asp:TextBox ID="intcrematoriumexistsaudited"  Text='<%# Eval("intcrematoriumexistsaudited") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"></asp:TextBox></td>
                        <td style="width:100px; height: 17px;"><asp:TextBox ID="intcrematoriumnewaudited" Text='<%# Eval("intcrematoriumnewaudited") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"></asp:TextBox></td>
                         <td style="width:100px; height: 17px;"><asp:TextBox ID="numamountaudited"  Text='<%# Eval("numamountaudited") %>' runat ="server" CssClass="floatnumbers" ReadOnly="true"></asp:TextBox></td>
                       </tr></table>
                       
                       
                       
                       </div>
                       
                       </div>
                       <div> <table width="100%"> <tr>  
                               <td style="width: 1200px; height: 51px;" align="center">
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

