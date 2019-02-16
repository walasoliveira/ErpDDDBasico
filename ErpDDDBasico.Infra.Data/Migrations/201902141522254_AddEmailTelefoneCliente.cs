namespace ErpDDDBasico.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailTelefoneCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Email", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddColumn("dbo.Cliente", "Telefone", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Telefone");
            DropColumn("dbo.Cliente", "Email");
        }
    }
}
