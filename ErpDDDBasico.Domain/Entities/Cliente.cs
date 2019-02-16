using ErpDDDBasico.Domain.ValueObject;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Endereco Endereco { get; private set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
