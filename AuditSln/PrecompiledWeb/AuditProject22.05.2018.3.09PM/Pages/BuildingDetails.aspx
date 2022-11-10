<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_BuildingDetails, App_Web_cllhm4gw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
             
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-titlen">6.കെട്ടിടങ്ങളുമായി ബന്ധപ്പെട്ട സേവനങ്ങള്‍</strong>
                                
                            </div>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptBuilding" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="3" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="15"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="15"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col"  align="center" colspan="5">
                തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകരുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col"   align="center"  colspan="5">
                 സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവ
                </th>
               <%-- <th></th>--%>
                   <th scope="col"  align="center"  colspan="5">
                    ശേഷിക്കുന്നവ
                </th>
                
                 <th scope="col"  align="center" colspan="5">
                തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകരുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col"  align="center"  colspan="5">
                 സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവ
                </th>
               <%-- <th></th>--%>
                   <th scope="col"  align="center"  colspan="5">
                    ശേഷിക്കുന്നവ
                </th>
                </tr>
                <tr>
                   <th scope="col"  align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col" align="center">
                    നം. നല്‍കല്‍
                </th>              
                  
                   <th scope="col"  align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col"   align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col"  align="center">
                    നികുതി ഒഴുവാക്കല്‍
                </th>
                
                
                   <th scope="col"   align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col" align="center">
                    നം. നല്‍കല്‍
                </th>            
                  
                   <th scope="col"  align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col"   align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col"   align="center">
                    നികുതി ഒഴുവാക്കല്‍
                </th>
                
                  <th scope="col"  align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col" align="center">
                    നം. നല്‍കല്‍
                </th>               
                  
                   <th scope="col"  align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col"  align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col"  align="center">
                    നികുതി ഒഴുവാക്കല്‍
                </th>
                  
                  
                   <th scope="col" align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col"  align="center">
                    നം. നല്‍കല്‍
                </th>              
                  
                   <th scope="col"  align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col" align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col"  align="center">
                    നികുതി ഒഴുവാക്കല്‍
                </th>
                
                
                   <th scope="col" align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col" align="center">
                    നം. നല്‍കല്‍
                </th>            
                  
                   <th scope="col" align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col"   align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col" align="center">
                    നികുതി ഒഴുവാക്കല്‍
                </th>
                
                  <th scope="col" align="center" >
                  പെര്‍മിറ്റ്
                </th>
                 <th scope="col"  align="center">
                    നം. നല്‍കല്‍
                </th>               
                  
                   <th scope="col"  align="center">
               ക്രമവത്കരണം
                </th>
              
                <th scope="col"  align="center">
                 ഉടമസ്ഥതാവകാശം
                </th>
            
                   <th scope="col"   align="center">
                    നികുതി ഒഴുവാക്കല്‍
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
                 <asp:Label ID="numid" runat="server" Text='<%# Eval("numid") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID= "intpermitapp" runat="server" Text='<%# Eval("intpermitapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
              <td><asp:TextBox ID= "intnumberingapp" runat="server" Text='<%# Eval("intnumberingapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
                <td><asp:TextBox ID= "intregularisationapp" runat="server" Text='<%# Eval("intregularisationapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
                  <td><asp:TextBox ID= "intownershipapp" runat="server" Text='<%# Eval("intownershipapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                    <td><asp:TextBox ID= "inttaxremissionapp" runat="server" Text='<%# Eval("inttaxremissionapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
               <td><asp:TextBox ID= "intpermitcompleted" runat="server" Text='<%# Eval("intpermitcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                 <td><asp:TextBox ID= "intnumberingcompleted" runat="server" Text='<%# Eval("intnumberingcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
                   <td><asp:TextBox ID= "intregularisationcompleted" runat="server" Text='<%# Eval("intregularisationcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>
                     <td><asp:TextBox ID= "intownershipcompleted" runat="server" Text='<%# Eval("intownershipcompleted") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                       <td><asp:TextBox ID= "inttaxremissioncompleted" runat="server" Text='<%# Eval("inttaxremissioncompleted") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                 <td><asp:TextBox ID= "intpermitbalance" runat="server" Text='<%# Eval("intpermitbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                   <td><asp:TextBox ID= "intnumberingbalance" runat="server" Text='<%# Eval("intnumberingbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                     <td><asp:TextBox ID= "intregularisationbalance" runat="server" Text='<%# Eval("intregularisationbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                       <td><asp:TextBox ID= "intownershipbalance" runat="server" Text='<%# Eval("intownershipbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                         <td><asp:TextBox ID= "inttaxremissionbalance" runat="server" Text='<%# Eval("inttaxremissionbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>               
         
         
           <td><asp:TextBox ID= "intauditedpermitapp" runat="server" Text='<%# Eval("intauditedpermitapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
              <td><asp:TextBox ID= "intauditednumberingapp" runat="server" Text='<%# Eval("intauditednumberingapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                <td><asp:TextBox ID= "intauditedregularisationapp" runat="server" Text='<%# Eval("intauditedregularisationapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                  <td><asp:TextBox ID= "intauditedownershipapp" runat="server" Text='<%# Eval("intauditedownershipapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                    <td><asp:TextBox ID= "intauditedtaxremissionapp" runat="server" Text='<%# Eval("intauditedtaxremissionapp") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
               <td><asp:TextBox ID= "intauditedpermitcompleted" runat="server" Text='<%# Eval("intauditedpermitcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                 <td><asp:TextBox ID= "intauditednumberingcompleted" runat="server" Text='<%# Eval("intauditednumberingcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                   <td><asp:TextBox ID= "intauditedregularisationcompleted" runat="server" Text='<%# Eval("intauditedregularisationcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                     <td><asp:TextBox ID= "intauditedownershipcompleted" runat="server" Text='<%# Eval("intauditedownershipcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                       <td><asp:TextBox ID= "intauditedtaxremissioncompleted" runat="server" Text='<%# Eval("intauditedtaxremissioncompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                 <td><asp:TextBox ID= "intauditedpermitbalance" runat="server" Text='<%# Eval("intauditedpermitbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                   <td><asp:TextBox ID= "intauditednumberingbalance" runat="server" Text='<%# Eval("intauditednumberingbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                     <td><asp:TextBox ID= "intauditedregularisationbalance" runat="server" Text='<%# Eval("intauditedregularisationbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                       <td><asp:TextBox ID= "intauditedownershipbalance" runat="server" Text='<%# Eval("intauditedownershipbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                         <td><asp:TextBox ID= "intauditedtaxremissionbalance" runat="server" Text='<%# Eval("intauditedtaxremissionbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td>               
         
            
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>


    <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                     
                               </td></tr> 
                              </table>
                            </div>






<div class="table table-striped table-bordered">

 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
7.വാസയോഗ്യമായ വീടില്ല എന്ന സര്‍ട്ടിഫിക്കറ്റ് / താമസക്കാരനാണ് എന്ന സര്‍ട്ടിഫിക്കറ്റ് / ഒക്കുപ്പന്‍സി സര്‍ട്ടിഫിക്കറ്റിനുള്ള അപേക്ഷയിന്‍ മേല്‍ സ്ഥല പരിശോധന നടത്തി റിപ്പോര്‍ട്ട് നല്‍കല്‍


                    </div>
                    
                    
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptOccupancy" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
              സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                 ശേഷിക്കുന്നവ
                </th>
                   
                   
                        <th scope="col" style="width: 200px" align="center">
                 തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
              സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                 ശേഷിക്കുന്നവ
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
       <tr>
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
            <td><asp:TextBox ID= "intoccupancyapplication" runat="server" Text='<%# Eval("intoccupancyapplication") %>' /></td>
            <td><asp:TextBox ID= "intoccupancycompleted" runat="server" Text='<%# Eval("intoccupancycompleted") %>' /></td>
            <td><asp:TextBox ID= "intoccupancybalance" runat="server" Text='<%# Eval("intoccupancybalance") %>' /></td>
            
            <td><asp:TextBox ID= "intauditedoccupancyapplication" runat="server" Text='<%# Eval("intauditedoccupancyapplication") %>' /></td>
            <td><asp:TextBox ID= "intauditedoccupancycompleted" runat="server" Text='<%# Eval("intauditedoccupancycompleted") %>' /></td>
            <td><asp:TextBox ID= "intauditedoccupancybalance" runat="server" Text='<%# Eval("intauditedoccupancybalance") %>' /></td>
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>






<div> <table width="100%"> <tr> <td colspan="3" style="width: 1000px" align="center">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
 
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                   CssClass="btn btn-secondary btn-sm" 
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="Save" />
                                     <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
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

