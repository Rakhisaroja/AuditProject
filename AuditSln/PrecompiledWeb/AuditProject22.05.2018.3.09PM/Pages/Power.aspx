<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_Power, App_Web_cllhm4gw" title="Untitled Page" %>
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
           
 8. ഉൗര്‍ജം
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
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptPower" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="8"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="8"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    വകരിയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    വകരിയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
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
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് / ഗു.വി
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
                 ബ്ലോക്ക് / ജില്ലാ വിഹിതം

                </th>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് / ഗു.വി
                </th>
            
                <th scope="col" style="width: 200px"  align="center">
                 ബ്ലോക്ക് / ജില്ലാ വിഹിതം

                </th>
                   
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "TextBox9" runat="server" Text='<%# Eval("numob") %>' />
          
            </td>
            <td><asp:TextBox ID= "TextBox11" runat="server" Text='<%# Eval("numob") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "numincome" runat="server" Text='<%# Eval("numincome") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "numexpenditure" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
            <td>
            
      <asp:TextBox ID= "TextBox10" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                 <asp:TextBox ID= "numauditedob" runat="server"  Text='<%# Eval("numauditedob") %>' v/>
            </td>
             <td>
                <asp:TextBox ID= "numauditedincome" runat="server"  Text='<%# Eval("numauditedincome") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                
               </td>  
                 <td>
                  <asp:TextBox ID= "numauditedexpenditure" runat="server"  Text='<%# Eval("numauditedexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "TextBox1" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox2" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox3" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox4" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox5" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox6" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox7" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "TextBox8" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
           
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td></tr> 
                              </table>
                            </div>
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="RptStreetLightDet" runat="server" OnItemCommand="RptStreetLightDet_ItemCommand"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> <th scope="col"  rowspan="4" align="center" valign="middle" >
                   വാര്‍ഡ്
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="7"  >
                   നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="7"  >
                  ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍

                </th>
              
                          
            </tr>
            
            <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="7"  >
                  നിലവിലുള്ള തെരുവുവിളക്കുകളുടെ തരവും എണ്ണവും
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="7"  >
                  നിലവിലുള്ള തെരുവുവിളക്കുകളുടെ തരവും എണ്ണവും

                </th>
              
                          
            </tr>
            
            
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                       ഒാര്‍ഡിനറി ബള്‍ബ്
                </th>
                  <th scope="col"  style="text-align:center"  align="center" rowspan="2"   >
                  സി.എഫ്.എല്‍
നിലവിലുള്ളത്
                </th>
                 <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                   എല്‍.ഇ.ഡി
                </th>
                <th scope="col" style="text-align:center"  align="center" rowspan="2" >
                   ഫ്ലൂറസെന്റ് ട്യൂബ്
                </th>
                  <th scope="col"  style="text-align:center"  align="center"  rowspan="2" >
                   മറ്റുളളവ
                </th>
                          
                          
                            <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                       ഒാര്‍ഡിനറി ബള്‍ബ്
                </th>
                  <th scope="col"  style="text-align:center"  align="center" rowspan="2"   >
                  സി.എഫ്.എല്‍
നിലവിലുള്ളത്
                </th>
                
                 <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                   എല്‍.ഇ.ഡി
                </th>
                <th scope="col" style="text-align:center"  align="center" rowspan="2" >
                   ഫ്ലൂറസെന്റ് ട്യൂബ്
                </th>
                  <th scope="col"  style="text-align:center"  align="center"  rowspan="2" >
                   മറ്റുളളവ
                </th>
            </tr>
            
            <tr>
               
                <th scope="col" align="center">
                നിലവിലുള്ളത്
                </th>
            
                <th scope="col" align="center">
              ഡിസ്മാന്റില്‍ ചെയ്തത്
                </th>
                
               
                   <th scope="col"   align="center">
                നിലവിലുള്ളത്
                </th>
                   <th scope="col"  align="center">
                  പുതുതായി സ്ഥാപിച്ചത്
                </th>
                 
                   <th scope="col"  align="center">
                നിലവിലുള്ളത്
                </th>
            
                <th scope="col"   align="center">
              ഡിസ്മാന്റില്‍ ചെയ്തത്
                </th>
                
               
                   <th scope="col" style="width: 100px"  align="center">
                നിലവിലുള്ളത്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  പുതുതായി സ്ഥാപിച്ചത്
                </th>
                 
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "intincanddescentexisting" runat="server" Text='<%# Eval("intincanddescentexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
          
            </td>
            <td><asp:TextBox ID= "intincanddescentdismantled" runat="server" Text='<%# Eval("intincanddescentdismantled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "intcflexisting" runat="server" Text='<%# Eval("intcflexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intledexisting" runat="server" Text='<%# Eval("intledexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
            <td>
            
      <asp:TextBox ID= "intlednew" runat="server" Text='<%# Eval("intlednew") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                 <asp:TextBox ID= "intfluerescent" runat="server"  Text='<%# Eval("intfluerescent") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "intothers" runat="server"  Text='<%# Eval("intothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                
               </td>  
                 <td>
                  <asp:TextBox ID= "intaudincanddescentexisting" runat="server"  Text='<%# Eval("intaudincanddescentexisting") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "intaudincanddescentdismantled" runat="server" Text='<%# Eval("intaudincanddescentdismantled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intadcflexisting" runat="server" Text='<%# Eval("intadcflexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudledexisting" runat="server" Text='<%# Eval("intaudledexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudlednew" runat="server" Text='<%# Eval("intaudlednew") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
            <td>
                <asp:TextBox ID= "intaudfluerescent" runat="server" Text='<%# Eval("intaudfluerescent") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudothers" runat="server" Text='<%# Eval("intaudothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div>



</div>


<div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                               <asp:Button
                                    ID="BtnStreetlight"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="BtnStreetlight_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td></tr> 
                              </table>
                            </div>








                              


<%--                                    8A            --%>

<div class="table table-striped table-bordered"> 
 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >8(a) മീറ്ററിംഗ് സംവിധാനത്തിന്റെ വിശദാംശങ്ങള്‍

                    </div>

 <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                
                            
                            
                           <asp:Repeater ID="Rpt8A" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                ആകെ സ്ഥാപിച്ചിട്ടുള്ള മീറ്ററുകളുടെ എണ്ണം
                </th>
             
                <th scope="col" style="width: 400px"  align="center">
             തെരുവുവിളക്കുകള്‍ക്കായി മീറ്റര്‍ സ്ഥാപിച്ചിട്ടില്ലെങ്കില്‍ പ്രസ്തുത ആവശ്യത്തിലേക്ക് നാളിതുവരെ ഒടുക്കിയ തുകയുടെ വിവരങ്ങള്‍

                </th>
               <th scope="col" style="width: 200px" align="center">
                ആകെ സ്ഥാപിച്ചിട്ടുള്ള മീറ്ററുകളുടെ എണ്ണം
                </th>
            
                <th scope="col" style="width: 400px"  align="center">
             തെരുവുവിളക്കുകള്‍ക്കായി മീറ്റര്‍ സ്ഥാപിച്ചിട്ടില്ലെങ്കില്‍ പ്രസ്തുത ആവശ്യത്തിലേക്ക് നാളിതുവരെ ഒടുക്കിയ തുകയുടെ വിവരങ്ങള്‍

                </th>
                  
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
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("SLNO") %>' />
                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("numid") %>'  Visible="false"/>
            </td>
          
             <td align="Center">
                 <asp:TextBox ID= "inttotalmeter" runat="server"  Text='<%# Eval("inttotalmeter") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "tnymeterforstreetlight" runat="server"  Text='<%# Eval("numamountforstreetlight") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numamountforstreetlight" runat="server"  Text='<%# Eval("intaudtotalmeter") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedcfl" runat="server"  Text='<%# Eval("numaudamountforstreetlight") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
           </tr></ItemTemplate>
                        


</asp:Repeater>
</div>

     <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                           <%--  <asp:Button
                                    ID="Button2"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="BtnStreetLightMeetering_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />--%>
                               </td></tr> 
                              </table>
                            </div>

 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >8(b) വാങ്ങിയ തെരുവുവിളക്കുകളും ചെലവഴിച്ച തുകയും- വിശദവിവരങ്ങള്‍

                    </div>
                     <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
  <asp:Repeater ID="RPT8B" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col"  align="center">
               സി.എഫ്.എല്‍
                </th>
             
                <th scope="col"   align="center">
             എല്‍.ഇ.ഡി

                </th>
               <th scope="col"  align="center">
                ട്യൂബ്
                </th>
            
                <th scope="col"  align="center">
           മറ്റുളളവ

                </th>
                
                
                <th scope="col"   align="center">
          അനുബന്ധ ഉപകരണങ്ങള്‍

                </th>
                
                
                <th scope="col"   align="center">
           ചെലവഴിച്ച തുക

                </th>
                  
                  
                     <th scope="col"  align="center">
               സി.എഫ്.എല്‍
                </th>
             
                <th scope="col"  align="center">
             എല്‍.ഇ.ഡി

                </th>
               <th scope="col" align="center">
                ട്യൂബ്
                </th>
            
                <th scope="col"   align="center">
           മറ്റുളളവ

                </th>
                
                
                <th scope="col"   align="center">
          അനുബന്ധ ഉപകരണങ്ങള്‍

                </th>
                
                
                <th scope="col"  align="center">
           ചെലവഴിച്ച തുക

                </th>
                  
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
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("SLNO") %>' />
                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("numid") %>'  Visible="false"/>
            </td>
          
             <td align="Center">
                 <asp:TextBox ID= "intpurchasedcfl" runat="server"  Text='<%# Eval("intpurchasedcfl") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedled" runat="server"  Text='<%# Eval("intpurchasedled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedtube" runat="server"  Text='<%# Eval("intpurchasedtube") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedothers" runat="server"  Text='<%# Eval("intpurchasedothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "intrelatedeqp" runat="server"  Text='<%# Eval("intrelatedeqp") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "numamount" runat="server"  Text='<%# Eval("numamount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
               <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedcfl" runat="server"  Text='<%# Eval("intaudpurchasedcfl") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedled" runat="server"  Text='<%# Eval("intaudpurchasedled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedtube" runat="server"  Text='<%# Eval("intaudpurchasedtube") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedothers" runat="server"  Text='<%# Eval("intaudpurchasedothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "intaudrelatedeqp" runat="server"  Text='<%# Eval("intaudrelatedeqp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "numaudamount" runat="server"  Text='<%# Eval("numaudamount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


    </div>            
                <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                            
                               </td></tr> 
                              </table>
                            </div>
                            
 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >8(c) തെരുവുവിളക്ക് പരിപാലനം - ചെലവുവിവരങ്ങള്‍

                    </div>
                     <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                                 <asp:Repeater ID="RPT8C" runat="server"    >

                       
                             <HeaderTemplate>
                                <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                             
     
                   
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
             
                <th scope="col"   align="center">
            പ്രോജക്ട് മുഖേന

                </th>
               <th scope="col" align="center">
               പ്രോജക്ട് മുഖേനയല്ലാതെ
                </th>
            
            
             <th scope="col"   align="center">
            പ്രോജക്ട് മുഖേന

                </th>
               <th scope="col"  align="center">
               പ്രോജക്ട് മുഖേനയല്ലാതെ
                </th>
            
               
            </tr>
            <tr>
             <th scope="col"  align="center">
              എ.എം.സി
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numamcplan" runat="server"  Text='<%# Eval("numamcplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numamcnonplan" runat="server"  Text='<%# Eval("numamcnonplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudamcplan" runat="server"  Text='<%# Eval("numaudamcplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudamcnonplan" runat="server"  Text='<%# Eval("numaudamcnonplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            </tr>
            
             <tr>
             <th scope="col" style="width: 200px" align="center">
             കരാര്‍ നിയമനം
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numcontractplan" runat="server"  Text='<%# Eval("numcontractplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numcontractnonplan" runat="server"  Text='<%# Eval("numcontractnonplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudcontractplan" runat="server"  Text='<%# Eval("numaudcontractplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudcontractnonplan" runat="server"  Text='<%# Eval("numaudcontractnonplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            </tr>
            
            <tr>
             <th scope="col" style="width: 200px" align="center">
            കെ.എസ്.ഇ.ബി സൂപ്പര്‍വിഷന്‍ ചാര്‍ജ്
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numksebplan" runat="server"  Text='<%# Eval("numksebplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numksebnonplan" runat="server"  Text='<%# Eval("numksebnonplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudksebplan" runat="server"  Text='<%# Eval("numaudksebplan") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudksebnonplan" runat="server"  Text='<%# Eval("numaudksebnonplan") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            </tr>
             
    </HeaderTemplate>


                        


</asp:Repeater>

</div>
       <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                             <asp:Button
                                    ID="BtnStreetLightMeetering"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="BtnStreetLightMeetering_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td></tr> 
                              </table>
                            </div>
                
     </div>           
                      <%--  8d     --%>
                     
                             

                 
                 
                      
                        
                      <div class="table table-striped table-bordered">             
                       <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           
8(d) തെരുവുവിളക്കുകളുടെ വെെദ്യുതി ചാര്‍ജ്
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><o:p></o:p></span></p>
                    </div>
       
                     <%--   <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >--%>
                            
                            
                           <asp:Repeater ID="Rpt8D" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th><th  rowspan="2">  മാസം</th>
                <th scope="col" style="text-align:center"  align="center"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center"   >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
               
            
                <th scope="col" style="width: 200px"  align="center">
              ഒടുക്കിയ തുക

                </th>
              
                  
            
                <th scope="col" style="width: 200px"  align="center">
              ഒടുക്കിയ തുക

                </th>
              
                  
            </tr>
             
    </HeaderTemplate>
    
    <ItemTemplate>
    <td>
        <asp:Label ID="numid" runat="server" Text='<%# Eval("numid") %>' Visible="false"/>
        <asp:Label ID="Label2" runat="server" Text='<%# Eval("SLNO") %>' />
        </td>
             <td>
                 <asp:Label ID= "chvmonthmal" runat="server"  Text='<%# Eval("chvmonthmal") %>' />
                 <asp:Label ID= "intmonthid" runat="server"  Text='<%# Eval("intmonthid") %>'  Visible="false"/>
            </td>
          
             <td>
                 <asp:TextBox ID= "numamount" runat="server"  Text='<%# Eval("numamount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
             <td>
                <asp:TextBox ID= "numaudamount" runat="server"  Text='<%# Eval("numaudamount") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
              </td>
                 
            
            
           </tr></ItemTemplate>
                        


</asp:Repeater>


<%--</div>--%>

</div>

 <table width="100%"> <tr> <td style="width: 100%; height: 21px; font-family:Meera;font-size:15px;" colspan="3" align="center">
                               <asp:Button
                                    ID="BtnStreetLightExp"
                                    runat="server"
                                    CssClass="lblMal"
                                    OnClick="BtnStreetLightExp_Click"
                                    TabIndex="10"
                                    Text="സമര്‍പ്പിക്കുക" />
                               </td></tr> 
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

