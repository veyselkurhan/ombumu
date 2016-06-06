using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class YeniBaslik : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");//db
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_click(object sender, EventArgs e)//resim ekle butonu.
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(MapPath("image/") + FileUpload1.FileName);
            Image1.ImageUrl = "image/" + FileUpload1.FileName;

        }
    }

    protected void btn1_click(object sender, EventArgs e)//2.resim ekle butonu.
    {
        if (FileUpload2.HasFile)
        {
            FileUpload2.SaveAs(MapPath("image/") + FileUpload2.FileName);

            Image2.ImageUrl = "image/" + FileUpload2.FileName;
        }
    }

    protected void anasayfayaGit(object sender, EventArgs e)
    {
        Response.Redirect("Anasayfa.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)//başlık aç butonu.
    {
        try
        {
            int val1 = 0;//resim 1 idsi.
            int val2 = 0;//resim 2 idsi.
            SqlDataAdapter da;
            DataTable dt;
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Picture(pic) values (@pic)", conn);
            cmd.Parameters.AddWithValue("@pic", Image1.ImageUrl);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "Select picID From Picture where pic='" + Image1.ImageUrl + "' ";
            da = new SqlDataAdapter(cmd.CommandText, conn);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                val1 = Convert.ToInt32(dr["picID"].ToString());

            }
            Image1.ImageUrl = "";
            if (Image1.ImageUrl == "" && Image2.ImageUrl != "")
            {
                cmd = new SqlCommand("INSERT INTO Picture(pic) values (@pic)", conn);
                cmd.Parameters.AddWithValue("@pic", Image2.ImageUrl);

                cmd.ExecuteNonQuery();
                cmd.CommandText = "Select picID From Picture where pic='" + Image2.ImageUrl + "' ";
                da = new SqlDataAdapter(cmd.CommandText, conn);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    val2 = Convert.ToInt32(dr["picID"].ToString());

                }
                Image2.ImageUrl = "";
            }
            char a = '0';
            if (CheckBox1.Checked) a = '1';
            cmd = new SqlCommand("INSERT INTO Users_title(userID,title,story,pic1D,pic2D,deadLine,com,tiStatus) values (@user,@title,@story,@p1,@p2,@deadline,@c,@t)", conn);
            cmd.Parameters.AddWithValue("@user", Convert.ToInt32(Session["userID"].ToString()));
            cmd.Parameters.AddWithValue("@title", txtVs1.Text + " VS " + txtVs2.Text);
            cmd.Parameters.AddWithValue("@story", story.Text);
            cmd.Parameters.AddWithValue("@p1", val1);
            cmd.Parameters.AddWithValue("@p2", val2);
            cmd.Parameters.AddWithValue("@deadline", TextBox3.Text);
            cmd.Parameters.AddWithValue("@c", a);
            cmd.Parameters.AddWithValue("@t", 1);
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            cmd = new SqlCommand("INSERT INTO voting(picID) values (@pic)", conn);
            cmd.Parameters.AddWithValue("@pic", val1);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("INSERT INTO voting(picID) values (@pic)", conn);
            cmd.Parameters.AddWithValue("@pic", val2);
            cmd.ExecuteNonQuery();
            conn.Close();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Kayıt başarılı", "<script>alert('Başlık açıldı.');</script>");

        }
        catch (Exception hata)
        {
            lblInfo.Visible = true;
            lblInfo.Text = hata.ToString();
        }
       

    }

      
   
}