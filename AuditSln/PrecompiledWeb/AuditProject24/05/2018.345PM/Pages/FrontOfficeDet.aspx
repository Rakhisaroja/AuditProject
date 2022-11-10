<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_FrontOfficeDet, App_Web_yasbjxhy" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">???? ????
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">

10. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനം വിശദാംശങ്ങള്‍



</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><?xml namespace=""
        prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                         <div class="card-header">
                                <strong class="card-titlen">എ. ഫ്രണ്ട് ഒാഫീസ് ഡയറി

</strong>
                                
                            </div>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptFrontOfce" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                     ക്രമ. നം
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
             തന്‍വര്‍ഷം ലഭിച്ച (സേവനങ്ങള്‍ക്കുവേണ്ടി) അപേക്ഷകളുടെഎണ്ണം
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
               തന്‍വര്‍ഷം ലഭിച്ച (സേവനങ്ങള്‍ക്കുവേണ്ടി) അപേക്ഷകളുടെഎണ്ണം
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
                <asp:TextBox ID= "intfrontofficeapplication" runat="server" Text='<%# Eval("intfrontofficeapplication") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intfrontofficecompleted" runat="server" Text='<%# Eval("intfrontofficecompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
           <td>
                <asp:TextBox ID= "intfrontofficebalance" runat="server" Text='<%# Eval("intfrontofficebalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            
            <td>
                <asp:TextBox ID= "intfrontofficeapplicationaud" runat="server" Text='<%# Eval("intfrontofficeapplicationaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intfrontofficecompletedaud" runat="server" Text='<%# Eval("intfrontofficecompletedaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intfrontofficebalanceaud" runat="server" Text='<%# Eval("intfrontofficebalanceaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>




    <div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;font-family:Meera;font-size:15px;" colspan="3" align="center">
                     
                               </td></tr> 
                              </table>
                            </div>






<div class="table table-striped table-bordered">

 <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
ബി. ഇന്‍വേഡ് രജിസ്റ്റര്‍

                    </div>
                    
                    
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptInwrd" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്രമ. നം
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
                 തന്‍വര്‍ഷം ലഭിച്ച തപാലുകളുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
              സമയബന്ധിതമായി കെെമാറിയ തപാലുകളുടെ എണ്ണം

                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                 ശേഷിക്കുന്നവ
                </th>
                   
                   
                        <th scope="col" style="width: 200px" align="center">
                തന്‍വര്‍ഷം ലഭിച്ച തപാലുകളുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
             സമയബന്ധിതമായി കെെമാറിയ തപാലുകളുടെ എണ്ണം

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
            <td><asp:TextBox ID= "intinward" runat="server" Text='<%# Eval("intinward") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            <td><asp:TextBox ID= "intinwardcompleted" runat="server" Text='<%# Eval("intinwardcompleted") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            <td><asp:TextBox ID= "intinwardbalance" runat="server" Text='<%# Eval("intinwardbalance") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            
            <td><asp:TextBox ID= "intinwardaud" runat="server" Text='<%# Eval("intinwardaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            <td><asp:TextBox ID= "intinwardcompletedaud" runat="server" Text='<%# Eval("intinwardcompletedaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            <td><asp:TextBox ID= "intinwardbalanceaud" runat="server" Text='<%# Eval("intinwardbalanceaud") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>




<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="SAVE" />&nbsp;
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

