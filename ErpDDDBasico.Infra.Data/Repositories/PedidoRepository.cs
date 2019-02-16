using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace ErpDDDBasico.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes)
        {
            _erpDDDBasicoContext.PedidoDetalhes.Add(pedidoDetalhes);
            _erpDDDBasicoContext.SaveChanges();
        }

        public void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes)
        {
            _erpDDDBasicoContext.PedidoDetalhes.AddRange(pedidoDetalhes);
            _erpDDDBasicoContext.SaveChanges();
        }
    }
}
