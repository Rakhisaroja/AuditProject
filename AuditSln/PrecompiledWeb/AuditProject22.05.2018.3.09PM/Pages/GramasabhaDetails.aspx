<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_GramasabhaDetails, App_Web_cllhm4gw" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">വരവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ഗ്രാമസഭ വിവരങ്ങള്‍</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvMergeHeader" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="9"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="9"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    വാര്‍ഡ് നം / പേര്
                </th>
                <th scope="col" style="width: 200px" colspan="2"align="center">
                  വോട്ടര്‍മാരുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" colspan="2" align="center">
                    പങ്കെടുത്ത വോട്ടര്‍മാരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                    ഗ്രാമസഭ കൂടിയ സ്ഥലം
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center">
                    തീയതി
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center"> ഹാജര്‍ ശതമാനം </th>
                  
                       <th scope="col" style="width: 100px" rowspan="2" align="center">
                   റിമാര്‍ക്ക്സ്
                </th>
                
                 <th scope="col" style="width: 80px;" rowspan="2" align="center">
                    വാര്‍ഡ് നം / പേര്
                </th>
                <th scope="col" style="width: 200px" colspan="2"align="center" valign="middle">
                   വോട്ടര്‍മാരുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" colspan="2" align="center" valign="middle">
                    പങ്കെടുത്ത വോട്ടര്‍മാരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle">
                    ഗ്രാമസഭ കൂടിയ സ്ഥലം
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle">
                    തീയതി
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle"> ഹാജര്‍ ശതമാനം </th>
                  
                       <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle">
                    റിമാര്‍ക്ക്സ്
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 100px" align="center">
                   സ്ത്രീ
                </th>
                <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    സ്ത്രീ
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍
                </th>
                
                <th scope="col" style="width: 100px" align="center">
                   സ്ത്രീ
                </th>
                <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    സ്ത്രീ
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    പുരുഷന്‍
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
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            
             <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <asp:Label ID="intWardNo1" runat="server" Text='<%# Eval("intWardNo1") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
               <%-- <asp:Label ID="Label8" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
               <%-- <asp:Label ID="Label9" runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>' />--%>
            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
                <%--<asp:Label ID="Label10" runat="server" Text='<%# Eval("intauditedparticipantmale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
                <%--<asp:Label ID="Label11" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="200px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label12" runat="server" Text='<%# Eval("chvauditedplacemal") %>' />--%>
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="200px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label13" runat="server" Text='<%# Eval("dtauditedgramasabha") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
               <%-- <asp:Label ID="Label14" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="200px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 
               <%-- <asp:Label ID="Label15" runat="server" Text='<%# Eval("chvauditedremarks") %>' />--%>
            </td>
            <%-- <td visible="false">
           <%--  <%# DataBinder.Eval(Container.DataItem, "intgramasabhano") %> 
         
            </td>--%>
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
<div><table><tr><td style="width: 53px; height: 51px;">
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

