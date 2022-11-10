<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PowerStreetLightExp_Urban.aspx.cs" Inherits="Pages_PowerStreetLightExp_Urban" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="content mt-3">
            <div class="animated fadeIn">
              <div class="row">

                <div class="col-md-12">
                    <div class="title-blue-Head">ചെലവ് ഭാഗം
                    </div>
                    
                     <div class="card-header">
                            <strong class="card-titlen">
                               4. ഉൗര്‍ജം</strong>
                        </div>
                        
                   
                        <div class="card">
                         
             



             <div class="card-body">       
                 
                      
                        
                      <div class="table table-striped table-bordered">             
                       <div style="font-weight: bold; font-size: 15pt; font-family: Meera" >
    <p class="Standarduser"
        style="margin: 0cm 0cm 0pt">
        <b><span
            lang="ML"
            style="color: #000000;
            font-family: 'Meera','sans-serif'">
           
8(d) തെരുവുവിളക്കുകളുടെ വെെദ്യുതി ചാര്‍ജ്
</span></b><span
                style="font-family: 'Meera','sans-serif'"><?xml
                    namespace=""
                    ns="urn:schemas-microsoft-com:office:office"
                    prefix="o" ?><o:p></o:p></span></p>
                    </div>
       
                     <%--   <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >--%>
                            
                            
                           <asp:Repeater ID="Rpt8D" runat="server"    >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 15px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th><th  rowspan="2">  മാസം</th>
                <th scope="col" style="text-align:center"  align="center"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center"   >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
               
            
                <th scope="col" style="width: 200px"  align="center">
              ഒടുക്കിയ തുക

                </th>
              
                  
            
                <th scope="col" style="width: 200px"  align="center">
              ഒടുക്കിയ തുക

                </th>
              
                  
            </tr>
             
    </HeaderTemplate>
    
    <ItemTemplate>
    <td>
        <asp:Label ID="numid" runat="server" Text='<%# Eval("numid") %>' Visible="false"/>
        <asp:Label ID="Label2" runat="server" Text='<%# Eval("SLNO") %>' />
        </td>
             <td>
                 <asp:Label ID= "chvmonthmal" runat="server"  Text='<%# Eval("chvmonthmal") %>' />
                 <asp:Label ID= "intmonthid" runat="server"  Text='<%# Eval("intmonthid") %>'  Visible="false"/>
            </td>
          
             <td>
                 <asp:TextBox ID= "numamount" runat="server"   ReadOnly="true"   Text='<%# Eval("numamount") %>'  CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
            </td>
             <td>
                <asp:TextBox ID= "numaudamount" runat="server"   ReadOnly="true"   Text='<%# Eval("numaudamount") %>'   CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"/>
              </td>
                 
            
            
           </tr></ItemTemplate>
                        
                        
     <FooterTemplate></table></FooterTemplate>  

</asp:Repeater>


<%--</div>--%>

</div>

</div>

 <table width="100%"> <tr> <td style="width: 1200px; height: 51px;" align="center" colspan="3">
 <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnBack_Click"
                                        Text="BACK" Width="62px" />
 
                               <asp:Button
                                    ID="Button2"
                                    runat="server"
                                    CssClass="btn btn-secondary btn-sm" 
                                    OnClick="BtnStreetLightExp_Click"
                                    TabIndex="10"
                                    Text="SAVE" />&nbsp;
                               </td></tr> 
                              </table>
                      </div>
                         
                </div>   
               </div> 
             </div>  
         </div>
</asp:Content>

