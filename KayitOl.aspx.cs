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

public partial class KayitOl : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection("Data Source=PRO2000-PRO2000\\SQLEXPRESS; Initial Catalog=navy; Integrated Security=True; MultipleActiveResultSets=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nick"] != null)
        {
            Response.Redirect("user.aspx");
        }

    }

    public string MD5Olustur(string input)//şifreleme
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

    protected void btnRegister_Click(object sender, EventArgs e)//kayıt ol butonu
    {

        if (txtNick.Text == "" || txtMail.Text == "" || RadioButtonList1.Text == "" || txtYas.Text == "" || txtPass.Text == "" || txtRePass.Text == "")
        {//boş bırakılan alan olmayacak
            lblInfo.Text = "Lütfen tüm alanları doldurunuz.";
            lblInfo.Visible = true;
            ClearTextbox();
        }else{//boş alan yok
         conn.Open();
        SqlCommand komut = new SqlCommand("select * from Users where nick='" + txtNick.Text + "'", conn);// verıtabanında textbox gırılen kullanıcı adına gore tarama yapıyoruzz
        SqlDataReader okuyucu = komut.ExecuteReader();// ve reader komutunu kullanarak gelen veriyi rdr adlı degıskenımıze atıyoruz
        lblInfo.Visible = true;

        if (okuyucu.Read())// Veritabanından gelen username ile textbox aynı mı?
        {
            lblInfo.Text = "Başka bir kullanıcı adı seçin.";
            conn.Close();
            okuyucu.Close();
        }
        else {  //artık kaydı yapabiliriz. 
      
        string group = "";
        if (Convert.ToInt32(txtYas.Text) < 18) group = "under18";
        else if (Convert.ToInt32(txtYas.Text) <= 40 ) group = "18-40";
        else group = "40 yaş üzeri";

        string a;//cinsiyet.
        Response.Write(RadioButtonList1.Text);
        if (RadioButtonList1.Text == "0") a = "female";
        else a = "male";

        if (txtPass.Text == txtRePass.Text)
        {
            try
            {
                String pass = MD5Olustur(txtPass.Text.ToString());//şifreleyerek gönderiyoruz.
                SqlCommand cmd = new SqlCommand("INSERT INTO Users(nick,gender,mail,age,pass,age_group) values (@nick,@gender,@mail,@age,@pass,@group)", conn);
                cmd.Parameters.AddWithValue("@nick", txtNick.Text);
                cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                cmd.Parameters.AddWithValue("@gender", a);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtYas.Text));
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@group", group);
                cmd.ExecuteNonQuery();
                conn.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Kayıt başarılı", "<script>alert('Üyeliğiniz tamamlandı, siteye giriş yapabilirsiniz.');</script>");
                ClearTextbox();
                RadioButtonList1.ClearSelection();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.ToString();
            }

        }
            }
        }
    }

}