<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_SCSTDevelopment, App_Web_yasbjxhy" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <%--<div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen"> 4. പട്ടികജാതി / പട്ടികവര്‍ഗ്ഗ വികസനം</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvSocialJustice" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="11"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
           <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                  <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                 <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                     
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                     <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                </th>
                     <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
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
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>'/>
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
         <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvremarks") %>' />
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
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="100px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 

            </td>
              <td>
             <asp:TextBox ID="TextBox1" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
              <td>
             <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
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







