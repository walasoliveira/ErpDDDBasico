using ErpDDDBasico.AspNetMvc.Models;
using System.ComponentModel.DataAnnotations;

namespace ErpDDDBasico.AspNetMvc.ViewModels
{
    public class PedidoDetalheViewModel
    {
        public int PedidoDetalhesId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public int ProdutoId { get; set; }

        public ProdutoModel ProdutoModel { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //public decimal ValorUnitario { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //public decimal? ValorDesconto { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //public decimal ValorFinal { get; set; }

        public int PedidoId { get; set; }
        public PedidoViewModel Pedido { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string ValorUnitario { get; set; }

        //[Required(ErrorMessage = "Campo obrigatorio")]
        public string ValorDesconto { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string ValorFinal { get; set; }
    }
}