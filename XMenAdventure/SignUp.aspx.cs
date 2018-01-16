using System;
using System.Data.Entity.Infrastructure;
using System.Web.Security;
using System.Web.UI.WebControls;
using XMenAdventure.Models;
using System.Security.Cryptography;
using Microsoft.AspNet.Cryptography.KeyDerivation;
using System.Text;
using System.Windows.Forms;
using System.Web.UI;

namespace XMenAdventure
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        user newUser = new user();
        private const int PBKDF2IterCount = 1000;
        public string hiddenName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHiddenName.Value = hiddenName;
        }
        //protected void rogue_Click(object sender, ImageClickEventArgs e)
        //{
        //    //System.Diagnostics.Debug.Write("Rogue");
        //    MessageBox.Show("Rogue");
        //    lblRogueHidden.Text = "Rogue";
        //}
        //protected void character_Click(object sender, RoutedEventArgs e)
        //{
           
        //    ImageButton btnSender = (ImageButton)sender;
        //    if (btnSender.ID == "btnRogue")
        //    {
        //        System.Diagnostics.Debug.Write("Rogue");
        //        lblRogueHidden.Text = "Rogue";
        //    }
        //     if (btnSender == btnGambit)
        //    {
        //        System.Diagnostics.Debug.Write("Gambit");
        //        lblGambitHidden.Text = "Gambit";
        //    }
        //     if (btnSender.ID == "btnMagik")
        //    {
        //        MessageBox.Show("Magik");
        //        lblMagikHidden.Text = "Magik";
        //    }
        //    if (btnSender.ID == "btnColossus")
        //    {
        //        lblColossusHidden.Text = "Colossus";
        //    }
        //}


        protected void SignUp_Click(object sender, EventArgs e)
        {
            equipment equip = new equipment();

            //if (lblRogueHidden.Text != null)
            //{
            //    newUser.character = lblRogueHidden.Text;
            //}
            // else if (lblGambitHidden.Text != null)
            //{
            //    newUser.character = lblGambitHidden.Text;
            //}
            // else if (lblMagikHidden.Text != null)
            //{
            //    newUser.character = lblMagikHidden.Text;
            //}
             if (lblHiddenName.Value != null)
            {
                newUser.character = lblHiddenName.Value.ToString();
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