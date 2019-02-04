using System;

namespace ErpDDDBasico.Domain.Entities
{
    public class UsuarioPermissaoModulo
    {
        public int UsuarioPermissaoModuloId { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
