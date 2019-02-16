using ErpDDDBasico.AspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.ViewModels
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        public ClienteModel Cliente { get; set; }

        public UsuarioModel Usuario { get; set; }
        public string ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }
        public PedidoDetalheViewModel PedidoDetalhe { get; set; }
        public List<PedidoDetalheViewModel> ListaPedidoDetalhe { get; set; }
    }
}