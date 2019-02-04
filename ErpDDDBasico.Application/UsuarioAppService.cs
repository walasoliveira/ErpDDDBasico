using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public bool PossuiAcessoRh(Usuario usuario)
        {
            return _usuarioService.PossuiAcessoRh(usuario);
        }

        public bool PossuiAcessoVendas(Usuario usuario)
        {
            return _usuarioService.PossuiAcessoVendas(usuario);
        }

        public Usuario BuscaUsuario(string usuario, string senha)
        {
            return _usuarioService.BuscaUsuario(usuario, senha);
        }
    }
}
