using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Anasayfa : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");//database bağlantısı

    protected void Page_Load(object sender, EventArgs e)
    {
       //kullanıcı giriş yapmışsa user sayfasına yönlendir, yoksa devam et.
        if (Session["nick"] == null)
        {
            Repeater1.DataSource = getdata();
            Repeater1.DataBind();
            conn.Close();
        }
        else
        {
            conn.Open();
            Update();
            conn.Close();
            Response.Redirect("user.aspx");
        }        
    }


  
       

    private DataSet getdata() //başlıkları topla.
    {
        conn.Open();
        DataSet ds =new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select titleID ,tiStatus,title,story,deadLine,com ,v.puan as puan,v1.puan as puan1,p.pic as p3,p1.pic as p4 from Users_title,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D order by titleID desc";
    
        
        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

    private void Update()// eğer başlığın deadlineı şu anki tarihi geçtiyse, başlık durumunu sıfıra getir. (oylamayı sonlandır)
    {
        string now = DateTime.Now.ToString("yyyy-MM-dd");
        SqlCommand cmd = new SqlCommand("update Users_title set tiStatus=0 where deadLine<'" + now + "'", conn);
        cmd.ExecuteNonQuery();
    }

    
    protected void link_Click(object sender, EventArgs e)
    {
        // yorumlar sayfasına git.
        LinkButton btn = (LinkButton)(sender);
        Session["titleID"] = btn.CommandArgument;
        Response.Redirect("comment.aspx");
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            Label title = (Label)e.Item.FindControl("label3"); //titleID'nin tutulduğu label.

            //başlık hakkındaki yorum istenme durumunu al.
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
                    // show comments devamı
                    if (dr["com"].ToString() == "0") // eğer 0 ise, yorum istenmiyor.
                    {
                        lbl.Text = "Yorum istenmiyor.";
                        lbl.Enabled = false;
                    }

                }
            }

            Label activeLabel = (Label)e.Item.FindControl("Label6");//tistatus (=1 başlık aktif, =0 başlık inaktif.)
            Label activeLabel2 = (Label)e.Item.FindControl("Label5");//oylama sonuçlarının yazdığı label.
            Label activeLabel3 = (Label)e.Item.FindControl("Label7");//oylama bitti yazan label.

            Update();//deadline ve şu anki tarihi karşılaştıran method.

            Label activeLabel4 = (Label)e.Item.FindControl("Label8"); // oylama devam ediyor yazan label.

            string s = activeLabel.Text;//tistatus
            if (s == "0")//başlık inaktif.
            {
                activeLabel3.Visible = true;//oylama bitti yaz.
                activeLabel.Visible = false;
                activeLabel2.Visible = true;//sonuçları göster.
                activeLabel4.Visible = false;
            }
            else//başlık aktif.
            {
                activeLabel4.Visible = true;//oylama devam ediyor yaz.
                activeLabel3.Visible = false;
                activeLabel.Visible = false;
                activeLabel2.Visible = false;
            }
        }

    }  

}