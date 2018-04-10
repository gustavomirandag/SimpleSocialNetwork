namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionei_posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        Author_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.Profiles");
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropTable("dbo.Posts");
        }
    }
}
