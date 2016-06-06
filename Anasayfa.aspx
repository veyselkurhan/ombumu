<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Anasayfa.aspx.cs" Inherits="Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="mystyle.css"/>
</head>  
<body>
    <form id="form1" runat="server">
    <div class="container wrapper">
        <div id="top">
    <h1>OmuBumu</h1>
	<p>Anasayfa</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="girisYap()">Giriş Yap
		<li class="menuitem" onclick="kayitOl()">Kayıt Ol
		
	 </ul>
    </div>

    <div id="main">
      <h1>Merhaba</h1>
      <h2>Ziyaretçi Görünümündesiniz</h2>
	  <p>Sitemizin olanaklarından faydalanabilmek için kayıt olun veya giriş yapın.</p>      
   </div>
     
    <div id="sidebar">
                    <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound">

                         <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1" style="width:816px; margin: 0 auto;">
                    <tr >
                        <th >
                           <h1> Aktif Başlıklar </h1>
                        </th>
                    </tr>
            </HeaderTemplate>


            <ItemTemplate>
                        
               <table id="table" border="1" style="width:800px; margin: 0 auto;"">

                    <tr style="width:400px;">
                       <td colspan="2">
                           <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <h2>  <asp:Label ID="Label1" runat="server" Text='<%#Eval("title")%>' ></asp:Label>      </h2>  </div>             
                       </td>
                       </tr>
                   <tr>
                       <td  colspan="2">
                           <asp:Label ID="Label2" runat="server" Text='<%#Eval("story") %>'></asp:Label>
                       </td>
                   </tr>


                   <tr>
                       <td>
                         <asp:Label ID="label3" runat="server" Text='<%#Eval("titleID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("tiStatus") %>' Visible="False"></asp:Label>
                     
                         <img  alt="" src='<%#Eval("p3")%>' height="400" width="400" />
                       </td>
                       <td>
                           <img  alt=""id="asd" src='<%#Eval("p4")%>' height="400" width="400" />
                       </td>
                   </tr>

                  
                   <tr>
                       <td colspan="2">
                       <asp:Label ID="Label7" runat="server" Text="Oylama bitti, " ></asp:Label>   
                           <asp:Label ID="Label8" runat="server" Text="Oylama devam ediyor..." ></asp:Label>
                           <asp:Label ID="Label5" runat="server" Text='<%#"sonuçlar: "+ Eval("title") + ": " + Eval("puan") + " VS " + Eval("puan1")%>' Visible="False"></asp:Label>

                           </td>
                   </tr>

                  
                   <tr>
                       <td colspan="2">
                                      <asp:LinkButton id="LBtn"  Text="Yorumlar..." runat="server" CommandArgument='<%#Eval("titleID") %>' OnClick="link_Click" Font-Bold="True" />
                           
                       </td>
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
        <p>
            &nbsp;</p>
    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
    
    </form>


     <script>
            function girisYap() {
                window.location.href = "Giris.aspx";
            }            function kayitOl() {
                window.location.href = "KayitOl.aspx";
            }                    </script> 

</body>
</html>
