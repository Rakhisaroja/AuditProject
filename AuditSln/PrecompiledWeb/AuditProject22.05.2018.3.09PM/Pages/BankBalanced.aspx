﻿<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_BankBalanced, App_Web_cllhm4gw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">വരവ് ഭാഗം
                </div>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">II. 31.03.2017 ലെ  നീക്കിയിരിപ്പ് വിശദാംശം  (RP 40(a) പ്രകാരം)
</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <div style="OVERFLOW: scroll; WIDTH: 1200px;height:300px" >
                       <%-- <asp:GridView id="grvBalanced" runat="server"  AutoGenerateColumns="False"   Width="100%" CellPadding="2" BackColor="White" BorderColor="Silver" Font-Names="Meera" OnRowCreated="grvBalanced_RowCreated"  >
                       --%>     
                       <asp:Repeater ID="grvBalanced" runat="server" OnItemCommand="grvBalanced_ItemCommand"   >

                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        <tr> <th scope="col"  rowspan="2" align="center"  >
                    ക്ര.ന
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="2"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                  ബാങ്ക്
                </th>
              <%--  <th></th>--%>
                <th scope="col" style="width: 200px"  align="center">
                   മുന്നിരിപ്പ് (ഓ.ബി)
                </th>
               <%-- <th></th>--%>
                   <th scope="col" style="width: 100px"  align="center">
                     ബാങ്ക്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                    മുന്നിരിപ്പ് (ഓ.ബി)
                </th>
                  
            </tr>
             
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
            </td>
            <td><asp:TextBox ID="txtBank" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            <asp:Label ID="vchaccountheadcode" runat="server" Text='<%# Eval("vchaccountheadcode") %>' />
            </td>
            <td><asp:TextBox ID="txtBalancd" runat="server" Text='<%# Eval("numobamount") %>' /></td>
             <td>
                <asp:TextBox ID="txtAuditedBank" runat="server" Text='<%# Eval("vchaccounthead") %>' />
            </td>
            <td>
                <asp:TextBox ID="txtAuditedBalancd" runat="server" Text='<%# Eval("numauditedobamount") %>' />
            </td>
           </tr></ItemTemplate>
                        


</asp:Repeater></div></div>
                  
                        </div>
                    </div>
                </div>
<div><table style="width: 57%"><tr><td align="center"  >
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>

                </div>
            </div><!-- .animated -->
        </div>
</asp:Content>



