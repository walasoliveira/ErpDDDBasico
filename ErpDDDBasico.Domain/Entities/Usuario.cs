using System;
using System.Collections.Generic;

namespace ErpDDDBasico.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioLogin { get; set; }
        public string UsuarioSenha { get; set; }
        public string UsuarioSenhaConfirmacao { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<UsuarioPermissaoModulo> UsuarioPermissaoModulos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
