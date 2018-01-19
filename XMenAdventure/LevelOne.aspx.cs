using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using XMenAdventure.Models;
using System.Windows.Forms;
using System.Web.Security;
using System.Collections.Generic;

namespace XMenAdventure
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        combat newCombat = new combat();
        public string equipment = "";
        public string picture = "";
        public string enemy = "";
        public string save = "";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());

        Dictionary<string, string> pictures = new Dictionary<string, string>();
       

        public string[] statementArray1 = new string[] { "You get startled awake by unknown reasons.  You look around ruble is around you as you lay on your bed, you sit up and rub your eyes.  This must be a dream?!?  What do you do? Look for your equipment and cloths or start walking around?",
        "You see your chest of drawers next to your bed you get dressed and see one piece of equipment.",
            "You get dressed and equip any equipment.  As you look around further you notice something that looks like a person near the woods. Do you go investigate the figure or look around in the rubble",
            "As you start to go toward the figure you see it's Pyro and starts to attack you.  Please click on the Start Combat button","You have defeat Pyro!  If you are wounded please click on the rest button, otherwise option 1 search for Pyro or option 2 search rubble of the mansion." };

        public string[] statementArray2 = new string[] { "You start walking around and you don’t see anyone else in the area you start to get cold since you are in your skivvies.  Do you go get dressed or continue looking?", "You get dressed and equip any equipment.  As you look around further you notice something that looks like a person near the woods. Do you go investigate or look around in the rubble",
            "You walk around more as you walk around your leg gets caught in in some rubble and before you can activate your powers your leg breaks and fall and knock yourself out!  You are now lunch for the wolves. GAME OVER!" };
        public string[] statementArrayEnd = new string[] {"You walk around more as you walk around your leg gets caught in in some rubble and before you can activate your powers your leg breaks and fall and knock yourself out!  You are now lunch for the wolves. GAME OVER!",
        "You were defeated in combat try again!"};

       

        protected void Page_Load(object sender, EventArgs e)
        {
            pictures.Add("Pyro", "images/pyro.jpg");
            pictures.Add("Professor", "images/professor_x.jpg");
            pictures.Add("Mystique", "images/mystique.jpg");
            pictures.Add("Quicksilver", "images/mystique.jpg");
            pictures.Add("Polaris", "images/polaris.jpg");
            pictures.Add("Man Thing", "images/man_thing.jpg");
            pictures.Add("Morph", "images/morph.jpg");
            pictures.Add("Magneto", "images/magneto.jpg");

            string userEmail = Context.User.Identity.Name;
        SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users,characterStats WHERE users.email = @email and users.equipId = equipment.equipId and users.character = characterStats.name;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lblCharacter.Text = dr["character"].ToString();
                lblDefense.Text = dr["charDef"].ToString();
                lblAtk.Text = dr["charAtk"].ToString();
                lblSpeed.Text = dr["charSpeed"].ToString();
                lblSpecName.Text = dr["special"].ToString();
                lblSpecial.Text = dr["specialBonus"].ToString();
                imgChar.ImageUrl = dr["picture"].ToString();
                save = dr["savePoint"].ToString();
            }

            if(Session[save] != null)
            {
                btnOption1.Visible = false;
                btnOption2.Visible = false;
                btnOption111.Visible = true;
                btnOption112.Visible = true;
                txtBegin.Visible = false;
                txt1.Visible = true;
                txt1.Text = statementArray1[2].ToString();

            }
            if (Session[save] != null)
            {
               
                btnOption111.Visible = true;
                btnOption112.Visible = true;
                txt1.Text = statementArray1[4].ToString();

            }

            if (Request.IsAuthenticated)
            {
                if (save == "beforeAttack")
                {
                    btnOption1.Visible = false;
                    btnOption2.Visible = false;
                    btnOption111.Visible = true;
                    btnOption112.Visible = true;
                    txtBegin.Visible = false;
                    txt1.Visible = true;
                    txt1.Text = statementArray1[2].ToString();

                }
                if (save == "afterAttack")
                {

                    btnOption111.Visible = true;
                    btnOption112.Visible = true;
                    txt1.Text = statementArray1[4].ToString();

                }else
                {
                    beginning();
                }
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        public void beginning()
        {

            txtBegin.Text = statementArray1[0].ToString();

        }


        public void EquipmentReward()
        {
            equipment equip = new equipment();
            equipmentList el = new equipmentList();
            el.equipmentPicker();
            int idInt = el.populateArray();


            SqlCommand cmd = new SqlCommand("SELECT * FROM equipmentList WHERE id = @id;", conn);
            cmd.Parameters.AddWithValue("@id", idInt);
           
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {


                equipment = dr["name"].ToString() + " " + dr["desciption"].ToString() + ". Please Click on the Picture to add to your equipment.";
                picture = dr["picture"].ToString();
            }


        }
        protected void imgEquip_Click(object sender, EventArgs e)
        {
            string slot1 = "";
            string slot2 = "";
            string slot3 = "";
            string class1 = "";
            string class2 = "";
            string class3 = "";
            string equipClass = "";
            string userEmail = Context.User.Identity.Name;
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @userEmail;", conn);
            cmd.Parameters.AddWithValue("@userEmail", userEmail);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                slot1 = dr["equipSlot1"].ToString();
                slot2 = dr["equipSlot2"].ToString();
                slot3 = dr["equipSlot3"].ToString();
                class1 = dr["equipClass1"].ToString();
                class2 = dr["equipClass2"].ToString();
                class3 = dr["equipClass3"].ToString();
                
                ImageButton btnSender = (ImageButton)sender;
                string picture = btnSender.ImageUrl;
                SqlCommand cmdClass = new SqlCommand("SELECT equipClass FROM equipmentList WHERE picture = @picture;", conn);
                cmdClass.Parameters.AddWithValue("@picture", picture);
                SqlDataReader dr2 = cmdClass.ExecuteReader();
                while (dr2.Read())
                {
                    equipClass = dr2["equipClass"].ToString();

                    if (slot1 == "")
                    {
                        slot1 = picture;
                        class1 = equipClass;
                    }
                    else if (slot2 == "")
                    {
                        slot2 = picture;
                        class2 = equipClass;
                    }
                    else if (slot3 == "")
                    {
                        slot3 = picture;
                        class3 = equipClass;
                    }
                    else
                    {
                        MessageBox.Show("Your Equipment is full please remove some equipment.");
                    }
                    

                    SqlCommand cmd2 = new SqlCommand("UPDATE equipment Set equipslot1 = @slot1, equipslot2 = @slot2, equipslot3 = @slot3, equipClass1 = @class1, equipClass2 = @class2, equipClass3 = @class3 FROM users INNER JOIN equipment ON (equipment.equipId = users.equipId) WHERE users.email = @userEmail;", conn);

                    cmd2.Parameters.AddWithValue("@slot1", slot1);
                    cmd2.Parameters.AddWithValue("@slot2", slot2);
                    cmd2.Parameters.AddWithValue("@slot3", slot3);
                    cmd2.Parameters.AddWithValue("@class1", class1);
                    cmd2.Parameters.AddWithValue("@class2", class2);
                    cmd2.Parameters.AddWithValue("@class3", class3);
                    cmd2.Parameters.AddWithValue("@userEmail", userEmail);
                    cmd2.ExecuteNonQuery();
                    
                    FormsAuthentication.RedirectFromLoginPage(userEmail, true);
                    Response.Redirect("CharEquipment.aspx");
                }
            }
            conn.Close();
        }
        //Path One
        protected void btnOption1_Click(object sender, EventArgs e)
        {
            save = "beforeAttack";
            btnSave_Click(sender, e);
            Session.Add(save, txt1.Text);
            txt1.Visible = true;
            txt2.Visible = true;
            txtEquip1.Visible = true;
            imgEquip.Visible = true;
            txt1.Text = statementArray1[1].ToString();
            EquipmentReward();
            txtEquip1.Text = equipment.ToString(); 
            imgEquip.ImageUrl = picture.ToString();
            
        }

        protected void btnOption111_Click(object sender, EventArgs e)
        {

            string userEmail = Context.User.Identity.Name;
            txt1.Text = statementArray1[3].ToString();
            txt2.Visible = false;
            imgEnemy1.ImageUrl = pictures["Pyro"];
            Session["enemy"] = "Pyro";
            btnOption111.Visible = false;
            btnOption112.Visible = false;
            imgEnemy1.Visible = true;
            btnCombat.Visible = true;
            

        }
        protected void btnOption112_Click(object sender, EventArgs e)
        {
            txt2.Text = statementArray2[4].ToString();
            btnOption111.Visible = false;
            btnOption112.Visible = false;
        }






        //Path Two
        protected void btnOption2_Click(object sender, EventArgs e)
        {
            txt1.Visible = true;
            btnOption221.Visible = true;
            btnOption22End.Visible = true;
            txt1.Text = statementArray2[0].ToString();
        }
        protected void btnOption221_Click(object sender, EventArgs e)
        {
            txt1.Text = statementArray2[1].ToString();
        }
        protected void btnOption22End_Click(object sender, EventArgs e)
        {
            txt2.Text = statementArrayEnd[0].ToString();
            btnRestart.Visible = true;

        }



        protected void btnCombat_Click(object sender, EventArgs e)
        {
            save = "afterAttack";
            btnSave_Click(sender, e);
            Session.Add(save, txt1.Text);
            Response.Redirect("combat.aspx");

        }
        protected void btnRestart_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelOne.aspx");

        }
        protected void btnRest_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelOne.aspx");

        }

        protected void btnEquipment_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharEquipment.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string userEmail = Context.User.Identity.Name;
            SqlCommand cmdSave = new SqlCommand("UPDATE users Set savePoint = @save FROM users WHERE users.email = @userEmail;", conn);
            cmdSave.Parameters.AddWithValue("@save", save);
            cmdSave.Parameters.AddWithValue("@userEmail", userEmail);
            cmdSave.ExecuteNonQuery();
        }
    }
}