namespace ErpDDDBasico.Infra.Data.Migrations
{
    using ErpDDDBasico.Domain.Entities;
    using ErpDDDBasico.Domain.ValueObject;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ErpDDDBasico.Infra.Data.Contexto.ErpDDDBasicoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexto.ErpDDDBasicoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Produto.AddOrUpdate(x => x.Nome,
                new Produto
                {
                    Nome = "Iphone 8",
                    Descricao = "Celular apple",
                    Preco = 3000.99m,
                    DataCadastro = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Produto
                {
                    Nome = "Samsung S8",
                    Descricao = "Celular samsung",
                    Preco = 2000.99m,
                    DataCadastro = DateTime.Now,
                    DataAlteracao = DateTime.Now
                }
            );

            context.Modulo.AddOrUpdate(x => x.Nome,
                new Modulo
                {
                    Nome = "Recursos Humanos",
                    DataCadastro = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Modulo
                {
                    Nome = "Vendas",
                    DataCadastro = DateTime.Now,
                    DataAlteracao = DateTime.Now
                }
            );

            context.SaveChanges();

            context.Funcionario.AddOrUpdate(x => new { x.Nome, x.SobreNome },
                new Funcionario
                {
                    Nome = "Administrador",
                    Cpf = "111.111.111-11",
                    Rg = "22.222.222-22",
                    Telefone = "11-99999-9999",
                    Ramal = "9999",
                    Email = "admin@admin.com.br",
                    SobreNome = "Administrador",
                    Setor = "TI",
                    NumeroBilheteUnico = "123456789",
                    NumeroValeRefeicao = "456789123",
                    ContaBancaria = new ContaBancaria
                    {
                        Agencia = "111111",
                        Conta = "222222"
                    },
                    Endereco = new Endereco
                    {
                        Numero = "1",
                        Logradouro = "Rua abc",
                        Bairro = "Vila abc",
                        Cidade = "SP",
                        Complemento = "AP 1000"
                    },
                    DataCadastro = DateTime.Now
                },
                new Funcionario
                {
                    Nome = "Maria",
                    SobreNome = "da Silva",
                    Cpf = "222.222.222-22",
                    Rg = "33.333.333-33",
                    Telefone = "11-99999-9999",
                    Ramal = "5555",
                    Email = "maria@maria.com.br",
                    Setor = "Vendas",
                    NumeroBilheteUnico = "123456789",
                    NumeroValeRefeicao = "456789123",
                    ContaBancaria = new ContaBancaria
                    {
                        Agencia = "123456",
                        Conta = "789456"
                    },
                    Endereco = new Endereco
                    {
                        Numero = "1",
                        Logradouro = "Rua abc",
                        Bairro = "Vila abc",
                        Cidade = "SP",
                        Complemento = "AP 1000"
                    },
                    DataCadastro = DateTime.Now
                }
            );

            context.SaveChanges();

            context.TipoPagamento.AddOrUpdate(x => x.Descricao,
                new TipoPagamento { Descricao = "Salario" },
                new TipoPagamento { Descricao = "VT" },
                new TipoPagamento { Descricao = "VR" }
            );

            context.SaveChanges();


            context.Pagamento.AddOrUpdate(x => new { x.FuncionarioId, x.PagamentoId, x.DataPagamento },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 1, Valor = 2000.00m, DataPagamento = Convert.ToDateTime("05/11/2018") },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 2, Valor = 576.46m, DataPagamento = Convert.ToDateTime("05/11/2018") },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 3, Valor = 400.00m, DataPagamento = Convert.ToDateTime("05/11/2018") },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 1, Valor = 2000.00m, DataPagamento = Convert.ToDateTime("05/12/2018") },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 2, Valor = 576.46m, DataPagamento = Convert.ToDateTime("05/12/2018") },
                    new Pagamento { FuncionarioId = 2, TipoPagamentoId = 3, Valor = 400.00m, DataPagamento = Convert.ToDateTime("05/12/2018") }
            );

            context.SaveChanges();

            //string querySalario1 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,1, 2000.00, '05/11/2018')";
            //string queryVT1 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,2, 576.40, '05/11/2018')";
            //string queryVR1 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,3, 400.00, '05/11/2018')";

            //context.Database.ExecuteSqlCommand(querySalario1);
            //context.Database.ExecuteSqlCommand(queryVT1);
            //context.Database.ExecuteSqlCommand(queryVR1);

            //string querySalario2 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,1, 2000.00, '05/12/2018')";
            //string queryVT2 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,2, 576.40, '05/12/2018')";
            //string queryvVR2 = "INSERT INTO Pagamento (FuncionarioId, TipoPagamentoId, Valor, DataPagamento) VALUES (2,3, 400.00, '05/12/2018')";

            //context.Database.ExecuteSqlCommand(querySalario2);
            //context.Database.ExecuteSqlCommand(queryVT2);
            //context.Database.ExecuteSqlCommand(queryvVR2);

            //int id1 = context.Funcionario.SingleOrDefault(f => f.Nome == "Administrador").FuncionarioId;
            string query1 = @"DECLARE @UsuarioCount INT
                              SET @UsuarioCount = (SELECT COUNT(*) FROM Usuario WHERE FuncionarioId = 1)
                              IF ( @UsuarioCount = 0 )
                              BEGIN                              
                                    INSERT INTO Usuario (UsuarioLogin, UsuarioSenha, UsuarioSenhaConfirmacao, DataCadastro, FuncionarioId) 
                                    VALUES ('admin','admin', 'admin', getdate(),1)
                              END";

            context.Database.ExecuteSqlCommand(query1);

            //int id2 = context.Funcionario.SingleOrDefault(f => f.Nome == "Maria").FuncionarioId;
            string query2 = @"DECLARE @UsuarioCount INT
                              SET @UsuarioCount = (SELECT COUNT(*) FROM Usuario WHERE FuncionarioId = 2)
                              IF ( @UsuarioCount = 0 )
                              BEGIN                              
                                    INSERT INTO Usuario (UsuarioLogin, UsuarioSenha, UsuarioSenhaConfirmacao, DataCadastro, FuncionarioId) 
                                    VALUES ('maria', 'maria', 'maria', getdate(),2)
                              END";

            context.Database.ExecuteSqlCommand(query2);
        }
    }
}











