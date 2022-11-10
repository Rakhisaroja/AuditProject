<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="FrontOffice_Urban.aspx.cs" Inherits="Pages_FrontOffice_Urban" Title="FrontOffice_Urban" %>

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
എ) ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി

</strong>
                                
                            </div>
                            
                            
        
                        <%--<div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                            <asp:TextBox ID="TextBox11"  runat="server" TabIndex="1" Width="200px"    CssClass="txtDate"       ReadOnly="true" ></asp:TextBox>
                             --%>     
                               
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                        
                        
                        
                          <table runat="server" id="Table1"> <tr> <td style="width: 200px; height: 21px;" colspan="4"></td></tr> 
                         <tr >
                          <td colspan="3"   align="center" style="font-size: 20px;font-family: Meera;">
                                    <asp:Label ID="Label7"   runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                                 <td  style="font-size: 20px;font-family: Meera;"  colspan="3">
                                    <asp:Label ID="Label8"  runat="server" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍  : " ></asp:Label>
                                   
                                </td>
                         </tr> 
                         
                         <tr>
                         
                         <td   align="left" style="font-size: 20px;font-family: Meera" colspan="2">
                                    <asp:Label ID="Label12"   runat="server" Text="ഫ്രണ്ട് ഓഫീസ് ഭൌതിക സൌകര്യങ്ങള്‍" Font-Bold="True" Font-Size="Smaller" ></asp:Label> </td>
                                    
                                    
                                    <td style="font-size: 20px;font-family: Meera"  colspan="2">
                                    <asp:Label ID="Label13"   runat="server" Text="ഉണ്ട്/ഇല്ല" Width="110px" Font-Bold="True" Font-Size="Smaller" ></asp:Label>
                                   
<asp:Label ID="Label14"   runat="server" Text="അഭിപ്രായകുറിപ്പ്" Width="196px"  Font-Bold="True" Font-Size="Smaller" ></asp:Label>
                                   
                                   
                                </td>
                       
                                    
                                    
                                    <td style="font-size: 20px;font-family: Meera" colspan="2">
                                    <asp:Label ID="Label16"   runat="server" Text="ഉണ്ട്/ഇല്ല" Width="110px" Font-Bold="True" Font-Size="Smaller" ></asp:Label>
                                   
<asp:Label ID="Label17"   runat="server" Text="അഭിപ്രായകുറിപ്പ്" Width="196px" Font-Bold="True" Font-Size="Smaller" ></asp:Label>
                                   
                                   
                                </td>
                         
                         </tr>
                         
                        
                                 
                                 
                                 
                                          <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label23"  runat="server" Text="1.ഫ്രണ്ട് ഓഫീസ് കൌണ്ടര്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td valign="top"><asp:DropDownList ID="ddlcounter" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtcounter" ReadOnly="true"  runat="server" TabIndex="1" Height="50px"                   Width="213px" TextMode="MultiLine"  ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                 
                                    <asp:DropDownList ID="ddlcounterAud" runat="server"   Width="98px" >
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtcounterAud" ReadOnly="true"  runat="server" TabIndex="1"      Height="50px"          Width="213px" TextMode="MultiLine"        ></asp:TextBox>
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                              
                              
                              
                                          <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label1"  runat="server" Text="2.അവധി ദിവസങ്ങളിലും, ഓഫീസ് പ്രവര്‍ത്തനത്തിനും ശേഷം അപേക്ഷകളും മറ്റും നിക്ഷേപിക്കുന്നതിനുള്ള തപാല്‍പെട്ടി" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddlthapal" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txttapaldet" ReadOnly="true"  runat="server" TabIndex="1"        Height="50px"        Width="213px" TextMode="MultiLine"      ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddlthapalAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txttapaldetAud" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"           Width="213px" TextMode="MultiLine"      ></asp:TextBox>
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                              
                              
                              
                              
                               <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label2"  runat="server" Text="3.സൗകര്യപ്രദമായ ഇരിപ്പിടങ്ങള്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddlseat" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtseatdet" ReadOnly="true"  runat="server" TabIndex="1"         Height="50px"       Width="213px" TextMode="MultiLine"    ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddlseatAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtseatdetAud" ReadOnly="true"  runat="server" TabIndex="1"    Height="50px"            Width="213px" TextMode="MultiLine"      ></asp:TextBox>
                                </td>
                               
                              </tr> 
                                        
                                        
                                        
                                       
                                       
                                       
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label3"  runat="server" Text="4.ഭിന്നശേഷിയുള്ളവര്‍ക്ക് റാമ്പ് സംവിധാനം" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddlramp" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtramp" ReadOnly="true"  runat="server" TabIndex="1"         Height="50px"       Width="213px" TextMode="MultiLine"       ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddlrampAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtrampAud" ReadOnly="true"  runat="server" TabIndex="1"    Height="50px"            Width="213px" TextMode="MultiLine"        ></asp:TextBox>
                                </td>
                               
                              </tr>           
                                       
                                        
                                  
                                  
                                   <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label4"  runat="server" Text="5.ടോക്കണ്‍ സമ്പ്രദായം" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddltocken" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txttocken" ReadOnly="true"  runat="server" TabIndex="1"       Height="50px"         Width="213px" TextMode="MultiLine"       ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddltockenAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txttockenAud" ReadOnly="true"  runat="server" TabIndex="1"  Height="50px"              Width="213px" TextMode="MultiLine"        ></asp:TextBox>
                                </td>
                               
                              </tr>               
                                        
                              
                              
                              
                               <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label5"  runat="server" Text="6.കുടിവെള്ളം" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddldrinkwtr" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtdrnkwtr" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"           Width="213px" TextMode="MultiLine"     ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddldrinkwtrAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtdrnkwtrAud" ReadOnly="true"  runat="server" TabIndex="1"   Height="50px"             Width="213px" TextMode="MultiLine"      ></asp:TextBox>
                                </td>
                               
                              </tr>               
                                        
                             
                             
                             
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label6"  runat="server" Text="7.ശുചിമുറി" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddltoilet" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txttoilet" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"           Width="213px" TextMode="MultiLine"   ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddltoiletAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txttoiletAud" ReadOnly="true"  runat="server" TabIndex="1"   Height="50px"             Width="213px" TextMode="MultiLine"        ></asp:TextBox>
                                </td>
                               
                              </tr>       
                              
                              
                              
                              
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label9"  runat="server" Text="8.പത്രമാസികകള്‍, ലഘുലേഖകള്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddlmagazine" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtmagazine" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"         Width="213px" TextMode="MultiLine"       ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddlmagazineAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtmagazineAud" ReadOnly="true"  runat="server" TabIndex="1"   Height="50px"             Width="213px" TextMode="MultiLine"       ></asp:TextBox>
                                </td>
                               
                              </tr> 
                              
                              
                              
                                <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label10"  runat="server" Text="9.നഗരസഭയുടെ വിവിധ പദ്ധതികളും സേവനങ്ങളും സംബന്ധിച്ച വിവരങ്ങള്‍ അറിയിപ്പുകള്‍
പ്രദര്‍ശിപ്പിക്കുന്നതിന് ടെലിവിഷന്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddltelvn" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txttelvn" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"           Width="213px" TextMode="MultiLine"      ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddltelvnAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txttelvnAud" ReadOnly="true"  runat="server" TabIndex="1"  Height="50px"           Width="213px" TextMode="MultiLine"      ></asp:TextBox>
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label11"  runat="server" Text="10.അപേക്ഷ ഫോറങ്ങള്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                         <td><asp:DropDownList ID="ddlapplnform" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                    
                                     <asp:TextBox ID="txtapplform" ReadOnly="true"  runat="server" TabIndex="1"     Height="50px"           Width="213px" TextMode="MultiLine"      ></asp:TextBox>
               <%-- <asp:TextBox ID="tnystatusreport" runat="server" Text='<%# Eval("tnystatusreport") %>' />--%>
            </td>
                         
                             
                              
                                <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2">
                                 
                                    <asp:DropDownList ID="ddlapplnformAud" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox ID="txtapplformAud" ReadOnly="true"  runat="server" TabIndex="1"   Height="50px"             Width="213px" TextMode="MultiLine"      ></asp:TextBox>
                                </td>
                               
                              </tr> 
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
                                        Text="NEXT" Width="62px" Visible="false" />
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

