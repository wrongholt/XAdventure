using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using XMenAdventure.Models;

namespace XMenAdventure
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
   

       protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
       
        protected void SignIn_Click(object sender, EventArgs e)
        {
            string dbPassword = "";
            PasswordHasher PH = new PasswordHasher();
            string password = txtSignPass.Text;
            string email = txtSignEmail.Text;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE email = @email;", conn);
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                dbPassword = dr["password"].ToString();
                
            }  
                if (PH.ValidatePassword(password, dbPassword))
                {
                    FormsAuthentication.RedirectFromLoginPage(txtSignEmail.Text, RememberMe.Checked);
                    Response.Redirect("LevelOne.aspx");
                }
                else
                {
                    InvalidCredentialsMessage.Visible = true;
                }
            

        }

    }
}