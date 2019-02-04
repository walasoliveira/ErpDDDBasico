using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Services
{
    public class PagamentoService : ServiceBase<Pagamento>, IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository):base(pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public List<TipoPagamento> BuscarTiposPagamento()
        {
            return _pagamentoRepository.BuscarTiposPagamento();
        }
    }
}
