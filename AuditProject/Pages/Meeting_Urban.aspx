<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="Meeting_Urban.aspx.cs" Inherits="Pages_Meeting_Urban" %>

<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                   <%-- <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>--%>
          
                        <div class="card">
                           <div class="card-header">
                                <strong class="card-titlen">I.(iv)യോഗനടപടികളുടെ വിവരം</strong>
                                
                            </div>
                              <asp:Button id="btnNew" onclick="btnNew_Click" runat="server" Text="NEW  DETAILS" Width="150px" CssClass="btn btn-secondary btn-sm"></asp:Button> 
                            <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlNewEntry" runat="server" Visible="false">
                        <table style="width: 936px">
                        <tr>
                       <%-- <th  >ക്രമ നമ്പര്‍</th>--%> <td   style="width:50px">
                            &nbsp;</td>
                         <th colspan="2" align="center" >
                             <span lang="ML"
                                 style="font-size: 12pt;
                                 color: #000000;
                                 font-family: 'Meera','sans-serif';
                                 mso-fareast-font-family: Calibri;
                                 mso-ansi-language: EN-GB;
                                 mso-fareast-language: EN-GB;
                                 mso-bidi-language: ML">
                                 യോഗങ്ങള്‍
                                 കൂടിയതിന്റെ
                                 <span lang="ML"
                                     style="font-size: 12pt;
                                     font-family: 'Meera','sans-serif';
                                     mso-fareast-font-family: Calibri;
                                     mso-ansi-language: EN-GB;
                                     mso-fareast-language: EN-GB;
                                     mso-bidi-language: ML">
                                     വിവരങ്ങള്‍</span></span></th>
                         
                        </tr>
                        <tr> <td   style="width:50px; height: 28px;">
                            &nbsp;</td>
                        <%--<td> <asp:Label ID="label2" runat="server" Text="1" /></td>--%>     
                        <td style="width: 350px; height: 28px;" align="left"> <asp:Label ID="label1" runat="server" Text=" മുനിസിപ്പാലിറ്റി/കോർപ്പറേഷൻ കൗൺസിലുകള്‍ യോഗം ചേര്‍ന്ന തീയതി " Font-Bold="True" />
                            (*)</td>
                        <td style="width: 381px; height: 28px;" align="left"><asp:TextBox ID="dtMeetingDate" runat="server" Text= "" Width="176px"  CssClass="txtDate" oncopy="return false;" onpaste="return false;"  />
                        
                         <asp:CompareValidator
    id="CompareValidator28" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="dtMeetingDate" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator> 
                        
                        </td>
                        </tr>
                        
                        
                        
                             <%-- New--%>
                    
                       <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> ആകെ അംഗങ്ങളുടെ എണ്ണം:</strong></td>
                       <td><asp:TextBox ID="txttotalmembr" runat="server" Text= "" Width="176px"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                        
                        
                        
                        
                      <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"  > 
                            <strong> ഹാജര്‍ നില:</strong></td>
                       <td><asp:TextBox ID="txtAttndnceCnt" runat="server" Text= "" Width="176px"  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" oncopy="return false;" onpaste="return false;" /></td>
                        </tr>
                        
               
                        
                  
                     
                     
                     
                       
                             <tr>
                          <td   style="width:50px">
                            &nbsp;</td>
                        <td style="width: 279px; height: 28px;" align="left"> 
                            <strong>  അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം   </strong></td>
                       <td><asp:TextBox ID="txtMtnCnt" runat="server" Text= "" onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" Width="176px" oncopy="return false;" onpaste="return false;"/>
                      </td>
                       
                        </tr>
                         
                            
                        <tr>
                         <td   style="width:50px">
                            &nbsp;</td>
                        <td colspan="2" align="center">
                            &nbsp;<asp:Button ID="btnNewSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNewSave_Click"
         Text="SAVE" Width="63px" /></td>
                        </tr>
                        
                        
                            
                        </table></asp:Panel></div></div>
                        
                        
                               <div class="card-body"> 
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                            
                            
                           <asp:Repeater ID="rptMeeting" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="4"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="4"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                മുനിസിപ്പാലിറ്റി/കോർപ്പറേഷൻ കൗൺസിലുകള്‍ യോഗം ചേര്‍ന്ന തീയതി 
                </th>
             
             
               <th scope="col" style="width: 200px"  align="center">
               ആകെ അംഗങ്ങളുടെ എണ്ണം
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               ഹാജര്‍ നില
                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം
                </th>
                           
                <th scope="col" style="width: 200px" align="center">
                 മുനിസിപ്പാലിറ്റി/കോർപ്പറേഷൻ കൗൺസിലുകള്‍ യോഗം ചേര്‍ന്ന തീയതി
                </th>
             
             
               <th scope="col" style="width: 200px"  align="center">
               ആകെ അംഗങ്ങളുടെ എണ്ണം
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
                 <asp:Label ID="intcommitteeno" runat="server" Text='<%# Eval("intcommitteeno") %>' Visible="false" />
            </td>
           
            <td><asp:TextBox ID= "dtcommittee" runat="server" Text='<%# Eval("dtcommittee") %>' CssClass="txtDate" ReadOnly="true"/></td>
             
          <%--  new--%>
            
             <td>
                <asp:TextBox ID= "inttotalmembrs" runat="server" Text='<%# Eval("inttotalmembers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/>
            </td>
            
            
             <td>
                <asp:TextBox ID= "intattendancettot" runat="server" Text='<%# Eval("intattendancettot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intmotiontot" runat="server" Text='<%# Eval("intmotiontot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/>
            </td>
             
          
            <td>
                <asp:TextBox ID= "dtauditedcommittee" runat="server" Text='<%# Eval("dtauditedcommittee") %>' CssClass="txtDate" ReadOnly="true"/>
                 
            </td>
            
            
               <%--  new--%>
            
             <td>
                <asp:TextBox ID= "intAudtotalmembers" runat="server" Text='<%# Eval("intAudtotalmembers") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/>
            </td>
            
            
            <td>
                <asp:TextBox ID= "intauditedattendancettot" runat="server" Text='<%# Eval("intauditedattendancettot") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"  ReadOnly="true"/>
            </td>
            <td>
                <asp:TextBox ID= "intauditedmotiontot" runat="server" Text='<%# Eval("intauditedmotiontot") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" ReadOnly="true"/>
            </td>
            <td>
                 <asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return confirmdelete()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
                
            
            </td>
           
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


</div></div>

</div>
<div> <table width="100%"> <tr>
                               
                              <td style="width: 1200px; height: 51px;" align="Center" colspan="3">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
 
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="Button1" runat="server" Text="SAVE" OnClick="btnsave_Click" Width="63px"></asp:Button>&nbsp;
                      
                        
                     
                                    
                                    
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

