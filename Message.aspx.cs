using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Message : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");//db bağlantısı

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nick"] == null)//üye girişi yapılmamışsa giremesin
        {
            Response.Redirect("Anasayfa.aspx");
        }
        else
        {
            Repeater1.Visible = true;//inbox repeateri.
            Repeater2.Visible = false;
            Repeater1.DataSource = getdata();//inboxları doldur
            Repeater1.DataBind();
            Repeater2.DataSource = getdata2();//outboxları doldur
            Repeater2.DataBind();
            conn.Close();
        }

    }

    private DataSet getdata()//gelen kutusu
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select * from messages where receiver_Name = '" + Session["nick"] + "' AND receiver_Active='1' ORDER BY message_ID desc";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

    private DataSet getdata2()//giden kutusu
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select * from messages where sender_Name = '" + Session["nick"] + "' AND sender_Active='1' ORDER BY message_ID desc";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

    protected void btnMesajGonder_Click(object sender, EventArgs e)//mesaj gönder butonu.
    {
        String senderName = Session["nick"].ToString(); // giriş yaptığında kaydetmiştik.
        String receiverName = txtAlici.Text;
        receiverName = receiverName.Replace(" ", ""); // boşluk varsa arada siliyoruz, böylece kullanıcı adlarını alırken sorun olmuyor.
        string[] receiverNames = receiverName.Split(','); //virgüle göre ayırıp hepsini arraye atıyoruz.
        String messageDetails = txtMessage.Text;
        

        foreach (string item in receiverNames)
        {
            if (Int32.Parse(Session["adminStatus"].ToString()) == 0 && receiverNames.Length > 3)
            { // admin değilse ve 3ten fazla kişiye mesaj atmaya çalışıyorsa hata veriyor.
                lblInfo.Text = "En fazla 3 kişiye mesaj atabilirsiniz.";
                break;
            }


            SqlConnection nbaglanti = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True; MultipleActiveResultSets=True");
            nbaglanti.Open();


            try
            {
                if (Int32.Parse(Session["adminStatus"].ToString()) == 1 && receiverName.Length == 0)//adminse ve alıcı kısmını boş bıraktıysa.
                { 
                    lblInfo.Text = "Mesajınız herkese gönderildi."; //yani alıcı kısmı boş oluyor. bu durumda eğer adminse herkese göndersin diyoruz.
                    SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Users", nbaglanti);

                    SqlDataReader okuyucu = cmdSearch.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        Session["receivers"] = okuyucu["nick"].ToString();
                        if (Session["receivers"].ToString() != Session["nick"].ToString())//kendisine gitmesin.
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Messages (sender_Name, receiver_Name, message_Details) VALUES ('" + senderName + "','" + okuyucu["nick"].ToString() + "','" + messageDetails + "')", nbaglanti);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    nbaglanti.Close();
                    txtAlici.Text = "";
                    txtMessage.Text = "";
                }
                else if (Int32.Parse(Session["adminStatus"].ToString()) == 0 && receiverName.Length == 0)
                {//admin değilse de user boşa mesaj atmaya çalışıyor mu diye kontrol etmiş oluyoruz.
                    lblInfo.Text = "Bir kullanıcı ismi girin.";
                }
                else
                {//geriye tüm kısıtlamaların uygun olduğu hal kalıyor.
                    SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Users WHERE nick='" + item + "'", nbaglanti);
                    SqlDataReader okuyucu = cmdSearch.ExecuteReader();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Messages (sender_Name, receiver_Name, message_Details) VALUES ('" + senderName + "','" + item + "','" + messageDetails + "')", nbaglanti);
                    if (okuyucu.Read())
                    {
                        lblInfo.Text += item + "'e mesaj gönderildi. <br />";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {//yanlış kullanıcı adı girdiyse database'e kaydetmiyoruz.
                        lblInfo.Text += item + " diye biri yok. <br />";
                    }
                    txtAlici.Text = "";
                    txtMessage.Text = "";
                    nbaglanti.Close();
                }

            }
            catch (Exception hata)
            {
                Response.Write(hata.Message);
            }
        }

        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();

            
    }

   
    protected void Button4_Click(object sender, EventArgs e)//inboxtan sil.
    {
        conn.Open();
        SqlCommand cm = new SqlCommand();

        Button btn = (Button)(sender);
        int p2 = Convert.ToInt32(btn.CommandArgument);
        SqlCommand cmd = new SqlCommand("UPDATE messages SET receiver_Active='0' where message_ID = '" + p2 + "'", conn);
        //delete yapsaydık eğer karşı tarafın outboxtan da giderdi. bu yüzden aktiflik rowu eklendi.


        cmd.ExecuteNonQuery();

        conn.Close();

        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();

    }

    protected void Button5_Click(object sender, EventArgs e)//outboxtan sil.
    {
        conn.Open();
        SqlCommand cm = new SqlCommand();

        Button btn = (Button)(sender);
        int p2 = Convert.ToInt32(btn.CommandArgument);
        SqlCommand cmd = new SqlCommand("UPDATE messages SET sender_Active=0 where message_ID = '" + p2 + "'", conn);


        cmd.ExecuteNonQuery();

        conn.Close();

        Repeater1.DataSource = getdata2();
        Repeater1.DataBind();
        conn.Close();



    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Repeater1.Visible = true;
        Repeater2.Visible = false;
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();
        lblSide.Text = "Gelen kutusu";
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Repeater2.Visible = true;
        Repeater1.Visible = false;
        Repeater2.DataSource = getdata2();
        Repeater2.DataBind();
        conn.Close();
        lblSide.Text = "Giden kutusu";
    }
}