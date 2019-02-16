using ErpDDDBasico.AspNetMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.Models
{
    public class FuncionarioModel
    {
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Ramal { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Setor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public List<PagamentoViewModel> Pagamentos { get; set; }
    }
}