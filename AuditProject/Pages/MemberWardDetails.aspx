<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="MemberWardDetails.aspx.cs" Inherits="Pages_MemberWardDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <%--<div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">I.i നിയോജകമണ്ഡലങ്ങളുടെ/വാര്‍ഡുകളുടെ വിവരം</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvMemWard" runat="server" OnItemCommand="grvMemWard_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
         <th scope="col" style="text-align:center"  align="center" rowspan="3"  >
                    ക്ര.നം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    വാര്‍ഡ് നം
                </th>
                <th scope="col" style="width: 200px" rowspan="2"align="center">
                 പേര്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                    അതിരുകള്‍
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" colspan="2" align="center">
                   ജനസംഖ്യ
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                   വാര്‍ഡ് മെമ്പര്‍
                </th>
                
                  <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    വാര്‍ഡ് നം
                </th>
                <th scope="col" style="width: 200px" rowspan="2"align="center">
                 പേര്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                    അതിരുകള്‍
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" colspan="2" align="center">
                   ജനസംഖ്യ
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                   വാര്‍ഡ് മെമ്പര്‍
                </th>
                                
            </tr>
              <tr>
            
                <th scope="col" style="width: 100px" align="center">
                   സ്ത്രീകള്‍
                </th>
                <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍മാര്‍
                </th>
                
                 <th scope="col" style="width: 100px" align="center">
                   സ്ത്രീകള്‍
                </th>
                <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍മാര്‍
                </th>
                 
                          
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
         <td>
                   <asp:Label ID="SLNO" Width="80px" runat="server" Text='<%# Eval("SLNO") %>'></asp:Label></td>
            <td>
                   <asp:Label ID="intWardNo" Width="100px" runat="server" Text='<%# Eval("intWardNo") %>'  ></asp:Label></td>
            <td>
                   <asp:Label ID="chvWardMalName" Width="250px" runat="server" Text='<%# Eval("chvWardMalName") %>'  ></asp:Label>
            </td>
    <td>
                  <asp:TextBox ID="nchvDirection" Width="200px"  TextMode="MultiLine" runat="server" Text='<%# Eval("nchvDirection") %>' ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="intDirectionType" Width="200px" Visible="false"   runat="server" Text='<%# Eval("intDirectionType") %>'></asp:Label>--%>
            </td>
             <td>
                  <asp:TextBox ID="intPopulationWardwiseFemale" Width="100px" ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intPopulationWardwiseFemale") %>'> </asp:TextBox>
            </td>
               <td>
                   <asp:TextBox ID="intPopulationWardwiseMale" Width="100px" ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intPopulationWardwiseMale") %>'> </asp:TextBox></td>
            <td>
                   <asp:TextBox ID="chvMalFirstName" Width="200px" runat="server"  ReadOnly="true" Text='<%# Eval("chvMalFirstName") %>'> </asp:TextBox></td>
    <td>
                  <asp:Label ID="intWardNo1" Width="100px" runat="server"  Text='<%# Eval("intWardNo1") %>'> </asp:Label>
            </td>
             <td>
                  <asp:Label ID="chvWardMalName1" Width="250px" runat="server"   Text='<%# Eval("chvWardMalName") %>'></asp:Label>
            </td>
               <td>
                <%--   <asp:TextBox ID="TextBox8" Width="200px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox></td>--%>
                <%--<asp:DropDownList ID="cmbDirection" runat="server" ></asp:DropDownList>--%>
                <asp:TextBox ID="nchAuditvDirection" TextMode="MultiLine" Width="200px" runat="server" Text='<%# Eval("nchAuditvDirection") %>'  ></asp:TextBox>
                
                </td>
            <td>
                   <asp:TextBox ID="intAuditedPopulnWardwiseFemale" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intAuditedPopulnWardwiseFemale") %>'></asp:TextBox>
            </td>
    <td>
                  <asp:TextBox ID="intAuditedPopulnWardwiseMale" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intAuditedPopulnWardwiseMale") %>'></asp:TextBox>
            </td>
             <td>
                  <asp:TextBox ID="chvAuditedMalFirstName" Width="250px" runat="server" Text='<%# Eval("chvAuditedMalFirstName") %>'></asp:TextBox>
            </td>
         <%--    <td>
                  <asp:TextBox ID="chvAuditedEngFirstName" Width="200px" runat="server" Text='<%# Eval("chvAuditedEngFirstName") %>'></asp:TextBox>
            </td>
             --%>
             </tr> 
    </ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr></table>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                 
  
                </div>
 <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
         Text="NEXT" Width="63px" /></td></tr></table></div>
                </div>
            </div><!-- .animated -->
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
 
