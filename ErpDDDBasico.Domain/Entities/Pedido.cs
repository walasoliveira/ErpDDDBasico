using System;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<PedidoDetalhes> PedidoDetalhes { get; set; }
    }
}
