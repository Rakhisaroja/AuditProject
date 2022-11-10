<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_SoilNWaterDetails, App_Web_yasbjxhy" title="Untitled Page" %>
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
           
3.മണ്ണ് ജല സംരക്ഷണം
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
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptSoinNWtr" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
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
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" runat="server" Text='<%# Eval("chvProjectName") %>' />
                 <asp:Label ID="lbldecProjectID" runat="server" Text='<%# Eval("decProjectID") %>' Visible="false" />
            </td>
            <td>
          <asp:TextBox ID= "fltDevFund" runat="server" Text='<%# Eval("fltDevFund") %>' />
          
            </td>
            <td><asp:TextBox ID= "fltMG" runat="server" Text='<%# Eval("fltMG") %>' /></td>
             <td>
                <asp:TextBox ID= "fltOwnFund" runat="server" Text='<%# Eval("fltOwnFund") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' />
            </td>
             
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' />
            </td>
             <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' />
                
               </td>  
                 <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  />
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' />
            </td>
            
           
            
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
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
                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
           </div>












</asp:Content>

