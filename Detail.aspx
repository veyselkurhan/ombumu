<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
	<p>Detaylar</p>
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
      <h2>Başlık</h2>
        <p>





           <asp:Repeater ID="Repeater1" runat="server"  Visible="true">
            <ItemTemplate>
                        
               <table id="table" border="1" style="width:800px;" >

                 
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
                       <td>                    
                           <asp:Label ID="Label5" runat="server" Text='<%#"Aldığı oy: "+ Eval("puan")%>'></asp:Label>

                       </td>
                         <td>                    
                           <asp:Label ID="Label1" runat="server" Text='<%#"Aldığı oy: "+  Eval("puan1")%>' ></asp:Label>

                       </td>
                   </tr>
             </table>
                </ItemTemplate>
         
        </asp:Repeater>  
                  </p>
       <h2>Toplam Verilen Oy:
                    <asp:Label ID="lblToplamOy" runat="server" Text="Label"></asp:Label>
                  </h2>
   </div>
     
    <div id="sidebar">
      <h3 id="side">
          Grafikler</h3>
	  <p>
		  Cinsiyete göre oy dağılım oranları:</p>
        <p>
		    <Table>
                <tr>
                <td></td>
                <td class="auto-style18"><b style="font-size: x-large">Cinsiyete göre oy dağılım oranları:</b></td>
                <td class="auto-style19"></td>
            </tr>
               <tr>
                <td></td>
                <td class="auto-style18">
                     <table border='1' style="width:400px;" >
                         <tr>
                             <td>1. seçenek:</td>
                             <td>2. seçenek:</td>
                         </tr>
                         <tr>
                             <td>

        <asp:Chart ID="Chart2" runat="server" Width="278px">
            <Series>
                <asp:Series Name="Series1"    XValueMember="gender" YValueMembers="count">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
 

                             </td>
                             <td>
        <asp:Chart ID="Chart1" runat="server" Width="278px">
            <series>
                <asp:Series Name="Series1" LegendText="Ad"
                    XValueMember="gender" YValueMembers="count">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
 

                             </td>
                         </tr>
                         </table>


                   </td>
                <td class="auto-style19"></td>
            </tr>
		    </Table></p>
        <p>
		    Yaşa göre oy dağılım oranları:</p>
        <p>
		     <table border='1' style="width:400px;" >
                         <tr>
                             <td>1. seçenek:</td>
                             <td>2. seçenek:</td>
                         </tr>
                         <tr>
                             <td>

                    <asp:Chart ID="Chart3" runat="server" Width="278px">
                      
                        <Series>
                            <asp:Series Name="Series1" XValueMember="age_group" YValueMembers="count">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>



                             </td><td>
                                 
              <asp:Chart ID="Chart4" runat="server" Width="278px">
               <Series>
                   <asp:Series Name="Series1" XValueMember="age_group"  YValueMembers="count" >
                   </asp:Series>
               </Series>
               <ChartAreas>
                   <asp:ChartArea Name="ChartArea1">
                   </asp:ChartArea>
               </ChartAreas>
           </asp:Chart>


                                  </td></tr>

                         </table></p>
    </div>
  </div>
  <div id="bottom">
      MIS 336 dersi projesi kapsamında Boğaziçi Üniversitesi öğrencileri tarafından yapılmıştır. Tüm hakları saklıdır.  </div>
        
    </div>
    

    </form>

     <script>           
            function anasayfayaGit() {
                window.location.href = "user.aspx";
            }          
        </script> 

</body>
</html>
