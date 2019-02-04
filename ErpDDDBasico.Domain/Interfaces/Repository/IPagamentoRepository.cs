using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Interfaces.Repository
{
    public interface IPagamentoRepository : IRepositoryBase<Pagamento>
    {
        List<TipoPagamento> BuscarTiposPagamento();
    }
}
