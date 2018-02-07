namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class charHealth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "charHealth", c => c.Int(nullable: false));
            DropColumn("dbo.users", "health");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "health", c => c.Int(nullable: false));
            DropColumn("dbo.users", "charHealth");
        }
    }
}
