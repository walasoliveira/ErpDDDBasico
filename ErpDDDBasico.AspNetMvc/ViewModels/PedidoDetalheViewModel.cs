using ErpDDDBasico.AspNetMvc.Models;

namespace ErpDDDBasico.AspNetMvc.ViewModels
{
    public class PedidoDetalheViewModel
    {
        public int PedidoDetalhesId { get; set; }
        
        public int ProdutoId { get; set; }
        public ProdutoModel ProdutoModel { get; set; }

        public decimal ValorUnitario { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal ValorFinal { get; set; }
    }
}