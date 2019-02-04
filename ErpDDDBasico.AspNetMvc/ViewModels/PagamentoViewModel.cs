using ErpDDDBasico.AspNetMvc.Models;
using System;
using System.Collections.Generic;

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
        public FuncionarioModel Funcionario { get; set; }
        public decimal Valor { get; set; }
        public TipoPagamentoModel TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public List<TipoPagamentoModel> ListaTiposPagamento { get; set; }
        public List<FuncionarioModel> ListaFuncionarios { get; set; }
    }
}