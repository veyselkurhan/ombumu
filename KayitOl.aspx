<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KayitOl.aspx.cs" Inherits="KayitOl" %>


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
	<p>Giriş</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa
		<li class="menuitem" onclick="giris()">Giriş Yap
		
	 </ul>
    </div>

    <div id="main">
      <h1>OmuBumu Kullanıcı Kayıt Formu</h1>
      <h2>Üye Adı</h2>
        <h2><asp:TextBox ID="txtNick" runat="server"></asp:TextBox>
                </h2>
      <h2>Şifre</h2>
        <h2><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </h2>
	
      <h2>Tekrar Şifre</h2>
        <h2><asp:TextBox ID="txtRePass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
                </h2>
	 
      <h2>Mail Adresi</h2>
        <h2><asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                 </h2>

      <h2>Cinsiyet</h2><asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="189px">
                        <asp:ListItem Value="0">Kadın</asp:ListItem>
                        <asp:ListItem Value="1">Erkek</asp:ListItem>
                    </asp:RadioButtonList>
                 

      <h2>Yaş</h2>
        <h2><asp:TextBox ID="txtYas" runat="server"></asp:TextBox>
                 </h2>
        
                    <asp:Button ID="btnRegister" runat="server" Text="Kayıt Ol" OnClick="btnRegister_Click" />
                    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="False"></asp:Label>
               
        	
   </div>
   
  </div>
         <div id="sidebar">
      </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>        
    
    </form>

     <script>
            function giris() {
                window.location.href = "Giris.aspx";
            }
            function anasayfayaGit() {
                window.location.href = "Anasayfa.aspx";
            }
        </script> 


</body>
</html>
