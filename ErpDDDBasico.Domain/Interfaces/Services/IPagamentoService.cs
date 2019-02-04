using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Interfaces.Services
{
    public interface IPagamentoService : IServiceBase<Pagamento>
    {
        List<TipoPagamento> BuscarTiposPagamento();
    }
}
