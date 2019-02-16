using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Interfaces.Services
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes);
        void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes);
    }
}
