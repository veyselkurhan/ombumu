<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

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
	<p>Mesajlar</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa
		<li class="menuitem" onclick="inbox()">Inbox
		<li class="menuitem" onclick="outbox()">Outbox
	 </ul>
    </div>

    <div id="main">
      <h1>Mesaj Gönder</h1>
      <h2>Mesaj</h2>
        <p>
              
            <asp:TextBox ID="txtMessage" runat="server" Height="72px" Width="215px" TextMode="MultiLine"></asp:TextBox>
  
           </p>
	  
       <h2>Alıcı</h2>
        <p>  <asp:TextBox ID="txtAlici" runat="server"></asp:TextBox></p>
        <p>
                    <asp:Button ID="btnMesajGonder" runat="server" Text="Gönder" Height="20px" OnClick="btnMesajGonder_Click" />
                    
                    

                    <asp:Label ID="lblInfo" runat="server"></asp:Label>
                    
                    

                    </p>
	 
   </div>
     
    <div id="sidebar">
      <h3 id="side">
          <asp:Label ID="lblSide" runat="server" Text="Gelen Kutusu"></asp:Label>
        </h3>
	  <p>

            <asp:Repeater ID="Repeater1" runat="server">
                 <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1"  style="width:650px">
                    <tr >
                        <th  style="width:100px">
                            Gönderen
                        </th>
                        <th  style="width:100px">
                            Alıcı
                        </th>
                       <th style="width:400px">
                            Mesaj
                        </th>
                        <th style="width:50px">

                        </th>
                    </tr>
            </HeaderTemplate>
                 <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                <tr>
                    <td>
                    <%#DataBinder.Eval(Container.DataItem,"sender_Name") %>
                        
                    </td>
                      <td>
                    <%#DataBinder.Eval(Container.DataItem,"receiver_Name") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "message_Details")%>
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="Sil" CommandArgument='<%#Eval("message_ID") %>' OnClick="Button4_Click" Width="50"/>  
                     
                    </td>
                 </tr>
            </ItemTemplate>
            <AlternatingItemTemplate><!-- ikinci satırda görüntülenecek bilgilerin biçimi  -->
                <tr bgcolor="#e9e9e9" style="width:650px">
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"sender_Name") %>
                        
                    </td>
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"receiver_Name") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "message_Details")%>
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Text="Sil" CommandArgument='<%#Eval("message_ID") %>' OnClick="Button4_Click" Width="50" />  
                       

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

                <asp:Repeater ID="Repeater2" runat="server">
                 <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1" style="width:650px">
                    <tr>
                        <th  style="width:100px">                            Gönderen
                        </th>
                        <th  style="width:100px">                            Alıcı
                        </th>
                        <th  style="width:400px">                            Mesaj
                        </th>
                        <th  style="width:50px"> 
                        </th>
                    </tr>
            </HeaderTemplate>
                 <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                <tr>
                    <td>
                    <%#DataBinder.Eval(Container.DataItem,"sender_Name") %>
                        
                    </td>
                      <td>
                    <%#DataBinder.Eval(Container.DataItem,"receiver_Name") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "message_Details")%>
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="Sil" CommandArgument='<%#Eval("message_ID") %>' OnClick="Button5_Click" Width="50" />  
                    </td>
                 </tr>
            </ItemTemplate>
            <AlternatingItemTemplate><!-- ikinci satırda görüntülenecek bilgilerin biçimi  -->
                <tr bgcolor="#e9e9e9" style="width:650px">
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"sender_Name") %>
                        
                    </td>
                     <td>
                    <%#DataBinder.Eval(Container.DataItem,"receiver_Name") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "message_Details")%>
                    </td>
                    <td>
                        <asp:Button ID="Button7" runat="server" Text="Sil" CommandArgument='<%#Eval("message_ID") %>' OnClick="Button5_Click" Width="50" />  
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

	  </p>
    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
   

         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="display:none">Inbox</asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" style="display:none"></asp:LinkButton>
           
    </form>
     <script>
            
            function anasayfayaGit() {
                window.location.href = "user.aspx";
            }
            function inbox() {
                document.getElementById('<%= LinkButton1.ClientID %>').click();
            }
            function outbox() {
                document.getElementById('<%= LinkButton2.ClientID %>').click();
            }
        </script> 

</body>
</html>