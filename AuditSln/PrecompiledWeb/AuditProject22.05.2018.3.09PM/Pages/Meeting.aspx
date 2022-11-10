<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_Meeting, App_Web_cllhm4gw" title="Untitled Page" %>

<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
                    <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           
I.ii യോഗനടപടികളുടെ വിവരം


</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><o:p></o:p></span></p>
                    </div>
                        <div class="card">
                           <%-- <div class="card-header">
                                <strong class="card-titlen">എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍</strong>
                                
                            </div>--%>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptMeeting" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                ഗ്രാമപഞ്ചായത്ത് യോഗം ചേര്‍ന്ന തീയതി
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               ഹാജര്‍ നില
                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം
                </th>
                           
                <th scope="col" style="width: 200px" align="center">
                ഗ്രാമപഞ്ചായത്ത് യോഗം ചേര്‍ന്ന തീയതി
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               ഹാജര്‍ നില
                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം
                </th>
                  
            </tr>
             
    </HeaderTemplate>
      <%-- <ItemTemplate>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvincometypemal") %>' />
            </td>
            
            </ItemTemplate>--%>
    <ItemTemplate>
       
            <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
                 <asp:Label ID="lblNumId" runat="server" Text='<%# Eval("numid") %>' Visible="false" />
            </td>
           
            <td><asp:TextBox ID= "dtcommittee" runat="server" Text='<%# Eval("dtcommittee") %>' /></td>
              <cc1:CalendarExtender id="CalendarExtender3"  runat="server" TargetControlID="dtcommittee" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
             <td>
                <asp:TextBox ID= "intattendancettot" runat="server" Text='<%# Eval("intattendancettot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:TextBox ID= "intmotiontot" runat="server" Text='<%# Eval("intmotiontot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             
          
            <td>
                <asp:TextBox ID= "dtauditedcommittee" runat="server" Text='<%# Eval("dtauditedcommittee") %>' />
                 <cc1:CalendarExtender id="CalendarExtender1"  runat="server" TargetControlID="dtauditedcommittee" Format="dd/MM/yyyy" PopupPosition="topleft"></cc1:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID= "intauditedattendancettot" runat="server" Text='<%# Eval("intauditedattendancettot") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
            </td>
            <td>
                <asp:TextBox ID= "intauditedmotiontot" runat="server" Text='<%# Eval("intauditedmotiontot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
           
           
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr>
                               
                               <td colspan="3" style="width: 1000px" align="center">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
 
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnsave_Click" Width="63px"></asp:Button>&nbsp;
                      
                        
                     
                                    
                                    
                                    <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" /></td>
                               
                               
                               </tr> 
                              </table>
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

