using System;
using System.Configuration;
using System.Data.SqlClient;

namespace XMenAdventure
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string slot1 = "";
        public string slot2 = "";
        public string slot3 = "";
        public string pieceEquip = "";
        public string equipClass = "";
        public int headAtkbonus = 0;
        public int headDefbonus = 0;
        public int headSpeedbonus = 0;
        public int beltAtkbonus = 0;
        public int beltDefbonus = 0;
        public int beltSpeedbonus = 0;
        public int bootsAtkbonus = 0;
        public int bootsDefbonus = 0;
        public int bootsSpeedbonus = 0;
        public int atk = 0;
        public int def = 0;
        public int speed = 0;
        public int newSpeed ;
        public int newDef;
        public int newAtk;
        public string userEmail = "";
        public string description = "";

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmenContext"].ToString());


        protected void Page_Load(object sender, EventArgs e)
        {

            

           userEmail = Context.User.Identity.Name;
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users,characterStats,equipmentList WHERE users.email = @email and users.equipId = equipment.equipId and users.character = characterStats.name;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lblCharacter.Text = dr["character"].ToString();
                def = Convert.ToInt32(dr["charDef"].ToString());
                atk = Convert.ToInt32(dr["charAtk"].ToString());
                speed = Convert.ToInt32(dr["charSpeed"].ToString());
                lblSpecName.Text = dr["special"].ToString();
                lblSpecial.Text = dr["specialBonus"].ToString();
                imgSlot1.ImageUrl = dr["equipSlot1"].ToString();
                imgSlot1.AlternateText = dr["slot1Desc"].ToString();
                imgSlot2.ImageUrl = dr["equipSlot2"].ToString();
                imgSlot2.AlternateText = dr["slot2Desc"].ToString();
                imgSlot3.ImageUrl = dr["equipSlot3"].ToString();
                imgSlot3.AlternateText = dr["slot3Desc"].ToString();
                imgSlot1.CssClass = dr["equipClass1"].ToString();
                imgSlot2.CssClass = dr["equipClass2"].ToString();
                imgSlot3.CssClass = dr["equipClass3"].ToString();
                top.ImageUrl = dr["head"].ToString();
                bottom.ImageUrl = dr["boots"].ToString();
                middle.ImageUrl = dr["belt"].ToString();
            }
            

            SqlCommand cmd2 = new SqlCommand("SELECT equipmentList.name, equipmentList.desciption, equipmentList.atkBonus, equipmentList.speedBonus,equipmentList.defBonus FROM equipment,users,characterStats,equipmentList WHERE users.email = @email and users.equipId = equipment.equipId and characterStats.name = users.character and equipmentList.picture = equipment.head;", conn);
            cmd2.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                lblHeadName.Text = dr2["name"].ToString();
                lblHeadDesc.Text = dr2["desciption"].ToString();
                headAtkbonus = Convert.ToInt32(dr2["atkBonus"].ToString());
                headDefbonus = Convert.ToInt32(dr2["defBonus"].ToString());
                headSpeedbonus = Convert.ToInt32(dr2["speedBonus"].ToString());
            }
            SqlCommand cmd3 = new SqlCommand("SELECT equipmentList.name, equipmentList.desciption, equipmentList.atkBonus, equipmentList.speedBonus,equipmentList.defBonus FROM equipment,users,characterStats,equipmentList WHERE users.email = @email and users.equipId = equipment.equipId and characterStats.name = users.character and equipmentList.picture = equipment.belt;", conn);
            cmd3.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                lblBeltName.Text = dr3["name"].ToString();
                lblBeltDesc.Text = dr3["desciption"].ToString();
                beltAtkbonus = Convert.ToInt32(dr3["atkBonus"].ToString());
                beltDefbonus = Convert.ToInt32(dr3["defBonus"].ToString());
                beltSpeedbonus = Convert.ToInt32(dr3["speedBonus"].ToString());
            }
            SqlCommand cmd4 = new SqlCommand("SELECT equipmentList.name, equipmentList.desciption, equipmentList.atkBonus, equipmentList.speedBonus,equipmentList.defBonus FROM equipment,users,characterStats,equipmentList WHERE users.email = @email and users.equipId = equipment.equipId and characterStats.name = users.character and equipmentList.picture = equipment.boots;", conn);
            cmd4.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr4 = cmd4.ExecuteReader();

            while (dr4.Read())
            {
                lblFeetName.Text = dr4["name"].ToString();
                lblFeetDesc.Text = dr4["desciption"].ToString();
                bootsAtkbonus = Convert.ToInt32(dr4["atkBonus"].ToString());
                bootsDefbonus = Convert.ToInt32(dr4["defBonus"].ToString());
                bootsSpeedbonus = Convert.ToInt32(dr4["speedBonus"].ToString());
            }
            if (bootsAtkbonus > 0 || beltAtkbonus > 0 || headAtkbonus > 0)
            {
                newAtk = (atk + bootsAtkbonus + beltAtkbonus + headAtkbonus) ;
            }
            else
            {
                newAtk = (atk);
            }
            if (bootsDefbonus > 0 || beltDefbonus > 0 || headDefbonus > 0)
            {
                newDef = (def + bootsDefbonus + beltDefbonus + headDefbonus);
            }else
            {
                newDef = (def);
            }
            if (bootsSpeedbonus > 0 || beltSpeedbonus > 0 || headSpeedbonus > 0)
            {
                newSpeed = (speed + bootsSpeedbonus + beltSpeedbonus + headSpeedbonus);
            }
            else
            {
                newSpeed = (speed);
            }
            //slot 1
      
            if (imgSlot1.CssClass == "hat")
            {
                btnEquip1.Text = "Equip";
                btnEquip1.Visible = true;
                btnRemove1.Visible = true;

            }
            else if (imgSlot1.CssClass == "belt")
            {
                btnEquip1.Text = "Equip";
                btnEquip1.Visible = true;
                btnRemove1.Visible = true;

            }
            else if (imgSlot1.CssClass == "boots")
            {
                btnEquip1.Text = "Equip";
                btnEquip1.Visible = true;
                btnRemove1.Visible = true;

            }
            //slot 2

            if (imgSlot2.CssClass == "hat")
            {
                btnEquip2.Text = "Equip";
                btnEquip2.Visible = true;
                btnRemove2.Visible = true;

            }
            else if (imgSlot2.CssClass == "belt")
            {
                btnEquip2.Text = "Equip";
                btnEquip2.Visible = true;
                btnRemove2.Visible = true;

            }
            else if (imgSlot2.CssClass == "boots")
            {
                btnEquip2.Text = "Equip";
                btnEquip2.Visible = true;
                btnRemove2.Visible = true;

            }
            //slot 3

            if (imgSlot3.CssClass == "hat")
            {
                btnEquip3.Text = "Equip";
                btnEquip3.Visible = true;
                btnRemove3.Visible = true;

            }
            else if (imgSlot3.CssClass == "belt")
            {
                btnEquip3.Text = "Equip";
                btnEquip3.Visible = true;
                btnRemove3.Visible = true;

            }
            else if (imgSlot3.CssClass == "boots")
            {
                btnEquip3.Text = "Equip";
                btnEquip3.Visible = true;
                btnRemove3.Visible = true;

            }

            update();
            lblAtk.Text = newAtk.ToString();
            lblDefense.Text = newDef.ToString();
            lblSpeed.Text = newSpeed.ToString();

        }
        
      
        protected void btnEquip_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users WHERE users.email = @email and users.equipId = equipment.equipId;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                equipClass = imgSlot1.CssClass;
                pieceEquip = dr["equipSlot1"].ToString();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.Parameters.AddWithValue("@slot1", equipClass);
                cmd2.Parameters.AddWithValue("@email", userEmail);
                cmd2.CommandText = "IF @slot1 = 'hat' UPDATE equipment Set head = equipSlot1 FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email IF @slot1 = 'belt' UPDATE equipment Set belt = equipSlot1 FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) INNER JOIN characterStats ON (users.character = characterStats.name) WHERE users.email = @email IF @slot1 = 'boots' UPDATE equipment Set boots = equipSlot1 FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email;";
                    cmd2.ExecuteNonQuery();
                
            }
            update();
            Unequip1();
        }
        protected void Unequip1()
        {

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.Parameters.AddWithValue("@email", userEmail);
            cmd3.CommandText = "Update equipment Set equipSlot1 = Null, equipClass1 = Null, slot1Desc = Null FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId)WHERE users.email = @email;";
            cmd3.ExecuteNonQuery();
            btnEquip1.Visible = false;
            btnRemove1.Visible = false;
            Response.Redirect(Request.RawUrl);
        }
        protected void btnEquip2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users WHERE users.email = @email and users.equipId = equipment.equipId;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                equipClass = dr["equipClass2"].ToString();


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.Parameters.AddWithValue("@slot1", equipClass);
                cmd2.CommandText = "IF @slot1 = 'hat' UPDATE equipment Set head = equipSlot2 FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email IF @slot1 = 'belt' UPDATE equipment Set belt = equipSlot2, equipSlot2 = NULL FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email IF @slot1 = 'boots' UPDATE equipment Set boots = equipSlot2, equipSlot2 = NULL FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email;";
                cmd2.Parameters.AddWithValue("@email", userEmail);
                    cmd2.ExecuteNonQuery();
            }
            update();
            Unequip2();
        }
        protected void Unequip2()
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.Parameters.AddWithValue("@email", userEmail);
            cmd3.CommandText = "Update equipment Set equipSlot2 = Null, equipClass2 = Null, slot2Desc = Null FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId)WHERE users.email = @email;";
            cmd3.ExecuteNonQuery();
            btnEquip2.Visible = false;
            btnRemove2.Visible = false;
            Response.Redirect(Request.RawUrl);
        }
        protected void btnEquip3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM equipment,users WHERE users.email = @email and users.equipId = equipment.equipId;", conn);
            cmd.Parameters.AddWithValue("@email", userEmail);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                equipClass = dr["equipClass3"].ToString();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.Parameters.AddWithValue("@slot1", equipClass);
                cmd2.CommandText = "IF @slot1 = 'hat' UPDATE equipment Set head = equipSlot3 FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email IF @slot1 = 'belt' UPDATE equipment Set belt = equipSlot3, equipSlot3 = NULL FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email IF @slot1 = 'boots' UPDATE equipment Set boots = equipSlot3, equipSlot3 = NULL FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId) WHERE users.email = @email;";
                cmd2.Parameters.AddWithValue("@email", userEmail);
                    cmd2.ExecuteNonQuery();

            }
            update();
            Unequip3();
        }
        protected void Unequip3()
        {

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.Parameters.AddWithValue("@email", userEmail);
            cmd3.CommandText = "Update equipment Set equipSlot3 = Null, equipClass3 = Null, slot3Desc = Null FROM equipment INNER JOIN users ON (equipment.equipId = users.equipId)WHERE users.email = @email;";
            cmd3.ExecuteNonQuery();
            btnEquip3.Visible = false;
            btnRemove3.Visible = false;
            Response.Redirect(Request.RawUrl);
        }
        protected void update()
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn;
            cmd3.Parameters.AddWithValue("@email", userEmail);
            cmd3.Parameters.AddWithValue("@atk", newAtk);
            cmd3.Parameters.AddWithValue("@speed", newSpeed);
            cmd3.Parameters.AddWithValue("@def", newDef);
            cmd3.CommandText = "Update users Set atk = @atk, speed = @speed, def = @def FROM users WHERE users.email = @email;";
            cmd3.ExecuteNonQuery();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
                Response.Redirect("LevelOne.aspx");
        }

        protected void btnRemove1_Click(object sender, EventArgs e)
        {
            Unequip1();
        }

        protected void btnRemove2_Click(object sender, EventArgs e)
        {
            Unequip2();
        }

        protected void btnRemove3_Click(object sender, EventArgs e)
        {
            Unequip3();
        }
    }
}