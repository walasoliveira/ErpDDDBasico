namespace ErpDDDBasico.Domain.Entities
{
    public class PedidoDetalhes
    {
        public int PedidoDetalhesId { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public decimal ValorUnitario { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
