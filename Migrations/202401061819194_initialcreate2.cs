namespace LibraryAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Emprunts", "Date_empr");
            DropColumn("dbo.Emprunts", "Date_retour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emprunts", "Date_retour", c => c.DateTime(nullable: false));
            AddColumn("dbo.Emprunts", "Date_empr", c => c.DateTime(nullable: false));
        }
    }
}
