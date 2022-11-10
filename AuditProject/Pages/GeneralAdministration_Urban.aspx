<%@ Page Language="C#" MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="GeneralAdministration_Urban.aspx.cs" Inherits="Pages_GeneralAdministration_Urban" Title="GeneralAdministration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanelFinance" runat="server" UpdateMode="always"><ContentTemplate>
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen">I(i) പൊതുഭരണം</strong>
                        </div>    <div class="card-body">
                        <div class="table table-striped table-bordered">
    <table width="100%" border="1">
        <tr>
            <td align="left" rowspan="1" style="width: 314px">
            </td>
            <td rowspan="1" style="width: 117px">
                <asp:Label ID="Label6" runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍" Font-Bold="True" Font-Names="Meera" Font-Size="20px" Width="242px" Height="30px"></asp:Label></td>
            <td rowspan="1">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Meera" Font-Size="20px"
                    Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍" Height="30px" Width="290px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" rowspan="3" style="width: 300px">
            <span style="font-size: 12pt;font-family:Meera">
                            <strong>മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷൻ  സ്ഥിതി ചെയ്യുന്ന ജില്ല</strong></span></td>
            <td rowspan="2" style="width: 117px">
                </td>
            <td rowspan="2">
                </td>
        </tr>
        <tr>
                        
        </tr>
        <tr>
            <%--<td style="width: 100px; height: 58px;">
             <span style="font-size: 14pt;font-family:Meera;color:dimgray">
             ഗ്രാമപഞ്ചായത്ത് സ്ഥിതി ചെയ്യുന്ന ജില്ല</span>
            </td>--%>
            <td style="width: 117px; height: 58px;">
                <%--<asp:Label ID="lblDist" runat="server" Text=""></asp:Label>--%>
                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;
                </td>
            <td style="width: 159px; height: 58px" align="left">
                <asp:DropDownList ID="ddlDistrictAud" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddlDistrictAud_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 300px">
               <span style="font-size: 12pt;font-family:Meera">
                    <strong>മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷൻ  സ്ഥിതി ചെയ്യുന്ന താലൂക്ക് </strong></span>
            </td>
            <td style="width: 117px">
                <%--<asp:Label ID="lblTaluk" runat="server"></asp:Label>--%>
                <asp:DropDownList ID="ddlTaluk" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddlTaluk_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btnAddNewTal" runat="server" Text="Add New" OnClick="btnAddNewTal_Click" />
                <asp:TextBox ID="txtTalukNew" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
                <asp:LinkButton ID="lbtnRemove" runat="server" Font-Underline="True" ForeColor="Blue"
                    OnClick="lbtnRemove_Click">Remove</asp:LinkButton></td>
            <td style="width: 159px" align="left">
                <asp:TextBox ID="txtTalukAud" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinance">
                                    <ProgressTemplate>
                                        <div id="Div1">
                                            <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 9px; top: 10px;" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress></td>
        </tr>
        <tr>
            <td style="width: 300px">
             <span style="font-size: 12pt;font-family:Meera"><strong> മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷൻ സ്ഥിതി ചെയ്യുന്ന നിയോജകമണ്ഡലം</strong></span>
            </td>
            <td style="width: 117px">
              <asp:DropDownList ID="ddlAssembly" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddlAssembly_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btnAddNewAss" runat="server" OnClick="btnAddNewAss_Click" Text="Add New" />
                <asp:TextBox ID="txtAssNew" runat="server" Width="300px"></asp:TextBox>
                <asp:LinkButton ID="lbtnRemoveAss" runat="server" Font-Underline="True" ForeColor="Blue"
                    OnClick="lbtnRemoveAss_Click">Remove</asp:LinkButton>
                    
                    </td>
            <td style="width: 159px" align="left">
                <asp:TextBox ID="txtAssemblyAud" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanelFinance">
                                    <ProgressTemplate>
                                        <div id="Div2">
                                            <img src="..\images\loadingnew.gif" style="display: inline;
                                                    background-image: none; position: relative; background-color: transparent; left: 9px; top: 10px;" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress></td>
        </tr>
        <tr>
            <td style="width: 300px;">
               <span style="font-size: 12pt;font-family:Meera"><strong>മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷന്‍റെ അതിരുകള്‍</strong></span>
            </td>
            <td style="width: 300px">
              <%--  <asp:Label ID="lblEast" runat="server" Text="കിഴക്ക്"></asp:Label>
                <asp:TextBox ID="txtEast" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblWest" runat="server" Text="പടിഞ്ഞാറ്"></asp:Label>
                <asp:TextBox ID="txtWest" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblSouth" runat="server" Text="തെക്ക്"></asp:Label>
                <asp:TextBox ID="txtSouth" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblNorth" runat="server" Text="വടക്ക്"></asp:Label>
                <asp:TextBox ID="txtNorth" runat="server" ReadOnly="True"></asp:TextBox>--%>
              <table><tr><td style="width: 167px">
                <asp:Label ID="lblEast" runat="server" Font-Names="Meera" Text="കിഴക്ക്"></asp:Label></td>
               <td align="left">
                <asp:TextBox ID="txtEast" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="lblWest" runat="server" Font-Names="Meera" Text="പടിഞ്ഞാറ്" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtWest" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr>
                 <tr><td style="width: 167px"><asp:Label ID="lblSouth" runat="server" Font-Names="Meera" Text="തെക്ക്" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtSouth" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr>
                 <tr><td style="width: 167px"><asp:Label ID="lblNorth" runat="server" Font-Names="Meera" Text="വടക്ക്" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtNorth" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                
                </td>
            <td style="width: 300" align="left">
                  <%--  <asp:Label ID="lblEastAud" runat="server" Text="കിഴക്ക്"></asp:Label>
                <asp:TextBox ID="txtEastAud" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblWestAud" runat="server" Text="പടിഞ്ഞാറ്"></asp:Label>
                <asp:TextBox ID="txtWestAud" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblSouthAud" runat="server" Text="തെക്ക്"></asp:Label>
                <asp:TextBox ID="txtSouthAud" runat="server" ReadOnly="True"></asp:TextBox>
                     <asp:Label ID="lblNorthAud" runat="server" Text="വടക്ക്"></asp:Label>
                <asp:TextBox ID="txtNorthAud" runat="server" ReadOnly="True"></asp:TextBox>--%>
                 <table><tr>
               <td align="left">
                <asp:TextBox ID="txtEastAud" runat="server" Width="200px" ReadOnly="True"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtWestAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr>
                 <tr>
               <td align="left"> <asp:TextBox ID="txtSouthAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr>
                 <tr>
               <td align="left"> <asp:TextBox ID="txtNorthAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                
                </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera">
                   <strong>മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷന്‍റെ ആകെ വിസ്തീര്‍ണം (ച.കി)</strong></span>
            </td>
            <td align="left">
               <%-- <asp:Label ID="lblArea" runat="server"></asp:Label>--%>
               <asp:TextBox ID="txtArea" runat="server" ReadOnly="True" CssClass="floatnumbers" oncopy="return false;" onpaste="return false;"></asp:TextBox>
                </td>
            <td>
                <asp:TextBox ID="txtAreaAud" runat="server" ReadOnly="True" CssClass="floatnumbers"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 300px;">
                <span style="font-size: 12pt;font-family:Meera">
             <strong> മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷനിലെ ആകെ ജനസംഖ്യ (Census of India 2011, KERALA SERIES .33)</strong></span>
               
            </td>
            <td style="width: 180px; height: 98px;">
<%--                <asp:Label ID="lblMale" runat="server" Text="ആണ്:" Font-Names="Meera" Width="51px"></asp:Label>
                <asp:TextBox ID="txtMale" runat="server" Width="100px" ReadOnly="True" CssClass="floatnumbers"></asp:TextBox></td>
            <td style="width: 180px">
                <asp:Label ID="Label2" runat="server" Font-Names="Meera" Text="ആണ്:" Width="51px"></asp:Label>
                <asp:TextBox ID="txtMaleAud" runat="server" Width="100px" ReadOnly="True" CssClass="floatnumbers"></asp:TextBox>--%>
                 <table>
                <tr><td style="width: 167px"><asp:Label ID="Label29" runat="server" Font-Names="Meera" Text="സ്ത്രീ :" Width="88px"></asp:Label></td>
               <td style="width: 214px" align="left"> 
               <asp:TextBox ID="txtFemale" onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric"  runat="server" Width="200px" ReadOnly="True" oncopy="return false;" onpaste="return false;" ></asp:TextBox></td></tr>
               <tr><td style="width: 167px">
                <asp:Label ID="lblMale" runat="server" Font-Names="Meera" Text="പുരുഷൻ :"></asp:Label></td>
               <td style="width: 214px" align="left"> 
               <asp:TextBox ID="txtMale" onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric"  runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine" oncopy="return false;" onpaste="return false;"></asp:TextBox></td></tr></table>
            </td><td><table><tr><td style="width: 167px" align="left">
            
            <asp:TextBox ID="txtFemaleAud" onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric" runat="server" Width="200px" ReadOnly="True" oncopy="return false;" onpaste="return false;" ></asp:TextBox>
            
            
            </td></tr><tr>
            <td align="left">  <asp:TextBox ID="txtMaleAud" onkeypress="return  isNumberKey(event)"  CssClass="txtBoxNumeric" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine" oncopy="return false;" onpaste="return false;"></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        <tr>
           <td style="width: 300px">
            </td>
            <td style="width: 150px">
 <%--               <asp:Label ID="lblFemale" runat="server" Text="പെണ്ണ്:" Font-Names="Meera" color="black" Width="51px" ></asp:Label>
                <asp:TextBox ID="txtFemale" runat="server" Width="100px" ReadOnly="True" CssClass="floatnumbers"></asp:TextBox></td>
            <td style="width: 150px">
                <asp:Label ID="Label3" runat="server" color="black" Font-Names="Meera" Text="പെണ്ണ്:" Width="51px"></asp:Label>
                <asp:TextBox ID="txtFemaleAud" runat="server" Width="100px" ReadOnly="True" CssClass="floatnumbers"></asp:TextBox>
               --%>
              <%--  <table><tr><td style="width: 167px">
                <asp:Label ID="Label3" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td> <asp:TextBox ID="TextBox23" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px; height: 31px;"><asp:Label ID="Label30" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td style="height: 31px"> <asp:TextBox ID="TextBox24" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>--%>
                 <table><tr>
               </tr>
                <tr>
               </tr></table> </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>
                മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷൻ ചെയർപേഴ്സൺ /മേയറുടെ പേര്, കാലയളവ്‌</strong></span>
            </td>
            <td style="width: 200px">
                <table><tr><td>
                <asp:Label ID="Label16" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtPreName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label17" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtPrePeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label4" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtPreNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="lblP" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtPrePeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                
               <table><tr>
               <td align="left"> <asp:TextBox ID="txtPreNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtPrePeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        <tr>
            <td style="width: 300px">
               <span style="font-size: 12pt;font-family:Meera"><strong>
                    ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌ </strong></span>
            </td>
            <td style="width: 200px"><table  ><tr><td>
                <asp:Label ID="Label18" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
                <td align="left"><asp:TextBox ID="txtFinName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
               </tr><tr><td style="height: 29px; width: 223px;"> <asp:Label ID="Label19" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td style="height: 29px" align="left"> <asp:TextBox ID="txtFinPeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox></td> 
               </tr></table></td>
            <td style="width: 200px">
            <%--    <asp:Label ID="Label8" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtFinNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtFinPeriodAud" runat="server" Width="65px" ReadOnly="True"></asp:TextBox>--%>
                <table><tr>
               <td align="left"> <asp:TextBox ID="txtFinNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtFinPeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
        </tr>
        <tr>
            <td style="width: 300px">
              <span style="font-size: 12pt;font-family:Meera"><strong>
                    വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്‌,കാലയളവ്‌ </strong></span>
            </td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label20" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtDevName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label21" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtDevPeriod" runat="server" Width="65px" ReadOnly="True"></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label20" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtDevName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label21" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtDevPeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
            <td style="width: 200px">
                <%--<asp:Label ID="Label10" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtDevNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtDevPeriodAud" runat="server" Width="65px" ReadOnly="True"></asp:TextBox>--%>
                      <table><tr>
               <td style="height: 39px" align="left"> <asp:TextBox ID="txtDevNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtDevPeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
        </tr>
        <tr>
            <td style="width: 300px">
             <span style="font-size: 12pt;font-family:Meera"><strong>ആരോഗ്യകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി
                    ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span></td>
            <td style="width: 200px">
              <%--  <asp:Label ID="Label22" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtHealthName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label23" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtHealthPeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label22" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtHealthName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label23" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtHealthPeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label12" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtHealthNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtHealthPeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                    <table><tr>
               <td align="left"> <asp:TextBox ID="txtHealthNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtHealthPeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                 </td>
        </tr>
        <tr>
            <td style="width: 300px">
             <span style="font-size: 12pt;font-family:Meera"><strong>വിദ്യാഭ്യാസ കലാ കായിക  കാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി
                    ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span></td>
            <td style="width: 200px">
              <%--  <asp:Label ID="Label22" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtHealthName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label23" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtHealthPeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label221" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtEducationName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label231" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtEducationPeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label12" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtHealthNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtHealthPeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                    <table><tr>
               <td align="left"> <asp:TextBox ID="txtEducationNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtEducationPeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                 </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>ക്ഷേമകാര്യ
                        സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span>
            </td>
            <td style="width: 200px">
             <%--   <asp:Label ID="Label24" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtWelfareName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label25" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label24" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtWelfareName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label25" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtWelfarePeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label14" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtWelfareNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr>
               <td align="left"> <asp:TextBox ID="txtWelfareNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtWelfarePeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        
  <%--      newly added--%>
        
        
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>മരാമത്ത് കാര്യ
                        സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span>
            </td>
            <td style="width: 200px">
             <%--   <asp:Label ID="Label24" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtWelfareName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label25" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label2" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtcarromname" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label3" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtcarromperiod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label14" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtWelfareNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr>
               <td align="left"> <asp:TextBox ID="txtcarromnameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtcarromperiodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        
        
         <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>മുനിസിപല്‍ കോര്‍പ്പറേഷനുകളില്‍ നഗരാസൂത്രണകാര്യം
                        സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span>
            </td>
            <td style="width: 200px">
             <%--   <asp:Label ID="Label24" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtWelfareName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label25" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label4" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txttownplanname" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label5" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txttownplanperiod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label14" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtWelfareNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr>
               <td align="left"> <asp:TextBox ID="txttownplannameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txttownplanperiodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        
        
        
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>നികുതി അപ്പീല്‍കാര്യ
                        സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</strong></span>
            </td>
            <td style="width: 200px">
             <%--   <asp:Label ID="Label24" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtWelfareName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label25" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriod" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr><td>
                <asp:Label ID="Label7" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txttaxappname" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label8" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txttaxappperoid" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table>
                </td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label14" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
            <asp:TextBox ID="txtWelfareNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtWelfarePeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr>
               <td align="left"> <asp:TextBox ID="txttaxappnameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txttaxappperoidAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        
        
        <tr>
            <td style="width: 300px">
                <span style="font-size: 12pt;font-family:Meera"><strong>
                    മുനിസിപ്പാലിറ്റി/ കോർപ്പറേഷൻ സെക്രട്ടറിയുടെ പേര് ,കാലയളവ്</strong></span></td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label26" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtSecName" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label27" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtSecPeriod" runat="server" Width="65px" ReadOnly="True"></asp:TextBox>--%>
                 <table><tr><td style="width: 167px">
                <asp:Label ID="Label26" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtSecName" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td style="width: 167px"><asp:Label ID="Label27" runat="server" Font-Names="Meera" Text="കാലയളവ്‌" Width="88px"></asp:Label></td>
               <td align="left"> <asp:TextBox ID="txtSecPeriod" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
            <td style="width: 200px">
               <%-- <asp:Label ID="Label5" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>&nbsp;
                <asp:TextBox ID="txtSecNameAud" runat="server" Width="139px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
                <asp:TextBox ID="txtSecPeriodAud" runat="server" Width="65px" ReadOnly="True" ></asp:TextBox>--%>
                 <table><tr>
               <td align="left"> <asp:TextBox ID="txtSecNameAud" runat="server" Width="200px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr>
               <td align="left"> <asp:TextBox ID="txtSecPeriodAud" runat="server" Width="200px" ReadOnly="True" ></asp:TextBox>
                
                </td></tr></table></td>
        </tr>
        
        
        
        
        
        <tr>
            <td style="width: 100px; height: 28px;">
            </td>
            <td style="width: 117px; height: 28px;">
            </td>
            <td style="width: 159px; height: 28px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
            </td>
            <td style="width: 159px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="NEXT" Width="62px" OnClick="btnNext_Click" /></td>
            <td style="width: 159px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanelFinance"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="Div3">
                            <img src="..\images\loadingnew.gif" style="display: inline; left: 9px; background-image: none;
                                position: relative; top: 10px; background-color: transparent" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="width: 159px">
            </td>
        </tr>
    </table></div></div>
              </div>      
                </div>


                </div>
            </div><!-- .animated -->
        </div></ContentTemplate></asp:UpdatePanel>
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

