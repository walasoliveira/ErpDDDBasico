using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ErpDDDBasico.Infra.Data.EntityConfig
{
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            HasKey(f => f.FuncionarioId);

            Property(f => f.FuncionarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(f => f.ContaBancaria.Agencia).HasColumnName("Agencia").HasMaxLength(ContaBancaria.AgenciaMaxLentgh).IsRequired();

            Property(f => f.ContaBancaria.Conta).HasColumnName("Conta").HasMaxLength(ContaBancaria.ContaMaxLentgh).IsRequired();

            Property(f => f.Endereco.Logradouro).HasColumnName("Logradouro").HasMaxLength(Endereco.LogradouroMaxLenght).IsRequired();

            Property(f => f.NumeroBilheteUnico).HasMaxLength(10).IsRequired();

            Property(f => f.NumeroValeRefeicao).HasMaxLength(10).IsRequired();

            Property(f => f.Endereco.Numero).HasColumnName("Numero").HasMaxLength(Endereco.NumeroMaxLenght).IsRequired();

            Property(f => f.Endereco.Complemento).HasColumnName("Complemento").HasMaxLength(Endereco.ComplementoMaxLenght).IsOptional();

            Property(f => f.Endereco.Bairro).HasColumnName("Bairro").HasMaxLength(Endereco.BairroMaxLenght).IsRequired();

            Property(f => f.Endereco.Cidade).HasColumnName("Cidade").HasMaxLength(Endereco.CidadeMaxLenght).IsRequired();
        }
    }
}
