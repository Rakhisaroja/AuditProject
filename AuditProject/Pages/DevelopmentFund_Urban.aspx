<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="DevelopmentFund_Urban.aspx.cs" Inherits="Pages_DevelopmentFund_Urban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <%--<div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">വികസനഫണ്ട് - മേഖലാടിസ്ഥാനത്തിലുള്ള വകയിരുത്തല്‍</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvDevelopmentFund" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="15"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="13"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>
                   <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    വിഭാഗം
                </th>
                   <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ആകെ വകയിരുത്തിയ തുക
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  ഉല്പാദന മേഖല
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    സേവന മേഖല
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 400px" colspan="4" align="center">
                   പശ്ചാത്തല മേഖല
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ആകെ വകയിരുത്തിയ തുക
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  ഉല്പാദന മേഖല
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    സേവന മേഖല
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 400px" colspan="4" align="center">
                   പശ്ചാത്തല മേഖല
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വകയിരുത്തിയ തുക
                </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ചെലവഴിച്ച തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    %
                </th>
                   <th scope="col" style="width: 120px" align="center">
                    വകയിരുത്തിയ തുക
                </th>
                
                <th scope="col" style="width: 100px" align="center">
                   %
                </th>
                <th scope="col" style="width: 100px" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   %
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   വകയിരുത്തിയ തുക
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    ചെലവഴിച്ച തുക
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                   </th>
                <th scope="col" style="width: 120px" align="center">
                   വകയിരുത്തിയ തുക
                </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ചെലവഴിച്ച തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    %
                </th>
                   <th scope="col" style="width: 120px" align="center">
                    വകയിരുത്തിയ തുക
                </th>
                
                <th scope="col" style="width: 100px" align="center">
                   %
                </th>
                <th scope="col" style="width: 100px" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   %
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   വകയിരുത്തിയ തുക
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    ചെലവഴിച്ച തുക
                   </th>
                <th scope="col" style="width: 100px" align="center">
                    %
                   </th>
                          
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="SlNo" runat="server" Text='<%# Eval("SlNo") %>' />
            </td>
            <td>
                <asp:Label ID="FundSource" runat="server" Text='<%# Eval("FundSource") %>' />
                  <asp:Label ID="LBId"  runat="server" Text='<%# Eval("intlbid") %>' Visible="false"/> 
                 <asp:Label ID="FinYearId"  runat="server" Text='<%# Eval("intfinancialyearid") %>' Visible="false"/>
                <asp:Label ID="FundSrcId" runat="server" Text='<%# Eval("intFundSrcID") %>' Visible="false"/>
            </td>
    <td>
                <asp:Label ID="Totalloc" runat="server" Text='<%# Eval("Totalloc") %>' />
            </td>
             <td>
                <asp:Label ID="Prodalloc" runat="server" Text='<%# Eval("Prodalloc") %>' />
                <asp:Label ID="Prodid" runat="server" Text='<%# Eval("Prodid") %>' Visible="false"/>
            </td>
            <td>
                <asp:Label ID="Prodallocper" runat="server" Text='<%# Eval("Prodallocper") %>' />
            </td>
            <td>
                <asp:Label ID="Prodexp" runat="server" Text='<%# Eval("Prodexp") %>' />
            </td>
             <td>
                <asp:Label ID="Prodexpper" runat="server" Text='<%# Eval("Prodexpper") %>' />
            </td>
            <td>
                <asp:Label ID="Servalloc" runat="server" Text='<%# Eval("Servalloc") %>' />
                 <asp:Label ID="Servid" runat="server" Text='<%# Eval("Servid") %>' Visible="false"/>
            </td>
            <td>
                <asp:Label ID="Servallocper" runat="server" Text='<%# Eval("Servallocper") %>' />
            </td>
            <td>
                <asp:Label ID="Servexp" runat="server" Text='<%# Eval("Servexp") %>' />
            </td>
            <td>
                <asp:Label ID="Servexpper" runat="server" Text='<%# Eval("Servexpper") %>' />
            </td>
            <td>
                <asp:Label ID="Infraalloc" runat="server" Text='<%# Eval("Infraalloc") %>' />
                <asp:Label ID="Infraid" runat="server" Text='<%# Eval("Infraid") %>' Visible="false"/>
            </td>
            <td>
                <asp:Label ID="Infraallocper" runat="server" Text='<%# Eval("Infraallocper") %>' />
            </td>
            <td>
                <asp:Label ID="Infraexp" runat="server" Text='<%# Eval("Infraexp") %>' />
            </td>
            <td>
                <asp:Label ID="Infraexpper" runat="server" Text='<%# Eval("Infraexpper") %>' />
            </td>
            
             <td>
   
              <asp:TextBox ID="TotallocAud" Width="100px" runat="server" Text='<%# Eval("Totaudalloc") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>
            </td>
            <td>
             <asp:TextBox ID="ProdallocAud" Width="100px" runat="server" Text='<%# Eval("Prodaudalloc") %>' CssClass="floatnumbers"></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="ProdallocperAud" Width="100px"  runat="server" Text='<%# Eval("Prodaudallocper") %>' CssClass="floatnumbers" Enabled="false"></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="ProdexpAud" Width="100px"  runat="server" Text='<%# Eval("Prodaudexp") %>' CssClass="floatnumbers"></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="ProdexpperAud" Width="100px" runat="server" Text='<%# Eval("Prodaudexpper") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="ServallocAud" runat="server" Width="100px"  Text='<%# Eval("Servaudalloc") %>' CssClass="floatnumbers"></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="ServallocperAud" Width="100px"  runat="server" Text='<%# Eval("Servaudallocper") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="ServexpAud" Width="100px" runat="server" Text='<%# Eval("Servaudexp") %>' CssClass="floatnumbers"></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="ServexpperAud" Width="100px" runat="server" Text='<%# Eval("Servaudexpper") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>
            </td>
              <td>
             <asp:TextBox ID="InfraallocAud" runat="server" Width="100px"  Text='<%# Eval("Infraaudalloc") %>' CssClass="floatnumbers"></asp:TextBox>
             
            </td>
              <td>
             <asp:TextBox ID="InfraallocperAud" runat="server" Width="100px"  Text='<%# Eval("Infraaudallocper") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>

            </td>
              <td>
             <asp:TextBox ID="InfraexpAud" runat="server" Width="100px"  Text='<%# Eval("Infraaudexp") %>' CssClass="floatnumbers"></asp:TextBox>
       
            </td>
              <td>
             <asp:TextBox ID="InfraexpperAud" runat="server" Width="100px"  Text='<%# Eval("Infraaudexpper") %>' Enabled="false" CssClass="floatnumbers"></asp:TextBox>

            </td>
        </tr> 
    </ItemTemplate>
    <FooterTemplate>
</table>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div><table><tr>
<td style="width: 1000px; height: 50px;" align="center">
    &nbsp;
                  <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="BACK" Width="62px" OnClick="btnBack_Click" />
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="NEXT" Width="62px" OnClick="btnNext_Click" /></td>
                        </tr></table></div>

                </div>
            </div><!-- .animated -->
        </div>
         
</asp:Content>



