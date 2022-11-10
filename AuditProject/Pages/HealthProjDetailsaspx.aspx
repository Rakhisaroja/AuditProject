<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="HealthProjDetailsaspx.aspx.cs" Inherits="Pages_HealthProjDetailsaspx"  %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">ചെലവ് ഭാഗം
                    </div>
            
                        <div class="card">
                           <div class="card-header">
                                <strong class="card-titlen">1. ആരോഗ്യമേഖല</strong>
                                
                            </div>
                             <div class="card-body">
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptHealth" runat="server"    >

       <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="10"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
            
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
               
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട് 
                </th>
                  </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് 
                </th>
            
                 <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                   
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" runat="server" Text='<%# Eval("chvProjectName") %>' />
                 <asp:Label ID="lbldecProjectID" runat="server" Text='<%# Eval("decProjectID") %>' Visible="false" />
                  <asp:Label ID="intWorkingGroupID" runat="server" Text='<%# Eval("intWorkingGroupID") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "fltDevFund" runat="server"  Text='<%# Eval("fltDevFund") %>'  CssClass="floatnumbers"   ReadOnly="true" />
          
            </td>
            <td><asp:TextBox ID= "fltMG" runat="server" Text='<%# Eval("fltMG") %>' CssClass="floatnumbers"  ReadOnly="true" /></td>
             <td>
                <asp:TextBox ID= "fltOwnFund" runat="server" Text='<%# Eval("fltOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltTotal" runat="server" Text='<%# Eval("fltTotal") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' CssClass="floatnumbers"  ReadOnly="true"  />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
                
               </td>  
                 <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  CssClass="floatnumbers"  ReadOnly="true" />
                
            
            </td>
            
              <td>
                <asp:TextBox ID= "fltTotalExp" runat="server" Text='<%# Eval("fltTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltaudTotal" runat="server" Text='<%# Eval("fltaudTotal") %>' CssClass="floatnumbers"  ReadOnly="true"  Enabled="false"/>
            </td>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            <td>
                <asp:TextBox ID= "fltaudTotalExp" runat="server" Text='<%# Eval("fltaudTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true"  Enabled="false"/>
            </td>
            </td>
           </tr></ItemTemplate>
                        
<FooterTemplate></table></FooterTemplate>

</asp:Repeater>


</div></div>
</div>
<div> <table width="100%"> <tr> 

<%--<td style="width: 53px; height: 51px;" >
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td>--%>
                                <td style="width: 1200px; height: 51px;" align="Center">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />&nbsp;
                               </td>
                               
                               </tr> 
                              </table>
                            </div>
                 
                 
                  <div class="card-body">
                        <div class="table table-striped table-bordered">
                 <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptHospDet" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="4" align="center"  >
                    ക്രമ. നം
                </th>
       <th scope="col"  style="text-align:center"  align="center" colspan="7"  >
                  നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="7"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                 <th scope="col"  rowspan="3" align="center"  >
                  ആശുപത്രി
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                 എണ്ണം
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                 ഇന്‍പേഷ്യന്‍സ് എണ്ണം
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                   ഔട്ട്പേഷ്യന്‍സ് എണ്ണം
                </th>
                 
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                  എച്ച്.എം.സി കള്‍ സംബന്ധിച്ചുള്ള വിവരങ്ങള്‍
                </th>
                            
                            
                            
                <th scope="col"  rowspan="3" align="center"  >
                  ആശുപത്രി
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                 എണ്ണം
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                 ഇന്‍പേഷ്യന്‍സ് എണ്ണം
                </th>
                 <th scope="col"  rowspan="3" align="center"  >
                   ഔട്ട്പേഷ്യന്‍സ് എണ്ണം
                </th>
                 
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                  എച്ച്.എം.സി കള്‍ സംബന്ധിച്ചുള്ള വിവരങ്ങള്‍
                </th>
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center"  rowspan="2" >
                 എച്ച്.എം.സി രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല
                </th>
            
                <th scope="col" style="width: 200px"  align="center"  colspan="2">
               വാര്‍ഷിക കണക്കുകളുടെ വിവരം

                </th>
               
                  <th scope="col" style="width: 200px" align="center" rowspan="2">
                 എച്ച്.എം.സി രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല
                </th>
            
                <th scope="col" style="width: 200px"  align="center"  colspan="2">
               വാര്‍ഷിക കണക്കുകളുടെ വിവരം

                </th>              
                  
                   
                  
            </tr>
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                ഒടുവില്‍ സമര്‍പ്പിച്ചത്
                </th>
            
                <th scope="col" style="width: 200px"  align="center" >
             ഒടുവില്‍ ഒാഡിറ്റ് നടത്തിയത്
                </th>
             <th scope="col" style="width: 200px" align="center">
                ഒടുവില്‍ സമര്‍പ്പിച്ചത്
                </th>
            
                <th scope="col" style="width: 200px"  align="center" >
             ഒടുവില്‍ ഒാഡിറ്റ് നടത്തിയത്
                </th>
            </tr>
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
    
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                
               <asp:Label ID="numhospitalid" runat="server" Text='<%# Eval("numhospitalid") %>' Visible="false"/>
            </td>
            
            <td>

        <asp:TextBox ID= "chvhospitaltypemal" runat="server"  Text='<%# Eval("chvhospitaltypemal") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            <asp:Label ID="inthospitaltypeid" runat="server" Text='<%# Eval("inthospitaltypeid") %>' Visible="false"/>
            </td>
            <td><asp:TextBox ID= "intcount" runat="server" Text='<%# Eval("intcount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" /></td>
             <td>
                <asp:TextBox ID= "numipcount" runat="server" Text='<%# Eval("numipcount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "numopcount" runat="server" Text='<%# Eval("numopcount") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
             
            <td>
            
    <%--  <asp:TextBox ID= "ss" runat="server" Text='<%# Eval("ss") %>' />
       <asp:Label ID="tnyhmcexisting" runat="server" Text='<%# Eval("tnyhmcexisting") %>' Visible="false"/>--%>
       
          <asp:RadioButtonList ID="sbmtSc" runat="server" RepeatDirection="Horizontal" Enabled="false">
                   <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
    <asp:ListItem  Value="2">ഇല്ല</asp:ListItem>
                </asp:RadioButtonList>
                
                
            </td>
             <td>
                 <asp:TextBox ID= "dtafslastsubmitted" runat="server"  Text='<%# Eval("dtafslastsubmitted") %>' CssClass="txtDate" ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "dtauditedlast" runat="server"  Text='<%# Eval("dtauditedlast") %>' CssClass="txtDate" ReadOnly="true" />
                
               </td>  
                 <td>
            
        <asp:TextBox ID= "TextBox1" runat="server"  Text='<%# Eval("chvhospitaltypemal") %>'    ReadOnly="true" />
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("inthospitaltypeid") %>' Visible="false"/>
            </td>
                 <td>
                  <asp:TextBox ID= "intcountaud" runat="server"  Text='<%# Eval("intcountaud") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "numipcountaud" runat="server" Text='<%# Eval("numipcountaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "numopcountaud" runat="server" Text='<%# Eval("numopcountaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <%--<asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />--%>
                
                <asp:RadioButtonList ID="sbmt" runat="server" RepeatDirection="Horizontal" Enabled="false">
                   <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
    <asp:ListItem  Value="2">ഇല്ല</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:TextBox ID= "dtafslastsubmittedaud" runat="server" Text='<%# Eval("dtafslastsubmittedaud") %>' CssClass="txtDate" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "dtauditedlastaud" runat="server" Text='<%# Eval("dtauditedlastaud") %>' CssClass="txtDate" ReadOnly="true" />
            </td>
          
           
             
              
             
             
           
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div>
</div>
<div> <table width="100%"> <tr> 


                                <td style="width: 1200px; height: 51px;" align="Center">
                               <asp:Button
                                    ID="btnHospDet"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnHospDet_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
                                  
                               </td>
                               
                               </tr> 
                              </table>
                            </div>

</div>


<asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW MEETING DETAILS" Width="200px" CssClass="btn btn-secondary btn-sm"></asp:Button></div>
<div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
                        <table style="width: 936px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             <span lang="ML"
                                 style="font-size: 12pt;
                                 color: #000000;
                                 font-family: 'Meera','sans-serif';
                                 mso-fareast-font-family: Calibri;
                                 mso-ansi-language: EN-GB;
                                 mso-fareast-language: EN-GB;
                                 mso-bidi-language: ML">
                                 യോഗങ്ങള്‍
                                 കൂടിയതിന്റെ
                                 <span lang="ML"
                                     style="font-size: 12pt;
                                     font-family: 'Meera','sans-serif';
                                     mso-fareast-font-family: Calibri;
                                     mso-ansi-language: EN-GB;
                                     mso-fareast-language: EN-GB;
                                     mso-bidi-language: ML">
                                     വിവരങ്ങള്‍</span></span></th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. ആശുപത്രി" Font-Bold="True" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left"> 
                            <asp:DropDownList ID="ddlHosp" runat="server" OnSelectedIndexChanged="ddlWardNo_SelectedIndexChanged"
                                Width="176px" AutoPostBack="True">
                            </asp:DropDownList>
                            </td>
                        </tr>
                        
                        
                      <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>യോഗ നം:</strong></td>
                       <td><asp:TextBox ID="txtNo11" runat="server" Text= "" Width="176px" /></td>
                        </tr>
                        
                     
                       
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>5. തീയതി </strong></td>
                       <td><asp:TextBox ID="txtMtngDate" runat="server" Text= "" CssClass="txtDate" Width="176px" />
                      </td>
                       
                        </tr>
                         
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>5. റിമാര്‍ക്ക്സ് </strong></td>
                       <td><asp:TextBox ID="txtRemarks" runat="server" Text= "" Width="376px" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" /></td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                 
                          
                      <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="rptHospMeeting" runat="server"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
        <th scope="col"  rowspan="2" align="center"  >
                    ക്രമ. നം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;"  align="center">
                  ആശുപത്രി
                </th>
                <th scope="col" style="width: 200px" align="center">
                  യോഗങ്ങളുടെ നമ്പര്‍ 

                </th>
            
                   <th scope="col" style="width: 100px" align="center">
                    തീയതി
                </th>
                  
                  
                       <th scope="col" style="width: 100px"  align="center">
                   റിമാര്‍ക്ക്സ്
                </th>
                
                
                <th scope="col" style="width: 80px;"  align="center">
                  ആശുപത്രി
                </th>
                <th scope="col" style="width: 200px" align="center">
                  യോഗങ്ങളുടെ നമ്പര്‍ 

                </th>
            
                   <th scope="col" style="width: 100px" align="center">
                    തീയതി
                </th>
               
                  
                       <th scope="col" style="width: 100px"  align="center">
                   റിമാര്‍ക്ക്സ്
                </th>
               
               
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            
        <td>
            
        <asp:TextBox ID= "TextBox1" runat="server"  Text='<%# Eval("chvhospitaltypemal") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("inthospitaltypeid") %>' Visible="false"/>
            </td>
            
            <td>
                <asp:TextBox ID= "intMeetingNo" runat="server" Text='<%# Eval("intMeetingNo") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "dtdate" runat="server" Text='<%# Eval("dtdate") %>' CssClass="txtDate" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "chvRemarks" runat="server" Text='<%# Eval("chvRemarks") %>'  ReadOnly="true" />
            </td>
            <td>
            
        <asp:TextBox ID= "TextBox2" runat="server"  Text='<%# Eval("chvhospitaltypemal") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("inthospitaltypeid") %>' Visible="false"/>
            </td>
            
            <td>
                <asp:TextBox ID= "intMeetingNoaudited" runat="server" Text='<%# Eval("intMeetingNoaudited") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "dtdateaudited" runat="server" Text='<%# Eval("dtdateaudited") %>' CssClass="txtDate" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "chvRemarksAudted" runat="server" Text='<%# Eval("chvRemarksAudted") %>' ReadOnly="true" />
            </td>
             
           
            </td>
           </tr></ItemTemplate>
        <FooterTemplate></table></FooterTemplate>  
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                         <div> <table width="100%"> <tr> 


                                <td style="width: 1200px; height: 51px;" align="Center">
                                    <asp:Button
                                        ID="btnBack"
                                        runat="server"
                                        CssClass="btn btn-secondary btn-sm"
                                        OnClick="btnBack_Click"
                                        Text="BACK"
                                        Width="62px" />
                               <asp:Button
                                    ID="btnHospMtng"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnHospMtng_Click"
                                    TabIndex="10"
                                    Text="SAVE" />
                                    <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" /></td>
                               
                               </tr> 
                              </table>
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

