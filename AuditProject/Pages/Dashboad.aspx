<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="Dashboad.aspx.cs" Inherits="Pages_Dashboad"  %>
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
                        
                        
                        <DIV class="content mt-3"><DIV class="animated fadeIn"><DIV class="row"><DIV class="col-md-12"><DIV class="title-blue-Head">Statewise List </DIV><DIV class="card"><DIV class="card-header"><%--<strong class="card-titlen" >Statewise List</strong>
                        </div>--%><DIV class="card-body"><DIV class="table table-striped table-bordered"><FIELDSET id="ff" runat="server"><LEGEND style="BACKGROUND-POSITION: center 50%">Audit Unitwise List</LEGEND><asp:GridView id="GrdUnit" runat="server" Font-Size="14px" Font-Names="Trebuchet MS" ForeColor="Black" Width="1000px" AutoGenerateColumns="False" CellPadding="3" CellSpacing="3" DataKeyNames="numunitcode,Auditunitname"><Columns>
<asp:TemplateField HeaderText="Sl No"><ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Audit Unit">
                        <EditItemTemplate >
                            <%--<asp:Label ID="txtinTime" runat="server"   Text='<%# Eval("ffd") %>'></asp:Label>--%>
                        </EditItemTemplate>
                        <ItemTemplate > 
                            <asp:LinkButton ID="lnkUnit" CssClass="button1" runat="server" Text='<%# Eval("Auditunitname") %>' OnClick="lnkUnit_Click" ></asp:LinkButton>
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
</asp:GridView> </FIELDSET> <%-- <table><tr><td style="height: 35px">
                        
                        </td>
                        </tr></table></div></div></asp:Panel>--%><asp:Panel id="pnlLBList" runat="server" Visible="false"><DIV class="card-body"><DIV class="table table-striped table-bordered"><FIELDSET id="Fieldset1" runat="server"><LEGEND><asp:Label id="lblUnit" runat="server" Font-Size="14px" Font-Names="Trebuchet MS" Text="gdfgfdg" ForeColor="#C00000" Width="350px" Visible="False"></asp:Label>: Localbodywise List</LEGEND><asp:Label id="lblUnitCode" runat="server" Font-Size="14px" Font-Names="Trebuchet MS" ForeColor="#C00000" Visible="False"></asp:Label> <asp:GridView id="grdLBList" runat="server" Font-Size="14px" Font-Names="Trebuchet MS" ForeColor="Black" CssClass="Grid" Width="990px" AutoGenerateColumns="False" CellPadding="3" CellSpacing="3" DataKeyNames="intLBID"><Columns>
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
                    <asp:TemplateField HeaderText="Returned to Audit ">
                        <EditItemTemplate >
                            <%--<asp:Label ID="txtinTime" runat="server"   Text='<%# Eval("ffd") %>'></asp:Label>--%>
                        </EditItemTemplate>
                        <ItemTemplate > 
                            <%--<asp:LinkButton ID="lnkRtnAudit"   runat="server"  OnClick="lnkRtnAudit_Click" Font-Names="Meera" Font-Size="14px" Font-Underline="True" ForeColor="Teal" Width="120px"  ></asp:LinkButton>--%>
                            <asp:ImageButton id="lnkRtnAudit" CssClass="linkreturn" OnClick="lnkRtnAudit_Click"  OnClientClick="return confirmdelete()" runat="server"  ImageUrl="~/images/rtn1.png"  
   
 ></asp:ImageButton> 
                
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px"  ForeColor="Blue" Font-Size="12px" />
                    </asp:TemplateField>
</Columns>
    <SelectedRowStyle BackColor="LightSteelBlue" ForeColor="GhostWhite"  />
    <AlternatingRowStyle CssClass="alt"  />
</asp:GridView> </FIELDSET> 
<TABLE>
<TBODY><TR><TD style="HEIGHT: 35px"><asp:UpdateProgress id="upgLoad" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="theprogress">
                                                <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress> </TD></TR></TBODY></TABLE>
                                    </DIV></DIV></asp:Panel> </DIV></DIV></DIV></DIV></DIV></DIV></DIV></DIV>
</ContentTemplate>
                        <Triggers>
<asp:PostBackTrigger ControlID="grdLBList"></asp:PostBackTrigger>
</Triggers>
                        </asp:UpdatePanel>
                        <DIV><asp:Button id="btnConsolidateReport" Visible ="false"  runat="server" Text="കൺസോളിഡേറ്റ് റിപ്പോര്‍ട്ട്‌" CssClass="btn btn-secondary" Width="210px" OnClick="btnConsolidateReport_Click"></asp:Button>
                        <asp:Button id="btnSatewiseReport" runat="server" Text="സംസ്ഥാനതല റിപ്പോര്‍ട്ട്‌" CssClass="btn btn-secondary" Width="210px" OnClick="btnSatewiseReport_Click" ></asp:Button>
                         </DIV>

                        <script type="text/javascript"> 
                        function confirmdelete()
            {
                if (confirm("Are you sure to return this Localbody for further modification?")== true)
                 return true;
                   else
                return false;
            }
            </script>
</asp:Content>

