﻿<%@ Page Language="C#"MasterPageFile="~/Pages/AuditMasterPage.master" AutoEventWireup="true" CodeFile="SocialJusticeChildAged_Urban.aspx.cs" Inherits="AuditProject_Pages_SocialJusticeChildAged_Urban" Title="Socialjusticechildaged" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12" style="left: 0px; top: 0px">
                 <div class="title-blue-Head">ചെലവ് ഭാഗം (Page 3)
                </div>
<div class="card-header">
 <strong class="card-titlen"> 2(d)കുട്ടികള്‍,വൃദ്ധര്‍,ട്രാന്‍സ്ജെന്‍ഡേർസ് -പ്രോജക്ടുകളുടെ വിവരങ്ങള്‍</strong>
 </div>  
 <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(d)(1) കുട്ടികള്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍</strong>
 </div>  
  <div class="card-body">
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:1000px" >
                          <asp:Repeater ID="rptchild" runat="server" >


                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="6"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="6"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="3"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="3"  >
                   ചെലവഴിച്ച തുക
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
            
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
               
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട്/ഗു.വി
                </th>
                  <%-- <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട്/ഗു.വി
                </th>
             
                <%--<th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട് /ഗു.വി
                </th>
                  </th>
                   <%--<th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>--%>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് /ഗു.വി
                </th>
            
                <%-- <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                   --%>
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" runat="server" Text='<%# Eval("chvProjectName") %>' />
                 <asp:Label ID="lbldecProjectID" runat="server" Text='<%# Eval("decProjectID") %>' Visible="false" />
                  <asp:Label ID="intWorkingGroupID" runat="server" Text='<%# Eval("intWorkingGroupID") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "fltDevFund" runat="server"  Text='<%# Eval("fltDevFund") %>'  CssClass="floatnumbers"   ReadOnly="true" />
          
            </td>
            <td><asp:TextBox ID= "fltMG" runat="server" Text='<%# Eval("fltMG") %>' CssClass="floatnumbers"  ReadOnly="true" /></td>
             <td>
                <asp:TextBox ID= "fltOwnFund" runat="server" Text='<%# Eval("fltOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <%--<td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>--%>
             <%-- <td>
                <asp:TextBox ID= "fltTotal" runat="server" Text='<%# Eval("fltTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>--%>
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' CssClass="floatnumbers"  ReadOnly="true"  />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
                
               </td>  
                <%--  <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  CssClass="floatnumbers"  ReadOnly="true" />
                
            
            </td>--%>
            
              <%--<td>
                <asp:TextBox ID= "fltTotalExp" runat="server" Text='<%# Eval("fltTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>--%>
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <%--<td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltaudTotal" runat="server" Text='<%# Eval("fltaudTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>--%>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <%--<td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            <td>
                <asp:TextBox ID= "fltaudTotalExp" runat="server" Text='<%# Eval("fltaudTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true"  Enabled="false"/>
            </td>--%>
            </td>
           </tr></ItemTemplate>
              <FooterTemplate></table></FooterTemplate>          

</asp:Repeater>
</DIV>
</div>
                        </div>
                        <%--<div class="card-body">
                         <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(b)(2) വൃദ്ധര്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍</strong>
 </div>
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="rptAged" runat="server" >


                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="10"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
            
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
               
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട് 
                </th>
                  </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് 
                </th>
            
                 <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                   
                  
            </tr>
            
            
            
            
            
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" runat="server" Text='<%# Eval("chvProjectName") %>' />
                 <asp:Label ID="lbldecProjectID" runat="server" Text='<%# Eval("decProjectID") %>' Visible="false" />
                  <asp:Label ID="intWorkingGroupID" runat="server" Text='<%# Eval("intWorkingGroupID") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "fltDevFund" runat="server"  Text='<%# Eval("fltDevFund") %>'  CssClass="floatnumbers"   ReadOnly="true" />
          
            </td>
            <td><asp:TextBox ID= "fltMG" runat="server" Text='<%# Eval("fltMG") %>' CssClass="floatnumbers"  ReadOnly="true" /></td>
             <td>
                <asp:TextBox ID= "fltOwnFund" runat="server" Text='<%# Eval("fltOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltTotal" runat="server" Text='<%# Eval("fltTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' CssClass="floatnumbers"  ReadOnly="true"  />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
                
               </td>  
                 <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  CssClass="floatnumbers"  ReadOnly="true" />
                
            
            </td>
            
              <td>
                <asp:TextBox ID= "fltTotalExp" runat="server" Text='<%# Eval("fltTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false"  />
            </td>
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltaudTotal" runat="server" Text='<%# Eval("fltaudTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false"/>
            </td>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            <td>
                <asp:TextBox ID= "fltaudTotalExp" runat="server" Text='<%# Eval("fltaudTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false"/>
            </td>
            </td>
           </tr></ItemTemplate>
              <FooterTemplate></table></FooterTemplate>          


</asp:Repeater>

</DIV>
</div>
                       </div>--%>
                       <%-- <div class="card-body">
                                                <div class="card-header">
 <strong class="card-titlen">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 2(b)(3) പാലിയേറ്റീവ് കെയർ പ്രോജക്ടുകള്‍</strong>
 </div>
                        <div class="table table-striped table-bordered">
                        <DIV style="OVERFLOW: scroll; WIDTH: 1200px;height:500px" >
                          <asp:Repeater ID="rptPaliative" runat="server" >


                       
                             <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1" style="font-size: 20px;font-family: Meera; vertical-align:middle" >
        
        
        <tr> 
        <th scope="col"  rowspan="3" align="center"  >
                    ക്രമ. നം
                </th>
        <th scope="col"  rowspan="3" align="center"  >
                   പ്രോജക്ടുകളുടെ വിവരം
                </th>
                <th scope="col" style="text-align:center"  align="center" colspan="10"  >
                     നിലവിലുള്ള വിവരങ്ങള്‍
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="10"  >
                   ഓഡിറ്റില്‍ കണ്ടെത്തിയ വിവരങ്ങള്‍
                </th>
                          
            </tr>
        <tr> 
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                
                <th scope="col" style="text-align:center"  align="center" colspan="5"  >
                    വകയിരുത്തിയതുക
                </th>
                  <th scope="col"  style="text-align:center"  align="center" colspan="5"  >
                   ചെലവഴിച്ച തുക
                </th>
                          
            </tr>
            
            <tr>
               
                <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
            
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
               
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട്
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
              
              
              <th scope="col" style="width: 200px" align="center">
                 വികസന ഫണ്ട്
                </th>
             
                <th scope="col" style="width: 200px"  align="center">
               മെ.ഫ

                </th>
              
                   <th scope="col" style="width: 100px"  align="center">
                  തനത് ഫണ്ട് 
                </th>
                  </th>
                   <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                 <th scope="col" style="width: 100px" align="center">
                      വികസന ഫണ്ട്
                </th>
                 <th scope="col" style="width: 100px" align="center">
                   മെ.ഫ
                </th>
                  
                  
                   <th scope="col" style="width: 200px" align="center">
               തനത് ഫണ്ട് 
                </th>
            
                 <th scope="col" style="width: 100px" align="center">
                  മറ്റുള്ളവ
                </th>
                </th>
                   <th scope="col" style="width: 100px" align="center">
                  ആകെ
                </th>
                   
                  
            </tr>
  
             
    </HeaderTemplate>
    
    <ItemTemplate>
       
        <td>
                <asp:Label ID="txtSlno" runat="server" Text='<%# Eval("SLNO") %>' />
               
            </td>
            <td>
                <asp:Label ID="chvProjectName" runat="server" Text='<%# Eval("chvProjectName") %>' />
                 <asp:Label ID="lbldecProjectID" runat="server" Text='<%# Eval("decProjectID") %>' Visible="false" />
                  <asp:Label ID="intWorkingGroupID" runat="server" Text='<%# Eval("intWorkingGroupID") %>' Visible="false" />
            </td>
            <td>
            
        <asp:TextBox ID= "fltDevFund" runat="server"  Text='<%# Eval("fltDevFund") %>'  CssClass="floatnumbers"   ReadOnly="true" />
          
            </td>
            <td><asp:TextBox ID= "fltMG" runat="server" Text='<%# Eval("fltMG") %>' CssClass="floatnumbers"  ReadOnly="true" /></td>
             <td>
                <asp:TextBox ID= "fltOwnFund" runat="server" Text='<%# Eval("fltOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltOtherFund" runat="server" Text='<%# Eval("fltOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltTotal" runat="server" Text='<%# Eval("fltTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>
            <td>
            
      <asp:TextBox ID= "fltDevFundExp" runat="server" Text='<%# Eval("fltDevFundExp") %>' CssClass="floatnumbers"  ReadOnly="true"  />
            </td>
             <td>
                 <asp:TextBox ID= "fltMGExp" runat="server"  Text='<%# Eval("fltMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
             <td>
                <asp:TextBox ID= "fltOwnFundExp" runat="server"  Text='<%# Eval("fltOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
                
               </td>  
                 <td>
                  <asp:TextBox ID= "fltOtherFundExp" runat="server"  Text='<%# Eval("fltOtherFundExp") %>'  CssClass="floatnumbers"  ReadOnly="true" />
                
            
            </td>
            
              <td>
                <asp:TextBox ID= "fltTotalExp" runat="server" Text='<%# Eval("fltTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false" />
            </td>
            
            
            <td>
                <asp:TextBox ID= "fltaudDevFund" runat="server" Text='<%# Eval("fltaudDevFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMG" runat="server" Text='<%# Eval("fltaudMG") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFund" runat="server" Text='<%# Eval("fltaudOwnFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFund" runat="server" Text='<%# Eval("fltaudOtherFund") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
              <td>
                <asp:TextBox ID= "fltaudTotal" runat="server" Text='<%# Eval("fltaudTotal") %>' CssClass="floatnumbers"  ReadOnly="true" Enabled="false"/>
            </td>
            <td>
                <asp:TextBox ID= "fltaudDevFundExp" runat="server" Text='<%# Eval("fltaudDevFundExp") %>' CssClass="floatnumbers" ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudMGExp" runat="server" Text='<%# Eval("fltaudMGExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOwnFundExp" runat="server" Text='<%# Eval("fltaudOwnFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            <td>
                <asp:TextBox ID= "fltaudOtherFundExp" runat="server" Text='<%# Eval("fltaudOtherFundExp") %>' CssClass="floatnumbers"  ReadOnly="true" />
            </td>
            
            <td>
                <asp:TextBox ID= "fltaudTotalExp" runat="server" Text='<%# Eval("fltaudTotalExp") %>' CssClass="floatnumbers"  ReadOnly="true"  Enabled="false"/>
            </td>
            </td>
           </tr></ItemTemplate>
              <FooterTemplate></table></FooterTemplate>          


</asp:Repeater>



</DIV>
</div>
                
                        </div>--%>
 
                        </div>
                    </div>
                   <table><tr><td></td></tr></table> 
                    
                </div>
<div><table width="100%"> <tr> 
<td style="width: 500px">
    &nbsp; &nbsp;
                  <asp:Button ID="btnBack" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="BACK" Width="62px" OnClick="btnBack_Click" />
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-secondary btn-sm" OnClick="btnSave_Click"
                                        Text="SAVE" Width="62px" />
                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-secondary btn-sm"
                  Text="NEXT" Width="62px" OnClick="btnNext_Click" /></td>
                               
                               </tr> 
                              </table></div>

                </div>
            <!-- .animated -->
        

</asp:Content>

