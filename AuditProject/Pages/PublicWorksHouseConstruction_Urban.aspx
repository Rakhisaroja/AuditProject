<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PublicWorksHouseConstruction_Urban.aspx.cs" Inherits="Pages_PublicWorksConstruction_Urban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചിലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ഇ) മരാമത്ത്കാര്യം സ്റ്റാന്റിംഗ് കമ്മിറ്റി

</strong>
                        </div>
                        <div class="card-header">
                            <strong class="card-titlen">ഇ(IV) ഭവന നിര്‍മാണം
</strong>
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
                            &nbsp;<asp:Label ID="lblCommID" runat="server" Visible="False"></asp:Label></td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>
                        <td style="width: 362px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text="1. ഭവന നിര്‍മ്മാണത്തിന്റെ  പേര്" Font-Bold="True" Width="334px" />
                            <strong><span style="color: #000000">(*)</span></strong></td>
                        <td style="width: 381px; height: 28px;" align="left"> <asp:TextBox ID="txtnameofhouseconsruction"  runat="server" Text= "" Width="413px" /></td>
                        </tr>
                        
                           <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left"  > 
                            <strong><span style="font-size: 12pt; font-family: Meera;
                                        mso-fareast-font-family: Calibri; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB;
                                        mso-bidi-language: ML"><strong><span style="color: #000000"><span lang="ML"><asp:Label ID="Label2" runat="server" Text="2. ഗുണഭോക്താക്കളുടെ എണ്ണം" Font-Bold="True" Width="342px" />(*)</span></span></strong></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtnoofbeneficiary" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   runat="server" Text= "" Width="413px"  oncopy="return false;" onpaste="return false;"/></td>
                        </tr>
                        
                        
                        
                       <%-- NEW with change--%>
                        
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left" > 
                            <strong>
                                <span style="font-family: Meera"><span style="color: #000000"><span lang="ML"><asp:Label ID="Label3" runat="server" Text="3. ചെലവഴിച്ച തുക" Font-Bold="True" Width="342px" Height="32px" />(*)</span><o:p></o:p></span></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtamount"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"    runat="server" Text= "" Width="413px" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                        
                        
                      
                      
                            <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 362px; height: 28px;" align="left" > 
                            <strong>
                                <span style="font-family: Meera"><span style="color: #000000"><span lang="ML"><asp:Label ID="Label4" runat="server" Text="4. പൂര്‍ത്തീകരിച്ചവയുടെ എണ്ണം" Font-Bold="True" Width="342px" Height="32px" />(*)</span><o:p></o:p></span></span></strong></td>
                       <td align="left"><asp:TextBox ID="txtnoofcompleted"   onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text= "" Width="413px"  oncopy="return false;" onpaste="return false;"/></td>
                        </tr>
                        
                        
                        
                        
              
                        
                        
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" />
         <asp:Label ID="lblGSNo" runat="server" Text="Label" Visible="False"></asp:Label>
         
         </td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        
                        
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                       <%-- <asp:GridView id="grvBalanced" runat="server"  AutoGenerateColumns="False"   Width="100%" CellPadding="2" BackColor="White" BorderColor="Silver" Font-Names="Meera" OnRowCreated="grvBalanced_RowCreated"  >
                       --%>
                     <%--  <div class="card-body">--%>
                       <asp:Repeater ID="grvOther" runat="server"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <%--<th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 ഭവന നിര്‍മ്മാണത്തിന്റെ  പേര്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 ഗുണഫോക്താക്കളുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <%-- <th></th>--%>
                   <th scope ബാങ്ക്="col" style="width: 100px"  align="center">
                   ചെലവഴിച്ച തുക
                </th>
                  
                <th scope ബാങ്ക്="col" style="width: 100px"  align="center">
                    പൂര്‍ത്തീകരിച്ചവയുടെ എണ്ണം
                </th> 
                 
                
                        
                     <th scope="col" style="width: 200px" align="center">
                  ഭവന നിര്‍മ്മാണത്തിന്റെ  പേര്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                  ഗുണഫോക്താക്കളുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope ബാങ്ക്="col" style="width: 90px"  align="center">
                    ചെലവഴിച്ച തുക
                </th>
                  
                <th scope ബാങ്ക്="col" style="width: 100px"  align="center">
                    പൂര്‍ത്തീകരിച്ചവയുടെ എണ്ണം
                </th> 
                 
                
              
                  
            </tr>
           
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <%--<td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>--%>
            
            <td>
             <asp:Label ID="intHouselID" runat="server"  Visible="false" Text='<%# Eval("intHouselID") %>' />
            
            <asp:TextBox ID="chvnameofconstruction" runat="server" Text='<%# Eval("chvnameofconstruction") %>' />
            </td>
            <td> <asp:TextBox ID="intnoofbenediciaries" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   Text='<%# Eval("intnoofbenediciaries") %>' oncopy="return false;" onpaste="return false;"/>
            </td>
            <td><asp:TextBox ID="floatamount" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"   Text='<%# Eval("floatamount") %>'  oncopy="return false;" onpaste="return false;"/>
            </td>
              <td><asp:TextBox ID="intnoofcompleted" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intnoofcompleted") %>' oncopy="return false;" onpaste="return false;"/>
            
             
            </td>
            <td><asp:TextBox ID="chvnameofconstructionAud" runat="server" Text='<%# Eval("chvnameofconstructionAud") %>' /></td>
            
               <td><asp:TextBox ID="intnoofbenediciariesAud" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  runat="server" Text='<%# Eval("intnoofbenediciariesAud") %>' oncopy="return false;" onpaste="return false;"/></td>
            
             <td><asp:TextBox ID="floatamountAud"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("floatamountAud") %>'  oncopy="return false;" onpaste="return false;"/></td>
            
            <td><asp:TextBox ID="intnoofcompletedAud"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" runat="server" Text='<%# Eval("intnoofcompletedAud") %>' oncopy="return false;" onpaste="return false;" /></td>
            
            
            
          
         
            
            
            
            
            
            
           </tr></ItemTemplate>
              <FooterTemplate></table></FooterTemplate>          


</asp:Repeater><%--</div>--%></div>     


</div><div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
         
          <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" />
     </td></tr></table></div></div> 
                  
                        </div>
                   <%-- </div>--%>
                </div>
 

                </div>
            </div><!-- .animated -->
        </div>

<asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinanceWrkgrp">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

</ContentTemplate></asp:UpdatePanel>



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

