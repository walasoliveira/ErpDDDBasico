using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);

            Property(p=>p.ProdutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome).HasMaxLength(20).IsRequired();

            Property(p => p.Descricao).HasMaxLength(20).IsRequired();

            Property(p => p.Preco).IsRequired();
        }
    }
}
