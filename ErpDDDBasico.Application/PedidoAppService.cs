using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;

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
    }
}
