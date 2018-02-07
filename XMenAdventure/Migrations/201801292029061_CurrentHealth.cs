namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentHealth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "currentHealth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "currentHealth");
        }
    }
}
