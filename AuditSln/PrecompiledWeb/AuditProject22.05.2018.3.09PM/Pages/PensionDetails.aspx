<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_PensionDetails, App_Web_gj0yjz6k" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">വരവ് ഭാഗം
                    </div>
             
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-titlen">5. വിവിധ പെന്‍ഷനുകള്‍ - അപേക്ഷ തീര്‍പ്പാക്കല്‍ വിവരങ്ങള്‍</strong>
                                
                            </div>
                            
                       <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                            
                            
                           <asp:Repeater ID="rptPension" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                പെന്‍ഷനുകള്‍
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 അപേക്ഷകരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                    സമയപരിധിക്കുള്ളില്‍ അനുവദിച്ചവയുടെ എണ്ണം
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   സമയപരിധി കഴിഞ്ഞ് അനുവദിച്ചവയുടെ എണ്ണം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                    നിരസിച്ചവയുടെ എണ്ണം
                </th>
               
                  
                   <th scope="col" style="width: 200px" align="center">
                പെന്‍ഷനുകള്‍
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                 അപേക്ഷകരുടെ എണ്ണം
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                    സമയപരിധിക്കുള്ളില്‍ അനുവദിച്ചവയുടെ എണ്ണം
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   സമയപരിധി കഴിഞ്ഞ് അനുവദിച്ചവയുടെ എണ്ണം
                </th>
                 <th scope="col" style="width: 100px" align="center">
                    നിരസിച്ചവയുടെ എണ്ണം
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
            <td>
            
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvpensionmal") %>' />
              <asp:Label ID="intpensionid" runat="server" Text='<%# Eval("intpensionid") %>' Visible="false" />
           
            </td>
            <td><asp:TextBox ID= "intapplicationcount" runat="server" Text='<%# Eval("intapplicationcount") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/></td>
             <td>
                <asp:TextBox ID= "intapprovedwithintimelimit" runat="server" Text='<%# Eval("intapprovedwithintimelimit") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
            <td>
                <asp:TextBox ID= "intapprovedaftertimelimit" runat="server" Text='<%# Eval("intapprovedaftertimelimit") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
               <asp:TextBox ID= "intrejected" runat="server" Text='<%# Eval("intrejected") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
          
            <td>
            
              <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvpensionmal") %>' />
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("intpensionid") %>' Visible="false" />
            </td>
             <td>
                 <asp:TextBox ID= "intapplicationcountaudited" runat="server"  Text='<%# Eval("intapplicationcountaudited") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
            </td>
             <td>
                <asp:TextBox ID= "intapprovedwithintimelimitaudited" runat="server"  Text='<%# Eval("intapprovedwithintimelimitaudited") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric"/>
                 <td>
                  <asp:TextBox ID= "intapprovedaftertimelimitaudited" runat="server"  Text='<%# Eval("intapprovedaftertimelimitaudited") %>'  onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
                 <td>
                <asp:TextBox ID= "intrejectedaudited" runat="server"  Text='<%# Eval("intrejectedaudited") %>' onkeypress="return  isNumberKey(event)" CssClass="txtBoxNumeric" />
               
            
            </td>
            </td>
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater>


</div></div>
<div> <table width="100%"> <tr> <td colspan="3" style="width: 1000px" align="center">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
 
                               <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm"
                                    OnClick="btnsave_Click"
                                    TabIndex="10"
                                    Text="Save" />
                                     <asp:Button ID="btnNxt" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnNxt_Click"
                                        Text="NEXT" Width="62px" />
                               </td></tr> 
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

