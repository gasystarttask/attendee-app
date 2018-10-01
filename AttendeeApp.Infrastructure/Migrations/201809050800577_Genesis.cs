namespace AttendeeApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genesis : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Attendee");
            AddColumn("dbo.Attendee", "AttendeeId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Attendee", "AttendeeId");
            DropColumn("dbo.Attendee", "NameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendee", "NameId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Attendee");
            DropColumn("dbo.Attendee", "AttendeeId");
            AddPrimaryKey("dbo.Attendee", "NameId");
        }
    }
}
