namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messageStatusUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
    }
}
