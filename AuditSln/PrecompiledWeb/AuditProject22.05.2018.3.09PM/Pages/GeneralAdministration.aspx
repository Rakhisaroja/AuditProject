<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_GeneralAdministration, App_Web_cllhm4gw" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
    <table width="80%" border="1">
        <tr>
            <td style="height: 24px" colspan="2">
                <strong>
                i.<font face="Meera"><font size="4" style="font-size:18pt;font-weight:bold"><b>പൊതുഭരണം</b></font></font></strong></td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 159px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
                <asp:Label ID="Label6" runat="server" Text="നിലവിലുള്ള വിവരങ്ങള്‍" Font-Bold="True" Font-Names="Meera" Font-Size="18px" ForeColor="InactiveCaptionText" Width="180px"></asp:Label></td>
            <td colspan="1">
            </td>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Meera" Font-Size="18px"
                    ForeColor="InactiveCaptionText" Text="ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 25px;">
            </td>
            <td style="width: 117px; height: 25px;">
            </td>
            <td style="width: 100px; height: 25px;">
            </td>
            <td style="width: 159px; height: 25px;">
            </td>
            <td style="width: 100px; height: 25px;">
            </td>
            <td style="width: 100px; height: 25px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 58px;">
             <span style="font-size: 14pt;font-family:Meera;color:dimgray">
             ഗ്രാമപഞ്ചായത്ത് സ്ഥിതി ചെയ്യുന്ന ജില്ല</span>
            </td>
            <td style="width: 117px; height: 58px;">
                <asp:Label ID="lblDist" runat="server" Text=""></asp:Label></td>
            <td style="width: 100px; height: 58px">
            </td>
            <td style="width: 159px; height: 58px">
                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 58px;">
            </td>
            <td style="width: 100px; height: 58px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
               <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                        ഗ്രാമപഞ്ചായത്ത്‌ സ്ഥിതി ചെയ്യുന്ന താലൂക്ക്</span>
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblTaluk" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:DropDownList ID="ddlTaluk" runat="server" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
             <span style="font-size: 14pt;font-family:Meera;color:dimgray">ഗ്രാമപഞ്ചായത്ത് സ്ഥിതി ചെയ്യുന്ന നിയോജകമണ്ഡലം</span>
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblAss" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:DropDownList ID="ddlAssembly" runat="server" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
               <span style="font-size: 14pt;font-family:Meera;color:dimgray">ഗ്രാമപഞ്ചായത്തിന്റെ അതിരുകള്‍</span>
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblBorder" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:TextBox ID="txtBorder" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                    ഗ്രാമപഞ്ചായത്തിന്റെ ആകെ വിസ്തീര്‍ണം (ച.കി)</span>
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblArea" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:TextBox ID="txtArea" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                ഗ്രാമപഞ്ചായത്തിന്റെ ആകെ ജനസംഖ്യ </span>
               
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblMale" runat="server" Text="ആണ്:" Font-Names="Meera" color="black" Width="51px"></asp:Label>
                &nbsp;<asp:Label ID="lblM" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Names="Meera" Text="ആണ്:"
                    Width="51px" Height="1px"></asp:Label>
                <asp:TextBox ID="txtAuditM" runat="server" Width="50px"></asp:TextBox>&nbsp;
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblFemale" runat="server" Text="പെണ്ണ്:" Font-Names="Meera" color="black" Width="46px"></asp:Label>&nbsp;
                <asp:Label ID="lblF" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:Label ID="Label3" runat="server" color="black" Font-Names="Meera" Text="പെണ്ണ്:"
                    Width="46px"></asp:Label>
                <asp:TextBox ID="txtAuditF" runat="server" Width="50px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                ഗ്രാമപഞ്ചായത്ത് പ്രസിഡന്റ് പേര്,കാലയളവ്‌</span>
            </td>
            <td style="width: 117px">
                <asp:Label ID="lblPre" runat="server"></asp:Label>
                <asp:Label ID="Label16" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblPrePeriod" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:TextBox ID="txtAPreName" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtAPrePeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="lblP" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
               <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                    ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌ </span>
            </td>
            <td style="width: 117px">
            <asp:Label ID="lblFin" runat="server"></asp:Label>
            <asp:Label ID="Label17" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblFinPeriod" runat="server"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            <asp:TextBox ID="txtAFin" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtAFinPeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
              <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                    വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്‌,കാലയളവ്‌ </span>
            </td>
            <td style="width: 117px">
                     <asp:Label ID="lblDevelop" runat="server"></asp:Label>
                     <asp:Label ID="Label18" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblDevelopPeriod" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            <asp:TextBox ID="txtADevelop" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label10" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtADevelopPeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
             <span style="font-size: 14pt;font-family:Meera;color:dimgray">ആരോഗ്യ വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി
                    ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</span></td>
            <td style="width: 117px">
                 <asp:Label ID="lblHealthEdu" runat="server"></asp:Label>
                 <asp:Label ID="Label19" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblHealthEduPeriod" runat="server"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            <asp:TextBox ID="txtAHealthEdu" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label12" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtAHealthEduPeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <span style="font-size: 14pt;font-family:Meera;color:dimgray">ക്ഷേമകാര്യ
                        സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്‍മാന്‍ പേര്,കാലയളവ്‌</span>
            </td>
            <td style="width: 117px">
                 <asp:Label ID="lblWelfare" runat="server"></asp:Label>
                 <asp:Label ID="Label20" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblWelfarePeriod" runat="server"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            <asp:TextBox ID="txtAWelfare" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtAWelfarePeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <span style="font-size: 14pt;font-family:Meera;color:dimgray">
                    ഗ്രാമപഞ്ചായത്ത്
                        സെക്രട്ടറി പേര്,
                            കാലയളവ്</span></td>
            <td style="width: 117px">
                <asp:Label ID="lblSec" runat="server"></asp:Label>
                <asp:Label ID="Label21" Text="," runat="server"></asp:Label>
                <asp:Label ID="lblSecPeriod" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:TextBox ID="txtASecName" runat="server" Width="139px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Font-Names="Meera" Text="പേര്"></asp:Label>
                <asp:TextBox ID="txtASecPeriod" runat="server" Width="65px"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" Font-Names="Meera" Text="കാലയളവ്‌"></asp:Label>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 117px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click" /></td>
            <td style="width: 100px"><asp:Button ID="Button2" runat="server" Font-Bold="True" Text="Next" OnClick="btnNextClick" /></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
                    
                </div>


                </div>
            </div><!-- .animated -->
        </div>
</asp:Content>



