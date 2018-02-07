namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class el2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.equipmentList", "atkBonus", c => c.Int(nullable: false));
            AddColumn("dbo.equipmentList", "speedBonus", c => c.Int(nullable: false));
            AddColumn("dbo.equipmentList", "defBonus", c => c.Int(nullable: false));
            AddColumn("dbo.equipmentList", "otherBonus", c => c.Int(nullable: false));
            DropColumn("dbo.equipmentList", "bonus");
            DropColumn("dbo.equipmentList", "secondBonus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.equipmentList", "secondBonus", c => c.Int(nullable: false));
            AddColumn("dbo.equipmentList", "bonus", c => c.Int(nullable: false));
            DropColumn("dbo.equipmentList", "otherBonus");
            DropColumn("dbo.equipmentList", "defBonus");
            DropColumn("dbo.equipmentList", "speedBonus");
            DropColumn("dbo.equipmentList", "atkBonus");
        }
    }
}
