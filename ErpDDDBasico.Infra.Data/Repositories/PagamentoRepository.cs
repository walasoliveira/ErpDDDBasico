using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ErpDDDBasico.Infra.Data.Repositories
{
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        public List<TipoPagamento> BuscarTiposPagamento()
        {
            return _erpDDDBasicoContext.TipoPagamento.ToList();
        }
    }
}
