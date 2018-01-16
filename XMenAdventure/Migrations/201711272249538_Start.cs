namespace XMenAdventure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
       
            CreateTable(
                "dbo.equipment",
                c => new
                    {
                        equipId = c.Int(nullable: false, identity: true),
                        head = c.String(),
                        headId = c.Int(),
                        belt = c.String(),
                        beltId = c.Int(),
                        boots = c.String(),
                        bootsId = c.Int(),
                        equipSlot1 = c.String(),
                        equipSlot1Id = c.Int(),
                        equipSlot2 = c.String(),
                        equipSlot2Id = c.Int(),
                        equipSlot3 = c.String(),
                        equipSlot3Id = c.Int(),
                    })
                .PrimaryKey(t => t.equipId);
            
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        firstName = c.String(),
                        email = c.String(),
                        password = c.String(),
                        character = c.String(),
                        equipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.equipment", t => t.equipId, cascadeDelete: true)
                .Index(t => t.equipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "equipId", "dbo.equipment");
            DropIndex("dbo.users", new[] { "equipId" });
            DropTable("dbo.users");
            DropTable("dbo.equipment");
 
        }
    }
}
