using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class PagamentoConfig : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoConfig()
        {
            HasKey(p => p.PagamentoId);

            Property(p => p.PagamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Valor).IsRequired();

            HasRequired(p => p.Funcionario)
                .WithMany(f => f.Pagamento)
                .HasForeignKey<int>(f => f.FuncionarioId);

            HasRequired(p => p.TipoPagamento)
                .WithMany(tp => tp.Pagamento)
                .HasForeignKey<int>(tp => tp.TipoPagamentoId);
        }
    }
}
