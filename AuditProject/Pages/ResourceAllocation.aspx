<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="ResourceAllocation.aspx.cs" Inherits="Pages_ResourceAllocation"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <%--<div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">വിഭവ വകയിരുത്തല്‍ / ചെലവ് വിവരങ്ങള്‍</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvResourceAllocation" runat="server" OnItemCommand="grvResourceAllocation_ItemCommand" OnItemDataBound="grvResourceAllocation_ItemDataBound" >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
               
              <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>
                     <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    വിഭവ സ്രോതസ്സുകള്‍
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="3">
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3">
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
          
                   <th scope="col" style="width: 80px;" rowspan="1" align="center">
                    വകയിരുത്തിയ തുക
                </th>
                   <th scope="col" style="width: 100px;" rowspan="1" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                      <th scope="col" style="width: 80px;" rowspan="1" align="center">
                    ചെലവ് ശതമാനം
                </th>
                      <th scope="col" style="width: 80px;" rowspan="1" align="center">
                    വകയിരുത്തിയ തുക
                </th>
                      <th scope="col" style="width: 100px;" rowspan="1" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                      <th scope="col" style="width: 80px;" rowspan="1" align="center">
                    ചെലവ് ശതമാനം
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="SlNo" runat="server" Text='<%# Eval("SlNo") %>' />
            </td>
            <td>
                <asp:Label ID="chvFundSource" runat="server" Text='<%# Eval("chvFundSource") %>' />
                 <asp:Label ID="LBId"  runat="server" Text='<%# Eval("intlbid") %>' Visible="false"/> 
                 <asp:Label ID="FinYearId"  runat="server" Text='<%# Eval("intfinancialyearid") %>' Visible="false"/>
                 <asp:Label ID="FundSrcId"  runat="server" Text='<%# Eval("intFundSrcId") %>' Visible="false"/>
            </td>
              <td>
                <asp:Label ID="fltalloc" runat="server" Text='<%# Eval("fltalloc") %>' />
            </td>
             <td>
                <asp:Label ID="fltexpense" runat="server" Text='<%# Eval("fltexpense") %>' />
            </td>
            <td>
                <asp:Label ID="tnyper" runat="server" Text='<%# Eval("tnyper") %>' />
            </td>
           
            <td>
             <asp:TextBox ID="fltaudalloc" Width="100px" CssClass="floatnumbers" runat="server" Text='<%# Eval("fltaudalloc") %>' ReadOnly="true"></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="fltaudexpense" Width="100px" CssClass="floatnumbers" runat="server" Text='<%# Eval("fltaudexpense") %>'  ReadOnly="true"></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="tnyaudper" Width="100px" CssClass="floatnumbers" runat="server" Text='<%# Eval("tnyaudper") %>'  ReadOnly="true"></asp:TextBox>
      
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
   <td style="width: 300px">
       &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="BACK" Width="62px" OnClick="btnBack_Click" />
  <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" /></td></tr></table></div>

                </div>
            </div>
        </div>
        
</asp:Content>



