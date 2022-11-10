<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_LocalDevolopmnetDet, App_Web_yasbjxhy" title="Untitled Page" %>
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
           
6.പ്രാദേശികസാമ്പത്തിക വികസനം
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
                            
                            
                           <asp:Repeater ID="rptLclDvlpmnt" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
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
            
      <asp:TextBox ID= "TextBox10" runat="server" Text='<%# Eval("numexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
             <td>
                 <asp:TextBox ID= "numauditedob" runat="server"  Text='<%# Eval("numauditedob") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "numauditedincome" runat="server"  Text='<%# Eval("numauditedincome") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                
               </td>  
                 <td>
                  <asp:TextBox ID= "numauditedexpenditure" runat="server"  Text='<%# Eval("numauditedexpenditure") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "TextBox1" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox2" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox3" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox4" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox5" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox6" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox7" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "TextBox8" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            
           
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
                                    Text="SAVE" />
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

