<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="SocialJusticeNurserySchool_Urban.aspx.cs" Inherits="Pages_SocialJusticeNurserySchool_Urban"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം (Page 2)
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">2(b). അങ്കണവാടികള്‍ - ഭൌതികസൌകര്യങ്ങള്‍

</strong>
                        </div>
                          <div class="card-header">
                            <strong class="card-titlen">അങ്കണവാടികളുടെ എണ്ണം :

</strong>
                            <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
                                <tr>
                                      <th scope="col" style="text-align:center; width: 559px;"  align="center" colspan="1"  >
                                          നിലവിലുള്ള വിവരങ്ങള്‍
                                      </th>
                                         <th scope="col"  style="text-align:center; width: 648px;"  align="center" colspan="1"  >
                                         ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                                         </th>
                          
                             </tr>
                             <tr>
                             <td style="width: 559px">
                             <asp:TextBox ID="numNurseryCount" runat="server" CssClass="floatnumbers"  Text = '<%# Eval("numNurseryCount") %>' Width="540px"></asp:TextBox>
                             </td>
                             <td>
                             <asp:TextBox ID="numAudNurseryCount" runat="server" CssClass="floatnumbers"  Text = '<%# Eval("numAudNurseryCount") %>' Width="629px"></asp:TextBox>
                             </td>
                             </tr>
                             </table>


                              
                        </div>
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1225px;height:300px" >
                         
  
        
                         <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
                                <tr>
                                      <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                                          നിലവിലുള്ള വിവരങ്ങള്‍
                                      </th>
                                         <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                                         ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                                         </th>
                          
                             </tr>
                             <tr>
                                   <th scope="col" style="width: 200px" align="center">
                                         സ്വന്തം സ്ഥലം
                                        </th>
                                      <%--  <th></th>--%>
                                        <th scope="col" style="width: 200px"  align="center">
                                          മതിയായ സൌകര്യമുള്ള കെട്ടിടം
                                        </th>
                                       <%-- <th></th>--%>
                                           <th scope ="col" style="width: 100px"  align="center">
                                            ചുറ്റുമതിൽ
                                        </th>
                                        <th scope ="col" style="width: 100px"  align="center">
                                            കുടി വെള്ളം
                                        </th>
                                        <th scope ="col" style="width: 100px"  align="center">
                                            വൈദ്യുതി
                                        </th>
                                        
                                        
                                        
                                             <th scope="col" style="width: 200px" align="center">
                                         സ്വന്തം സ്ഥലം
                                        </th>
                                      <%--  <th></th>--%>
                                        <th scope="col" style="width: 200px"  align="center">
                                         മതിയായ സൌകര്യമുള്ള കെട്ടിടം
                                        </th>
                                       <%-- <th></th>--%>
                                           <th scope ="col" style="width: 100px"  align="center">
                                            ചുറ്റുമതിൽ
                                        </th>
                                        <th scope ="col" style="width: 100px"  align="center">
                                            കുടി വെള്ളം
                                        </th>
                                        <th scope ="col" style="width: 100px"  align="center">
                                           വൈദ്യുതി
                                        </th>
                   
                             
                             </tr>
                             <tr>
                             <td>
                            <asp:TextBox ID = "numOwnedPlace" runat ="server"  CssClass="floatnumbers"  Text = '<%# Eval("numOwnedPlace") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numSuitableBuilding" runat ="server" CssClass="floatnumbers"  Text = '<%# Eval("numSuitableBuilding") %>' />
                            </td>
                             <td>
                            <asp:TextBox ID = "numCompoundWall" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numCompoundWall") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numDrinkingWater" runat ="server" CssClass="floatnumbers"  Text = '<%# Eval("numDrinkingWater") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numElectricity" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numElectricity") %>' />
                            </td>
                            
                            <td>
                            <asp:TextBox ID = "numAuditOwnedPlace" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numAuditOwnedPlace") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numAuditSuitableBuilding" runat ="server"  CssClass="floatnumbers" Text = '<%# Eval("numAuditSuitableBuilding") %>' />
                            </td>
                             <td>
                            <asp:TextBox ID = "numAuditCompoundWall" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numAuditCompoundWall") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numAuditDrinkingWater" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numAuditDrinkingWater") %>' />
                            </td>
                            <td>
                            <asp:TextBox ID = "numAuditElectricity" runat ="server" CssClass="floatnumbers" Text = '<%# Eval("numAuditElectricity") %>' />
                            </td>
                            </tr>
                        </table> 
                        </div> 
                        </div> 
                        
                        
                        
                       
                        <%--<div class="card-body">--%>
                        

<div class="card-header">
 <strong class="card-titlen"> 2 (c)  അങ്കണവാടികള്‍ - ഭൌതികസൌകര്യങ്ങള്‍ മെച്ചപ്പെടുത്തല്‍ - തന്‍വര്‍ഷം നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍</strong>
 </div> 
 <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvSocialJustice" runat="server" >


                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
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
                  <%-- <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് / ഗു.വി
                </th>
             
                <%--<th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട്  / ഗു.വി
                </th>
                  </th>
                  <%-- <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട്  / ഗു.വി
                </th>
            
                 <%--<th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
                   
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" Width="200px" runat="server" Text='<%# Eval("chvProjectName") %>' />
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
           <%-- <td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltTotal" runat="server" Text='<%# Eval("fltTotal") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>--%>
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' CssClass="floatnumbers"  ReadOnly="true"  />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
                
               </td>  
                <%-- <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  CssClass="floatnumbers"  ReadOnly="true" />
                
            
            </td>
            
              <td>
                <asp:TextBox ID= "fltTotalExp" runat="server" Text='<%# Eval("fltTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>--%>
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <%--<td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltaudTotal" runat="server" Text='<%# Eval("fltaudTotal") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>--%>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <%--<td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            <td>
                <asp:TextBox ID= "fltaudTotalExp" runat="server" Text='<%# Eval("fltaudTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>--%>
            </td>
           </tr></ItemTemplate>
              <FooterTemplate></table></FooterTemplate>          


</asp:Repeater>



</div>
</div>
</div> 
<div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
         Text="NEXT" Width="63px" /></td></tr></table></div></div> 
                  
                        </div>
                   <%-- </div>--%>
                </div>
 

                </div>
            </div><!-- .animated -->
        <%--</div>--%>
</asp:Content>

