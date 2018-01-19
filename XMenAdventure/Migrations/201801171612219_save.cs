namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class save : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "savePoint", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "savePoint");
        }
    }
}
