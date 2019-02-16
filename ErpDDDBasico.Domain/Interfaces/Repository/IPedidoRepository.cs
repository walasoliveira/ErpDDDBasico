using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Interfaces.Repository
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes);
        void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes);
    }
}
