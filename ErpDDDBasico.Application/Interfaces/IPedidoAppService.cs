using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Application.Interfaces
{
    public interface IPedidoAppService : IAppServiceBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes);
    }
}
