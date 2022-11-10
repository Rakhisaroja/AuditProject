<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_ResourceAllocation, App_Web_yasbjxhy" title="Untitled Page" %>
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
                          <asp:Repeater ID="grvDevelopmentFund" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
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
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
              <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
            <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
      
            </td>
            
        </tr> 
    </ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div><table><tr><td style="width: 1200px; height: 51px;" align="Center" colspan="3">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>

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



