namespace LibraryAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auteurs", "ImageWeb", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auteurs", "ImageWeb");
        }
    }
}
