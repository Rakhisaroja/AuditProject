<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="LicenseDetails.aspx.cs" Inherits="Pages_LicenseDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">ചെലവ് ഭാഗം
                    </div>
                          <div class="card-header">
                                <strong class="card-titlen">9. ലെെസന്‍സ് നല്‍കല്‍
</strong>
                                
                            </div>
               
                        <div class="card">
                         <div class="card-header">
                                <strong class="card-titlen">എ) ഫാക്ടറി , വ്യവസായം, വ്യാപാരം, വര്‍ക്ക്ഷോപ്പ്, ക്വോറി , ഇഷ്ടിക കമ്പനി, ഹോളോ ബ്രിക്സ്

</strong>
                                
                            </div>
                             <div class="card-body">
                       <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptlicense" runat="server"    >

                       
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
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
           
           
             <td>
                <asp:TextBox ID= "intindustryapplication" runat="server" Text='<%# Eval("intindustryapplication") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intindustrycompleted" runat="server" Text='<%# Eval("intindustrycompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
             
           <td>
                <asp:TextBox ID= "intindustrybalance" runat="server" Text='<%# Eval("intindustrybalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            
            <td>
                <asp:TextBox ID= "intindustryapplicationaud" runat="server" Text='<%# Eval("intindustryapplicationaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intindustrycompletedaud" runat="server" Text='<%# Eval("intindustrycompletedaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intindustrybalanceaud" runat="server" Text='<%# Eval("intindustrybalanceaud ") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
           
           
           </tr></ItemTemplate>
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


</div></div>


</div>

    <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                     
                               </td></tr> 
                              </table>
                            </div>






<div class="table table-striped table-bordered">

 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
ബി) ലെെഫ് സ്റ്റോക്ക് ഫാം, പന്നി, പട്ടി മുതലായവ


                    </div>
                    
                    
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptLiveStock" runat="server"    >

                       
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
            <td><asp:TextBox ID= "intlvestockapplication" runat="server" Text='<%# Eval("intlvestockapplication") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
            <td><asp:TextBox ID= "intlivestockcompleted" runat="server" Text='<%# Eval("intlivestockcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
            <td><asp:TextBox ID= "intlivestockbalance" runat="server" Text='<%# Eval("intlivestockbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
            
            <td><asp:TextBox ID= "intlvestockapplicationaud" runat="server" Text='<%# Eval("intlvestockapplicationaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
            <td><asp:TextBox ID= "intlivestockcompletedaud" runat="server" Text='<%# Eval("intlivestockcompletedaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
            <td><asp:TextBox ID= "intlivestockbalanceaud" runat="server" Text='<%# Eval("intlivestockbalanceaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/></td>
           
           </tr></ItemTemplate>
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


</div></div>




<div> <table width="100%"> <tr><td style="width: 1200px; height: 51px;" align="Center" colspan="3">
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

