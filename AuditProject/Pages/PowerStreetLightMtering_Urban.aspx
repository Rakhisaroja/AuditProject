<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PowerStreetLightMtering_Urban.aspx.cs" Inherits="Pages_PowerStreetLightMtering_Urban" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">ചെലവ് ഭാഗം
                    </div>
                    
                     <div class="card-header">
                            <strong class="card-titlen">
                               4. ഉൗര്‍ജം</strong>
                        </div>
                        
                   
                        <div class="card">
                           <div class="card-body">  
                            
                       <div class="table table-striped table-bordered">
                        <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >4(a) മീറ്ററിംഗ് സംവിധാനത്തിന്റെ വിശദാംശങ്ങള്‍

                    </div>
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;" >
                        
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
                  <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>'  Visible="false"/>
            </td>
          
             <td align="Center">
                 <asp:TextBox ID= "inttotalmeter" runat="server"  ReadOnly="true"    Text='<%# Eval("inttotalmeter") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numamountforstreetlight" runat="server"  ReadOnly="true"    Text='<%# Eval("numamountforstreetlight") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudtotalmeter" runat="server"  ReadOnly="true"    Text='<%# Eval("intaudtotalmeter") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudamountforstreetlight" runat="server"  ReadOnly="true"    Text='<%# Eval("numaudamountforstreetlight") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
             
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

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
                            
                            
                      </div>
                      
                       <div class="table table-striped table-bordered">
                       <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >4(b) വാങ്ങിയ തെരുവുവിളക്കുകളും ചെലവഴിച്ച തുകയും- വിശദവിവരങ്ങള്‍

                    </div>
                     <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
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
                 <asp:TextBox ID= "intpurchasedcfl"  ReadOnly="true"    runat="server"  Text='<%# Eval("intpurchasedcfl") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedled"  ReadOnly="true"    runat="server"  Text='<%# Eval("intpurchasedled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedtube"  ReadOnly="true"    runat="server"  Text='<%# Eval("intpurchasedtube") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intpurchasedothers"   ReadOnly="true"   runat="server"  Text='<%# Eval("intpurchasedothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "intrelatedeqp" runat="server"  ReadOnly="true"     Text='<%# Eval("intrelatedeqp") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "numamount" runat="server"  ReadOnly="true"     Text='<%# Eval("numamount") %>' CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
             
               <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedcfl" runat="server"  ReadOnly="true"     Text='<%# Eval("intaudpurchasedcfl") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedled" runat="server"  ReadOnly="true"     Text='<%# Eval("intaudpurchasedled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedtube" runat="server"   ReadOnly="true"    Text='<%# Eval("intaudpurchasedtube") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "intaudpurchasedothers" runat="server"   ReadOnly="true"    Text='<%# Eval("intaudpurchasedothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "intaudrelatedeqp" runat="server"  ReadOnly="true"     Text='<%# Eval("intaudrelatedeqp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;" />
            </td>
            
             <td align="Center">
                 <asp:TextBox ID= "numaudamount" runat="server"   ReadOnly="true"    Text='<%# Eval("numaudamount") %>' CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


    </div>       
    </div>     
                <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                            
                               </td></tr> 
                              </table>
                            </div>
                            
                            
                        <div class="table table-striped table-bordered">     
                      
                <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >4(c) തെരുവുവിളക്ക് പരിപാലനം - ചെലവുവിവരങ്ങള്‍

                    </div>
                     <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                    <%--        
                                 <asp:Repeater ID="RPT8C" runat="server"    >

                       
                             <HeaderTemplate>--%>
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
              <%-- </HeaderTemplate>
    
    <ItemTemplate>--%>
            <tr>
             <th scope="col"  align="center">
              എ.എം.സി
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numamcplan" runat="server"   ReadOnly="true"   Text='<%# Eval("numamcplan") %>' CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numamcnonplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numamcnonplan") %>' CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudamcplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudamcplan") %>'   CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudamcnonplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudamcnonplan") %>'   CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
            </tr>
            
             <tr>
             <th scope="col" style="width: 200px" align="center">
             കരാര്‍ നിയമനം
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numcontractplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numcontractplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;" />
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numcontractnonplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numcontractnonplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;" />
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudcontractplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudcontractplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudcontractnonplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudcontractnonplan") %>'   CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
            </tr>
            
            <tr>
             <th scope="col" style="width: 200px" align="center">
            കെ.എസ്.ഇ.ബി സൂപ്പര്‍വിഷന്‍ ചാര്‍ജ്
                </th>
                  <td align="Center">
                 <asp:TextBox ID= "numksebplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numksebplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numksebnonplan" runat="server"   ReadOnly="true"   Text='<%# Eval("numksebnonplan") %>'   CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudksebplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudksebplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
              <td align="Center">
                 <asp:TextBox ID= "numaudksebnonplan" runat="server"   ReadOnly="true"  Text='<%# Eval("numaudksebnonplan") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
            </tr>
             
    <%--</ItemTemplate> 


                                  
     <FooterTemplate></table></FooterTemplate>                


</asp:Repeater>--%>
</table>
   </div>
                            
                              <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                          <asp:Button
                              ID="btnBack"
                              runat="server"
                              CssClass="btn btn-secondary btn-sm"
                              OnClick="btnBack_Click"
                              Text="BACK"
                              Width="62px" />
                          <asp:Button
                              ID="Button2"
                              runat="server"
                              CssClass="btn btn-secondary btn-sm"
                              OnClick="BtnStreetLightMeetering_Click"
                              TabIndex="10"
                              Text="SAVE" />&nbsp;
                          <asp:Button
                              ID="Button1"
                              runat="server"
                              CssClass="btn btn-secondary btn-sm"
                              OnClick="btnNext_Click"
                              Text="NEXT"
                              Width="62px" />
                               </td></tr> 
                              </table>

</div>
                
                 
                    </div>
                  </div>
                </div>
                </div>
                </div>
                </div>
                </div>
                
</asp:Content>
                        

