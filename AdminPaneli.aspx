<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPaneli.aspx.cs" Inherits="admin" %>

!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="mystyle.css">
</head>  

<body>
    <form id="form1" runat="server">
    <div class="container wrapper">
        <div id="top">
    <h1>OmuBumu'ya Hoşgeldiniz</h1>
	<p>Admin Paneli</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa
		<li class="menuitem" onclick="userAra()">Kullanıcı Ara
		<li class="menuitem" onclick="mesajlaraGit()">Mesajlar
		<li class="menuitem" onclick="sikayetler()">Şikayetler
	 </ul>
    </div>

    <div id="main">
      <h1>Yapılabilecekler</h1>
      <h2>Kullanıcı Ara</h2>
	  <p>
		Kullanıcı ara butonu ile kullanıcı arayabilir ve kullanıcı üzerinde işlemler yapabilirsiniz.		
	  </p>
       <h2>Mesajlar</h2>
	  <p>
          Mesajlarınızı görüntülemek için Mesajlar sayfasına yönlendirilirsiniz.
	  </p>
      <h2>Şikayetler</h2>
	  <p>
		Gelen yorum ve başlık şikayetlerini görüntüleyebilir ve işlem yapabilirsiniz.		
	  </p>
   </div>
     
    <div id="sidebar">
      <h3 id="side">
          <asp:Label ID="lblSide" runat="server" Text="İşlem Seçin"></asp:Label>
        </h3>
	  <p>
		  <asp:Label ID="lblSide2" runat="server" Text="Seçtiğiniz işlemleri bu kısımda yapabilirsiniz."></asp:Label>
	  </p>
        <p>
          <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" Visible="False"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="find" Visible="False"/>

            

            <asp:Repeater ID="Repeater1" runat="server" >
                 <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1"  style="width:700px">
                    <tr >
                        
                        <th  style="width:100px">
                            Yazar
                        </th>
                       <th style="width:400px">
                            Yorum
                        </th>
                        <th style="width:100px">

                        </th>
                        <th style="width:100px">

                        </th>
                    </tr>
            </HeaderTemplate>
                 <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                <tr>
                                                   <td>
<asp:label ID="lbl1" runat="server" text='<%#Eval("nick") %>'></asp:label>
                               </td>

                                                   <td>
<asp:label ID="lbl2" runat="server" text='<%#Eval("comment") %>'></asp:label>

                               </td>

                                                      <td>
   <asp:Button ID="Button4" runat="server" Text="Del Comment" CommandArgument='<%#Eval("comID") %>' OnClick="Button4_Click" Width="100" />
                                   </td>

                                                   <td>
                 <asp:Button ID="Button3" runat="server" Text="Del User" CommandArgument='<%#Eval("userID") %>' OnClick="Button3_Click" Width="100" />
                               </td

                 </tr>
            </ItemTemplate>
            <AlternatingItemTemplate><!-- ikinci satırda görüntülenecek bilgilerin biçimi  -->
                <tr>
                                                   <td>
<asp:label ID="lbl1" runat="server" text='<%#Eval("nick") %>'></asp:label>
                               </td>

                                                   <td>
<asp:label ID="lbl2" runat="server" text='<%#Eval("comment") %>'></asp:label>

                               </td>

                                                      <td>
   <asp:Button ID="Button4" runat="server" Text="Del Comment" CommandArgument='<%#Eval("comID") %>' OnClick="Button4_Click" Width="100" />
                                   </td>

                                                   <td>
                 <asp:Button ID="Button3" runat="server" Text="Del User" CommandArgument='<%#Eval("userID") %>' OnClick="Button3_Click" Width="100" />
                               </td

                 </tr>
            </AlternatingItemTemplate>
            <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr style="height:30px">
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
            <asp:Repeater ID="Repeater2" runat="server" onItemDataBound="Repeater2_ItemDataBound">
                 <ItemTemplate>
                    <table border="1" style="width:450px">
                        <tr >
                   <td style="width:300px">  <asp:Label ID="nick" runat="server" Text='<%#Eval("nick") %>'></asp:Label></td>
            
                           
                         <td style="width:50px">    <asp:Button ID="sil" runat="server" OnClick="sil_Click" CommandArgument='<%# Eval("nick") %>' Text="sil" Width="50" /></td>  
                   <td style="width:100px">  <asp:Button ID="mod" runat="server" OnClick="mod_Click" Text="mod yap" CommandArgument='<%# Eval("nick") %>' Width="100" />
               </td>
                        </tr>

                  
                  
                </ItemTemplate>

                 <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr style="height:30px">
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
    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
            <asp:Button ID="btn_comp" runat="server" Text="complaints" onclick="compl_click" style="display:none" />

            <asp:Button ID="btn_findUser" runat="server" Text="complaints" onclick="find_click" style="display:none"/>
    
    </form>
        <script>
            function mesajlaraGit() {
                window.location.href = "Message.aspx";
            }
            function anasayfayaGit() {
                window.location.href = "user.aspx";
            }
            function sikayetler() {
                document.getElementById('<%= btn_comp.ClientID %>').click();
            }
            function userAra() {
                document.getElementById('<%= btn_findUser.ClientID %>').click();
            }
        </script> 
</body>
</html>
