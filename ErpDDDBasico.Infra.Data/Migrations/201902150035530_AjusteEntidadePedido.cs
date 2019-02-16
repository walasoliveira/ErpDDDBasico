namespace ErpDDDBasico.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteEntidadePedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "ValorTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "ValorTotal");
        }
    }
}
