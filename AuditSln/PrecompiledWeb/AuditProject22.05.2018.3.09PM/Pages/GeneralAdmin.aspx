<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_GeneralAdmin, App_Web_cllhm4gw" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">ചെലവിനം
                                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">I. GENERAL ADMINISTRATION</strong>
                        </div><div class="card-body">
                         <div class="card-header">
                            <strong class="card-titlen">a)Establishment expenditure  (employee related)</strong>
                        </div>
                        
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                          <asp:Repeater ID="grvGenralAdmin" runat="server" OnItemCommand="grvGenralAdmin_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
      <%--  <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                  Sl.No
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 400px;" align="center">
                    HEAD
                </th>
                <th scope="col" style="width: 200px"align="center">
                  Amount
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px"  align="center">
                   HEAD
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                   Amount
                </th>
                                
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
           <%-- <td>
                <asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>--%>
               <td><asp:Label ID="mainexpendituretype" runat="server" Text='<%# Eval("intmainexpendituretype") %>' Visible="false" />
            <asp:Label ID="subexpendituretype" runat="server" Text='<%# Eval("intsubexpendituretype") %>' Visible="false" />
           
           <asp:TextBox ID="txtHead" runat="server"  Width="100%" ReadOnly="true" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID="txtexpamounttotal" runat="server" Text='<%# Eval("numexpamounttotal") %>' /></td>
            <td><asp:TextBox ID="txtAuditHead" Width="100%" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
             
            </td> 
             <td>
                <asp:TextBox ID="txtauditedexpamounttotal" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />
            </td>
           
           </tr></ItemTemplate>
      <FooterTemplate>
        <tr><td colspan="4"><hr /></td></tr>
        <tr><td style="font-weight:bold">Total</td><%--<td></td >--%><td style="font-weight:bold"> 
        <asp:Label ID="expamounttotal" runat="server" Text='<%# Eval("numexpamounttotal") %>' />
       </td>
        <td></td>
        <td style="font-weight:bold">
        <asp:Label ID="Auditexpamounttotal" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />       
        </td></tr>
        </table>
        </FooterTemplate>
</asp:Repeater>



<%--</DIV>--%>
  <div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSaveAdmin" runat="server" Text="SAVE" OnClick="btnSaveAdmin_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>
</div>

                 
                        </div>
                      </div>
                        <div class="card-body">
                     <div class="card-header">
                            <strong class="card-titlen">b) Elected members</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                          <asp:Repeater ID="grvGenralAdminElected" runat="server" OnItemCommand="grvGenralAdminElected_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
        <%--<th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                  Sl.No
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ 
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 400px;" align="center">
                    HEAD
                </th>
                <th scope="col" style="width: 200px"align="center">
                  Amount
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px"  align="center">
                   HEAD
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                   Amount
                </th>
                                
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
          <%--  <td>
                <asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>--%>
               <td><asp:Label ID="mainexpendituretype" runat="server" Text='<%# Eval("intmainexpendituretype") %>' Visible="false" />
            <asp:Label ID="subexpendituretype" runat="server" Text='<%# Eval("intsubexpendituretype") %>' Visible="false" />
           
           <asp:TextBox ID="txtHead" runat="server" Width="100%" ReadOnly="true" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID="txtexpamounttotal" runat="server" Text='<%# Eval("numexpamounttotal") %>' /></td>
            
            <td><asp:TextBox ID="txtAuditHead" Width="100%" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
             
            </td> 
             <td>
                <asp:TextBox ID="txtauditedexpamounttotal" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />
            </td>
           
           </tr></ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div><div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSaveElected" runat="server" Text="SAVE" OnClick="btnSaveElected_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>

                 
                        </div></div>
                        <div class="card-body">
                                    <div class="card-header">
                            <strong class="card-titlen">c) Office Expenses :-</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                          <asp:Repeater ID="grvGenralAdminOfficeExp" runat="server" OnItemCommand="grvGenralAdminOfficeExp_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
       <%-- <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                  Sl.No
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 400px;" align="center">
                    HEAD
                </th>
                <th scope="col" style="width: 200px"align="center">
                  Amount
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px"  align="center">
                   HEAD
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                   Amount
                </th>
                                
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
       <%--     <td>
                <asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>--%>
               <td><asp:Label ID="mainexpendituretype" runat="server" Text='<%# Eval("intmainexpendituretype") %>' Visible="false" />
            <asp:Label ID="subexpendituretype" runat="server" Text='<%# Eval("intsubexpendituretype") %>' Visible="false" />
           
           <asp:TextBox ID="txtHead" runat="server" Width="100%" ReadOnly="true" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode"    runat="server" Text='<%# Eval("vchaccountheadcode") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID="txtexpamounttotal" runat="server" Text='<%# Eval("numexpamounttotal") %>' /></td>
            <td><asp:TextBox ID="txtAuditHead" Width="100%" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
             
            </td> 
             <td>
                <asp:TextBox ID="txtauditedexpamounttotal" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />
            </td>
           
           </tr></ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>
</asp:Repeater>



</DIV>
</div><div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSaveOfficeExp" runat="server" Text="SAVE" OnClick="btnSaveOfficeExp_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>

                 
                        </div></div><div class="card-body">
                         <div class="card-header">
                            <strong class="card-titlen">d) INTEREST AND FINANCE CHARGES</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                          <asp:Repeater ID="grvGenralAdminCharges" runat="server" OnItemCommand="grvGenralAdminCharges_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
     <%--   <th scope="col" style="text-align:center"  align="center" rowspan="2"  >
                  Sl.No
                </th>--%>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍ 
                </th>
                          
            </tr>
            
            <tr>
                <th scope="col" style="width: 400px;" align="center">
                    HEAD
                </th>
                <th scope="col" style="width: 200px"align="center">
                  Amount
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 400px"  align="center">
                   HEAD
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                   Amount
                </th>
                                
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
        <%--    <td>
                <asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>--%>
               <td><asp:Label ID="mainexpendituretype" runat="server" Text='<%# Eval("intmainexpendituretype") %>' Visible="false" />
            <asp:Label ID="subexpendituretype" runat="server" Text='<%# Eval("intsubexpendituretype") %>' Visible="false" />
           
           <asp:TextBox ID="txtHead" runat="server" Width="100%" ReadOnly="true" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>'  Visible="false"/>
            </td>
            <td><asp:TextBox ID="txtexpamounttotal" runat="server" Text='<%# Eval("numexpamounttotal") %>' /></td>
            <td><asp:TextBox ID="txtAuditHead" Width="100%" ReadOnly="true" runat="server" Text='<%# Eval("vchaccounthead") %>' />
             
            </td> 
             <td>
                <asp:TextBox ID="txtauditedexpamounttotal" runat="server" Text='<%# Eval("numauditedexpamounttotal") %>' />
            </td>
           
           </tr></ItemTemplate>
    <FooterTemplate>
      <tr>
 <td>
 <asp:Label ID="lblEmptyData"
        Text="No Data To Display" runat="server" Visible="false">
 </asp:Label>
 </td>
 </tr>
    </FooterTemplate>
</asp:Repeater>



</DIV>    
</div> <div><table><tr><td style="width: 100%; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSaveCharges" runat="server" Text="SAVE" OnClick="btnSaveCharges_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>
                        
                        </div></div>
                   
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<%--<div><table><tr><td style="width: 53px; height: 51px;">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>--%>

                </div>
            </div><!-- .animated -->
        </div>
</asp:Content>

