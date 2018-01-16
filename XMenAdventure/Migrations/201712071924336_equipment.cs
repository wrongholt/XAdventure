namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.equipment", "equipClass", c => c.String());
            DropColumn("dbo.equipment", "equipSlot1Id");
            DropColumn("dbo.equipment", "equipSlot2Id");
            DropColumn("dbo.equipment", "equipSlot3Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.equipment", "equipSlot3Id", c => c.Int());
            AddColumn("dbo.equipment", "equipSlot2Id", c => c.Int());
            AddColumn("dbo.equipment", "equipSlot1Id", c => c.Int());
            DropColumn("dbo.equipment", "equipClass");
        }
    }
}
