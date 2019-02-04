using ErpDDDBasico.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public string Ramal { get; set; }
        public string Setor { get; set; }

        public ContaBancaria ContaBancaria { get; set; }


        public string NumeroValeRefeicao { get; set; }
        public string NumeroBilheteUnico { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
    }
}
