<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YeniBaslik.aspx.cs" Inherits="YeniBaslik" %>

    
  <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <title></title>
    <link rel="stylesheet" type="text/css" href="mystyle.css"/>
</head>  

<body>
    <form id="form1" runat="server">
    <div class="container wrapper">
        <div id="top">
    <h1>OmuBumu</h1>
	<p>Yeni Başlık</p>
             </div>

  <div class="wrapper">
    <div id="menubar">
	  <ul id="menulist">
        <li class="menuitem" onclick="anasayfayaGit()">Anasayfa		
	 </ul>
    </div>

    <div id="main">
      <h1>Yeni başlık aç</h1>
        <table border="1" style="width:800px; border-spacing: 10px;">
           
            <tr>
                <td class="auto-style1" colspan="5"><strong style="text-align: right">Başlıkla ilgili bilgileri girin.</strong><asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            </td>
                            </tr>
                            <tr>
                                <td colspan="5"><strong style="text-align: right">Neleri karşılaştırıyorsun?</strong></td>
                            </tr>
                            <tr>
                                <td style="width:50px">1.</td>
                                <td style="width:300px">
                                    <asp:TextBox ID="txtVs1" runat="server"></asp:TextBox>
                                </td>
                                <td style="width:100px"><strong style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VS</strong></td>
                                <td style="width:50px">2.</td>
                                <td style="width:300px">
                                    <asp:TextBox ID="txtVs2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="5"><strong style="text-align: right">Resimlerini de koy.</strong></td>
                            </tr>
                            <tr>
                                <td >1.</td>
                                <td >
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td ><strong style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VS</strong></td>
                                <td ">2.</td>
                                <td>
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td >1.</td>
                                <td >
                                    <asp:Image ID="Image1" runat="server" Height="60px" Width="60px" />
                                    <br />
       
    
                                    <asp:Button ID="uppload1" runat="server" OnClick="btn_click" Text="Upload" />
                                </td>
                                <td ><strong style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VS</strong></td>
                                <td >2.</td>
                                <td >
                                    <asp:Image ID="Image2" runat="server" Height="60px" Width="60px" />
                                    <br />
              
                                    <asp:Button ID="uppload2" runat="server" OnClick="btn1_click" Text="Upload" />
                                </td>
                            </tr>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="uppload1" />
                            <asp:PostBackTrigger ControlID="uppload2" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
              <tr>
                <td class="auto-style30" colspan="2"><strong style="text-align: right">Ne zamana kadar kalsın?</strong></td>
                <td class="auto-style31" colspan="3">
                 
                     <asp:TextBox ID="TextBox3" runat="server" BackColor="White" ForeColor="Black"></asp:TextBox>
                 
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="5"><strong style="text-align: right">Sebebi neydi ki bunları buraya koyuyon sen şimdi?</strong></td>
            </tr>
            <tr>
                <td " colspan="5"><strong style="text-align: right">
                    <asp:TextBox ID="story" runat="server" Height="92px" MaxLength="140" TextMode="MultiLine" Width="278px"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="5">&nbsp;</td>
            </tr>
          
            <tr>
                <td class="auto-style34" colspan="5">
                    <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="True" Text="Yorumları da alayım." />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="kaydet" />
                </td>
            </tr>
           
        </table>
   </div>
      <div id="sidebar">
      </div>
  
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
 
    <asp:Button ID="btn_anasayfa" runat="server" Text="complaints" onclick="anasayfayaGit" style="display:none" />
    
    </form>
    <script>
        $(function () {
            $("#<%= TextBox3.ClientID %>").datepicker();
        });      
        function anasayfayaGit() {
            document.getElementById('<%= btn_anasayfa.ClientID %>').click();
        }
</script>
</body>
</html>