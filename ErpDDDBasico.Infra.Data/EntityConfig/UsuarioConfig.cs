using ErpDDDBasico.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.UsuarioId);

            Property(u => u.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.UsuarioLogin).HasMaxLength(50).IsRequired();

            Property(u => u.UsuarioSenha).HasMaxLength(50).IsRequired();

            Property(u => u.UsuarioSenhaConfirmacao).HasMaxLength(50).IsRequired();

            HasOptional(u => u.Funcionario)
                .WithOptionalDependent(f => f.Usuario)
                .Map(m => m.MapKey("FuncionarioId"));
        }
    }
}
