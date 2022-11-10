<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="StateGrant.aspx.cs" Inherits="Pages_StateGrant"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelStGrant" runat="server" UpdateMode="always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">വരവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">IV. സംസ്ഥാന ഗ്രാന്റുകള്‍-ലഭ്യതയും വിനിയോഗവും
</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                       <%-- <asp:GridView id="grvBalanced" runat="server"  AutoGenerateColumns="False"   Width="100%" CellPadding="2" BackColor="White" BorderColor="Silver" Font-Names="Meera" OnRowCreated="grvBalanced_RowCreated"  >
                       --%>     
                       <asp:Repeater ID="grvStateGrant" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                    <tr>
                    <th scope="col"   align="center" rowspan="2"  >
                    ക്ര.ന (1)
                </th>               
                <th scope="col" style="width: 400px" align="center" colspan="5">  നിലവിലുള്ള വിവരങ്ങള്‍                 
                </th>            
                <th scope="col" style="width: 400px"  align="center" colspan="5">     ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍              
                </th> 
                    
               
            </tr>
        <tr> 
                <th scope="col" style="text-align:center;Width:400px"   align="center"    > ഫണ്ടിനം (2) </th>
                   
                  <th scope="col"  style="text-align:center"  align="center"     >
                   സംസ്ഥാന ബഡ്ജറ്റ് അനുബന്ധം 4 പ്രകാരം വകയിരുത്തിയ തുക (3)
                </th>
                <th scope="col"    align="center"  >
                    സംസ്ഥാന സര്‍ക്കാര്‍ അനുവദിച്ച തുക (4)
                </th>
                <th scope="col" style="text-align:center"  align="center"   >
                    റസീപ്റ്റ് & പേമെന്റ് പ്രകാരം വരവ് - ചെലവ് (5)
                </th>
               <%--   <th scope="col"  style="text-align:center"  align="center"     >
                   ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക (5)
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ ശതമാനം (6)
                </th>--%>
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ലാപ്സായ തുക/ശതമാനം(4-5)

                </th>
                
               
                <th scope="col" style="text-align:center;Width:400px"  align="center"     > ഫണ്ടിനം (2) </th>
                   
                  <th scope="col"  style="text-align:center"  align="center"     >
                   സംസ്ഥാന ബഡ്ജറ്റ് അനുബന്ധം 4 പ്രകാരം വകയിരുത്തിയ തുക (3)
                </th>
                <th scope="col"    align="center"  >
                    സംസ്ഥാന സര്‍ക്കാര്‍ അനുവദിച്ച തുക (4)
                </th>
                <th scope="col" style="text-align:center"  align="center"   >
                    റസീപ്റ്റ് & പേമെന്റ് പ്രകാരം വരവ് - ചെലവ് (5)
                </th>
               <%--   <th scope="col"  style="text-align:center"  align="center"     >
                   ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക (5)
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ ശതമാനം (6)
                </th>--%>
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ലാപ്സായ തുക/ശതമാനം(4-5)

                </th>
                          
            </tr>            

             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>

            <td> <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' />
                <%--<asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />--%>
            </td>
            <td> <asp:Label ID="intFundSrcID" Visible="false" runat="server" Text='<%# Eval("intFundSrcID") %>' />
                <asp:Label ID="chvFundSource" ReadOnly="TRUE" Width="400px" runat="server" Text='<%# Eval("chvFundSource") %>' />
            </td>
    <td> <asp:TextBox ID="fltbudget" runat="server" Width="200px" Text='<%# Eval("fltbudget") %>'  CssClass="floatnumbers" />
                <%--<asp:TextBox ID="txtStateAlotAmt" runat="server" Text='<%# Eval("StateAlotAmt") %>' />--%>
            </td>
             <td>
                <asp:TextBox ID="fltrelease" Width="200px" runat="server" Text='<%# Eval("fltrelease") %>' CssClass="floatnumbers" />
            </td>
            <td>
                <asp:TextBox ID="fltexpense"  Width="200px" runat="server" Text='<%# Eval("fltexpense") %>' CssClass="floatnumbers" />
            </td>   <td><table><tr><td> 
            <asp:TextBox ID="fltlapse" Width="200px" runat="server" Text='<%# Eval("fltlapse") %>'  CssClass="floatnumbers"  /></td>
         <td>  <asp:Label ID="expper" Width="100px" runat="server" Text='<%# Eval("expper") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
       
          
            
            <td> <asp:Label ID="chvFundSource1"   Width="400px" runat="server" Text='<%# Eval("chvFundSource") %>' />
                <%--<asp:TextBox ID="txtfundtype" runat="server" Text='<%# Eval("fundtype") %>' />--%>
            </td>
    <td> <asp:TextBox ID="fltaudbudget" Width="400px" runat="server" Text='<%# Eval("fltaudbudget") %>'  CssClass="floatnumbers" />
                <%--<asp:TextBox ID="txtStateAlotAmt" runat="server" Text='<%# Eval("StateAlotAmt") %>' />--%>
            </td>
             <td>
                <asp:TextBox ID="fltaudrelease" Width="200px" runat="server" Text='<%# Eval("fltaudrelease") %>' CssClass="floatnumbers" />
            </td>
            <td>
                <asp:TextBox ID="fltaudexpense" Width="200px" runat="server" Text='<%# Eval("fltaudexpense") %>' CssClass="floatnumbers" />
            </td>   <td><table><tr><td> 
            <asp:TextBox ID="fltaudlapse" Width="200px" runat="server" Text='<%# Eval("fltaudlapse") %>'  CssClass="floatnumbers"  /></td>
         <td>  <asp:Label ID="expAuditper" Width="100px" runat="server" Text='<%# Eval("expAuditper") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
           
            
            </tr>
       
           <%-- </table>
          
            </td>
           </tr>--%>
           </ItemTemplate>
                    <FooterTemplate>
 <tr>  <td style="font-weight:bold" colspan="2" >Total
        </td> 
        <td  >
            <asp:Label ID="totbudget"  Font-Bold="True"  runat="server" Text='<%# Eval("totbudget") %>' />
        </td>   <td  >
            <asp:Label ID="totfltrelease"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltrelease") %>' />
        </td>
         <td  >
            <asp:Label ID="totfltexpense"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltexpense") %>' />
        </td>
       
         <td  >
            <asp:Label ID="totfltlapse"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltlapse") %>' />
        </td> <td></td>  <td  >
            <asp:Label ID="totaudbudget"  Font-Bold="True"  runat="server" Text='<%# Eval("totaudbudget") %>' />
        </td>
         <td  >
            <asp:Label ID="totaudfltrelease"  Font-Bold="True"  runat="server" Text='<%# Eval("totaudfltrelease") %>' />
        </td>
         <td  >
            <asp:Label ID="totaudfltexpense"  Font-Bold="True"  runat="server" Text='<%# Eval("totaudfltexpense") %>' />
        </td>
         <td  >
            <asp:Label ID="totaudfltlapse"  Font-Bold="True"  runat="server" Text='<%# Eval("totaudfltlapse") %>' />
        </td></tr>
    </table>
</FooterTemplate>    


</asp:Repeater></div></div>
                  
                        </div>
                        
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                       <%-- <asp:GridView id="grvBalanced" runat="server"  AutoGenerateColumns="False"   Width="100%" CellPadding="2" BackColor="White" BorderColor="Silver" Font-Names="Meera" OnRowCreated="grvBalanced_RowCreated"  >
                       --%>     
                       <asp:Repeater ID="grvStateGrantChild" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
                    <tr>
                    <th scope="col"   align="center" rowspan="2"  >
                    ക്ര.ന
                </th>               
                <th scope="col" style="width: 400px" align="center" colspan="3">  നിലവിലുള്ള വിവരങ്ങള്‍                 
                </th>            
                <th scope="col" style="width: 400px"  align="center" colspan="3">     ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍              
                </th> 
                    
               
            </tr>
        <tr> 
                <th scope="col" style="text-align:center; Width:400px "  align="center"    > ഫണ്ടിനം   </th>
                   
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക 
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ ശതമാനം 
                </th> 
                
               
               <th scope="col" style="text-align:center; Width:400px "  align="center"    > ഫണ്ടിനം   </th>
                   
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക 
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ ശതമാനം 
                </th> 
                
                          
            </tr>            

             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td> <asp:Label ID="SLNO" runat="server" Text='<%# Eval("SLNO") %>' />
                <asp:Label ID="intFundSrcID"  Visible="false" runat="server" Text='<%# Eval("intFundSrcID") %>' />
                <asp:Label ID="intMajorSecID"   Visible="false"  runat="server" Text='<%# Eval("intMajorSecID") %>' />
            </td>
            <td> <asp:Label ID="chvFundSource"  Width="400px" runat="server" Text='<%# Eval("chvFundSource") %>' />
                <%--<asp:TextBox ID="txtfundtype" runat="server" Text='<%# Eval("fundtype") %>' />--%>
            </td>
   <td><table><tr><td> 
            <asp:Label ID="Sec"  Width="150px" runat="server" Text='<%# Eval("Sec") %>'   /></td>
         <td>  <asp:TextBox ID="fltalloc" runat="server" Text='<%# Eval("fltalloc") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
           <td><table><tr><td> 
            <asp:TextBox ID="fltexpense" runat="server" Text='<%# Eval("fltexpense") %>'  CssClass="floatnumbers"  /></td>
         <td>  <asp:Label ID="expper" Width="100px" runat="server" Text='<%# Eval("expper") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
            <td> <asp:Label ID="chvFundSource1" Width="400px" runat="server" Text='<%# Eval("chvFundSource") %>' />
                <%--<asp:TextBox ID="txtfundtype" runat="server" Text='<%# Eval("fundtype") %>' />--%>
            </td>
   <td><table><tr><td> 
            <asp:Label ID="Sec1" runat="server"  Width="150px" Text='<%# Eval("Sec") %>'  CssClass="floatnumbers"  /></td>
         <td>  <asp:TextBox ID="fltaudalloc" runat="server" Text='<%# Eval("fltaudalloc") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
           <td><table><tr><td> 
            <asp:TextBox ID="fltaudexpense" runat="server" Text='<%# Eval("fltaudexpense") %>'  CssClass="fltaudalloc"  /></td>
         <td>  <asp:Label ID="audexpper" Width="100px" runat="server" Text='<%# Eval("audexpper") %>'  CssClass="floatnumbers"/></td>
        </tr>  </table>
          </td>
            
            </tr>
       
           <%-- </table>
          
            </td>
           </tr>--%>
           </ItemTemplate>
                    <FooterTemplate>
 <tr>  <td style="font-weight:bold" colspan="2" >Total
        </td> 
        <td  >
            <asp:Label ID="totfltalloc"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltalloc") %>' />
        </td>   <td  >
            <asp:Label ID="totfltexpense"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltexpense") %>' />
        </td>
          <td></td>  <td  >
            <asp:Label ID="totfltaudalloc"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltaudalloc") %>' />
        </td>
         <td  >
            <asp:Label ID="totfltaudexpense"  Font-Bold="True"  runat="server" Text='<%# Eval("totfltaudexpense") %>' />
        </td>
        </tr>
    </table>
</FooterTemplate>    


</asp:Repeater></div></div>
                  
                        </div>
                    </div>
                </div>
<div style="width:100%">
                    <table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        &nbsp;
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     </td></tr><tr><td align="center"> <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelStGrant">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 53px; top: 3px;" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress></td></tr></table></div>

                </div>
            </div><!-- .animated -->
        </div></ContentTemplate></asp:UpdatePanel>
        
        
</asp:Content>

