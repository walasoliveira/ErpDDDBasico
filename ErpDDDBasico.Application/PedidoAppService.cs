using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ErpDDDBasico.Application
{
    public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        
        public PedidoAppService(IPedidoService pedidoService):base(pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public void AddPedidoDetalhe(PedidoDetalhes pedidoDetalhes)
        {
            _pedidoService.AddPedidoDetalhe(pedidoDetalhes);
        }

        public void AddPedidoDetalheRange(List<PedidoDetalhes> pedidoDetalhes)
        {
            _pedidoService.AddPedidoDetalheRange(pedidoDetalhes);
        }
    }
}
