namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equip2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.equipment", "equipClass1", c => c.String());
            AddColumn("dbo.equipment", "equipClass2", c => c.String());
            AddColumn("dbo.equipment", "equipClass3", c => c.String());
            DropColumn("dbo.equipment", "equipClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.equipment", "equipClass", c => c.String());
            DropColumn("dbo.equipment", "equipClass3");
            DropColumn("dbo.equipment", "equipClass2");
            DropColumn("dbo.equipment", "equipClass1");
        }
    }
}
