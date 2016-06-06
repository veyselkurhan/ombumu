<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="comment" %>

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
	<p>Yorum</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa
             <li class="menuitem" onclick='javascript:history.back(1);'>Geri
	 </ul>
    </div>

    <div id="main">
      <h1>
          <asp:Label ID="lblBaslikName" runat="server" Text="Label"></asp:Label>
        </h1>
      <h2>Yorum Yap</h2>
        <p>
              
            <asp:TextBox ID="mesTxt" runat="server" Height="72px" Width="215px" TextMode="MultiLine"></asp:TextBox>
  
           </p>
        <p>
            <asp:Button ID="mesBtn" runat="server" OnClick="message_Click" Text="Gönder" />
           
           
            </p>
   </div>
     
    <div id="sidebar">

            <asp:Repeater ID="Repeater1" runat="server">
                 <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1"  style="width:650px">
                    <tr >
                        <th  style="width:100px">
                            Yazar
                        </th>
                        <th  style="width:400px">
                            Yorum
                        </th>
                       <th style="width:100px">
                            Tarih
                        </th>
                        <th style="width:50px">

                        </th>
                    </tr>
            </HeaderTemplate>
                 <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                <tr>
                    <td>
                    <%#DataBinder.Eval(Container.DataItem,"nick") %>
                        
                    </td>
                      <td>
                    <%#DataBinder.Eval(Container.DataItem,"comment") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "dati")%>
                    </td>
                    <td>
<asp:Button ID="sikayet" runat="server" Text="Bildir" CommandArgument='<%#Eval("comID") %>' onclick="sikay_etClick" Width="50" />
                      
                    </td>
                 </tr>
            </ItemTemplate>
            <AlternatingItemTemplate><!-- ikinci satırda görüntülenecek bilgilerin biçimi  -->
                <tr bgcolor="#e9e9e9" style="width:650px">
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"nick") %>
                        
                    </td>
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"comment") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "dati")%>
                    </td>
                    <td>
<asp:Button ID="sikayet2" runat="server" Text="Bildir" CommandArgument='<%#Eval("comID") %>' onclick="sikay_etClick" Width="50" />
                        

                    </td>
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

    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    
           
    </form>

     <script>
            
            function anasayfayaGit() {
                window.location.href = "user.aspx";
            }
            function sikayetler() {
                document.getElementById('<%= mesBtn.ClientID %>').click();
            }
            
        </script> 
</body>
</html>
