using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;
using System.Collections.Generic;

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

        public void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes)
        {
            _pedidoRepository.AddPedidoDetalheRange(pedidoDetalhes);
        }
    }
}
