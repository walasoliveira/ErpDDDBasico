namespace ErpDDDBasico.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 14, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 20, unicode: false),
                        Complemento = c.String(maxLength: 20, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.PedidoDetalhes",
                c => new
                    {
                        PedidoDetalhesId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorDesconto = c.Decimal(precision: 18, scale: 2),
                        ValorFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PedidoDetalhesId)
                .ForeignKey("dbo.Pedido", t => t.PedidoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 20, unicode: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UsuarioLogin = c.String(nullable: false, maxLength: 50, unicode: false),
                        UsuarioSenha = c.String(nullable: false, maxLength: 50, unicode: false),
                        UsuarioSenhaConfirmacao = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        FuncionarioId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        SobreNome = c.String(maxLength: 8000, unicode: false),
                        Rg = c.String(maxLength: 8000, unicode: false),
                        Cpf = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Telefone = c.String(maxLength: 8000, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 20, unicode: false),
                        Complemento = c.String(maxLength: 20, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 20, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 20, unicode: false),
                        Ramal = c.String(maxLength: 8000, unicode: false),
                        Setor = c.String(maxLength: 8000, unicode: false),
                        Agencia = c.String(nullable: false, maxLength: 10, unicode: false),
                        Conta = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroValeRefeicao = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBilheteUnico = c.String(nullable: false, maxLength: 10, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        PagamentoId = c.Int(nullable: false, identity: true),
                        FuncionarioId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoPagamentoId = c.Int(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PagamentoId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .ForeignKey("dbo.TipoPagamento", t => t.TipoPagamentoId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoPagamentoId);
            
            CreateTable(
                "dbo.TipoPagamento",
                c => new
                    {
                        TipoPagamentoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.TipoPagamentoId);
            
            CreateTable(
                "dbo.UsuarioPermissaoModulo",
                c => new
                    {
                        UsuarioPermissaoModuloId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ModuloId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.UsuarioPermissaoModuloId)
                .ForeignKey("dbo.Modulo", t => t.ModuloId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ModuloId);
            
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        ModuloId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ModuloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPermissaoModulo", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPermissaoModulo", "ModuloId", "dbo.Modulo");
            DropForeignKey("dbo.Usuario", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Pagamento", "TipoPagamentoId", "dbo.TipoPagamento");
            DropForeignKey("dbo.Pagamento", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.PedidoDetalhes", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.PedidoDetalhes", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.UsuarioPermissaoModulo", new[] { "ModuloId" });
            DropIndex("dbo.UsuarioPermissaoModulo", new[] { "UsuarioId" });
            DropIndex("dbo.Pagamento", new[] { "TipoPagamentoId" });
            DropIndex("dbo.Pagamento", new[] { "FuncionarioId" });
            DropIndex("dbo.Usuario", new[] { "FuncionarioId" });
            DropIndex("dbo.PedidoDetalhes", new[] { "ProdutoId" });
            DropIndex("dbo.PedidoDetalhes", new[] { "PedidoId" });
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropIndex("dbo.Pedido", new[] { "UsuarioId" });
            DropTable("dbo.Modulo");
            DropTable("dbo.UsuarioPermissaoModulo");
            DropTable("dbo.TipoPagamento");
            DropTable("dbo.Pagamento");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.PedidoDetalhes");
            DropTable("dbo.Pedido");
            DropTable("dbo.Cliente");
        }
    }
}
