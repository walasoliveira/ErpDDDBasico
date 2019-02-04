using System;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<PedidoDetalhes> PedidoDetalhes { get; set; }
    }
}
