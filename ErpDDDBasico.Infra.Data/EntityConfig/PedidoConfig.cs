using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class PedidoConfig : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfig()
        {
            HasKey(p => p.PedidoId);

            Property(p => p.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Usuario)
                .WithMany(p => p.Pedidos);

            HasRequired(p => p.Cliente)
                .WithMany(p => p.Pedido);
        }
    }
}
