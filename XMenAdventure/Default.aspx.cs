using Microsoft.AspNet.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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