using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Domain.Interfaces.Services
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes);
    }
}
