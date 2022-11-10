<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="DrinkingWaterList.aspx.cs" Inherits="Pages_DrinkingWaterList"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ഡി. ആരോഗ്യം വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി
</strong>
                        </div><div class="card-header">
                            <strong class="card-titlen">കുടിവെള്ള പദ്ധതി വിവരങ്ങള്‍</strong>
                        </div>
                         <div>
                             &nbsp;</div>
                        <%--BKJKBJK --%>
                          <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="true">
                        <table style="width: 1088px; height: 449px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             നിലവിലുള്ള വിവരങ്ങള്‍</th>
                            <th align="center" colspan="1">
                                &nbsp;ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍</th>
                         
                        </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                    <asp:Label ID="label1" runat="server" Text="1. കുടിവെള്ള പദ്ധതികള്‍ (എണ്ണം)" Font-Bold="True" Width="314px" />(*)</td>
                            </tr>
                        <tr> <td   style="width:50px; height: 14px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td align="left">
                            &nbsp;<asp:Label ID="Label12" runat="server" Text="നിലവിലുള്ളത്" Font-Bold="True" Width="120px" />
                        </td>
                        <td style="width: 162px; height: 14px;" align="left"> 
                           <table><tr>
                               <td >
                                   <asp:Label ID="label9" runat="server" Text="ഗുണ.സമിതി" Font-Bold="True" Width="122px" /></td>
                               <td >
                                   <asp:Label ID="label11" runat="server" Text="നേരിട്ട്" Font-Bold="True" Width="122px" /></td>
                           </tr>
                               <tr>
                                   <td>
                                       <asp:TextBox ID="txtdwprojectexistingbeneficiary"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                   <td>
                                       <asp:TextBox ID="txtdwprojectexistingdirect"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                               </tr>
                           </table> 
                            
                            </td>
                            <td align="left" style="width: 381px; height: 14px">
                                <table>
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label14" runat="server" Text="ഗുണ.സമിതി" Font-Bold="True" Width="122px" /></td>
                                        <td >
                                            <asp:Label ID="Label15" runat="server" Text="നേരിട്ട്" Font-Bold="True" Width="122px" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtAuddwprojectexistingbeneficiary"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                        <td>
                                            <asp:TextBox ID="txtAuditdwprojectexistingdirect"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" style="width: 362px; height: 28px">
                                </td>
                                <td align="left" style="width: 162px; height: 28px">
                                </td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label13" runat="server" Text="പുതുതായി നിര്‍മ്മിച്ചത്" Font-Bold="True" Width="157px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <table>
                                        <tr>
                                            <td >
                                                <asp:Label ID="Label8" runat="server" Text="ഗുണ.സമിതി" Font-Bold="True" Width="122px" /></td>
                                            <td >
                                                <asp:Label ID="Label10" runat="server" Text="നേരിട്ട്" Font-Bold="True" Width="122px" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtdwprojectnewbeneficiary"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                            <td>
                                                <asp:TextBox ID="txtdwprojectnewdirect"   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <table>
                                        <tr>
                                            <td >
                                                <asp:Label ID="Label16" runat="server" Text="ഗുണ.സമിതി" Font-Bold="True" Width="122px" /></td>
                                            <td >
                                                <asp:Label ID="Label17" runat="server" Text="നേരിട്ട്" Font-Bold="True" Width="122px" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAuditdwprojectnewbeneficiary"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                            <td>
                                                <asp:TextBox ID="txtAuditdwprojectnewdirect"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="94px" MaxLength="5" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                </td>
                            </tr>
                          
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                    <asp:Label ID="Label18" runat="server" Text="2. കുടിവെള്ള പദ്ധതി ജലസ്രോതസുകളുടെ വിവരം (എണ്ണം)" Font-Bold="True" Width="424px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label19" runat="server" Text="കിണര്‍ " Font-Bold="True" Width="68px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtwell" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditwell" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label20" runat="server" Text="കുഴല്‍കിണര്‍ " Font-Bold="True" Width="95px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtborewell" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditborewell" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label21" runat="server" Text="കുളം " Font-Bold="True" Width="42px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtpond" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditpond" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label29" runat="server" Text="അരുവി " Font-Bold="True" Width="74px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtstream" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditStream" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label30" runat="server" Text="നദി "   Font-Bold="True" Width="89px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtriver" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditriver" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                    <asp:Label ID="Label2" runat="server" Text=' 3. "ജലനിധി" പ്രകാരമുള്ള കുടിവെള്ള പദ്ധതികളുടെ വിവരം' Font-Bold="True" Width="425px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" style="width: 362px; height: 28px">
                                    <asp:Label ID="Label3" runat="server" Text="ഗുണഭോക്താക്കളുടെ എണ്ണം" Font-Bold="True" Width="177px" /></td>
                                <td align="left" style="width: 162px; height: 28px">
                                    <asp:TextBox ID="txtBenefi"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAuditBenefi"   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="138px" MaxLength="5" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="right" style="width: 362px; height: 28px">
                                </td>
                                <td align="center" style="width: 162px; height: 28px">
                                </td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="left" colspan="3">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="4. പൊതു ടാപ്പുകളുടെ വിവരങ്ങള്‍ :-"
                                        Width="439px"></asp:Label></td>
                            </tr>
                            <tr><td colspan="4">
                            <asp:Repeater ID="grvTap" runat="server" >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
         <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                    ക്ര.നം
                </th>
                     <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                    വാര്‍ഡ് നം/ പേര്
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
             <tr>
            
                <th scope="col" style="width: 300px" align="center" >
                   നിലവിലുള്ള എണ്ണം
                </th>
                <th scope="col" style="width: 300px" align="center" >
                    പുതുതായി നല്‍കിയ എണ്ണം
                </th>
                
                 <th scope="col" style="width: 300px" align="center" >
                    നിലവിലുള്ള എണ്ണം
                </th>
                <th scope="col" style="width: 300px" align="center" >
                    പുതുതായി നല്‍കിയ എണ്ണം
                </th>
                 
                          
            </tr>
            
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
         <td>
                   <asp:Label ID="SLNO" Width="80px" runat="server" Text='<%# Eval("SLNO") %>'></asp:Label></td>
            <td>
                   <asp:Label ID="intWardNo" Width="100px" Visible="false" runat="server" Text='<%# Eval("intWardNo") %>'  ></asp:Label>
                   <asp:Label ID="chvWardMalName" Width="400px" runat="server" Text='<%# Eval("chvWardMalName") %>'  ></asp:Label></td>
          
    <td> 
                  <asp:TextBox ID="inttapsexisting" Width="100px"  MaxLength="5" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("inttapsexisting") %>' ReadOnly="true"></asp:TextBox>
                    <%--<asp:Label ID="intDirectionType" Width="200px" Visible="false"   runat="server" Text='<%# Eval("intDirectionType") %>'></asp:Label>--%>
            </td>
             <td>
                  <asp:TextBox ID="inttapsnew" Width="100px" MaxLength="5" ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("inttapsnew") %>'> </asp:TextBox>
            </td>
               <td>
                   <asp:TextBox ID="intaudtapsexisting" MaxLength="5" Width="100px" ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intaudtapsexisting") %>'> </asp:TextBox></td>
             <td>
                   <asp:TextBox ID="intaudtapsnew" Width="100px" MaxLength="5" ReadOnly="true" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intaudtapsnew") %>'> </asp:TextBox></td>
             
             </tr> 
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
</asp:Repeater></td></tr>
                            <tr>
                                <td style="width: 50px; height: 28px">
                                </td>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
         Text="BACK" Width="63px" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
         Text="NEXT" Width="63px" /></td>
                            </tr>
                           
                            
                        </table></asp:Panel></div></div>
                        </div>

                 
                          
                      <%--  </div>--%>
                      <%--  </div>--%>
                         
                </div>   
               </div> 
             </div>  
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

	 	 	 	 	   
												 	 
