using System;
using System.Configuration;
using System.Data.SqlClient;
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
        public int ctr = 2;
        public int health;
        public int enemyHealth;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblI.Text = Convert.ToInt32(ViewState["attackCount"]).ToString(); 
            enemy = (string)(Session["enemy"]);
            userEmail = Context.User.Identity.Name;
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users,characterStats WHERE users.email = @email and users.equipId = equipment.equipId and users.character = characterStats.name;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lblCharacter.Text = dr["character"].ToString();
                lblDefense.Text = dr["def"].ToString();
                lblAtk.Text = dr["atk"].ToString();
                lblSpeed.Text = dr["speed"].ToString();
                lblSpecName.Text = dr["special"].ToString();
                lblSpecial.Text = dr["specialBonus"].ToString();
                imgChar.ImageUrl = dr["picture"].ToString();
                character = dr["character"].ToString();
                health = Convert.ToInt32(dr["currentHealth"].ToString());
                bonus = Convert.ToInt32(dr["specialBonus"].ToString());
                attack = Convert.ToInt32(dr["atk"].ToString());

            }
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM characterStats WHERE   name = @name;", conn);
            cmd2.Parameters.AddWithValue("@name", enemy);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                enemyHealth = Convert.ToInt32(dr2["health"].ToString());
                imgEnemy.ImageUrl = dr2["picture"].ToString();

            }
            lblEnemy.Text = enemy;
           
                lblHealth.Text = health.ToString();

            if (enemyHealth <= 0)
            {
                btnAttack.Visible = false;
                btnRun.Visible = false;
                btnBack.Visible = true;
            }

            if (health <= 0)
            {
                SqlCommand cmdRestart = new SqlCommand();
                cmdRestart.Connection = conn;
                cmdRestart.Parameters.AddWithValue("@email", userEmail);
                cmdRestart.CommandText = "Update users Set savePoint = Null FROM users WHERE users.email = @email;";
                cmdRestart.ExecuteNonQuery();
                btnAttack.Visible = false;
                btnRun.Visible = false;
                btnRestart.Visible = true;
            }
          

        }

        protected void Run_Click(object sender, EventArgs e)
        {
            txtOther.Text = statementArrayEnd[1].ToString();
            SqlCommand cmdRestart = new SqlCommand();
            cmdRestart.Connection = conn;
            cmdRestart.Parameters.AddWithValue("@email", userEmail);
            cmdRestart.CommandText = "Update users Set savePoint = Null FROM users WHERE users.email = @email;";
            cmdRestart.ExecuteNonQuery();
            btnRestart.Visible = true;
        }
        protected void Special_Click(object sender, EventArgs e)
        {

            btnSpecial.Visible = false;
                if(character == "Rogue")
                {
                    attack += bonus;
                    txtOther.Text = "You touch the enemy stealing there powers and get a plus to your damage";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail) + "\n";

            }
            if (character == "Gambit")
                {
                    attack += bonus;
                    txtOther.Text = "What you think lets do 52 card pick up game! Get bonus to damage.";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail) + "\n";

            }
            if (character == "Colossus")
                {
                    attack += bonus;
                    txtOther.Text = "You pick up an item and throw it super fast batter up!  Bonus to damage";
                    txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n" + newCombat.enemyCombatPhase(enemy, userEmail) + "\n";

            }
            if (character == "Magik")
                {
                    txtOther.Text = "How is limbo today! Slows enemy enemy losses a turn.";
                txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n";

            }


        }
        protected void Attack_Click(object sender, EventArgs e)
        {
            

            if (Convert.ToInt32(ViewState["attackCount"]) == ctr) {
                
                    btnSpecial.Visible = true;
                ViewState["attackCount"] = 0;
            }
            else
            {
                btnSpecial.Visible = false;
                if (ViewState["attackCount"] == null)
                {
                    ViewState["attackCount"] = 1;
                }
                else
                {
                    i = Convert.ToInt32(ViewState["attackCount"]);
                    ViewState["attackCount"] = i + 1;
                }
                txtbattle.Text = newCombat.userCombatPhase(enemy, userEmail, attack) + "\n";
                txtOther.Text = newCombat.enemyCombatPhase(enemy, userEmail) + "\n";
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelOne.aspx");
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