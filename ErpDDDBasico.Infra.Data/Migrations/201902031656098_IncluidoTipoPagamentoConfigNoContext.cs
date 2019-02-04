namespace ErpDDDBasico.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncluidoTipoPagamentoConfigNoContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipoPagamento", "Descricao", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoPagamento", "Descricao", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
