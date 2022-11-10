<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_BudgetDetails, App_Web_cllhm4gw" title="Untitled Page" %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >ബഡ്ജറ്റ് വിവരങ്ങള്‍
                    </div>
                        <div class="card">
                           
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                        
                        
                        
                          <table runat="server"> <tr> <td style="width: 200px; height: 21px;" colspan="4"></td></tr> 
                         <tr >
                          <td colspan="3" style="color:Maroon; background-color: #9999cc; height: 25px;"  align="center">
                                    <asp:Label ID="Label7"   runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                                 <td style="width: 400px; color:Maroon;background-color: #9999cc; height: 25px;"  >
                                    <asp:Label ID="Label8"  runat="server" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                         </tr> 
                         
                         
                          <tr >
                          <td colspan="2"   align="center" rowspan="4"  style="font-family:Meera;font-size:18px; width: 250px;" >
                                    <asp:Label ID="Label9"   runat="server" Text="വിവിധ സ്റ്റാന്റിംഗ് കമ്മിറ്റികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബഡ്ജറ്റ് നിര്‍ദ്ദേശങ്ങള്‍ സമര്‍പ്പിച്ച തീയതി  : " Width="400px" ></asp:Label>
                                   
                                </td>
                                 <td style="width: 400px; color:Maroon;font-family:Meera;font-size:18px; height: 32px;"  >
                                    <asp:Label ID="Label10"  runat="server" Text="വികസനം  : " Width="125px" ></asp:Label>
                                    <asp:TextBox ID="txtDvlpmnt"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ></asp:TextBox>
                                    <cc1:CalendarExtender id="CalendarExtender3"  runat="server" TargetControlID="txtDvlpmnt" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                </td>
                                
                                 <td style="width: 400px; color:Maroon;font-family:Meera;font-size:18px; height: 32px;"  >
                                     &nbsp; &nbsp;
                                     &nbsp;
                                    
                                    <asp:TextBox ID="txtDvlpmntAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                               <cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtDvlpmntAudt" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                </td>
                               
                         </tr> 
                         
                         
                         
                          <tr> <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;">
                              <asp:Label runat="server" 
                                  ID="Label11"
                                  
                                  Text="ക്ഷേമം  :" Width="125px"></asp:Label>
                                   <asp:TextBox ID="txtWlfr"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                   <cc1:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="txtWlfr" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                 </td> <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;">
                                      &nbsp; &nbsp;
                                      &nbsp;
                             
                                   <asp:TextBox ID="txtWlfrAudt"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                   <cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="txtWlfrAudt" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                  </td></tr> 
                         
                         <tr> <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;">
                             <asp:Label
                                 ID="Label12"
                                 runat="server"
                                 Text="ആരോഗ്യം    : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtHealth"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                 <cc1:CalendarExtender id="CalendarExtender5" runat="server" TargetControlID="txtHealth" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                 </td>
                                  <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;">
                                      &nbsp; &nbsp;
                                      &nbsp;
                             
                                   <asp:TextBox ID="txtHealthAudt"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                   <cc1:CalendarExtender id="CalendarExtender6" runat="server" TargetControlID="txtHealthAudt" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                  </td>
                                 </tr> 
                                  <tr> <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;">
                             <asp:Label
                                 ID="Label13"
                                 runat="server"
                                 Text="വിദ്യാഭ്യാസം   : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtedu"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                   <cc1:CalendarExtender id="CalendarExtender7" runat="server" TargetControlID="txtedu" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                 </td>
                                  <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px;" align="left">
                                      &nbsp; &nbsp;
                                      &nbsp;
                             
                                   <asp:TextBox ID="txteduAudt"  runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                                   <cc1:CalendarExtender id="CalendarExtender8" runat="server" TargetControlID="txteduAudt" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
                                  </td>
                                 </tr> 
                              <tr>
                            
                             
                                 <td style="width: 400px; height: 21px;font-family:Meera;font-size:18px; " align="left" colspan="2" >
                                    <asp:Label ID="Label5"  runat="server" Text="ബഡ്ജറ്റ് അവതരിപ്പിച്ച തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 21px;" align="center">
                                  &nbsp;
                                  <asp:TextBox ID="txtBdgtDat"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                  <cc1:CalendarExtender id="CalendarExtender9" runat="server" TargetControlID="txtBdgtDat" Format="dd/MM/yyyy" PopupPosition="topleft">
                                  </cc1:CalendarExtender>
                                </td>
                                <td style="width: 200px; height: 21px;" align="left">
                                    &nbsp; &nbsp;
                                    &nbsp; &nbsp;
                                     <asp:TextBox ID="txtBdgtDatAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                    <cc1:CalendarExtender id="CalendarExtender10" runat="server" TargetControlID="txtBdgtDatAudt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                    </cc1:CalendarExtender>
                                </td>
                               
                              </tr> 
                              <tr> <td style="width: 200px; height: 21px;font-family:Meera;font-size:18px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"   colspan="2" >
                                    <asp:Label ID="Label1"  runat="server" Text="ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtBdgtPassDt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                  <cc1:CalendarExtender id="CalendarExtender11" runat="server" TargetControlID="txtBdgtPassDt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                  </cc1:CalendarExtender>
                                </td>
                                <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtBdgtPassDtAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                    <cc1:CalendarExtender id="CalendarExtender12" runat="server" TargetControlID="txtBdgtPassDtAudt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                    </cc1:CalendarExtender>
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label2"  runat="server" Text="തീരുമാന നമ്പര്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtOrdrNum"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td> 
                                <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtOrdrNumAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 20px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label3"  runat="server" Text="മുന്നിരിപ്പ്" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtOpening"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                                <td style="width: 200px; height: 21px;"  align="center">
                                     <asp:TextBox ID="txtOpeningAudt"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ></asp:TextBox>
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label4"  runat="server" Text="തന്‍വര്‍ഷം വരവ്" Width="400px" ></asp:Label>
                                   
                                </td>
                              
                              <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtIncm"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtIncmAudt"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2">
                                    <asp:Label ID="Label6"  runat="server" Text="ആകെ" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtTotal"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                                <td style="width: 200px; height: 21px;"  align="center">
                                     <asp:TextBox ID="txtTotalAudt"  runat="server" TabIndex="1" Width="125px"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ></asp:TextBox>
                                </td>
                               
                              </tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2">
                                    <asp:Label ID="Label17"  runat="server" Text="ചെലവ്" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtExpndture"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ></asp:TextBox>
                                </td>
                                <td style="width: 200px; height: 21px;"  align="center">
                                     <asp:TextBox ID="txtExpndtureAudt"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                               
                              </tr> 
                                  <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label14"  runat="server" Text="നീക്കിയിരിപ്പ്" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtBlnce"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                                <td style="width: 200px; height: 21px;"  align="center">
                                     <asp:TextBox ID="txtBlnceAudt"  runat="server" TabIndex="1" Width="125px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ></asp:TextBox>
                                </td>
                               
                              </tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2">
                                    <asp:Label ID="Label15"  runat="server" Text="സപ്ലിമെന്ററി / റിവെെസ്ഡ് ബഡ്ജറ്റ് തയ്യാറാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtrevisedbudgetDt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                  <cc1:CalendarExtender id="CalendarExtender13" runat="server" TargetControlID="txtrevisedbudgetDt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                  </cc1:CalendarExtender>
                                </td>
                                <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtrevisedbudgetDtAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                    <cc1:CalendarExtender id="CalendarExtender14" runat="server" TargetControlID="txtrevisedbudgetDtAudt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                    </cc1:CalendarExtender>
                                </td>
                               
                              </tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label16"  runat="server" Text="വാര്‍ഷിക ബഡ്ജറ്റില്‍ ഉള്‍പ്പെടാത്ത ചെലവുകള്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtdecision"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtdecisionAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                              </tr> 
                                 <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label18"  runat="server" Text="ബഡ്ജറ്റില്‍ ഉള്‍ക്കൊള്ളിച്ചതിനേക്കാള്‍ കൂടുതല്‍ ചെലവുകള്‍ ഏതെങ്കിലും ഇനത്തില്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtresolutionno"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtresolutionnoAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                              </tr> 
                                 <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label19"  runat="server" Text="പാസ്സാക്കിയ വാര്‍ഷിക ബഡ്ജറ്റിന്റെ പകര്‍പ്പ് സംസ്ഥാന ഒാഡിറ്റ് വകുപ്പിന് നല്‍കിയതിന്റെ വിവരം (തീരുമാനം, നം, തീയതി)" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; height: 21px;" align="center";>
                                     <asp:TextBox ID="txtStataudtdate"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                  <cc1:CalendarExtender id="CalendarExtender15" runat="server" TargetControlID="txtStataudtdate" Format="dd/MM/yyyy" PopupPosition="topleft">
                                  </cc1:CalendarExtender>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="center">
                                     <asp:TextBox ID="txtStataudtdateAudt"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                     <cc1:CalendarExtender id="CalendarExtender16" runat="server" TargetControlID="txtStataudtdateAudt" Format="dd/MM/yyyy" PopupPosition="topleft">
                                     </cc1:CalendarExtender>
                                </td>
                              </tr> 
                              
                              
                                <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr> <td style="width: 200px; height: 21px;" colspan="3" align="center">
                                   &nbsp;</td></tr> 
                              </table>
                            
                            
</div></div>
<div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;" colspan="3" align="center">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="Save" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
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
