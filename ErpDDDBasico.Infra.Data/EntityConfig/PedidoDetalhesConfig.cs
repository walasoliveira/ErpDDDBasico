using ErpDDDBasico.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class PedidoDetalhesConfig : EntityTypeConfiguration<PedidoDetalhes>
    {
        public PedidoDetalhesConfig()
        {
            HasKey(p => p.PedidoDetalhesId);

            Property(p => p.ValorUnitario).IsRequired();
            Property(p => p.ValorDesconto).IsOptional();
            Property(p => p.ValorFinal).IsRequired();

            HasRequired(p => p.Pedido)
                .WithMany(p => p.PedidoDetalhes)
                .HasForeignKey<int>(p => p.PedidoId);

            HasRequired(p => p.Produto)
                .WithMany(p => p.PedidoDetalhes)
                .HasForeignKey<int>(p => p.ProdutoId);
        }
    }
}
