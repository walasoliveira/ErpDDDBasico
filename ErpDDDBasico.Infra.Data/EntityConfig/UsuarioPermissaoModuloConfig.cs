using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class UsuarioPermissaoModuloConfig : EntityTypeConfiguration<UsuarioPermissaoModulo>
    {
        public UsuarioPermissaoModuloConfig()
        {
            HasKey(up => up.UsuarioPermissaoModuloId);

            Property(up => up.UsuarioPermissaoModuloId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(up => up.Usuario)
                .WithMany(u => u.UsuarioPermissaoModulos)
                .HasForeignKey<int>(u => u.UsuarioId);

            HasRequired(up => up.Modulo)
                .WithMany(m => m.UsuarioPermissaoModulos)
                .HasForeignKey<int>(m => m.ModuloId);
        }
    }
}
