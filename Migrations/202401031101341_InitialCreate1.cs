namespace LibraryAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "Admins");
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Image = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Emprunts", "EtatRetour", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "Nom");
            DropColumn("dbo.Admins", "Prenom");
            DropColumn("dbo.Admins", "Adresse");
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "Phone");
            DropColumn("dbo.Admins", "Image");
            DropColumn("dbo.Admins", "DateNaissance");
            DropColumn("dbo.Admins", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Admins", "DateNaissance", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "Image", c => c.String());
            AddColumn("dbo.Admins", "Phone", c => c.String());
            AddColumn("dbo.Admins", "Email", c => c.String());
            AddColumn("dbo.Admins", "Adresse", c => c.String());
            AddColumn("dbo.Admins", "Prenom", c => c.String());
            AddColumn("dbo.Admins", "Nom", c => c.String());
            DropColumn("dbo.Emprunts", "EtatRetour");
            DropTable("dbo.Employees");
            RenameTable(name: "dbo.Admins", newName: "Employees");
        }
    }
}
