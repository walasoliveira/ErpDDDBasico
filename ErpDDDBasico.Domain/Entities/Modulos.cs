using System;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Modulo
    {
        public int ModuloId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<UsuarioPermissaoModulo> UsuarioPermissaoModulos { get; set; }
    }
}
