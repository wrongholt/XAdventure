namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "atk", c => c.Int(nullable: false));
            AddColumn("dbo.users", "speed", c => c.Int(nullable: false));
            AddColumn("dbo.users", "def", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "def");
            DropColumn("dbo.users", "speed");
            DropColumn("dbo.users", "atk");
        }
    }
}
