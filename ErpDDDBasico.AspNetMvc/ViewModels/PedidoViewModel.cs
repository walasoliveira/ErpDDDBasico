using ErpDDDBasico.AspNetMvc.Models;
using System.Collections.Generic;

namespace ErpDDDBasico.AspNetMvc.ViewModels
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public ClienteModel Cliente { get; set; }
        public UsuarioModel Usuario { get; set; }
        public PedidoDetalheViewModel PedidoDetalhe { get; set; }
        public List<PedidoDetalheViewModel> ListaPedidoDetalhe { get; set; }
    }
}