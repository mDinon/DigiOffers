namespace DigiOffers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Logs", newName: "Log");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Log", newName: "Logs");
        }
    }
}
