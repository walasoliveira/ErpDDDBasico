using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repositoryUsuario;

        public UsuarioService(IUsuarioRepository repositoryUsuario):base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public bool PossuiAcessoRh(Usuario usuario)
        {
            return _repositoryUsuario.PossuiAcessoRh(usuario);
        }

        public bool PossuiAcessoVendas(Usuario usuario)
        {
            return _repositoryUsuario.PossuiAcessoVendas(usuario);
        }

        public Usuario BuscaUsuario(string usuario, string senha)
        {
            return _repositoryUsuario.BuscaUsuario(usuario, senha);
        }
    }
}
