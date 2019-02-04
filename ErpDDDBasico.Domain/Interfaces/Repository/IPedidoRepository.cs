using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Domain.Interfaces.Repository
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes);
    }
}
