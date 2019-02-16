using ErpDDDBasico.AspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.ViewModels
{
    public class PagamentoViewModel
    {
        public PagamentoViewModel()
        {
            ListaFuncionarios = new List<FuncionarioModel>();
            ListaTiposPagamento = new List<TipoPagamentoModel>();
        }

        public int PagamentoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public FuncionarioModel Funcionario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public TipoPagamentoModel TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public List<TipoPagamentoModel> ListaTiposPagamento { get; set; }
        public List<FuncionarioModel> ListaFuncionarios { get; set; }
    }
}