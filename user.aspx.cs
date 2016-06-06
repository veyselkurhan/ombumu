using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class user : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
      
        //kullanıcı girişi yapılmış mı? giren admin mi?

        if (Session["nick"] == null)
        {
            Response.Redirect("Anasayfa.aspx");
        }
        else
        {
            Label2.Text = " " + Session["nick"];
            Repeater1.DataSource = getdata();
            Repeater1.DataBind();
            conn.Close();
        }

        if (Int32.Parse(Session["adminStatus"].ToString()) == 1)
        {
            lnkAdmin.Visible = true;
        }
        else
        {
            lnkAdmin.Visible = false;
        }

    }


    protected void Button2_Click(object sender, EventArgs e)//başlık aç sayfası.
    {
        Response.Redirect("YeniBaslik.aspx");
    }

   

    protected void link_Click(object sender, EventArgs e)//yorumlar sayfası.
    {
        LinkButton btn = (LinkButton)(sender);
        Session["titleID"] = btn.CommandArgument;
        Response.Redirect("comment.aspx");
    }

    protected void link1_Click(object sender, EventArgs e)//detaylar sayfası.
    {
        // detail formu açmak için
        LinkButton btn = (LinkButton)(sender);
        Session["titleID"] = btn.CommandArgument;
        Response.Redirect("Detail.aspx");
    }

    private DataSet getdata()//başlıkları al.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select titleID ,tiStatus,title,story,deadLine,com ,p.picID as p1,p1.picID as p2,v.puan as puan,v1.puan as puan1,p.pic as p3,p1.pic as p4 from Users_title,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D order by titleID desc";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }


    //başlık arama butonu için ayrı repeater kullanıldı. bu yüzden 4 tane oy verme butonu var.
    protected void Button4_Click(object sender, EventArgs e)//oy verme butonu.
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

    protected void Button6_Click(object sender, EventArgs e)//oy verme butonu.
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
        Repeater2.DataSource = getdata2();
        Repeater2.DataBind();
        conn.Close();


    }

    protected void Button3_Click(object sender, EventArgs e)//oy verme
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

    protected void Button5_Click(object sender, EventArgs e)//oy verme.
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
        Repeater2.DataSource = getdata2();
        Repeater2.DataBind();

        conn.Close();

    }


    protected void lnkCikis_Click(object sender, EventArgs e)//çıkış yap.
    {
        Session.Abandon();
        Response.Redirect("Anasayfa.aspx");
    }



    

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)//tün başlıklar.
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            Label activeLabel2 = (Label)e.Item.FindControl("puan1");
            Label activeLabel1 = (Label)e.Item.FindControl("puan");
            Label title = (Label)e.Item.FindControl("titleID");

            SqlCommand cm1 = new SqlCommand();
            cm1.CommandText = "select com,titleID from Users_title where titleID=" + title.Text + "";//yorum isteniyor mu bilgisini al.
            SqlDataAdapter da1 = new SqlDataAdapter(cm1.CommandText, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    LinkButton lbl = (LinkButton)e.Item.FindControl("LBtn");
                    if (dr["com"].ToString() == "0")//istenmiyorsa linki kapat, yazıyı değiştir.
                    {
                        lbl.Text = "Yoruma kapalı.";
                        lbl.Enabled = false;
                    }

                }
            }


            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select titleID from vote_user where titleID=" + title.Text + " and userID=" + Convert.ToInt32(Session["userID"].ToString()) + "";//user üye vermiş mi?
            SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {//üye verdiyse oy ver butonlarını kapat, sonuçları göster.
                    Button activeButton4 = (Button)e.Item.FindControl("Button3");
                    Button activeButton3 = (Button)e.Item.FindControl("Button4");
                    activeButton4.Enabled = false;
                    activeButton4.Text = "Aldığı Oy: " + activeLabel1.Text;
                    activeButton3.Enabled = false;
                    activeButton3.Text = "Aldığı Oy: " + activeLabel2.Text;
                }
            }
            Label activeLabel = (Label)e.Item.FindControl("Label6");//tistatus. başlık durumu.


            Label lbl1 = (Label)e.Item.FindControl("Label3");//bitti
            Label lbl2 = (Label)e.Item.FindControl("Label8");//devam
           

            Button activeButton1 = (Button)e.Item.FindControl("Button3");
            Button activeButton2 = (Button)e.Item.FindControl("Button4");
            string s = activeLabel.Text;//başlık durumunu aldık.
            if (s == "1")
            {
                lbl2.Visible = true;//devam          
            }
            else
            {
                lbl1.Visible = true;//bitti
                activeButton1.Enabled = false;
                activeButton1.Text = "Aldığı Oy: " + activeLabel1.Text;
                activeButton2.Enabled = false;
                activeButton2.Text = "Aldığı Oy: " + activeLabel2.Text;

            }


            activeLabel.Visible = false;
            activeLabel2.Visible = false;
            activeLabel1.Visible = false;
        }






    }

    protected void lnkbasliklar_Click(object sender, EventArgs e)//tün başlıklar.
    {
        Repeater1.Visible = true;
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        Repeater2.Visible = false;
    }

    protected void btnAra_Click(object sender, EventArgs e)//başlık ara.
    {
        Repeater1.Visible = false;
        Repeater2.DataSource = getdata2();
        Repeater2.DataBind();
        Repeater2.Visible = true;
    }

    private DataSet getdata2()//başlık araya göre bilgileri topla.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select titleID ,tiStatus,title,story,deadLine,com ,p.picID as p1,p1.picID as p2,v.puan as puan,v1.puan as puan1,p.pic as p3,p1.pic as p4 from Users_title,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D and title LIKE '%" + txtAra.Text + "%'"; 


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)// başlık arada gelen repeaterde yine aynı işlemler. oy verme, yorumlar vs.
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            Label activeLabel2 = (Label)e.Item.FindControl("puan1");
            Label activeLabel1 = (Label)e.Item.FindControl("puan");
            Label title = (Label)e.Item.FindControl("titleID");

            SqlCommand cm1 = new SqlCommand();
            cm1.CommandText = "select com,titleID from Users_title where titleID=" + title.Text + "";
            SqlDataAdapter da1 = new SqlDataAdapter(cm1.CommandText, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    LinkButton lbl = (LinkButton)e.Item.FindControl("LBtn");
                    if (dr["com"].ToString() == "0")
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
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Button activeButton4 = (Button)e.Item.FindControl("Button3");
                    Button activeButton3 = (Button)e.Item.FindControl("Button4");
                    activeButton4.Enabled = false;
                    activeButton4.Text = "Aldığı Oy: " + activeLabel1.Text;
                    activeButton3.Enabled = false;
                    activeButton3.Text = "Aldığı Oy: " + activeLabel2.Text;
                }
            }
            Label activeLabel = (Label)e.Item.FindControl("Label6");

            //  burdaki  


            Label lbl1 = (Label)e.Item.FindControl("Label3");//bitti
            Label lbl2 = (Label)e.Item.FindControl("Label8");//devam


            Button activeButton1 = (Button)e.Item.FindControl("Button3");
            Button activeButton2 = (Button)e.Item.FindControl("Button4");
            string s = activeLabel.Text;
            if (s == "1")
            {
                lbl2.Visible = true;//devam          
            }
            else
            {
                lbl1.Visible = true;//bitti
                activeButton1.Enabled = false;
                activeButton1.Text = "Aldığı Oy: " + activeLabel1.Text;
                activeButton2.Enabled = false;
                activeButton2.Text = "Aldığı Oy: " + activeLabel2.Text;

            }




            activeLabel.Visible = false;
            activeLabel2.Visible = false;
            activeLabel1.Visible = false;
        }



    }
}