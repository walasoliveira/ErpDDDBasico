using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class ModuloConfig: EntityTypeConfiguration<Modulo>
    {
        public ModuloConfig()
        {
            HasKey(m=>m.ModuloId);

            Property(m => m.ModuloId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
