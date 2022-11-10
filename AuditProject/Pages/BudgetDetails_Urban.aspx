<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="BudgetDetails_Urban.aspx.cs" Inherits="Pages_BudgetDetails_Urban" Title="BudgetDetails" %>

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
I(ii)ബഡ്ജറ്റ് വിവരങ്ങള്‍

</strong>
                                
                            </div>
                            
                            
        
                        <%--<div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>
                            <asp:TextBox ID="TextBox11"  runat="server" TabIndex="1" Width="200px"    CssClass="txtDate"       ReadOnly="true" ></asp:TextBox>
                             --%>     
                               
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:1200px" >
                        
                        
                        
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
                          <td colspan="2"   align="center" rowspan="7"  style="font-family:Meera;font-size:18px; width: 250px;" >
                                    <asp:Label ID="Label9"   runat="server" Text="വിവിധ സ്റ്റാന്റിംഗ് കമ്മിറ്റികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബഡ്ജറ്റ് നിര്‍ദ്ദേശങ്ങള്‍ സമര്‍പ്പിച്ച തീയതി  : " Width="400px" ></asp:Label>
                                   
                                </td>
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left"  >
                                    <asp:Label ID="Label10"  runat="server" Text="വികസനം  : " Width="125px" ></asp:Label>
                                    <asp:TextBox ID="txtDvlpmnt"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"       ReadOnly="true" ></asp:TextBox>
                                    <asp:CompareValidator
    id="CompareValidator28" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtDvlpmnt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                </td>
                                
                                 <td style="width: 400px; height: 32px;" align="left"  >
                                   
                                    
                                    <asp:TextBox ID="txtDvlpmntAudt" ReadOnly="true"  CssClass="txtDate"          runat="server" TabIndex="1"  Width="125px" ></asp:TextBox>
                              <asp:CompareValidator
    id="CompareValidator29" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtDvlpmntAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                               
                                </td>
                               
                         </tr> 
                         
                         
                         
                          <tr> <td style="width: 400px;  font-family:Meera;font-size:18px; height: 32px;" align="left">
                              <asp:Label runat="server" 
                                  ID="Label11"
                                  
                                  Text="ക്ഷേമം  :" Width="125px"></asp:Label>
                                   <asp:TextBox ID="txtWlfr" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate" ></asp:TextBox>
                                    <asp:CompareValidator
    id="CompareValidator1" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtWlfr" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 </td> <td style="width: 400px;font-family:Meera; height: 32px;" align="left">
                                  
                             
                                   <asp:TextBox ID="txtWlfrAudt" ReadOnly="true"   runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"        ></asp:TextBox>
     <asp:CompareValidator
    id="CompareValidator2" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtWlfrAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td></tr> 
                         
                         <tr> <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                             <asp:Label
                                 ID="Label12"
                                 runat="server"
                                 Text="ആരോഗ്യം    : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtHealth"  ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"  ></asp:TextBox>
                                
                                 
                                 <asp:CompareValidator
    id="CompareValidator3" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtHealth" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 
                                 
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                                  
                                   <asp:TextBox ID="txtHealthAudt" ReadOnly="true"   runat="server" TabIndex="1"  Width="125px"   CssClass="txtDate"         ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator4" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtHealthAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td>
                                 </tr> 
                                 
                                 
                                 
                                 
                                 
                                 
                                  <tr> <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                             <asp:Label
                                 ID="Label20"
                                 runat="server"
                                 Text="മരാമത്ത്   : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtcarrom"  ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                
                                 <asp:CompareValidator
    id="CompareValidator5" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtcarrom" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                                  
                                   <asp:TextBox ID="txtcarromAudt" ReadOnly="true"   runat="server" TabIndex="1"  Width="125px"   CssClass="txtDate"       ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator6" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtcarromAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td>
                                 </tr> 
                                 
                                 
                                 
                                 
                                  <tr> <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                                 <asp:Label
                                 ID="Label13"
                                 runat="server"
                                 Text="വിദ്യാഭ്യാസ കലാകായികം : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txtedu" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator30" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtedu" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px; height: 32px;" align="left">
                                  
                                   <asp:TextBox ID="txteduAudt" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"       ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator7" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txteduAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td>
                                 </tr> 
                                 
                                 
                                 <tr> <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                                 <asp:Label
                                 ID="Label21"
                                 runat="server"
                                 Text="നഗരാസൂത്രണo   : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txttownplan" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                 <asp:CompareValidator
    id="CompareValidator8" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txttownplan" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                                  
                                   <asp:TextBox ID="txttownplanAud" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"       ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator9" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txttownplanAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td>
                                 </tr> 
                                 
                                 
                                    <tr> <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                                 <asp:Label
                                 ID="Label22"
                                 runat="server"
                                 Text="നികുതി അപ്പീല്‍   : " Width="125px"></asp:Label>
                                  <asp:TextBox ID="txttax" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator10" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txttax" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                 </td>
                                  <td style="width: 400px; font-family:Meera;font-size:18px;" align="left">
                                  
                                   <asp:TextBox ID="txttaxAud" ReadOnly="true"  runat="server" TabIndex="1"  Width="125px"  CssClass="txtDate"       ></asp:TextBox>
                                 <asp:CompareValidator
    id="CompareValidator11" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txttaxAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                  </td>
                                 </tr> 
                                 
                                 
                                 
                                          <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label23"  runat="server" Text="കൈമാറിക്കിട്ടിയ സ്ഥാപന മേധാവികളുടെ യോഗം വിളിച്ച തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtmeetdte" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                 <asp:CompareValidator
    id="CompareValidator12" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtmeetdte" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtmeetdteAud" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                   <asp:CompareValidator
    id="CompareValidator13" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtmeetdteAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                                          <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label24"  runat="server" Text="കൈമാറിക്കിട്ടിയ സ്ഥാപന മേധാവികളുടെ യോഗം ചേര്‍ന്ന  തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtmeetconddte" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                 <asp:CompareValidator
    id="CompareValidator14" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtmeetconddte" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtmeetconddteAud" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                   
                                  <asp:CompareValidator
    id="CompareValidator15" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtmeetconddteAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                   
                                   
                                </td>
                               
                              </tr> 
                              
                              
                              
                                <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label25"  runat="server" Text="കൈമാറിക്കിട്ടിയ സ്ഥാപന മേധാവികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബജറ്റ് നിര്‍ദ്ദേശങ്ങള്‍
                                    സമര്‍പ്പിച്ച   തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtsubmitdte" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                    
                                    <asp:CompareValidator
    id="CompareValidator16" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtsubmitdte" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                    
                                    
                                     <br />
                                     <asp:Label ID="label29" runat="server" Text="ഉദ്യോഗസ്ഥരുടെ എണ്ണം"  Font-Size="Smaller"/>
                                <asp:TextBox ID="txtnoofMember" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" OnTextChanged="txtnoofMember_TextChanged" AutoPostBack="True" />
                            <asp:Button ID="btnMember" runat="server" OnClick="btnMember_Click" Text="Show" Width="48px" />
                                      
                                     <%-- <asp:Button ID="btnAddNewofficer" runat="server" Text="Add New" OnClick="btnAddNewofficer_Click" />--%>
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtsubmitdteAud" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                    <asp:CompareValidator
    id="CompareValidator17" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtsubmitdteAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                </td>
                               
                              </tr> 
                              
                              <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td align="left" colspan="3"> 
                           <asp:Label ID="lblnoofMember" runat="server" Text="ഉദ്യോഗസ്ഥരുടെ (പേര് വിവരം)" Visible="False" Font-Bold="True" Font-Names="Meera" /> </td>
                       
                        </tr>
                        <tr><td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="3">
                        <asp:Repeater ID="grvMembers" runat="server" OnItemCommand="grvMembers_ItemCommand" Visible="False"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 16px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  style="width:100px"  align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center; width:300px; font-family:Meera"  align="center"    >
                    ഉദ്യോഗസ്ഥന്‍റെ പേര്
                </th>
                  <th scope="col"  style="text-align:center; width:300px;font-family:Meera"   align="center"   >
                    ഉദ്യോഗസ്ഥന്‍റെ പേര് (ഓഡിറ്റില്‍ കണ്ടെത്തിയത്)
                </th>
                    <th scope="col"  style="text-align:center; width:80px;font-family:Meera"  align="center"   >
                    
                </th>
                          
            </tr>
            
     
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:100px">
                <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' /> 
                 <asp:Label ID="intslno"  Visible="false" runat="server" Text='<%# Eval("intslno") %>' /> </td>
            <td style="width:400px"> 
            <asp:TextBox ID="chvnameofofficermal" runat="server" Text='<%# Eval("chvnameofofficermal") %>' />
            </td >
            <td style="width:400px"><asp:TextBox ID="chvAuditnameofofficermal" runat="server" Text='<%# Eval("chvAuditnameofofficermal") %>' />   
         <td><asp:Button ID="btnDeleteMem" runat="server" Text="X" ForeColor="Red" Width="25px" Height="25px" OnClick="btnDeleteMem_Click" /></td>
          
             
           </tr></ItemTemplate>
           <FooterTemplate></table></FooterTemplate>
                        


</asp:Repeater>
                        </td>
                        </tr>
                              
                                 
                                 
                                 
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label5"  runat="server" Text="ബഡ്ജറ്റ് അവതരിപ്പിച്ച തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtBdgtDat" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator18" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtBdgtDat" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtBdgtDatAudt" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate" ></asp:TextBox>
                                   <asp:CompareValidator
    id="CompareValidator19" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtBdgtDatAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                              
                              
                              <tr> <td style="width: 200px; height: 21px;font-family:Meera;font-size:18px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; font-family:Meera;font-size:18px; height: 28px;"   colspan="2" >
                                    <asp:Label ID="Label1"  runat="server" Text="ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtBdgtPassDt" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                 
                                 
                                 <asp:CompareValidator
    id="CompareValidator20" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtBdgtPassDt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtBdgtPassDtAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                     <asp:CompareValidator
    id="CompareValidator21" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtBdgtPassDtAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
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
                               
                              </tr> 
                              
                              
                              
                              
                             <%-- new start--%>
                              
                              
                              <tr>
                            
                             
                                 <td style="width: 400px; font-family:Meera;font-size:18px; height: 28px;" align="left" colspan="2" >
                                    <asp:Label ID="Label26"  runat="server" Text="സപ്ലിമെന്ററി/റിവൈസ്ട് ബഡ്ജറ്റ് തയ്യാറാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                         
                              <td style="width: 200px; height: 28px;" align="left">
                            
                                  <asp:TextBox ID="txtrvseddte" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                  <asp:CompareValidator
    id="CompareValidator22" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtrvseddte" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                 
                                     <asp:TextBox ID="txtrvseddteAud" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                   
                                    <asp:CompareValidator
    id="CompareValidator23" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtrvseddteAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                              
                              
                              <tr> <td style="width: 200px; height: 21px;font-family:Meera;font-size:18px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; font-family:Meera;font-size:18px; height: 28px;"   colspan="2" >
                                    <asp:Label ID="Label27"  runat="server" Text="സപ്ലിമെന്ററി ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtsuplpassdte" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                      <asp:CompareValidator
    id="CompareValidator24" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtsuplpassdte" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                 
                                 
                                 
                                </td>
                                <td style="width: 200px; height: 28px;" align="left">
                                     <asp:TextBox ID="txtsuplpassdteAud" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  CssClass="txtDate"      ></asp:TextBox>
                                    
                                <asp:CompareValidator
    id="CompareValidator25" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtsuplpassdteAud" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                
                                
                                </td>
                               
                              </tr>   <tr> <td style="width: 200px; height: 21px;" colspan="3"></td></tr> 
                               <tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2" >
                                    <asp:Label ID="Label28"  runat="server" Text="തീരുമാന നമ്പര്‍" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtsuplordernum" ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  ></asp:TextBox>
                                </td> 
                                <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtsuplordernumAud"  ReadOnly="true"  runat="server" TabIndex="1" Width="125px" ></asp:TextBox>
                                </td>
                               
                              </tr> 
                              
                              
                              
                              
                               <%-- new end--%>
                              
                              
                              
                              
                              
                                <tr> <td style="width: 200px; height: 20px;" colspan="3"></td></tr> 
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
                                     <asp:TextBox ID="txtBlnce" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"   ></asp:TextBox>
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
                               <%--<tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;"  colspan="2">
                                    <asp:Label ID="Label15"  runat="server" Text="സപ്ലിമെന്ററി / റിവെെസ്ഡ് ബഡ്ജറ്റ് തയ്യാറാക്കിയ തീയതി" Visible="false" Width="400px" ></asp:Label>
                                   
                                </td>
                               
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtrevisedbudgetDt"  ReadOnly="true"  runat="server" TabIndex="1" Width="125px"  Visible="false"   CssClass="txtDate"       ></asp:TextBox>
                                  
                                </td>
                                <td style="width: 200px; " align="left">
                                     <asp:TextBox ID="txtrevisedbudgetDtAudt" ReadOnly="true"   runat="server" TabIndex="1" Width="125px"  Visible="false"   CssClass="txtDate"        ></asp:TextBox>
                                   
                                </td>
                               
                              </tr> --%>
                               <%--<tr>
                            
                             
                                 <td style="width: 200px; height: 21px; font-family:Meera;font-size:18px;" >
                                   
                                </td>
                                <td style="width: 200px; height: 21px;" >
                                </td>
                              <td style="width: 200px; height: 21px;" align="center";>
                                </td>
                              
                               
                              </tr>--%>
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
                                    <asp:Label ID="Label19"  runat="server" Text="പാസ്സാക്കിയ വാര്‍ഷിക ബഡ്ജറ്റിന്റെ പകര്‍പ്പ് സംസ്ഥാന ഒാഡിറ്റ് വകുപ്പിന് നല്‍കിയ തീയതി" Width="400px" ></asp:Label>
                                   
                                </td>
                             
                              <td style="width: 200px; " align="left";>
                                     <asp:TextBox ID="txtStataudtdcn" ReadOnly="true"  Visible="false"  runat="server" TabIndex="1" Width="325px" TextMode="MultiLine" ></asp:TextBox>&nbsp;
                                  <asp:TextBox
                                      ID="txtStataudtdcnNo"
                                      runat="server"
                                     placeholder="No"
                                      ReadOnly="true"
                                      TabIndex="1"
                                      Width="125px" Visible="false"></asp:TextBox>
                                  <br />
                                  <asp:TextBox
                                      ID="txtStataudtdate"
                                      runat="server"
                                       CssClass="txtDate"      
                                      ReadOnly="true"
                                      TabIndex="1"
                                      placeholder="Date"
                                      Width="125px"></asp:TextBox>
                                      
                                       <asp:CompareValidator
    id="CompareValidator26" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtStataudtdate" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                      
                                      
                                      </td>
                              
                                 <td style="width: 200px; " align="left">
                                     &nbsp;
                                      <asp:TextBox ID="txtStataudtdateAudt"  ReadOnly="true"  runat="server"   placeholder="Date"  TabIndex="1" Width="125px"   CssClass="txtDate"       ></asp:TextBox>
                                      <asp:CompareValidator
    id="CompareValidator27" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtStataudtdateAudt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                                     
                                     <asp:TextBox
                                         ID="txtStataudtdcnAudt"
                                         runat="server" Visible="false"
                                      
                                         ReadOnly="true"
                                         TabIndex="1"
                                         TextMode="MultiLine"
                                         Width="325px"></asp:TextBox><br />
                                     <asp:TextBox
                                         ID="txtStataudtdcnNoAudt"
                                         runat="server"
                                       placeholder="No"
                                         ReadOnly="true"
                                         TabIndex="1" Visible="false"
                                         Width="125px"></asp:TextBox><br />
                                    </td>
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

