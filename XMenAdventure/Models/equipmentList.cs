using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;

namespace XMenAdventure.Models
{
    [Table("equipmentList")]
    public class equipmentList
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string rarity { get; set; }
        public int atkBonus { get; set; }
        public int speedBonus { get; set; }
        public int defBonus { get; set; }
        public int otherBonus { get; set; }
        public string picture { get; set; }
        public string equipClass { get; set; }



        dieRoller d4 = new dieRoller();
        public string equipmentPicker()
        {

           int roll = d4.percent.Next(100);
           int roll2 = d4.d4Roll.Next(4);
            if (roll <= 5 && roll >= 95)
            {
                return rarity = "Gold";
            }
            else if (roll <= 15 || roll >= 85)
            {
                return rarity = "Purple";
            }
            else if(roll <= 30 || roll >= 70)
            {
                return rarity = "Blue";
            }
            else if(roll <= 40 || roll >= 60)
            {   
                return rarity = "Green";
            }
            else
            {
                return rarity = "Grey";
            }
            
            
        }
        public int populateArray()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT id FROM equipmentList WHERE rarity = @rarity;", conn);
            cmd.Parameters.AddWithValue("@rarity", rarity);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            var cases = new List<string>();
            while (dr.Read())
            {
               cases.Add(dr["id"].ToString());  
            }
            Random randomId = new Random();
            int i = randomId.Next(0, Convert.ToInt32(cases.Count));
            int randId = Convert.ToInt32(cases[i]);
            return randId;
        }


    }
}