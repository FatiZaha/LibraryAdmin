namespace LibraryAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adherents", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adherents", "Image", c => c.String());
        }
    }
}
