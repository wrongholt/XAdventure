using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using XMenAdventure.Models;

namespace XMenAdventure
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
        combat newCombat = new combat();
        public int bonus = 0;
        public int attack = 0;
        public int defense = 0;
        public string character = "";
        public string userEmail = "";
        public string enemy = "";
        public string[] statementArrayEnd = new string[] {"You were defeated in combat try again!","Your dead fuzzy bunny shouln't have ran!"};
        public int i = 0;
        public int ctr = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            enemy = (string)(Session["enemy"]);
            userEmail = Context.User.Identity.Name;
            txtbattle.Text = newCombat.enemyCombatPhase(enemy, userEmail);
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
                character = dr["character"].ToString();
                bonus = Convert.ToInt32(dr["specialBonus"].ToString());

            }
          

        }

        protected void Run_Click(object sender, EventArgs e)
        {
            txtOther.Text = statementArrayEnd[1].ToString() ;
        }
        protected void Special_Click(object sender, EventArgs e)
        {

            btnSpecial.Visible = false;
                if(character == "Rogue")
                {
                    attack += bonus;
                    txtOther.Text = "You touch the enemy stealing there powers and get a plus to your damage";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail);
                }
                if (character == "Gambit")
                {
                    attack += bonus;
                    txtOther.Text = "What you think lets do 52 card pick up game! Get bonus to damage.";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail);
                }
                if (character == "Colossus")
                {
                    attack += bonus;
                    txtOther.Text = "You pick up an item and throw it super fast batter up!  Bonus to damage";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail);
                }
                if (character == "Magik")
                {
                    attack += bonus;
                    txtOther.Text = "How is limbo today! Slows enemy enemy losses a turn.";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail);
                }
            

        }
        protected void Attack_Click(object sender, EventArgs e)
        {
            
            if(i == ctr) { 
                btnSpecial.Visible = true;
                i = 0;
            }else
            {
                i++;
                txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy,userEmail);
            }

        }
        protected void btnRestart_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelOne.aspx");

        }
        protected void btnRest_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelOne.aspx");

        }
    }
}