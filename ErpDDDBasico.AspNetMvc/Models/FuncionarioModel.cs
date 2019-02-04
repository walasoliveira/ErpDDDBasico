using System;

namespace ErpDDDBasico.AspNetMvc.Models
{
    public class FuncionarioModel
    {
        public int FuncionarioId { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public string Ramal { get; set; }
        public string Setor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}