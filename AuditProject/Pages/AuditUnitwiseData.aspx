<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="AuditUnitwiseData.aspx.cs" Inherits="Pages_AuditUnitwiseData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelFinanceWrkgrp" runat="server" UpdateMode="Always"><ContentTemplate>
<%--<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="title-blue-Head">DASHBOARD
                </div>
                 <div class="card">
                  
                        <asp:Panel ID="pnlfill" runat="server"  >
                        <div class="card-body">
                        <div class="table table-striped table-bordered">--%>
                        
                         
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <%--<strong class="card-titlen" >Statewise List</strong>
                        </div>--%>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                            &nbsp;<%-- <table><tr><td style="height: 35px">
                        
                        </td>
                        </tr></table></div></div></asp:Panel>--%><asp:Panel ID="pnlLBList" runat="server" Visible="false" >
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <fieldset id="Fieldset1" runat="server"> <legend> Localbodywise List</legend> 
                        <asp:GridView id="grdLBList" runat="server" ForeColor="Black" Font-Size="14px"   CssClass="Grid"  Width="990px" Font-Names="Trebuchet MS" DataKeyNames="intLBID" CellSpacing="3" CellPadding="3" AutoGenerateColumns="False"><Columns>
<asp:TemplateField HeaderText="Sl No"><ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
                            <asp:BoundField DataField="lbname"  HeaderText="Localbody Name" >
                                <ItemStyle Width="300px" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Not Started">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkNotStartedStatus" runat="server" Enabled="false"  AutoPostBack="true" BackColor="transparent"     />
                             <asp:Label ID="txtNotStarted" runat="server"   Text='<%# Eval("NotStarted") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ongoing">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkongoingStatus" runat="server" Enabled="false"  AutoPostBack="true" BackColor="transparent"     />
                             <asp:Label ID="txtongoing" runat="server"   Text='<%# Eval("ongoing") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submited">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSubmitStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"    />
                             <asp:Label ID="txtSubmitted" runat="server"   Text='<%# Eval("Submitted") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Returned">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkReturnStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"    />
                             <asp:Label ID="txtReturned" runat="server"   Text='<%# Eval("Returned") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Approved">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApprovedStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"   />
                             <asp:Label ID="txtApproved" runat="server"   Text='<%# Eval("Approved") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
</Columns>
    <SelectedRowStyle BackColor="LightSteelBlue" ForeColor="GhostWhite"  />
    <AlternatingRowStyle CssClass="alt"  />
</asp:GridView>
                       
                        </fieldset>
                        <table><tr><td style="height: 35px">
                        
                        </td>
                        </tr></table></div></div></asp:Panel>
                        
                        </div></div></div></div></div>
                        </ContentTemplate></asp:UpdatePanel>
</asp:Content>

