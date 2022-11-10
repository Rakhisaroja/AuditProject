<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_StateGrant, App_Web_yasbjxhy" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                       <asp:Repeater ID="grvStateGrant" runat="server" OnItemCommand="grvStateGrant_ItemCommand"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"   align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    ഫണ്ടിനം (1)
                  <th scope="col"  style="text-align:center"  align="center"     >
                   സംസ്ഥാന ബഡ്ജറ്റ് അനുബന്ധം 4 പ്രകാരം വകയിരുത്തിയ തുക (2)
                </th>
                <th scope="col"    align="center"  >
                    സംസ്ഥാന സര്‍ക്കാര്‍ അനുവദിച്ച തുക (3)
                </th>
                <th scope="col" style="text-align:center"  align="center"   >
                    റസീപ്റ്റ് & പേമെന്റ് പ്രകാരം വരവ് - ചെലവ് (4)
                </th>
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക (5)
                </th>
                <th scope="col" style="text-align:center"  align="center"    >
                    തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ ശതമാനം (6)
                </th>
                  <th scope="col"  style="text-align:center"  align="center"     >
                   ലാപ്സായ തുക/ശതമാനം(4-6)

                </th>
                          
            </tr>            
            <tr>               
               <%-- <th scope="col" style="width: 200px" align="center">                   
                </th>            
                <th scope="col" style="width: 200px"  align="center">                   
                </th> 
                <th scope="col" style="width: 200px"  align="center">                   
                </th>   --%>         
               
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td> <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                <%--<asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />--%>
            </td>
            <td> <asp:Label ID="txtfundtype" runat="server" Text='<%# Eval("fundtype") %>' />
                <%--<asp:TextBox ID="txtfundtype" runat="server" Text='<%# Eval("fundtype") %>' />--%>
            </td>
    <td> <asp:Label ID="txtStateAlotAmt" runat="server" Text='<%# Eval("StateAlotAmt") %>'   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                <%--<asp:TextBox ID="txtStateAlotAmt" runat="server" Text='<%# Eval("StateAlotAmt") %>' />--%>
            </td>
             <td>
                <asp:Label ID="txtStateSanctAmt" runat="server" Text='<%# Eval("StateSanctAmt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:Label ID="txtRecieptPayment" runat="server" Text='<%# Eval("RecieptPayment") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td><td><table>
          
            <tr>
                <th>  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AnnualPlanAssuredtype") %>' /></th>
                <td>  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("AnnualPlanAssuredAmt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            </tr></table></td>
            <td><table>
            <tr>
                <td>  <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("manoenSpentAmt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
                <td>  <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("manoenSpentPerce") %>' /></td>
            </tr> </table></td>
            <td><table>
           <tr> <td>  <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("LapseAmt") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
            <td>  <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("LapsePerce") %>' /></td></tr>
        </table></td></tr>
           <%-- </table>
            </td>
           </tr>--%>
           </ItemTemplate>
                        


</asp:Repeater></div></div>
                  
                        </div>
                    </div>
                </div>


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

