<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PublicShelter_Urban.aspx.cs" Inherits="Pages_PublicShelter_Urban"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">ഇ. മരാമത്ത്കാര്യ  സ്റ്റാന്റിംഗ് കമ്മിറ്റി
</strong>
                        </div><div class="card-header">
                            <strong class="card-titlen">പാര്‍പ്പിടം</strong>
                        </div>
                         <div>
                             &nbsp;</div>
                        <%--BKJKBJK --%>
                          <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="true">
                        <table  >
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:80px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             നിലവിലുള്ള വിവരങ്ങള്‍</th>
                            <th align="center" colspan="1">
                                &nbsp;ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍</th>
                         
                        </tr>
                          
                     
                          
                         
                          
                            
                            <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label27" runat="server" Text="ഭവനരഹിതരുടെ എണ്ണം " Font-Bold="True" Width="488px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txthomelessno"   runat="server" Text= "" Width="200px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Height="31px" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                    <asp:TextBox ID="txtAudhomelessno"   runat="server" Text= "" Width="200px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Height="31px" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                             <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label2" runat="server" Text="ഭൂരഹിതരുടെ എണ്ണം " Font-Bold="True" Width="488px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtlandless"   runat="server" Text= "" Width="200px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Height="39px" oncopy="return false;" onpaste="return false;" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                     <asp:TextBox ID="txtAudlandless"   runat="server" Text= "" Width="200px" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Height="39px" oncopy="return false;" onpaste="return false;" /></td>
                            </tr>
                                <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label1" runat="server" Text="അഗതി ആശ്രയ പദ്ധതി " Font-Bold="True" Width="488px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtpoorrelief"   runat="server" Text= "" Width="200px"  Height="39px" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                     <asp:TextBox ID="txtAudpoorrelief"   runat="server" Text= "" Width="200px"  Height="39px" /></td>
                            </tr>
                           
                           
                           
                           <tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="left" style="width: 164px; height: 28px">
                                    <asp:Label ID="Label3" runat="server" Text="രണ്ടാംഘട്ട ഗുണഭോക്താക്കളുടെ എണ്ണം" Font-Bold="True" Width="488px" /></td>
                                <td align="left" style="height: 28px">
                                    <asp:TextBox ID="txtnoofbeneficiary"   runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="200px"  Height="39px" oncopy="return false;" onpaste="return false;"/></td>
                                <td align="left" style="width: 381px; height: 28px">
                                     <asp:TextBox ID="txtAudnoofbeneficiary"   runat="server"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Text= "" Width="200px"  Height="39px" oncopy="return false;" onpaste="return false;"/></td>
                            </tr>
                            
                            
                            <%--<tr>
                                <td style="width: 80px;">
                                </td>
                                <td align="right" style="width: 362px; height: 28px">
                                </td>
                                <td align="center" style="width: 381px; height: 28px">
                                    <asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" /></td>
                                <td align="left" style="width: 381px; height: 28px">
                                </td>
                            </tr>
                        
                           <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                        
                            <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                             <tr>
                          <td   style="width:80px">
                            &nbsp;</td>
                        </tr>
                            <tr>
                                <td style="width: 80px">
                                </td>
                            </tr>
                        <tr>
                         <td   style="width:80px">
                            &nbsp;</td>
                        </tr>--%>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        <div class="card-body">  
                       <div style="width:100%"><table style="width: 1218px"><tr><td style="width: 58px; height: 51px;" align="center" valign="middle">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnPrev" runat="server" Text="BACK" OnClick="btnPrev_Click" Width="63px"></asp:Button>
     <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
         Text="SAVE" Width="63px" />&nbsp;
     <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNext_Click"
         Text="NEXT" Width="63px" /></td></tr></table></div></div></div>

                 
                          
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

