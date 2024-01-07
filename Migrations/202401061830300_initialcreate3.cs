namespace LibraryAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emprunts", "Date_empr", c => c.DateTime(nullable: false));
            AddColumn("dbo.Emprunts", "Date_retour", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emprunts", "Date_retour");
            DropColumn("dbo.Emprunts", "Date_empr");
        }
    }
}
