using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;//md5 için gerekli.
using System.Text;//md5 için gerekli.

public partial class _Default : System.Web.UI.Page


{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nick"] != null)//giriş yapılmışsa user sayfasına git.
        {
            Response.Redirect("user.aspx");
        }

    }

   public string MD5Olustur(string input)//şifreleme için gerekli method. password'u db'ye gönderirken kullanılacak.
   {
       MD5 md5Hasher = MD5.Create();
       byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
       StringBuilder sBuilder = new StringBuilder();
       for (int i = 0; i < data.Length; i++)
       {
           sBuilder.Append(data[i].ToString("x2"));
       }
       return sBuilder.ToString();
   }


    
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True");
        String nick, pass;
        nick = txtNick.Text.ToString();
        pass = MD5Olustur(txtPass.Text.ToString());//şifreleyerek gönderiyoruz.

        conn.Open();
        SqlCommand komut = new SqlCommand("select * from Users where nick='" + nick + "' and pass='" + pass + "'", conn);// verıtabanında textbox gırılen kullanıcı adı ve şifreye gore tarama yapıyoruzz
        SqlDataReader okuyucu = komut.ExecuteReader();// ve reader komutunu kullanarak gelen veriyi rdr adlı degıskenımıze atıyoruz
        lblInfo.Visible = true;

        if (okuyucu.Read())// Veritabanından gelen username ile textbox aynı mı?
        {
            if (okuyucu["U_status"].ToString() == "1")//üye inaktif
            {
                lblInfo.Text = "Kullanıcınız silinmiş.";
                ClearTextbox();
            }
            else//üye aktif
            {
                Session["nick"] = txtNick.Text;
                Session["userID"] = okuyucu["userID"].ToString();
                Session["adminStatus"] = okuyucu["adminStatus"].ToString();//kullanacağız.
                //eğer kullanıcı adı var ve aktifse.
                lblInfo.Text = "Welcome.";//bunu user göremeyecek gerçi :)
                ClearTextbox();
                Response.Redirect("user.aspx");
            }
        }
        else // hatalı giriş.
        {
            lblInfo.Text = "Geçersiz Kullanıcı";
            ClearTextbox();
        }
        conn.Close();
        okuyucu.Close();
            

    }

    public void ClearTextbox()
    {//ekrandaki tüm textboxları temizle.
        foreach (Control t in this.Page.Form.Controls)
        {
            if (t is TextBox)
            {
                ((TextBox)t).Text = string.Empty;
            }
        }
    }
  
}