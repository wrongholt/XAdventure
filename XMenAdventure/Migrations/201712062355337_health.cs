namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class health : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.characterStats", "health", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.characterStats", "health");
        }
    }
}
