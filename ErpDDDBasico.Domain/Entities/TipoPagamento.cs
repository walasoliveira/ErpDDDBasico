using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class TipoPagamento
    {
        public int TipoPagamentoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
    }
}
