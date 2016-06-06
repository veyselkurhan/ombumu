<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ben.aspx.cs" Inherits="Ben" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="mystyle.css">
</head>  

<body>
    <form id="form1" runat="server">
    <div class="container wrapper">
        <div id="top">
    <h1>OmuBumu</h1>
	<p>Ben</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa
		<li class="menuitem" onclick="mesajlaraGit()">Mesajlar
		<li class="menuitem" onclick="cik()">Çık
	 </ul>
    </div>

    <div id="main">
      <h1><asp:Label ID="lblNick" runat="server" Font-Bold="True"></asp:Label>
        </h1>
      <h2>Açtığı başlık sayısı: 
                    <asp:Label ID="lblBaslik" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </h2>
	
       <h2>Oy verdiği başlık sayısı: 
                     <asp:Label ID="lblOy" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </h2>
	
      <h2>Yaptığı yorum sayısı: 
                     <asp:Label ID="lblYorum" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </h2>
	
        <h2>Gönderdiği mesaj sayısı: 
                     <asp:Label ID="lblGiden" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </h2>
        <h2>Aldığı mesaj sayısı: 
                     <asp:Label ID="lblGelen" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </h2>
        
   </div>
     
    <div id="sidebar">
              <asp:Repeater ID="Repeater1" runat="server" Visible="true" OnItemDataBound="Repeater1_ItemDataBound">
                        
                          <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1" style="width:816px; margin: 0 auto;">
                    <tr >
                        <th >
                           <h3> Yazarın Başlıkları </h3>
                        </th>
                    </tr>
            </HeaderTemplate>

 <ItemTemplate>
                        
               <table id="table" border="1" style="width:800px; margin: 0 auto;"">

                    <tr style="width:400px;">
                       <td colspan="2">
                           <div style="margin-left: auto; margin-right: auto; text-align: center;">
                                          <asp:Label ID="titleID" runat="server" Text='<%#Eval("titleID")%>' Font-Bold="True" Visible="False"></asp:Label> 
                                                <asp:Label ID="puan" runat="server" Text= '<%#Eval("puan") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="puan1" runat="server" Text='<%#Eval("puan1") %>' Visible="False"></asp:Label>
                                       <h2>   <asp:Label ID="Label1" runat="server" Text='<%#Eval("title")%>'></asp:Label> </h2>
                                          <asp:Label ID="Label6" runat="server" Text='<%#Eval("tiStatus") %>' Visible="False"></asp:Label> </div>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td  colspan="2">
                           <asp:Label ID="Label7" runat="server" Text='<%#Eval("story") %>'></asp:Label>
                       </td>
                   </tr>


                   <tr>
                       <td>
                           <img alt="" src='<%#Eval("p3")%>' height="400" width="400"/>
                       </td> 
                       <td> 
                           <img alt=""id="asd" src='<%#Eval("p4")%>' height="400" width="400"/>                
                      </td>
                   </tr>

                   <tr>
                 <td>
                     <asp:Button ID="Button3" runat="server" Text="beğen" CommandArgument='<%#Eval("p1") %>' OnClick="Button3_Click" Width="400" />  
                 </td>
                 <td>
                      <asp:Button ID="Button4" runat="server" Text="beğen" CommandArgument='<%#Eval("p2") %>' OnClick="Button4_Click" Width="400" />    
                 </td>
             </tr>
              <tr>
                  <td><asp:LinkButton id="LBtn"  Text="Yorumlar..." runat="server" CommandArgument='<%#Eval("titleID") %>' OnClick="link_Click" Font-Bold="True" /></td>
                    <td><asp:LinkButton id="LinkButton1"  Text=" Detaylar..." runat="server" CommandArgument='<%#Eval("titleID") %>' OnClick="link1_Click" Font-Bold="True" /></td>
              </tr>

              
                
                </ItemTemplate>

              

                         <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr style="height:50px" bgcolor="#ffffff">
                    <td colspan="4">
                        <hr>
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate><!-- son satırda tabloyu kapayıyoruz  -->
                </table>
            </FooterTemplate>
         
        </asp:Repeater>  
        </p>
        <p>
                    &nbsp;</p>
    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
    
                    
     
                  <asp:LinkButton ID="lnkCikis" runat="server" OnClick="lnkCikis_Click" style="display:none">Çık</asp:LinkButton>

        </form>
    
              <script>
            function mesajlaraGit() {
                window.location.href = "Message.aspx";
            }
            function anasayfayaGit() {
                window.location.href = "user.aspx";
            }
            function cik() {
                document.getElementById('<%= lnkCikis.ClientID %>').click();
            }
           
        </script>            
              
        
    
</body>
</html>
