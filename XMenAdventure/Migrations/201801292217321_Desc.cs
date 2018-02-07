namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Desc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.equipment", "slot1Desc", c => c.String());
            AddColumn("dbo.equipment", "slot2Desc", c => c.String());
            AddColumn("dbo.equipment", "slot3Desc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.equipment", "slot3Desc");
            DropColumn("dbo.equipment", "slot2Desc");
            DropColumn("dbo.equipment", "slot1Desc");
        }
    }
}
