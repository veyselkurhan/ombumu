using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class comment : System.Web.UI.Page
{

    bool isZiyaretci = false;
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");//db bağlantısı
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null) { mesBtn.Text = "Üye girişi yapın."; isZiyaretci = true; }
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        basligiAl();
    }

    private void basligiAl()
    {
        SqlCommand komut = new SqlCommand(" select title,v.puan as puan, v1.puan as puan1, p.pic as p3, p1.pic as p4 from Users_title u,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D and u.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + "", conn);// verıtabanında textbox gırılen kullanıcı adına gore tarama yapıyoruzz
        SqlDataReader okuyucu = komut.ExecuteReader();// ve reader komutunu kullanarak gelen veriyi rdr adlı degıskenımıze atıyoruz
        if (okuyucu.Read())
        {
            lblBaslikName.Text = okuyucu["title"].ToString();            
        }
        okuyucu.Close();
        conn.Close();
    }

    protected void message_Click(object sender, EventArgs e)//yorum gönder butonu.
    {
        if (isZiyaretci == false)//ziyaretçi değil, giriş yapılmış.
        {
            DateTime now =  DateTime.Now;
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO comments(titleID,userId,comment,dati) values (@titleID,@userId,@comment,@dati)", conn);
            cmd.Parameters.AddWithValue("@titleID", Convert.ToInt32(Session["titleID"]));
            cmd.Parameters.AddWithValue("@userId", Convert.ToInt32(Session["userID"]));
            cmd.Parameters.AddWithValue("@comment", mesTxt.Text);
            cmd.Parameters.AddWithValue("@dati", now);

            cmd.ExecuteNonQuery();//yorum ekleme.
            conn.Close();
        }
        else Response.Redirect("KayitOl.aspx");//ziyaretçi girişi ise butona basında kayıt ol sayfasına yönlendir.

        Response.Redirect("comment.aspx");
    }


    private DataSet getdata()//commentleri topla.
    {
        conn.Open();

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select * from comments c,Users u where c.titleID="+ Convert.ToInt32(Session["titleID"])+" and c.userID=u.userID";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
       
        return ds;
    }


    protected void sikay_etClick(object sender, EventArgs e)//şikayet et butonu.
    {
      Button sikayet = (Button)(sender);
      int comID  = Convert.ToInt32(sikayet.CommandArgument);

      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO complaints(comID) values (@comID)", conn);
     cmd.Parameters.AddWithValue("@comID", comID);

      cmd.ExecuteNonQuery();
      conn.Close();
      Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Kayıt başarılı", "<script>alert('Bildiriminiz için teşekkürler.');</script>");

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Anasayfa.aspx");
    }
    
}