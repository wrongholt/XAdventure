using System;
using System.Configuration;
using System.Data.SqlClient;


namespace XMenAdventure.Models
{
    public class combat
    {
        dieRoller roll = new dieRoller();
        public string character = "";
        public string userChar = "";
        public int atk;
        public int def;
        public int bonus;
        public int userHealth;
        public int newUserHealth;

        public string specialName;
        public int userAtk;
        public int enemyAtk;
        public int enemyDmg;
        public int userDmg;

        public int enemyatk;
        public int enemydef;
        public int enemyBonus;
        public int enemyHealth;
        public int newEnemyHealth;
        public int d4;
        SqlCommand cmdHealth = new SqlCommand();
        
      

        public string userCombatPhase(string enemy, string userEmail, int attack)
        {
            
            d4 = roll.d4Roll.Next(4);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM users,characterStats WHERE users.email = @email and users.character = characterStats.name;", conn);
            cmd2.Parameters.AddWithValue("@email", userEmail);
            conn.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                userChar = dr2["character"].ToString();
                def = Convert.ToInt32(dr2["def"].ToString());
                userHealth = Convert.ToInt32(dr2["currentHealth"].ToString());
                bonus = Convert.ToInt32(dr2["specialBonus"].ToString());
            }

            SqlCommand cmdEnemy = new SqlCommand("SELECT * FROM characterStats WHERE name = @name;", conn);
            cmdEnemy.Parameters.AddWithValue("@name", enemy);
            SqlDataReader drenemy = cmdEnemy.ExecuteReader();
            while (drenemy.Read())
            {
                enemyatk = Convert.ToInt32(drenemy["charAtk"].ToString());
                enemydef = Convert.ToInt32(drenemy["charDef"].ToString());
                enemyHealth = Convert.ToInt32(drenemy["health"].ToString());
            }
            newEnemyHealth = enemyHealth;

            userAtk = Convert.ToInt32(attack + d4);
            if (newEnemyHealth >= 0)
            {

                if (userAtk >= enemydef)
                {
                    userDmg = (userAtk - enemydef) + d4;
                    newEnemyHealth -= userDmg;
                    cmdHealth.Parameters.Clear();
                    cmdHealth.Connection = conn;
                    cmdHealth.CommandText = "UPDATE characterStats Set health = @newhealth FROM characterStats as cs WHERE cs.name = @name;";
                    cmdHealth.Parameters.AddWithValue("@newhealth", newEnemyHealth);
                    cmdHealth.Parameters.AddWithValue("@name", enemy);
                    cmdHealth.ExecuteNonQuery();
                    return "You hit your target and did " + userDmg + " damage to the enemy, " + enemy + " has " + newEnemyHealth + " remaining health.";

                }


                else
                {
                    return "You missed your target ";
                }
            }else
            {
                return "You defeated " + enemy + "!";
            }
            


        }
        public string enemyCombatPhase(string enemy, string userEmail)
        {
            int ctr = 3;
            int i = 0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM users,characterStats WHERE users.email = @email and users.character = characterStats.name;", conn);
            cmd2.Parameters.AddWithValue("@email", userEmail); 
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                userChar = dr2["character"].ToString();
                atk = Convert.ToInt32(dr2["atk"].ToString());
                def = Convert.ToInt32(dr2["def"].ToString());
                userHealth = Convert.ToInt32(dr2["currentHealth"].ToString());
                
            }


            d4 = roll.d4Roll.Next(4);
            SqlCommand cmdEnemy = new SqlCommand("SELECT * FROM characterStats as cs WHERE cs.name = @name;", conn);
            cmdEnemy.Parameters.AddWithValue("@name", enemy);
            SqlDataReader drenemy = cmdEnemy.ExecuteReader();
            while (drenemy.Read())
            {
                enemyatk = Convert.ToInt32(drenemy["charAtk"].ToString());
                enemydef = Convert.ToInt32(drenemy["charDef"].ToString());
                enemyHealth = Convert.ToInt32(drenemy["health"].ToString());
                enemyBonus = Convert.ToInt32(drenemy["specialBonus"].ToString());
                specialName = drenemy["special"].ToString();
            }
            if (i == ctr)
            {
                enemyAtk = Convert.ToInt32(enemyatk + d4 + bonus);
                specialName.ToString();
                i = 0;
            }
            else
            {
                enemyAtk = Convert.ToInt32(enemyatk + d4);
                i += 1;
            }
            
            newUserHealth = userHealth;
            if (newUserHealth >= 0)
            {

                if (enemyAtk >= def)
                {
                    enemyDmg = (enemyAtk - def) + d4;
                    newUserHealth -= enemyDmg;
                    cmdHealth.Parameters.Clear();
                    cmdHealth.Connection = conn;
                    cmdHealth.CommandText = "UPDATE users Set currentHealth = @newhealth FROM users WHERE email = @email;";
                    cmdHealth.Parameters.AddWithValue("@newhealth", newUserHealth);
                    cmdHealth.Parameters.AddWithValue("@email", userEmail);
                    cmdHealth.ExecuteNonQuery();
                    
                    return "You got hit for " + enemyDmg + " damage and you have " + newUserHealth + " remaining health.";

                }
                else
                {
                    return enemy + " missed you! ";
                }
            }else
            {
                return "You were defeated!";
            }
        }


    }
    
}