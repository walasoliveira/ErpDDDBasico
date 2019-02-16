using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Application.Interfaces
{
    public interface IPedidoAppService : IAppServiceBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhe);
        void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes);
    }
}
