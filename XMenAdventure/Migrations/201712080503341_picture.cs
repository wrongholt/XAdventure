namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.characterStats", "picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.characterStats", "picture");
        }
    }
}
