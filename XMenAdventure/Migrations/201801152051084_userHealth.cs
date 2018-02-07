namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class userHealth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "health", c => c.Int(nullable: false));
            DropColumn("dbo.users", "salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.users", "salt", c => c.String());
            DropColumn("dbo.users", "health");
        }
    }
}
