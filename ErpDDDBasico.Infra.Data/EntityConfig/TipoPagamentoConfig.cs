using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class TipoPagamentoConfig : EntityTypeConfiguration<TipoPagamento>
    {
        public TipoPagamentoConfig()
        {
            HasKey(tp=>tp.TipoPagamentoId);

            Property(tp => tp.TipoPagamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(tp => tp.Descricao).HasMaxLength(20).IsRequired();
        }
    }
}
