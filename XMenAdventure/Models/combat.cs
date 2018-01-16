using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;


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
        
      

        public string userCombatPhase(string enemy, string userEmail, int atk)
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
                def = Convert.ToInt32(dr2["charDef"].ToString());
                userHealth = Convert.ToInt32(dr2["health"].ToString());
                bonus = Convert.ToInt32(dr2["specialBonus"].ToString());
            }

            SqlCommand cmdEnemy = new SqlCommand("SELECT * FROM characterStats as cs WHERE cs.name = @name;", conn);
            cmdEnemy.Parameters.AddWithValue("@name", enemy);
            SqlDataReader drenemy = cmdEnemy.ExecuteReader();
            while (drenemy.Read())
            {
                enemyatk = Convert.ToInt32(drenemy["charAtk"].ToString());
                enemydef = Convert.ToInt32(drenemy["charDef"].ToString());
                enemyHealth = Convert.ToInt32(drenemy["health"].ToString());
            }
            newEnemyHealth = enemyHealth;

            userAtk = Convert.ToInt32(atk + d4);
            if (newEnemyHealth > 0)
            {

                if (userAtk >= enemydef)
                {
                    userDmg = (userAtk - enemydef) + d4;
                    newEnemyHealth -= userDmg;
                    cmdHealth.Parameters.Clear();
                    cmdHealth.Connection = conn;
                    cmdHealth.CommandText = "UPDATE characterStats Set health = @newhealth FROM characterStats as cs WHERE cs.name = @name;";
                    cmdHealth.Parameters.Add(new SqlParameter("@newhealth", SqlDbType.Int)).Value = newEnemyHealth;
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
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            int ctr = 0;
            int i = 0;
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM users,characterStats WHERE users.email = @email and users.character = characterStats.name;", conn);
            cmd2.Parameters.AddWithValue("@email", userEmail);
            conn.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                userChar = dr2["character"].ToString();
                atk = Convert.ToInt32(dr2["charAtk"].ToString());
                def = Convert.ToInt32(dr2["charDef"].ToString());
                userHealth = Convert.ToInt32(dr2["health"].ToString());
                
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
            }
            if (i == ctr)
            {
                enemyAtk = Convert.ToInt32(enemyatk + d4 + bonus);
            }
            else
            {
                enemyAtk = Convert.ToInt32(enemyatk + d4);
            }
            i++;
            newUserHealth = userHealth;
            if (newUserHealth > 0)
            {

                if (enemyAtk >= def)
                {
                    enemyDmg = (enemyAtk - def) + d4;
                    newUserHealth -= enemyDmg;
                    cmdHealth.Parameters.Clear();
                    cmdHealth.Connection = conn;
                    cmdHealth.CommandText = "UPDATE characterStats Set health = @newhealth FROM characterStats as cs WHERE cs.name = @name;";
                    cmdHealth.Parameters.AddWithValue("@newhealth", newUserHealth);//(new SqlParameter("@newhealth", SqlDbType.Int)).Value = newUserHealth;
                    cmdHealth.Parameters.AddWithValue("@name", userChar);
                    cmdHealth.ExecuteNonQuery();
                    return "You got for " + enemyDmg + " damage and you have " + newUserHealth + " remaining health.";

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