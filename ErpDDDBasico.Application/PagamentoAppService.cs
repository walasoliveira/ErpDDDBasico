using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ErpDDDBasico.Application
{
    public class PagamentoAppService : AppServiceBase<Pagamento>, IPagamentoAppService
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoAppService(IPagamentoService pagamentoService) : base(pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public List<TipoPagamento> BuscarTiposPagamento()
        {
            return _pagamentoService.BuscarTiposPagamento();
        }
    }
}
