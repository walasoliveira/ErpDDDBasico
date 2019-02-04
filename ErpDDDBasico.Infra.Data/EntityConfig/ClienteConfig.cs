using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);

            Property(c=>c.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Cpf).HasMaxLength(14).IsRequired();

            Property(c => c.Endereco.Logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaxLenght).IsRequired();

            Property(c => c.Endereco.Numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaxLenght).IsRequired();

            Property(c => c.Endereco.Complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaxLenght).IsOptional();

            Property(c => c.Endereco.Bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaxLenght).IsRequired();

            Property(c => c.Endereco.Cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaxLenght).IsRequired();
        }
    }
}
