namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Sex", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "Title");
        }
    }
}
