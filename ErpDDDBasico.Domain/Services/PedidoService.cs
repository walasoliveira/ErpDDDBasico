using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository):base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes)
        {
            _pedidoRepository.AddPedidoDetalhe(pedidoDetalhes);
        }
    }
}
