using System;

namespace ErpDDDBasico.Domain.Entities
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int FuncionarioId { get; set; }
        public decimal Valor { get; set; }
        public int TipoPagamentoId { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}
