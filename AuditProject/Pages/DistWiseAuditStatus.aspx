<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="DistWiseAuditStatus.aspx.cs" Inherits="Pages_DistWiseAuditStatus"  %>
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
               <%-- <div class="title-blue-Head">Statewise List
                </div>--%>
                    <div class="card">
                        
                        <div class="card-body">
                        <div class="table table-striped table-bordered"> <asp:Panel ID="pnlGrdUnit" runat="server" Visible="false" >
                        <div class="card-header">
                            <strong class="card-titlen" >STATEWISE LIST</strong>
                             <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                        </div>
                        <fieldset id="ff" runat="server"> <legend style="background-position:center">Audit Districtwise List</legend> 
                        <asp:GridView id="GrdUnit" runat="server" Font-Size="14px" ForeColor="Black"  Font-Names="Trebuchet MS" DataKeyNames="intDistID,chvEngDistName" Width="1000px" CellSpacing="3" CellPadding="3" AutoGenerateColumns="False"><Columns>
<asp:TemplateField HeaderText="Sl No"><ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="District Name">
                        <EditItemTemplate >
                            <%--<asp:Label ID="txtinTime" runat="server"   Text='<%# Eval("ffd") %>'></asp:Label>--%>
                        </EditItemTemplate>
                        <ItemTemplate > 
                            <asp:LinkButton ID="lnkUnit" CssClass="button1" runat="server" Text='<%# Eval("chvEngDistName") %>' OnClick="lnkUnit_Click" ></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px"  ForeColor="Blue" />
                    </asp:TemplateField>
                     <asp:BoundField DataField="NotStarted" HeaderText="Not Started" />
                      <asp:BoundField DataField="ongoing" HeaderText="Ongoing" />
                            <asp:BoundField DataField="Submitted" HeaderText="Submitted" />
                            <asp:BoundField DataField="Returned" HeaderText="Returned" />
                            <asp:BoundField DataField="Approved" HeaderText="Approved" />
</Columns>
    <SelectedRowStyle BackColor="LightSteelBlue" ForeColor="GhostWhite"  />
</asp:GridView>
                        
                        </fieldset></asp:Panel>
                       <%-- <table><tr><td style="height: 35px">
                        
                        </td>
                        </tr></table></div></div></asp:Panel>--%>
                        <asp:Panel ID="pnlLBList" runat="server" Visible="false" >
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <fieldset id="Fieldset1" runat="server"> <legend><asp:Label id="lblDistrict" runat="server" Text="gdfgfdg" Visible="False" Font-Names="Trebuchet MS" Font-Size="14px" ForeColor="#C00000" Width="350px"  ></asp:Label> Localbodywise List</legend> 
                            <asp:Label ID="lblDistID" runat="server" Font-Names="Trebuchet MS" Font-Size="14px"
                                ForeColor="#C00000" Visible="False"></asp:Label>
                        <asp:GridView id="grdLBList" runat="server" ForeColor="Black" Font-Size="14px"   CssClass="Grid"  Width="990px" Font-Names="Trebuchet MS" DataKeyNames="intLBID" CellSpacing="3" CellPadding="3" AutoGenerateColumns="False"><Columns>
<asp:TemplateField HeaderText="Sl No"><ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
                            <asp:BoundField DataField="lbeng"  HeaderText="Localbody Name" >
                                <ItemStyle Width="300px" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Not Started">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkNotStartedStatus" runat="server" Enabled="false"  AutoPostBack="true" BackColor="transparent"     />
                           <%--  <asp:Label ID="txtNotStarted" runat="server"   Text='<%# Eval("NotStarted") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ongoing">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkongoingStatus" runat="server" Enabled="false"  AutoPostBack="true" BackColor="transparent"     />
                           <%--  <asp:Label ID="txtongoing" runat="server"   Text='<%# Eval("ongoing") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submited">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSubmitStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"    />
                            <%-- <asp:Label ID="txtSubmitted" runat="server"   Text='<%# Eval("Submitted") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Returned">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkReturnStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"    />
                             <%--<asp:Label ID="txtReturned" runat="server"   Text='<%# Eval("Returned") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Approved">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApprovedStatus" runat="server" Enabled="false" ForeColor="black" AutoPostBack="true" BackColor="transparent"   />
                           <%--  <asp:Label ID="txtApproved" runat="server"   Text='<%# Eval("Approved") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px"  />
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Annual report">
                        <EditItemTemplate >
                            <%--<asp:Label ID="txtinTime" runat="server"   Text='<%# Eval("ffd") %>'></asp:Label>--%>
                        </EditItemTemplate>
                        <ItemTemplate > 
                            <%--<asp:LinkButton ID="lnkAnnualRpt"   runat="server"   OnClick="lnkAnnualRpt_Click" Font-Names="Meera" Font-Size="14px" Font-Underline="True" ForeColor="Teal" Width="89px" ></asp:LinkButton>
                        --%>
                         <asp:ImageButton id="lnkAnnualRpt" OnClick="lnkAnnualRpt_Click"  CssClass="linkRpt" runat="server"  ImageUrl="~/images/2.jpg"></asp:ImageButton> 
                
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px"  ForeColor="Blue" Font-Size="12px" />
                    </asp:TemplateField>
</Columns>
    <SelectedRowStyle BackColor="LightSteelBlue" ForeColor="GhostWhite"  />
    <AlternatingRowStyle CssClass="alt"  />
</asp:GridView>
                        
                        </fieldset>
                     <%--   <table><tr><td style="height: 35px">       <asp:UpdateProgress ID="upgLoad" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                        
                        </td>
                        </tr></table>--%></div></div></asp:Panel>
                        
                        </div></div></div></div></div>
                        </ContentTemplate>
                        <Triggers><asp:PostBackTrigger  ControlID="grdLBList" /></Triggers>
                        </asp:UpdatePanel>
</asp:Content>

