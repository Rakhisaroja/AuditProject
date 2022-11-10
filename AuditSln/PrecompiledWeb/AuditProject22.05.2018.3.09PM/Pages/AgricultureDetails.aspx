<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_AgricultureDetails, App_Web_cllhm4gw" title="Untitled Page" %>
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
           
1. കൃഷി
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptAgri" runat="server"    >

                       
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
            
        <asp:TextBox ID= "txtDevolopmentFund" runat="server" Text='<%# Eval("numob") %>' />
          
            </td>
            <td><asp:TextBox ID= "txtMaintananceFund" runat="server" Text='<%# Eval("numob") %>' /></td>
             <td>
                <asp:TextBox ID= "txtOwnfund" runat="server" Text='<%# Eval("numincome") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtBlkDTShare" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
             
            <td>
            
      <asp:TextBox ID= "txtDevolopmentFundExp" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
             <td>
                 <asp:TextBox ID= "txtMaintananceFundExp" runat="server"  Text='<%# Eval("numauditedob") %>' />
            </td>
             <td>
                <asp:TextBox ID= "txtOwnfundExp" runat="server"  Text='<%# Eval("numauditedincome") %>' />
                
               </td>  
                 <td>
                  <asp:TextBox ID= "txtBlkDTShareExp" runat="server"  Text='<%# Eval("numauditedexpenditure") %>'  />
                
            
            </td>
            
            
            
            
            <td>
                <asp:TextBox ID= "txtDevolopmentFundAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtMaintananceFundAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtOwnfundAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtBlkDTShareAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtDevolopmentFundExpAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtMaintananceFundExpAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtOwnfundExpAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            <td>
                <asp:TextBox ID= "txtBlkDTShareExpAudt" runat="server" Text='<%# Eval("numexpenditure") %>' />
            </td>
            
           
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td style="width: 100%; height: 21px;" colspan="3" align="center">
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

