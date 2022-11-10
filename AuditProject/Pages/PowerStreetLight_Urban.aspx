<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PowerStreetLight_Urban.aspx.cs" Inherits="Pages_PowerStreetLight_Urban" Title="Untitled Page" %>
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
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                        
                        
                          <asp:Repeater ID="RptStreetLightDet" runat="server"     >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
         <th scope="col"  rowspan="4" align="center"  >
                    ക്ര.ന
                </th>
        <th scope="col"  rowspan="4" align="center" valign="middle" >
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
                <asp:Label ID="chvWardMalName" runat="server" Text='<%# Eval("chvWardMalName") %>' />
                 <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "intincanddescentexisting" runat="server" Text='<%# Eval("intincanddescentexisting") %>'  ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
          
            </td>
            <td><asp:TextBox ID= "intincanddescentdismantled"   ReadOnly="true"  runat="server" Text='<%# Eval("intincanddescentdismantled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/></td>
             <td>
                <asp:TextBox ID= "intcflexisting" runat="server"  ReadOnly="true"  Text='<%# Eval("intcflexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "intledexisting" runat="server"   ReadOnly="true"  Text='<%# Eval("intledexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
             
            <td>
            
      <asp:TextBox ID= "intlednew" runat="server"   ReadOnly="true"  Text='<%# Eval("intlednew") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
                 <asp:TextBox ID= "intfluerescent" runat="server"   ReadOnly="true"   Text='<%# Eval("intfluerescent") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
                <asp:TextBox ID= "intothers" runat="server"    ReadOnly="true"  Text='<%# Eval("intothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
                
               </td>  
                 <td>
                  <asp:TextBox ID= "intaudincanddescentexisting"   ReadOnly="true"  runat="server"  Text='<%# Eval("intaudincanddescentexisting") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "intaudincanddescentdismantled"   ReadOnly="true"  runat="server" Text='<%# Eval("intaudincanddescentdismantled") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "intadcflexisting" runat="server"  ReadOnly="true"  Text='<%# Eval("intadcflexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudledexisting" runat="server"  ReadOnly="true"  Text='<%# Eval("intaudledexisting") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudlednew" runat="server"  ReadOnly="true"  Text='<%# Eval("intaudlednew") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
           
            <td>
                <asp:TextBox ID= "intaudfluerescent" runat="server"  ReadOnly="true"  Text='<%# Eval("intaudfluerescent") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID= "intaudothers" runat="server"  ReadOnly="true"  Text='<%# Eval("intaudothers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;"/>
            </td>
           
            </td>
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>
                        
                        </div>
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
                              OnClick="BtnStreetlight_Click"
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
</asp:Content>

