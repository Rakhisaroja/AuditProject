<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="PortingData_Urban.aspx.cs" Inherits="Pages_Porting_Data_Urban"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">PORTING DATA
                </div>
                 <div class="card">
                    <%--    <div class="card-header">
                            <strong class="card-titlen">I.i നിയോജകമണ്ഡലങ്ങളുടെ/വാര്‍ഡുകളുടെ വിവരം</strong>
                        </div>--%>
                        <div class="card-body">
                        <div class="table table-striped table-bordered"><asp:Panel ID="pnlfill" runat="server" Visible="false">
                        <table><tr><td style="height: 35px">
                            <asp:Button ID="btnBank"  CssClass="btn btn-secondary btn-sm" runat="server" Text=" 31.03.2017 ലെ  നീക്കിയിരിപ്പ് വിശദാംശം  (RP 40(a) പ്രകാരം)" Width="348px" OnClick="btnBank_Click" /> </td>
                            <td align="center" style="height: 35px">
                            <asp:Button ID="btnCentralFund"  CssClass="btn btn-secondary btn-sm" runat="server" Text="കേന്ദ്ര ഫണ്ട്‌" Width="257px" OnClick="btnCentralFund_Click" />
                                <asp:Button ID="btnnegative"  CssClass="btn btn-secondary btn-sm" runat="server" Text=" ഋണശീര്‍ഷ വരവുകള്‍" Width="299px" OnClick="btnnegative_Click" /></td></tr><tr>
                            <td>
                            <asp:Button ID="btngrant"  CssClass="btn btn-secondary btn-sm" runat="server" Text=" മറ്റ് പ്രത്യേകോദ്ദേശ്യ ഗ്രാന്റുകള്‍/പിരിവുകള്‍" Width="348px" OnClick="btngrant_Click" /></td>
                            <td style="width: 570px">
                            <asp:Button ID="btndirectBeni"  CssClass="btn btn-secondary btn-sm" runat="server" Text="കേന്ദ്ര സംസ്ഥാന സര്‍ക്കാരുകള്‍ ഗുണഭോക്താക്കള്‍ക്ക് നേരിട്ട് കൈമാറ്റം ചെയ്യുന്ന തുകകളുടെ വിവരങ്ങള്‍" Width="100%" OnClick="btndirectBeni_Click" /></td></tr>
                            <tr>
                            <td>
                            <asp:Button ID="btntaxnontaxCash"  CssClass="btn btn-secondary btn-sm" runat="server" Text="കാഷ് അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍" Width="100%" OnClick="btntaxnontaxCash_Click" /></td>
                            <td style="width: 570px">
                            <asp:Button ID="btntaxnotaxAcrual"  CssClass="btn btn-secondary btn-sm" runat="server" Text=" അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍" Width="100%" OnClick="btntaxnotaxAcrual_Click" /></td>
                            <td>
                            </td></tr>
                            <tr>
                            <td>
                            <asp:Button ID="btnGeneral"  CssClass="btn btn-secondary btn-sm" runat="server" Text="ചെലവ് വിവരങ്ങള്‍" Width="100%" OnClick="btnGeneral_Click" /></td>
                            <td style="width: 570px">
                            <asp:Button ID="btnLoaanrepayment"  CssClass="btn btn-secondary btn-sm" runat="server" Text="വായ്പ്പ തിരിച്ചടവിന്‍റെ വിവരങ്ങള്‍" Width="100%" OnClick="btnLoaanrepayment_Click" /></td>
                            <td>
                            </td></tr>
                            <tr><td colspan="3" align="center"><asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinanceWrkgrp">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 0px; top: 0px;" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress></td></tr>
                            <%--<tr>
                            <td>
                            <asp:Button ID="Button3"  CssClass="btn btn-secondary btn-sm" runat="server" Text="കാഷ് അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍" Width="100%" /></td>
                            <td style="width: 570px">
                            <asp:Button ID="Button4"  CssClass="btn btn-secondary btn-sm" runat="server" Text=" അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍" Width="100%" OnClick="btnCash_Click" /></td>
                            <td>
                            </td></tr>--%>
                            </table></asp:Panel>
                        </div></div></div>
                        
                </div></div></div></div>

</ContentTemplate></asp:UpdatePanel>
</asp:Content>

