<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_Registration, App_Web_pchds3r-" title="Untitled Page" %>
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
           
2. ജനന രജിസ്ട്രേഷന്‍
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                       
                       
                           <table cellspacing="0" rules="all" border="1" width="50%" style="font-size: 15px;font-family: Meera; vertical-align:middle;"  >
                       
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" colspan="5" align="center"> നിലവിലുള്ള വിവരങ്ങള്‍ </td> 
                       
                       <td style="font-size: 15px;font-family: Meera;"  colspan="5" align="center">   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ </td>
                       </tr>
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" align="center" colspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                       
                        <td style="font-size: 15px;font-family: Meera;" align="center" colspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                          </tr>
                          <tr>
                          <td style="font-size: 15px;font-family: Meera;" align="center">ആശുപത്രി മുഖേന</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center">നേരിട്ട്</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                            
                            <td style="font-size: 15px;font-family: Meera;" align="center">ആശുപത്രി മുഖേന</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center">നേരിട്ട്</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                          
                          </tr>
                          
                          
                          <tr>
                         <td style=" height: 17px;"> 
                         <asp:TextBox ID="intbirthapplicationhospital"  Text='<%# Eval("intbirthapplicationhospital") %>' runat ="server"></asp:TextBox>
                         <asp:Label ID="lblnum"  Text='<%# Eval("numid") %>' runat ="server"></asp:label>
                         
                         </td>
                        <td style=" height: 17px;"><asp:TextBox ID="intbirthapplicationdirect" Text='<%# Eval("intbirthapplicationdirect") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intbirthcertwithintimelimit" Text='<%# Eval("intbirthcertwithintimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        
                        
                            <td style=" height: 17px;"> <asp:TextBox ID="intbirthcertaftertimelimit"  Text='<%# Eval("intbirthcertaftertimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        <td style="height: 17px;"><asp:TextBox ID="chvbirthremarks" Text='<%# Eval("chvbirthremarks") %>' runat ="server"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intbirthapplicationhospitalaud"  Text='<%# Eval("intbirthapplicationhospitalaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         
                         <td style=" height: 17px;"><asp:TextBox ID="intbirthapplicationdirectaud"  Text='<%# Eval("intbirthapplicationdirectaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intbirthcertwithintimelimitaud"  Text='<%# Eval("intbirthcertwithintimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style="height: 17px;"><asp:TextBox ID="intbirthcertaftertimelimitaud"  Text='<%# Eval("intbirthcertaftertimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="chvbirthremarksaud"  Text='<%# Eval("chvbirthremarksaud") %>' runat ="server"></asp:TextBox></td>
                       </tr></table>
                       
                       
                       
                       </div>
                       
                        <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           
3. മരണ രജിസ്ട്രേഷന്‍
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                    
                    
                      <div class="table table-striped table-bordered">
                       
                       
                           <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                       
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" colspan="5" align="center"> നിലവിലുള്ള വിവരങ്ങള്‍ </td> 
                       
                       <td style="font-size: 15px;font-family: Meera;"  colspan="5" align="center">   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ </td>
                       </tr>
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" align="center" colspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                       
                        <td style="font-size: 15px;font-family: Meera;" align="center" colspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                          </tr>
                          <tr>
                          <td style="font-size: 15px;font-family: Meera;" align="center">ആശുപത്രി മുഖേന</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center">നേരിട്ട്</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                            
                            <td style="font-size: 15px;font-family: Meera;" align="center">ആശുപത്രി മുഖേന</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center">നേരിട്ട്</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                          
                          </tr>
                          
                          
                          <tr>
                         <td style="height: 17px;"> 
                         <asp:TextBox ID="intdeathapplicationhospital"  Text='<%# Eval("intdeathapplicationhospital") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>&nbsp;
                         
                         </td>
                        <td style=" height: 17px;"><asp:TextBox ID="intdeathapplicationdirect" Text='<%# Eval("intdeathapplicationdirect") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intdeathcertwithintimelimit" Text='<%# Eval("intdeathcertwithintimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        
                        
                            <td style=" height: 17px;"> <asp:TextBox ID="intdeathcertaftertimelimit"  Text='<%# Eval("intdeathcertaftertimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        <td style=" height: 17px;"><asp:TextBox ID="chvdeathremarks" Text='<%# Eval("chvdeathremarks") %>' runat ="server"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intdeathapplicationhospitalaud"  Text='<%# Eval("intdeathapplicationhospitalaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"> </asp:TextBox></td>
                         
                         <td style=" height: 17px;"><asp:TextBox ID="intdeathapplicationdirectaud"  Text='<%# Eval("intdeathapplicationdirectaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"> </asp:TextBox></td>
                         <td style="height: 17px;"><asp:TextBox ID="intdeathcertwithintimelimitaud"  Text='<%# Eval("intdeathcertwithintimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intdeathcertaftertimelimitaud"  Text='<%# Eval("intdeathcertaftertimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="chvdeathremarksaud"  Text='<%# Eval("chvdeathremarksaud") %>' runat ="server"></asp:TextBox></td>
                       </tr></table>
                       
                       
                       
                       </div>
                       
                       
                           <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           
4. വിവാഹ രജിസ്ട്രേഷന്‍
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><?xml namespace=""
        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                    
                    
                      <div class="table table-striped table-bordered">
                       
                       
                           <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                       
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" colspan="4" align="center"> നിലവിലുള്ള വിവരങ്ങള്‍ </td> 
                       
                       <td style="font-size: 15px;font-family: Meera;"  colspan="4" align="center">   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ </td>
                       </tr>
                       
                       <tr>
                       <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                       
                        <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍</td>
                        <td style="font-size: 15px;font-family: Meera;" align="center"colspan="2">സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍</td>
                         <td style="font-size: 15px;font-family: Meera;" align="center" rowspan="2">റിമാര്‍ക്ക്സ്</td>
                         
                        
                    
                          </tr>
                          <tr>
                       
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                    
                         <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധിക്കുള്ളില്‍</td>
                            <td style="font-size: 15px;font-family: Meera;" align="center">സമയ പരിധി കഴിഞ്ഞ്</td>
                          
                          </tr>
                          
                          
                          <tr>
                         <td style="height: 17px;"> 
                         <asp:TextBox ID="intmarriageapplication"  Text='<%# Eval("intmarriageapplication") %>' runat ="server"></asp:TextBox>&nbsp;
                         
                         </td>
                       
                        
                            <td style=" height: 17px;"> <asp:TextBox ID="intmarragecertwithintimelimit"  Text='<%# Eval("intmarragecertwithintimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                        <td style=" height: 17px;"><asp:TextBox ID="intmarriagecertaftertimelimit" Text='<%# Eval("intmarriagecertaftertimelimit") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="chvmarriageremarks"  Text='<%# Eval("chvmarriageremarks") %>' runat ="server"></asp:TextBox></td>
                         
                         <td style=" height: 17px;"><asp:TextBox ID="intmarriageapplicationaud"  Text='<%# Eval("intmarriageapplicationaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intmarragecertwithintimelimitaud"  Text='<%# Eval("intmarragecertwithintimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="intmarriagecertaftertimelimitaud"  Text='<%# Eval("intmarriagecertaftertimelimitaud") %>' runat ="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox></td>
                         <td style=" height: 17px;"><asp:TextBox ID="chvmarriageremarksaud"  Text='<%# Eval("chvmarriageremarksaud") %>' runat ="server"></asp:TextBox></td>
                       </tr></table>
                       
                       
                       
                       </div>
                       
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

