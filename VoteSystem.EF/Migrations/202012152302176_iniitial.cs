namespace VoteSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Poll", "PollOwnerUserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserPolicy", "PolicyType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPolicy", "PolicyType");
            DropColumn("dbo.Poll", "PollOwnerUserId");
        }
    }
}
