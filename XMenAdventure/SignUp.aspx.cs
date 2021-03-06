﻿using System;
using System.Data.Entity.Infrastructure;
using System.Web.Security;
using XMenAdventure.Models;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace XMenAdventure
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        user newUser = new user();
        private const int PBKDF2IterCount = 1000;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRogue_Click(object sender, ImageClickEventArgs e)
        {
            lblRogueHidden.Text = "Rogue";
        }

        protected void btnGambit_Click(object sender, ImageClickEventArgs e)
        {
            lblGambitHidden.Text = "Gambit";
        }

        protected void btnMagik_Click(object sender, ImageClickEventArgs e)
        {
            lblMagikHidden.Text = "Magik";
        }

        protected void btnColossus_Click(object sender, ImageClickEventArgs e)
        {
            lblColossusHidden.Text = "Colossus";
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            equipment equip = new equipment();

            if (lblRogueHidden.Text != "")
            {
                newUser.character = lblRogueHidden.Text;
            }
            else if (lblGambitHidden.Text != "")
            {
                newUser.character = lblGambitHidden.Text;
            }
            else if (lblMagikHidden.Text != "")
            {
                newUser.character = lblMagikHidden.Text;
            }
            else if (lblColossusHidden.Text != "")
            {
                newUser.character = lblColossusHidden.Text;
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM characterStats WHERE name = @character;", conn);
            cmd.Parameters.AddWithValue("@character", newUser.character);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newUser.charHealth = Convert.ToInt32(dr["health"].ToString());
                newUser.atk = Convert.ToInt32(dr["charAtk"].ToString());
                newUser.def = Convert.ToInt32(dr["charDef"].ToString());
                newUser.speed = Convert.ToInt32(dr["charSpeed"].ToString());
            }
                string password = txtPassword.Text;

            PasswordHasher PH = new PasswordHasher();
            string hashed = PH.CreateHash(password);

            newUser.firstName = txtFName.Text;
            newUser.lastName = txtLName.Text;
            newUser.password = hashed;
            newUser.email = txtEmail.Text;
            newUser.equipId = equip.equipId;
            Session.Add("user", newUser);
            Session.Add("equipment", equip);

            xmenContext context = new xmenContext();
            context.users.Add(newUser);
            context.equipments.Add(equip);

            try { context.SaveChanges(); } catch (DbUpdateException ex) { Console.Write(ex.Message); }
            FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
            Response.Redirect("LevelOne.aspx");
        }

        
    }
}