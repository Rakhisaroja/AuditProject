<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="GramasabhaDetails.aspx.cs" Inherits="Pages_GramasabhaDetails"  %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>--%>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
               <%-- <div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ഗ്രാമ/വാര്‍ഡ്സഭ വിവരങ്ങള്‍</strong>
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
                             പുതിയ വിവരങ്ങള്‍</th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 314px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. വാര്‍ഡ് നം / പേര്" Font-Bold="True" Width="143px" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left"> 
                            <asp:DropDownList ID="ddlWardNo" runat="server" OnSelectedIndexChanged="ddlWardNo_SelectedIndexChanged"
                                Width="48px" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlWardName" runat="server" OnSelectedIndexChanged="ddlWardName_SelectedIndexChanged"
                                Width="224px" AutoPostBack="True">
                            </asp:DropDownList></td>
                        </tr>
                        
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>2. വോട്ടര്‍മാരുടെ എണ്ണം</strong></td>
                       <td><table><tr><td>സ്ത്രീ</td><td><asp:TextBox ID="txtnoofFemaleVote" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="100px" /></td></tr>
                       <tr><td>പുരുഷന്‍</td><td><asp:TextBox ID="txtnoofMaleVote" runat="server" Text= "" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td></tr></table></td>
                        </tr>
                        <tr><td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <td colspan="2" style="width:1000px; height: 28px;">
                            &nbsp;</td>
                        </tr>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left" > 
                            <strong>3. പങ്കെടുത്ത വോട്ടര്‍മാരുടെ എണ്ണം</strong></td>
                       <td><table><tr><td>സ്ത്രീ</td><td><asp:TextBox ID="txtnoofFemaleParicipate" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text= "" Width="100px" /></td></tr>
                       <tr><td>പുരുഷന്‍</td><td><asp:TextBox ID="txtnoofMaleParicipate" runat="server" Text= "" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" /></td></tr></table></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>4. ഗ്രാമ/വാര്‍ഡ്സഭ കൂടിയ സ്ഥലം (*)</strong></td>
                       <td><asp:TextBox ID="ttxGSPlace" runat="server" Text= "" Width="376px" /></td>
                        </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>5. തീയതി (*)</strong></td>
                       <td><asp:TextBox ID="txtGSDate" CssClass="txtDate"  runat="server" Text= "" Width="176px" />
                         </tr>
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong>6. റിമാര്‍ക്ക്സ് (*)</strong></td>
                       <td><asp:TextBox ID="txtRemarks" runat="server" Text= "" Width="376px" TextMode="MultiLine" /></td>
                        </tr>
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" />
                            <asp:Label ID="lblGSNo" runat="server" Text="Label" Visible="False" Width="59px"></asp:Label></td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        <%-- BKJKBJK --%>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                     
                          <asp:Repeater ID="grvMergeHeader" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table  id="Table1"  cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr class="header">
                <th scope="col" style="text-align:center"  align="center" colspan="9"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="9"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr class="header1">
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
                    ഗ്രാമ/വാര്‍ഡ്സഭ കൂടിയ സ്ഥലം
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
                    ഗ്രാമ/വാര്‍ഡ്സഭ കൂടിയ സ്ഥലം
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle">
                    തീയതി
                </th>
                   <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle"> ഹാജര്‍ ശതമാനം </th>
                  
                       <th scope="col" style="width: 100px" rowspan="2" align="center" valign="middle">
                    റിമാര്‍ക്ക്സ്
                </th>
               
            </tr>
              <tr class="header2">
            
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
                <asp:TextBox ID="intWardNo" Visible="false" ReadOnly="true"    runat="server" Text='<%# Eval("intWardNo") %>' />
                 <asp:TextBox ID="name" ReadOnly="true" runat="server" Text='<%# Eval("name") %>' />
            </td>
            <td>
                <asp:TextBox ID="inttotVotersfemale" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
    <td>
                <asp:TextBox ID="inttotVotersMale" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
             <td>
                <asp:TextBox ID="intparticipantfemale" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:TextBox ID="intparticipantmale" runat="server"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:TextBox ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:TextBox ID="dtgramasabha" CssClass="txtDate"  runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:TextBox ID="fltAttenPrece" runat="server"  ReadOnly="true"   Text='<%# Eval("fltAttenPrece") %>' />
            </td>
            <td>
                <asp:TextBox ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            
             <td>
            <%-- <asp:TextBox ID="txtauditedwardno" runat="server" Text='<%# Eval("intauditedwardno") %>'></asp:TextBox>--%>
              <%--<asp:TextBox ID="intWardNo1" ReadOnly="true" runat="server" Width="50px" Text='<%# Eval("intWardNo1") %>' />--%>
               <asp:TextBox ID="name1" ReadOnly="true" runat="server" Text='<%# Eval("name") %>' />
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label8" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label9" runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>' />--%>
            </td>
             <td>
              <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
                <%--<asp:Label ID="Label10" runat="server" Text='<%# Eval("intauditedparticipantmale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="intauditedparticipantmale" Width="100px"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
                <%--<asp:Label ID="Label11" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="200px"   Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label12" runat="server" Text='<%# Eval("chvauditedplacemal") %>' />--%>
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="200px" CssClass="txtDate"   runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label13" runat="server" Text='<%# Eval("dtauditedgramasabha") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" ReadOnly="true" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
               <%-- <asp:Label ID="Label14" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>' />--%>
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="200px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 
               <%-- <asp:Label ID="Label15" runat="server" Text='<%# Eval("chvauditedremarks") %>' />--%>
            </td>
              <td>
                 <asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return confirmdelete()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
                
            
            </td>
            <%-- <td visible="false">
           <%--  <%# DataBinder.Eval(Container.DataItem, "intgramasabhano") %> 
         
            </td>--%>
        </tr> 
    </ItemTemplate>
    <FooterTemplate>
<%--      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>--%>
 </table>
    </FooterTemplate>
</asp:Repeater>



</DIV></section>
</div>

                 
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div> <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>&nbsp;
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     </td></tr></table></div>
<%--<div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>--%>

                </div>
            </div> 
         <%--   <table><tr><td style="height: 35px">       <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                        
                        </td>
                        </tr></table> 
        </div>
        
          
                        
                       
                        </ContentTemplate>
                     <Triggers><asp:PostBackTrigger  ControlID="grvMergeHeader" /></Triggers> 
                        </asp:UpdatePanel>--%>
                        
        
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
   
    <script type="text/javascript"> 
         function confirmdelete()
            {
                if (confirm("Are you sure to Delete this Data?")== true)
                 return true;
                   else
                return false; 
            }
            </script>

</asp:Content>

