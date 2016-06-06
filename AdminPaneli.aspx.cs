using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class admin : System.Web.UI.Page
{
   
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["adminStatus"] != null)//admin status dolu.
          {
                if (Int32.Parse(Session["adminStatus"].ToString()) != 1)// 1 değilse sayfaya gireme.
                {
                    Response.Redirect("Anasayfa.aspx");
                }
            }
            else//admin status boş.
            {
                Response.Redirect("Anasayfa.aspx");
            }
         

    }

     
    private DataSet getDataComp()// şikayetleri topla.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select * from comments c,complaints c1 , Users u where c.comID=c1.comID and c.userID =u.userID ";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }

    protected void compl_click(object sender, EventArgs e)//şikayetler menüsüne basıldığında.
    {
        lblSide.Text = "Şikayetler";
        lblSide2.Text = "Gelen şikayetleri görebilir, kullanıcıyı veya yorumu silebilirsiniz.";
        TextBox3.Visible = false;// kullşanıcı arama ile ilgili buton ve textbox gözükmesin.
        Button1.Visible = false;

        Repeater1.Visible = true; //şikayetleri göster.
        Repeater1.DataSource = getDataComp();
        Repeater1.DataBind();
        Repeater2.Visible = false;
    }

    protected void find_click(object sender, EventArgs e) //kullanıcı ara menüsüne basıldığında.
    {
        lblSide.Text = "Kullanıcı Ara";
        lblSide2.Text = "Aşağıdaki textbox'a kullanıcı nickname'i girerek kullanıcı arayabilir, ve gerekli işlemleri yapabilirsiniz.";
        Repeater1.Visible = false;
        TextBox3.Visible = true;
        Button1.Visible = true;

    }

    protected void Button1_Click(object sender, EventArgs e)//user arama butonu.
    {
        Repeater2.Visible = true;
        Repeater2.DataSource = getdata();
        Repeater2.DataBind();

    }

    private DataSet getdata() //aranan user ile ilgili bilgileri topla.
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " select * from Users where nick Like '%" + TextBox3.Text + "%'";


        SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
        da.Fill(ds);
        return ds;
    }
   

    protected void Button4_Click(object sender, EventArgs e)//yorum sil butonu.
    {
        conn.Open();
        Button btn = (Button)(sender);
        int comID = Convert.ToInt32(btn.CommandArgument);

        SqlCommand cmd1 = new SqlCommand("delete  from comments  where comID=" + comID + "", conn);

        cmd1.ExecuteNonQuery();
        Repeater1.DataSource = getDataComp();
        Repeater1.DataBind();
    }


    protected void Button3_Click(object sender, EventArgs e)// User sil butonu
    {

        conn.Open();
        Button btn = (Button)(sender);
        int userID = Convert.ToInt32(btn.CommandArgument);
        int comID = Convert.ToInt32(btn.CommandArgument);
        SqlCommand cmd = new SqlCommand("update Users set U_status=1 where userID=" + userID + "", conn);// user direkt silinmez, hesabı inaktif edilir.

        cmd.ExecuteNonQuery();

        // user silindiyse yorumu da sil.

        SqlCommand cmd1 = new SqlCommand("delete  from comments  where comID=" + comID + "", conn);

        cmd.ExecuteNonQuery();


        Repeater1.DataSource = getDataComp();
        Repeater1.DataBind();
    }

    protected void sil_Click(object sender, EventArgs e)//kullanıcı aradıktan sonra gelen sil butonu.
    {
        conn.Open();
        Button btn = (Button)(sender);
        string nick = (btn.CommandArgument);
        Response.Write(nick);
        SqlCommand cmd = new SqlCommand("update Users set U_status=1 where nick='" + nick + "'", conn);

        cmd.ExecuteNonQuery();
        Repeater2.DataSource = getdata();
        Repeater2.DataBind();
    }
    protected void mod_Click(object sender, EventArgs e)//kullanıcı aradıktan sonra gelen mod yap butonu.
    {
        conn.Open();
        Button btn = (Button)(sender);
        string nick = (btn.CommandArgument);
        SqlCommand cmd = new SqlCommand("update Users set adminStatus=2 where nick='" + nick + "'", conn);// admin status =0user =1admin =2mod

        cmd.ExecuteNonQuery();
        Repeater2.DataSource = getdata();
        Repeater2.DataBind();
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)//kullanıcı ara repeaterinde yapılabilecek işlemler.
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl = (Label)e.Item.FindControl("nick");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select DISTINCT * from Users where nick='" + lbl.Text + "' ";


            SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)// admin ve user statuslere göre sil ve mod yap butonlarını enable et veya etme.
                {
                    if (dr["adminStatus"].ToString() == "2" && dr["u_Status"].ToString() == "1")
                    {

                        Button btn1 = (Button)e.Item.FindControl("sil");
                        Button btn2 = (Button)e.Item.FindControl("mod");
                        btn1.Enabled = false;
                        btn2.Enabled = false;

                    }
                    else if (dr["adminStatus"].ToString() == "2")
                    {
                        Button btn1 = (Button)e.Item.FindControl("sil");
                        Button btn2 = (Button)e.Item.FindControl("mod");


                        btn2.Enabled = false;

                    }
                    else if (dr["u_Status"].ToString() == "1")
                    {
                        Button btn1 = (Button)e.Item.FindControl("sil");
                        Button btn2 = (Button)e.Item.FindControl("mod");

                        btn2.Enabled = false;
                        btn1.Enabled = false;
                    }
                }
            }

        }
    }   

}
