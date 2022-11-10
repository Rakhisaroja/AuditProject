<%@ page language="C#" masterpagefile="~/Pages/AuditMasterPage.master" autoeventwireup="true" inherits="Pages_SocialJustice, App_Web_yasbjxhy" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                <%--<div class="title-blue-Head">വരവ് ഭാഗം
                </div>--%>
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-titlen"> 2. സാമൂഹ്യ നീതി</strong>
                        </div>
                        <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="grvSocialJustice" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="11"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
           <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                  <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                 <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                     
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                     <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                </th>
                     <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>                  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
    <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' />
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
         <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="100px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 

            </td>
              <td>
             <asp:TextBox ID="TextBox1" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
              <td>
             <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
       </tr> 
    </ItemTemplate>
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
</div>
<%--Second grid starts--%>
<div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="2"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 180px;" colspan="1"  align="center">
                   ഭിന്നശേഷികാര്‍ക്കായി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍
                </th>
                <th scope="col" style="width: 180px" colspan="1" align="center">
                  ഗുണഭോക്താക്കളുടെ എണ്ണം
                </th>
              
                <th scope="col" style="width: 100px" colspan="1" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                <th scope="col" style="width: 180px" colspan="1" align="center">
                  ഗുണഭോക്താക്കളുടെ എണ്ണം
                </th>
              
                <th scope="col" style="width: 100px" colspan="1" align="center">
                    ചെലവഴിച്ച തുക
                </th>
                   
               
            </tr>
              
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
            
       </tr> 
    </ItemTemplate>
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
</div>
<%--  second grid ends--%>     
<%--third grid starts    --%>    
<div class="card-header">
 <strong class="card-titlen"> 2 (a)  ബഡ്സ് സ്ക്കൂള്‍/ബഡ്സ് റിഹാബിലിറ്റേഷന്‍ സെന്റര്‍-വിവരങ്ങള്‍</strong>
 </div>  
<div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="7" >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="7" >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   നിലവിലുണ്ട്
                </th>
                <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   തന്‍വര്‍ഷം സ്ഥാപിച്ചു
                </th>
                <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   നിലവിലില്ല
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                   മതിയായ അടിസ്ഥാന സൗകര്യങ്ങള്‍ ഉണ്ട്/ഇല്ല.
                </th>
                <th scope="col" style="width: 300px" colspan="3"align="center">
                  ചെലവ് വിവരങ്ങള്‍
                </th>
               <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   നിലവിലുണ്ട്
                </th>
                <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   തന്‍വര്‍ഷം സ്ഥാപിച്ചു
                </th>
                <th scope="col" style="width: 100px;" rowspan="2" align="center">
                   നിലവിലില്ല
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                   മതിയായ അടിസ്ഥാന സൗകര്യങ്ങള്‍ ഉണ്ട്/ഇല്ല.
                </th>
                <th scope="col" style="width: 300px" colspan="3"align="center">
                  ചെലവ് വിവരങ്ങള്‍
                </th>
                
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 100px" align="center">
                   വാഹന വാ‍ടക 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ഓണറേറിയം
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ഇതര ചെലവുകള്‍
                </th>
                <th scope="col" style="width: 100px" align="center">
                   വാഹന വാ‍ടക 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ഓണറേറിയം
                </th>
                <th scope="col" style="width: 100px" align="center">
                  ഇതര ചെലവുകള്‍
                </th>
                   
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
    <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
  
            </td>
       </tr> 
    </ItemTemplate>
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
</div>
<%--third grid ends--%>
<%--fourth grid starts--%>
<div class="card-header">
 <strong class="card-titlen"> 2(e)കുട്ടികള്‍,വൃദ്ധര്‍,ട്രാന്‍സ്ജെന്‍ഡേർസ് -പ്രോജക്ടുകളുടെ വിവരങ്ങള്‍</strong>
 </div>  
 <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(e)(1) കുട്ടികള്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍</strong>
 </div>  
<div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="11"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
           <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                  <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                 <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                     
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                     <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                </th>
                     <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>                  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
    <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' />
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
         <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="100px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 

            </td>
              <td>
             <asp:TextBox ID="TextBox1" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
              <td>
             <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
       </tr> 
    </ItemTemplate>
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
</div>
<%--fourth grid ends--%>
<%--fifth grid starts--%>
 <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(e)(2)വൃദ്ധര്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍</strong>
 </div>  
<div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="11"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
           <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                  <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                 <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                     
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                     <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                </th>
                     <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>                  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
    <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' />
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
         <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="100px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 

            </td>
              <td>
             <asp:TextBox ID="TextBox1" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
              <td>
             <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
       </tr> 
    </ItemTemplate>
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
</div>
<%--fifth grid ends--%>

<%--sixth grid starts--%>
 <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(e)(3)പാലിയേറ്റിവ് കെയര്‍ പ്രോജക്ടുകള്‍</strong>
 </div>  
<div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="grvMergeHeader_ItemCommand"   >
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera;">
        <tr>
                <th scope="col" style="text-align:center"  align="center" colspan="11"  >
                    നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
            
            <tr>
                <%--<th scope="col" style="width: 80px;" rowspan="2" align="center">
                    ക്രമ നം
                </th>--%>
                <th scope="col" style="width: 80px;" rowspan="2" align="center">
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
           <th scope="col" style="width: 400px" colspan="4"align="center">
                  വകയിരുത്തിയ തുക
                </th>
              
                <th scope="col" style="width: 400px" colspan="4" align="center">
                    ചെലവഴിച്ച തുക
                </th>
             
                   <th scope="col" style="width: 400px" rowspan="2" align="center">
                   സൃഷ്ടിക്കപ്പെട്ട ആസ്തികള്‍
                </th>
                <th scope="col" style="width: 120px;" rowspan="2" align="center">
                    ഉണ്ടായ പ്രോജനം
                </th>
               
            </tr>
              <tr>
            
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                  <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                 <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>
                     
                <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                     <th scope="col" style="width: 120px" align="center">
                   വികസന ഫണ്ട് 
                </th>
                </th>
                     <th scope="col" style="width: 100px" align="center">
                  മെ.ഫ
                </th>
                <th scope="col" style="width: 100px" align="center">
                  തനത് ഫണ്ട് / ഗു.വി
                </th>
                   <th scope="col" style="width: 100px" align="center">
                   ബ്ലോക്ക് / ജില്ലാ വിഹിതം
                </th>                  
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="intWardNo" runat="server" Text='<%# Eval("intWardNo") %>' />
            </td>
            <td>
                <asp:Label ID="inttotVotersMale" runat="server" Text='<%# Eval("inttotVotersMale") %>' />
            </td>
    <td>
                <asp:Label ID="inttotVotersfemale" runat="server" Text='<%# Eval("inttotVotersfemale") %>' />
            </td>
             <td>
                <asp:Label ID="intparticipantmale" runat="server" Text='<%# Eval("intparticipantmale") %>' />
            </td>
            <td>
                <asp:Label ID="intparticipantfemale" runat="server" Text='<%# Eval("intparticipantfemale") %>' />
            </td>
            <td>
                <asp:Label ID="chvplacemal" runat="server" Text='<%# Eval("chvplacemal") %>' />
            </td>
             <td>
                <asp:Label ID="dtgramasabha" runat="server" Text='<%# Eval("dtgramasabha") %>' />
            </td>
            <td>
                <asp:Label ID="fltAttenPrece" runat="server" Text='<%# Eval("fltAttenPrece") %>' />
            </td>
            <td>
                <asp:Label ID="chvremarks" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
         <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("chvremarks") %>' />
            </td>
             <td>
             <asp:TextBox ID="intAuditedtotVotersMale" Width="100px" runat="server" Text='<%# Eval("intAuditedtotVotersMale") %>'></asp:TextBox>
            
            </td>
            <td>
             <asp:TextBox ID="intAuditedtotVotersFemale" Width="100px"  runat="server" Text='<%# Eval("intAuditedtotVotersFemale") %>'></asp:TextBox>

            </td>
             <td>
              <asp:TextBox ID="intauditedparticipantmale" Width="100px"  runat="server" Text='<%# Eval("intauditedparticipantmale") %>'></asp:TextBox>
      
            </td>
            <td>
             <asp:TextBox ID="intaudiitedparticipantfemale" Width="100px" runat="server" Text='<%# Eval("intaudiitedparticipantfemale") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="chvauditedplacemal" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
        
            </td>
             <td>
              <asp:TextBox ID="dtauditedgramasabha" Width="100px"  runat="server" Text='<%# Eval("dtauditedgramasabha") %>'></asp:TextBox>
         
            </td>
            <td>
             <asp:TextBox ID="fltAuditAttenPrece" Width="100px" runat="server" Text='<%# Eval("fltAuditAttenPrece") %>'></asp:TextBox>
  
            </td>
            <td>
             <asp:TextBox ID="chvauditedremarks" Width="100px" runat="server" Text='<%# Eval("chvauditedremarks") %>'></asp:TextBox>
               <asp:Label ID="intgramasabhano"  runat="server" Text='<%# Eval("intgramasabhano") %>' Visible="false" /> 

            </td>
              <td>
             <asp:TextBox ID="TextBox1" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
              <td>
             <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Eval("chvauditedplacemal") %>'></asp:TextBox>
             </td>
       </tr> 
    </ItemTemplate>
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
</div>
<%--sixth grid ends--%>
                        </div>
                        
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div><table><tr><td style="width: 1200px; height: 51px;" align="Center" colspan="3">
                        <asp:Button   CssClass="btn btn-secondary btn-sm" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"></asp:Button>&nbsp;
                        </td></tr></table></div>

                </div>
            </div><!-- .animated -->
        </div>
</asp:Content>





