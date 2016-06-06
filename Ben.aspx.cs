using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Ben : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS ;Initial Catalog=navy; Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["nick"] == null)//session boşsa anasayfaya yönlendir.
        {
            Response.Redirect("Anasayfa.aspx");
        }
        else
        {        
        lblNick.Text = Session["nick"].ToString();
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();
        baslikSayisi();
        gidenMesajSayisi();
        gelenMesajSayisi();
        oySayisi();
        yorumSayisi();
        }
    }

   
    //user'ın istatistiki bilgileri için methodlar.
    private void baslikSayisi()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(*) from Users_title where userID = '" + Session["userID"].ToString() + "'", conn);
        Int32 count = (Int32)cmd.ExecuteScalar();
        lblBaslik.Text = count.ToString();
        conn.Close();       
    }

    private void oySayisi()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(*) from vote_user where userID = '" + Session["userID"].ToString() + "'", conn);
        Int32 count = (Int32)cmd.ExecuteScalar();
        lblOy.Text = count.ToString();
        conn.Close();
    }

   private void yorumSayisi()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(*) from comments where userID = '" + Session["userID"].ToString() + "'", conn);
        Int32 count = (Int32)cmd.ExecuteScalar();
        lblYorum.Text = count.ToString();
        conn.Close();
    }

    private void gidenMesajSayisi()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(*) from messages where sender_Name = '" + Session["nick"].ToString() + "'", conn);
        Int32 count = (Int32)cmd.ExecuteScalar();
        lblGiden.Text = count.ToString();
        conn.Close();
    }

   private void gelenMesajSayisi()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select COUNT(*) from messages where receiver_Name = '" + Session["nick"].ToString() + "'", conn);
        Int32 count = (Int32)cmd.ExecuteScalar();
        lblGelen.Text = count.ToString();
        conn.Close();
    }

    private DataSet getdata()//userın açtığı başlıkları topla.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select titleID ,tiStatus,title,story,deadLine,com ,p.picID as p1,p1.picID as p2,v.puan as puan,v1.puan as puan1,p.pic as p3,p1.pic as p4 from Users_title t,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D and t.userID = '" + Session["userID"].ToString() + "'";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

  

    protected void lnkCikis_Click(object sender, EventArgs e)//çıkış yap.
    {
        Session.Abandon();
    }

    protected void link_Click(object sender, EventArgs e)//yorumlara yönlendir.
    {
        LinkButton btn = (LinkButton)(sender);
        Session["titleID"] = btn.CommandArgument;
        Response.Redirect("comment.aspx");
    }

    protected void link1_Click(object sender, EventArgs e)//detaylara yönlendir.
    {
        LinkButton btn = (LinkButton)(sender);
        Session["titleID"] = btn.CommandArgument;
        Response.Redirect("Detail.aspx");
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)//açılan başlıklar repeaterinde yapılabilecekler.
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label title = (Label)e.Item.FindControl("titleID");

            SqlCommand cm1 = new SqlCommand();
            cm1.CommandText = "select com,titleID from Users_title where titleID=" + title.Text + "";//başlığın yorumlar hakkındaki bilgisini al.
            SqlDataAdapter da1 = new SqlDataAdapter(cm1.CommandText, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    LinkButton lbl = (LinkButton)e.Item.FindControl("LBtn");
                    
                    if (dr["com"].ToString() == "0")//0sa yoruma kapalı yaz, yönlendirmeyi kapat.
                    {
                        lbl.Text = "Yoruma kapalı.";
                        lbl.Enabled = false;
                    }

                }
            }


            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select titleID from vote_user where titleID=" + title.Text + " and userID=" + Convert.ToInt32(Session["userID"].ToString()) + "";
            SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)//yazarın oy verdiği başlıkları aldık. eğer yazar oy verdiyse, butonları inaktif edip sonuçları göster.
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Button activeButton4 = (Button)e.Item.FindControl("Button3");
                    Button activeButton3 = (Button)e.Item.FindControl("Button4");
                    activeButton4.Enabled = false;
                    activeButton3.Enabled = false;
                }

                Label activeLabel = (Label)e.Item.FindControl("Label6");//başlık durumu tistatus
                Label activeLabel2 = (Label)e.Item.FindControl("puan1");
                Label activeLabel1 = (Label)e.Item.FindControl("puan");

                Button activeButton1 = (Button)e.Item.FindControl("Button3");//oy verme butonları
                Button activeButton2 = (Button)e.Item.FindControl("Button4");//oy verme butonları
                string s = activeLabel.Text;

                activeButton1.Enabled = false;
                activeButton1.Text = "Aldığı Oy: " + activeLabel1.Text;
                activeButton2.Enabled = false;
                activeButton2.Text = "Aldığı Oy: " + activeLabel2.Text;

                activeLabel.Visible = false;
                activeLabel2.Visible = false;
                activeLabel1.Visible = false;
            }
        }
    }

    
    protected void Button4_Click(object sender, EventArgs e)//oy verme işlemleri.
    {
        conn.Open();
        int titleID = 0;
        SqlCommand cm = new SqlCommand();

        Button btn = (Button)(sender);
        int p2 = Convert.ToInt32(btn.CommandArgument);
        cm.CommandText = "select titleID from Users_title where pic1D=" + p2 + " or pic2D=" + p2 + "";
        SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                titleID = Convert.ToInt32(dr["titleID"].ToString());
            }
        }


        SqlCommand cmd = new SqlCommand("insert into vote_user(titleID,userID,picID) values (@p,@u,@pi)", conn);

        cmd.Parameters.AddWithValue("@p", titleID);
        cmd.Parameters.AddWithValue("@u", Convert.ToInt32(Session["userID"]));
        cmd.Parameters.AddWithValue("@pi", p2);
        cmd.ExecuteNonQuery();


        cmd.CommandText = "update voting set puan=puan+1 where picID=" + p2 + "";
        cmd.ExecuteNonQuery();

        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        conn.Close();


    }
    protected void Button3_Click(object sender, EventArgs e)//oy verme işlemleri.
    {
        int titleID = 0;
        SqlCommand cm = new SqlCommand();
        conn.Open();
        Button btn = (Button)(sender);
        int p1 = Convert.ToInt32(btn.CommandArgument);
        cm.CommandText = "select titleID from Users_title where pic1D=" + p1 + " or pic2D=" + p1 + "";
        SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                titleID = Convert.ToInt32(dr["titleID"].ToString());
            }
        }
        SqlCommand cmd = new SqlCommand("insert into vote_user(titleID,userID,picID) values (@t,@u,@pic)", conn);

        cmd.Parameters.AddWithValue("@t", titleID);
        cmd.Parameters.AddWithValue("@u", Convert.ToInt32(Session["userID"]));
        cmd.Parameters.AddWithValue("@pic", p1);
        cmd.ExecuteNonQuery();


        cmd.CommandText = "update voting set puan=puan+1 where picID=" + p1 + "";


        cmd.ExecuteNonQuery();
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();

        conn.Close();
    }

}