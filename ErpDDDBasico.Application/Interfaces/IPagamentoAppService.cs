using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Application.Interfaces
{
    public interface IPagamentoAppService : IAppServiceBase<Pagamento>
    {
        List<TipoPagamento> BuscarTiposPagamento();
    }
}
