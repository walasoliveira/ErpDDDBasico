using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;

namespace ErpDDDBasico.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes)
        {
            _erpDDDBasicoContext.PedidoDetalhes.Add(pedidoDetalhes);
            _erpDDDBasicoContext.SaveChanges();
        }
    }
}
