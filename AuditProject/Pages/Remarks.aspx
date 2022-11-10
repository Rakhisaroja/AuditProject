<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true"
    CodeFile="Remarks.aspx.cs" Inherits="Pages_Remarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <b></b></div>
            <div class="panel-body">
              <div class="card-header">
                                <strong class="card-titlen">കുറിപ്പുകള്‍</strong>
                                
                            </div>
                <div class="form-group">
               
                    <div class="row">
                        <div class="col-sm-6">
                           Main Heading<asp:DropDownList ID="drmainHeading" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="drmainHeading_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                           Sub Heading <asp:DropDownList ID="drsubHeading"  AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="drsubHeading_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                         Remarks  <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="multiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                
                
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                        <asp:Label ID="lblErr" runat="server"  ForeColor="red"></asp:Label>
                           <asp:Button ID="btnSave" runat="server" Text="Save Remarks" Width="150px" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" >
                            </asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
