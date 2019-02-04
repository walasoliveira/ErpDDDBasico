using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ErpDDDBasico.Infra.Data.Contexto
{
    public class ErpDDDBasicoContext : DbContext
    {
        public ErpDDDBasicoContext() : base("ErpDDDBasicoConnection")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDetalhes> PedidoDetalhes { get; set; }
        public DbSet<UsuarioPermissaoModulo> UsuarioPermissaoModulo { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new FuncionarioConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new PedidoConfig());
            modelBuilder.Configurations.Add(new PedidoDetalhesConfig());
            modelBuilder.Configurations.Add(new ModuloConfig());
            modelBuilder.Configurations.Add(new UsuarioPermissaoModuloConfig());
            modelBuilder.Configurations.Add(new TipoPagamentoConfig());
            modelBuilder.Configurations.Add(new PagamentoConfig());

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<decimal>()
                .Configure(p => p.HasColumnType("decimal").HasPrecision(18, 2));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
