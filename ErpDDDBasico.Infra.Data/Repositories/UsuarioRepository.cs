using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using System.Linq;

namespace ErpDDDBasico.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public bool PossuiAcessoRh(Usuario usuario)
        {
            return true;
        }

        public bool PossuiAcessoVendas(Usuario usuario)
        {
            return true;
        }

        public Usuario BuscaUsuario(string usuario, string senha)
        {
            return _erpDDDBasicoContext.Usuario.SingleOrDefault(u => u.UsuarioLogin == usuario && u.UsuarioSenha == senha);
        }
    }
}
