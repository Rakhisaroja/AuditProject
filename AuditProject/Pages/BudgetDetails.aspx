<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="BudgetDetails.aspx.cs" Inherits="Pages_BudgetDetails"   %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >ബഡ്ജറ്റ് വിവരങ്ങള്‍
                    </div>
                        <div class="card">
                           
                       <div class="table table-striped table-bordered">--%>
                       <div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                   <%-- <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>--%>
                    
                          <div class="card-header">
                                <strong class="card-titlen">           
ബഡ്ജറ്റ് വിവരങ്ങള്‍

</strong>
                                
                            </div>
                            
                            
        
                        <%--<div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                            <asp:TextBox ID="TextBox11"  runat="server" TabIndex="1" Width="200px"   CssClass="txtDate" ReadOnly="true" ></asp:TextBox>
                             --%>     
                               
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                        
                        
                        
                          <table runat="server" id="Table1"> <tr> <td style="width: 200px; height: 21px;" colspan="4"></td></tr> 
                         <tr >
                          <td colspan="3"   align="center" style="font-size: 20px;font-family: Meera;">
                                    <asp:Label ID="Label7"   runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                                 <td  style="font-size: 20px;font-family: Meera;" >
                                    <asp:Label ID="Label8"  runat="server" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                         </tr> 
                         
                         
                          <tr >
                          <td colspan="2"   align="center" rowspan="4"  style="font-family:Meera;font-size:18px; width: 250px;" >
                                    <asp:Label ID="Label9"   runat="server" Text="വിവിധ സ്റ്റാന്റിംഗ് കമ്മിറ്റികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബഡ്ജറ്റ് നിര്‍ദ്ദേശങ്ങള്‍ സമര്‍പ്പിച്ച തീയതി  : " Width="400px" ></asp:Label>
                                   
                                </td>
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left"  >
                                    <asp:Label ID="Label10"  runat="server" Text="വികസനം  : " Width="125px" ></asp:Label>
                                    <asp:TextBox ID="txtDvlpmnt"  runat="server" TabIndex="1" Width="125px" CssClass="txtDate" ReadOnly="true" ></asp:TextBox>
                                    
                                </td>
                                
                                 <td style="width: 400px; height: 32px;" align="left"  >
                                   
                                    
                                    <asp:TextBox ID="txtDvlpmntAudt" ReadOnly="true" CssClass="txtDate"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                              
                               
                                </td>
                               
                         </tr> 
                         
                         
                         
                          <tr> <td style="width: 400px;  font-family:Meera;font-size:18px; height: 32px;" align="left">
                              <asp:Label runat="server" 
                                  ID="Label11"
                                  
                                  Text="ക്ഷേമം  :" Width="125px"></asp:Label>
                                   <asp:TextBox ID="txtWlfr" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px" CssClass="txtDate" ></asp:TextBox>
                                   
                                 </td> <td style="width: 400px;font-family:Meera; height: 32px;" align="left">
                                  
                             
                                   <asp:TextBox ID="txtWlfrAudt" ReadOnly="true"   runat="server" TabIndex="1"  Width="125px" CssClass="txtDate"></asp:TextBox>
                                  
                                  </td></tr> 
                         
                         <tr> <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                             <asp:Label
                                 ID="Label12"
                                 runat="server"
                                 Text="ആരോഗ്യം    : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtHealth"  ReadOnly="true"  runat="server" TabIndex="1"  Width="125px" CssClass="txtDate" ></asp:TextBox>
                                
                                 
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                                  
                                   <asp:TextBox ID="txtHealthAudt" ReadOnly="true"   runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"></asp:TextBox>
                                  
                                  </td>
                                 </tr> 
                                  <tr> <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                             <asp:Label
                                 ID="Label13"
                                 runat="server"
                                 Text="വിദ്യാഭ്യാസം   : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtedu" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px" CssClass="txtDate"></asp:TextBox>
                                 
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                                  
                                   <asp:TextBox ID="txteduAudt" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px" CssClass="txtDate" ></asp:TextBox>
                                 
                                  </td>
                                 </tr> 
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label5"  runat="server" Text="ബഡ്ജറ്റ് അവതരിപ്പിച്ച തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtBdgtDat" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" CssClass="txtDate"></asp:TextBox>
                                 
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtBdgtDatAudt" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" CssClass="txtDate"></asp:TextBox>
                                   
                                </td>
                               
                              </tr> 
                              <tr> <td style="width: 200px; height: 21px;font-family:Meera;font-size:18px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; font-family:Meera;font-size:18px; height: 28px;"   colspan="2" >
                                    <asp:Label ID="Label1"  runat="server" Text="ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtBdgtPassDt" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" CssClass="txtDate"></asp:TextBox>
                                 
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtBdgtPassDtAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px" CssClass="txtDate"></asp:TextBox>
                                    
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label2"  runat="server" Text="തീരുമാന നമ്പര്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtOrdrNum" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  ></asp:TextBox>
                                </td> 
                                <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtOrdrNumAudt"  ReadOnly="true"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 20px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 28px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label3"  runat="server" Text="മുന്നിരിപ്പ്" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtOpening" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" OnTextChanged="txtOpening_TextChanged"    ></asp:TextBox>
                                </td>
                                <td style="width: 200px; height: 28px;"  align="left">
                                     <asp:TextBox ID="txtOpeningAudt" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label4"  runat="server" Text="തന്‍വര്‍ഷം വരവ്" Width="400px" ></asp:Label>
                                   
                                </td>
                              
                              <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtIncm" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  CssClass="floatnumbers" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px;" align="left">
                                     <asp:TextBox ID="txtIncmAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px" CssClass="floatnumbers"  ></asp:TextBox>
                                </td>
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                                <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2">
                                    <asp:Label ID="Label6"  runat="server" Text="ആകെ" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtTotal" Enabled="false"  runat="server" TabIndex="1" Width="125px"  CssClass="floatnumbers"  ></asp:TextBox>
                                </td>
                                <td style="width: 200px; "  align="left">
                                     <asp:TextBox ID="txtTotalAudt"  runat="server" TabIndex="1" Width="125px"  CssClass="floatnumbers" Enabled="False" ></asp:TextBox>
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
                             
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtExpndture" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" CssClass="floatnumbers" ></asp:TextBox>
                                </td>
                                <td style="width: 200px; "  align="left">
                                     <asp:TextBox ID="txtExpndtureAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  CssClass="floatnumbers"  ></asp:TextBox>
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
                               
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtBlnce" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  ></asp:TextBox>
                                </td>
                                <td style="width: 200px; "  align="left">
                                     <asp:TextBox ID="txtBlnceAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"   ></asp:TextBox>
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
                               
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtrevisedbudgetDt"  ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate" ></asp:TextBox>
                                  
                                </td>
                                <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtrevisedbudgetDtAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"  ></asp:TextBox>
                                   
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
                             
                              <td style="width: 200px; height: 21px;" align="left";>
                                     <asp:TextBox ID="txtdecision" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" OnTextChanged="txtdecision_TextChanged" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="left">
                                     <asp:TextBox ID="txtdecisionAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
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
                             
                              <td style="width: 200px; height: 21px;" align="left";>
                                     <asp:TextBox ID="txtresolutionno" ReadOnly="true"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                              
                                 <td style="width: 200px; height: 21px;" align="left">
                                     <asp:TextBox ID="txtresolutionnoAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
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
                             
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtStataudtdcn" ReadOnly="true"   runat="server" TabIndex="1" Width="325px" TextMode="MultiLine" ></asp:TextBox>&nbsp;
                                  <asp:TextBox
                                      ID="txtStataudtdcnNo"
                                      runat="server"
                                     placeholder="No"
                                      ReadOnly="true"
                                      TabIndex="1"
                                      Width="125px"></asp:TextBox>
                                  <br />
                                  <asp:TextBox
                                      ID="txtStataudtdate"
                                      runat="server"
                                      CssClass="txtDate"
                                      ReadOnly="true"
                                      TabIndex="1"
                                      placeholder="Date"
                                      Width="125px"></asp:TextBox></td>
                              
                                 <td style="width: 200px; " align="left">
                                     &nbsp;<asp:TextBox
                                         ID="txtStataudtdcnAudt"
                                         runat="server"
                                      
                                         ReadOnly="true"
                                         TabIndex="1"
                                         TextMode="MultiLine"
                                         Width="325px"></asp:TextBox><br />
                                     <asp:TextBox
                                         ID="txtStataudtdcnNoAudt"
                                         runat="server"
                                       placeholder="No"
                                         ReadOnly="true"
                                         TabIndex="1"
                                         Width="125px"></asp:TextBox><br />
                                     <asp:TextBox ID="txtStataudtdateAudt"  ReadOnly="true"  runat="server"   placeholder="Date"  TabIndex="1" Width="125px"  CssClass="txtDate" ></asp:TextBox></td>
                              </tr> 
                              
                              
                                <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr> <td style="width: 200px; height: 21px;" colspan="3" align="center">
                                   &nbsp;</td></tr> 
                              </table>
                            
                            
</div></div>
<div> <table width="100%"> <tr><td style="width: 1200px; height: 51px;" align="Center">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
                               <asp:Button
                                    ID="btnSave"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
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
   <script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>
<script type="text/javascript">
function validatenumericamount(kbevent) {
  
    var keyCode, keyChar;
    keyCode = kbevent.keyCode;
    if (window.event)
        keyCode = kbevent.keyCode;
    else
        keyCode = kbevent.which;
    if (keyCode === null)
        return true;
    keyChar = String.fromCharCode(keyCode);
    var charSet = "0123456789.";
    if (charSet.indexOf(keyChar) !== -1) {
        return true;
    }
    if (keyCode === null || keyCode === 0 || keyCode === 8 || keyCode === 9 || keyCode === 13 || keyCode === 27)
        return true;
    return false;
}

    </script>


</asp:Content>
