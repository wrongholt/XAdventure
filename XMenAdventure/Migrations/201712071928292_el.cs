namespace XMenAdventure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class el : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.equipmentList", "equipClass", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.equipmentList", "equipClass");
        }
    }
}
