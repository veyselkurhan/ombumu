<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="_Default" %>

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
		<li class="menuitem" onclick="kayitOl()">Kayıt Ol
   	 </ul>
    </div>

    <div id="main">
        <h1>OmuBumu Kullanıcı Girişi</h1>
      <h2>Üye Adı</h2>
        <h2>
                    <asp:TextBox ID="txtNick" runat="server"></asp:TextBox>
                </h2>
	 
       <h2>Şifre</h2>
        <h2>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </h2>
        
                    <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" OnClick="btnGiris_Click" />
                  <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="False"></asp:Label>               
      
   </div>

       <div id="sidebar">
      </div>
  
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
  
    </form>

     <script>
            function kayitOl() {
                window.location.href = "kayitOl.aspx";
            }
            function anasayfayaGit() {
                window.location.href = "Anasayfa.aspx";
            }
        </script> 


</body>
</html>