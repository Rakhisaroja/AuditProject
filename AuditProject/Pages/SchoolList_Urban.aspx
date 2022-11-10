<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="SchoolList_Urban.aspx.cs" Inherits="Pages_SchoolList_Urban"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">
                   ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">1.a)സ്കൂളുകളുടെ വിവരങ്ങള്‍</strong>
                        </div>
                        <div><asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW" Width="63px" CssClass="btn btn-secondary btn-sm"></asp:Button></div>
                        <%--BKJKBJK --%>
                          <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
                        <table style="width: 936px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             നിലവിലുള്ള വിവരങ്ങള്‍</th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. സ്കൂളിന്റെ പേര്" Font-Bold="True" Width="136px" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left"> <asp:TextBox ID="txtSchoolName" runat="server" Text= "" Width="352px" TextMode="MultiLine" /></td>
                        </tr>
                        
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                         <asp:Label ID="label2" runat="server" Text="2. വിദ്യാര്‍ത്ഥികളുടെ എണ്ണം" Font-Bold="True" Width="232px" />
                         
                           (*) </td>
                       <td><asp:TextBox ID="txtnoofStudent" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="80px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                        <tr><td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" style="width:1000px">
                            &nbsp;</td>
                        </tr>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left" > <asp:Label ID="Label3" runat="server" Text="3. അധ്യാപകരുടെ എണ്ണം" Font-Bold="True" Width="232px" />(*)</td>
                       <td><asp:TextBox ID="txtnoofTeacher" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="80px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px; height: 29px;">
                            &nbsp;</td>
                       <td style="height: 29px" align="center" colspan="2"><asp:Label ID="Label4" runat="server" Text="4. അടിസ്ഥാന സൗകര്യങ്ങളുടെ ലഭ്യത" Font-Bold="True" Width="344px" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="right"  > 
                            <strong>&nbsp;<asp:Label ID="Label7" runat="server" Text="ജലം" Font-Bold="True" Width="168px" /></strong></td>
                       <td align="left"><asp:TextBox ID="txtWater" runat="server" Text= "" Width="352px" TextMode="MultiLine" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px; height: 29px;">
                            &nbsp;</td>
                        <td style="width: 279px; height: 29px;" align="right" > 
                            <strong>&nbsp;<asp:Label ID="Label6" runat="server" Text="വെെദ്യുതി" Font-Bold="True" Width="216px" /></strong></td>
                       <td style="height: 29px"><asp:TextBox ID="txtElecricity" runat="server" Text= "" Width="352px" TextMode="MultiLine" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px; height: 29px;">
                            &nbsp;</td>
                        <td style="width: 279px; height: 29px;" align="right"  > 
                            <strong>&nbsp;<asp:Label ID="Label5" runat="server" Text="ഫര്‍ണീച്ചര്‍ (എണ്ണം)" Font-Bold="True" Width="224px" /></strong></td>
                       <td style="height: 29px" align="left"><asp:TextBox ID="txtnoofFurniture" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="ടോയിലറ്റ്  (എണ്ണം)" Font-Bold="True" Width="192px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtnoofToilet" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="വാഷ്ബയിസിന്‍ (എണ്ണം)" Font-Bold="True" Width="208px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtnoofWashbase" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="80px" MaxLength="5" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="പാചക പുര" Font-Bold="True" Width="208px" /></td>
                                <td align="left">
                                    <asp:TextBox ID="txtKitchen" runat="server" Text= "" Width="352px" TextMode="MultiLine" /></td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label11" runat="server" Text="5. പി.റ്റി.എ രൂപീകരിച്ചിട്ടുണ്ട്/ ഇല്ല" Font-Bold="True" Width="256px" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlpta" runat="server" Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" />
                            <asp:Label ID="lblGSNo" runat="server" Text="Label" Visible="False"></asp:Label></td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        <%-- BKJKBJK --%>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvMergeHeader" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="10"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   സ്കൂളിന്റെ പേര്
                </th>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                  വിദ്യാര്‍ത്ഥികളുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px" rowspan="2" align="center">
                    അധ്യാപകരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 300px" colspan="6" align="center">
                    അടിസ്ഥാന സൗകര്യങ്ങളുടെ ലഭ്യത
                </th>
                   <th scope="col" style="width: 300px" rowspan="2" align="center">
                    പി.റ്റി.എ രൂപീകരിച്ചിട്ടുണ്ട്/ ഇല്ല
                </th>   
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   സ്കൂളിന്റെ പേര്
                </th>
                <th scope="col" style="width: 300px" rowspan="2" align="center">
                  വിദ്യാര്‍ത്ഥികളുടെ എണ്ണം
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 300px" rowspan="2" align="center">
                    അധ്യാപകരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 300px" colspan="6" align="center">
                    അടിസ്ഥാന സൗകര്യങ്ങളുടെ ലഭ്യത
                </th>
                   <th scope="col" style="width: 200px" rowspan="2" align="center">
                    പി.റ്റി.എ രൂപീകരിച്ചിട്ടുണ്ട്/ ഇല്ല
                </th>                      
               
            </tr>
              <tr>
           
                <th scope="col" style="width: 100px" align="center">
                    ജലം
                </th>
                <th scope="col" style="width: 100px" align="center">
                    വെെദ്യുതി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ഫര്‍ണീച്ചര്‍ (എണ്ണം)
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ടോയിലറ്റ്  (എണ്ണം)
                </th>
                
                <th scope="col" style="width: 100px" align="center">
                  വാഷ്ബയിസിന്‍ (എണ്ണം)
                </th>
                <th scope="col" style="width: 100px" align="center">
                   പാചക പുര
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ജലം
                </th>
                <th scope="col" style="width: 100px" align="center">
                    വെെദ്യുതി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ഫര്‍ണീച്ചര്‍ (എണ്ണം)
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    ടോയിലറ്റ്  (എണ്ണം)
                </th>
                
                <th scope="col" style="width: 100px" align="center">
                  വാഷ്ബയിസിന്‍ (എണ്ണം)
                </th>
                <th scope="col" style="width: 100px" align="center">
                   പാചക പുര
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            
            
         
            <td>
            <asp:Label ID="intSchoolID" runat="server"  Visible="false" Text='<%# Eval("intSchoolID") %>' />
                <asp:TextBox ID="nchvSchoolName" runat="server"   Text='<%# Eval("nchvSchoolName") %>'/>
            </td>
    <td>
                <asp:TextBox ID="intstudentcount" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intstudentcount") %>' oncopy="return false;" onpaste="return false;" />
            </td>
             <td>
                <asp:TextBox ID="intteacherscount" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intteacherscount") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            <td>
                <asp:TextBox ID="chvbasicfacilitywater" runat="server"   Text='<%# Eval("chvbasicfacilitywater") %>' />
            </td>
            <td>
                <asp:TextBox ID="chvbasicfacilityelectricity" runat="server" Text='<%# Eval("chvbasicfacilityelectricity") %>' />
            </td>
             <td>
                <asp:TextBox ID="intfurniture" MaxLength="5" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intfurniture") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            <td>
                <asp:TextBox ID="inttoilet" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("inttoilet") %>'  oncopy="return false;" onpaste="return false;"/>
            </td>
            <td>
                <asp:TextBox ID="intwashbasin" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intwashbasin") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            
             <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <asp:TextBox ID="chvkitchen"   runat="server" Text='<%# Eval("chvkitchen") %>' />
            </td>
                 <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <%--<asp:TextBox ID="tnypta"   runat="server" Text='<%# Eval("tnypta") %>' />--%>
                     <asp:DropDownList ID="tnypta" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
            </td>
            <td> 
           <%-- <asp:Label ID="Label12" runat="server"  Visible="false" Text='<%# Eval("intSchoolID") %>' />--%>
                <asp:TextBox ID="nchvSchoolNameaudit" runat="server"   Text='<%# Eval("nchvSchoolNameaudit") %>' />
            </td>
    <td>
                <asp:TextBox ID="intstudentcountaudit" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intstudentcountaudit") %>' oncopy="return false;" onpaste="return false;" />
            </td>
             <td>
                <asp:TextBox ID="intteacherscountaudit" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intteacherscountaudit") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            <td>
                <asp:TextBox ID="chvbasicfacilitywateraudit" runat="server"   Text='<%# Eval("chvbasicfacilitywateraudit") %>' />
            </td>
            <td>
                <asp:TextBox ID="chvbasicfacilityelectricityaudit" runat="server" Text='<%# Eval("chvbasicfacilityelectricityaudit") %>' />
            </td>
             <td>
                <asp:TextBox ID="intfurnitureaudit" MaxLength="5" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intfurnitureaudit") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            <td>
                <asp:TextBox ID="inttoiletaudit" MaxLength="5" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("inttoiletaudit") %>' oncopy="return false;" onpaste="return false;" />
            </td>
            <td>
                <asp:TextBox ID="intwashbasinaudit" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intwashbasinaudit") %>'  oncopy="return false;" onpaste="return false;"/>
            </td>
            
             <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <asp:TextBox ID="chvkitchenaudit"   runat="server" Text='<%# Eval("chvkitchenaudit") %>' />
            </td>
                 <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <%--<asp:TextBox ID="tnyptaaudit"   runat="server" Text='<%# Eval("tnypta") %>' />--%>
                    <asp:DropDownList ID="tnyptaaudit" runat="server"   Width="98px">
                                        <asp:ListItem Value="0">----</asp:ListItem>
                                        <asp:ListItem Value="1">ഉണ്ട്</asp:ListItem>
                                        <asp:ListItem Value="2">ഇല്ല</asp:ListItem>
                                    </asp:DropDownList>
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
 </tr></table>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div> <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>&nbsp;
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
                        Text="NEXT" Width="63px" /></td></tr></table></div>
<%--<div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>--%>

                </div>
            </div> 
        </div><script type="text/javascript">
    
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

