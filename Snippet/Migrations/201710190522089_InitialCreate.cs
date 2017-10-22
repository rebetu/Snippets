namespace Snippet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "snippet.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "snippet.SnippetText",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("snippet.AppUser", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "snippet.SnippetLike",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsLiked = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        LikedBy_Id = c.Int(),
                        Snippet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("snippet.AppUser", t => t.LikedBy_Id)
                .ForeignKey("snippet.SnippetText", t => t.Snippet_Id)
                .Index(t => t.LikedBy_Id)
                .Index(t => t.Snippet_Id);
            
            CreateTable(
                "snippet.SnippetShare",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsShared = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        SharedBy_Id = c.Int(),
                        Snippet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("snippet.AppUser", t => t.SharedBy_Id)
                .ForeignKey("snippet.SnippetText", t => t.Snippet_Id)
                .Index(t => t.SharedBy_Id)
                .Index(t => t.Snippet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("snippet.SnippetShare", "Snippet_Id", "snippet.SnippetText");
            DropForeignKey("snippet.SnippetShare", "SharedBy_Id", "snippet.AppUser");
            DropForeignKey("snippet.SnippetLike", "Snippet_Id", "snippet.SnippetText");
            DropForeignKey("snippet.SnippetLike", "LikedBy_Id", "snippet.AppUser");
            DropForeignKey("snippet.SnippetText", "User_Id", "snippet.AppUser");
            DropIndex("snippet.SnippetShare", new[] { "Snippet_Id" });
            DropIndex("snippet.SnippetShare", new[] { "SharedBy_Id" });
            DropIndex("snippet.SnippetLike", new[] { "Snippet_Id" });
            DropIndex("snippet.SnippetLike", new[] { "LikedBy_Id" });
            DropIndex("snippet.SnippetText", new[] { "User_Id" });
            DropTable("snippet.SnippetShare");
            DropTable("snippet.SnippetLike");
            DropTable("snippet.SnippetText");
            DropTable("snippet.AppUser");
        }
    }
}
