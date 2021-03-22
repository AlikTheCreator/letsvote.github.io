namespace VoteSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoteChoice", "Vote_Id", "dbo.Vote");
            DropIndex("dbo.VoteChoice", new[] { "Vote_Id" });
            AlterColumn("dbo.VoteChoice", "Vote_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.VoteChoice", "Vote_Id");
            AddForeignKey("dbo.VoteChoice", "Vote_Id", "dbo.Vote", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoteChoice", "Vote_Id", "dbo.Vote");
            DropIndex("dbo.VoteChoice", new[] { "Vote_Id" });
            AlterColumn("dbo.VoteChoice", "Vote_Id", c => c.Int());
            CreateIndex("dbo.VoteChoice", "Vote_Id");
            AddForeignKey("dbo.VoteChoice", "Vote_Id", "dbo.Vote", "Id");
        }
    }
}
