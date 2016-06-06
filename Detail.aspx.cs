using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Detail : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        // istatikler için çartların sonuçlarının toplanması.
        Chart1.DataSource = getdata1();
        Chart1.DataBind();
        Repeater1.DataSource = getdata();
        Repeater1.DataBind();
        Chart1.ChartAreas[0].AxisX.Title = "gender";
        Chart1.ChartAreas[0].AxisY.Title = "picture2";
        Chart2.DataSource = getdata2();
        Chart2.DataBind();
        Chart2.ChartAreas[0].AxisX.Title = "gender";
        Chart2.ChartAreas[0].AxisY.Title = "picture1";
        basligiAl();
        Chart3.DataSource = getdata3();
        Chart3.DataBind();
        Chart3.ChartAreas[0].AxisX.Title = "age_group";
        Chart3.ChartAreas[0].AxisY.Title = "picture1";
        Chart4.DataSource = getdata4();
        Chart3.DataBind();
        Chart4.ChartAreas[0].AxisX.Title = "age_group";
        Chart4.ChartAreas[0].AxisY.Title = "picture2";
    }

    private DataSet getdata1()//chart1-resim1
    {
        conn.Open();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = " select u.gender ,count(pic2D) as count from vote_user v ,Users u,Users_title t where v.userID=u.userID and v.picID=t.pic2D and t.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + " group by u.gender";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;

    }
    private DataSet getdata2()//chart1-resim2
    {

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = " select u.gender ,count(pic1D) as count from vote_user v ,Users u,Users_title t where v.userID=u.userID and v.picID=t.pic1D and  t.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + " group by u.gender";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;

    }

    private DataSet getdata3()//chart2-resim1
    {

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT age_group,count(*) as count FROM Users u,Users_title t,vote_user v where u.userID=v.userID and v.picID=t.pic1D and  t.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + " group by age_group";
        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;

    }
    private DataSet getdata4()//chart2-resim2
    {

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT age_group,count(*) as count FROM Users u,Users_title t,vote_user v where u.userID=v.userID and v.picID=t.pic2D and  t.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + " group by age_group";
        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;

    }

    private DataSet getdata()//başlığı al
    {
       

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select titleID ,tiStatus,title,story,deadLine,com ,v.puan as puan,v1.puan as puan1,p.pic as p3,p1.pic as p4 from Users_title u,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D and u.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + "";
        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
       
        return ds;
    }

    private void basligiAl()
    {
        SqlCommand komut = new SqlCommand(" select title,v.puan as puan, v1.puan as puan1, p.pic as p3, p1.pic as p4 from Users_title u,Picture p,Picture p1, voting v,voting v1 where p.picID=pic1D and p1.picID=pic2D and v.picID=pic1D and v1.picID=pic2D and u.titleID=" + Convert.ToInt32(Session["titleID"].ToString()) + "", conn);// verıtabanında textbox gırılen kullanıcı adına gore tarama yapıyoruzz
        SqlDataReader okuyucu = komut.ExecuteReader();// ve reader komutunu kullanarak gelen veriyi rdr adlı degıskenımıze atıyoruz
        if (okuyucu.Read())// Veritabanından gelen username ile textbox aynı mı?
        {
            lblBaslikName.Text = okuyucu["title"].ToString();
            String puan = okuyucu["puan"].ToString();
            String puan1 = okuyucu["puan1"].ToString();
            int toplamoy = Int32.Parse(puan) + Int32.Parse(puan1);
            lblToplamOy.Text = toplamoy.ToString();
        }
        okuyucu.Close();
        conn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("user.aspx");
    }

   
}