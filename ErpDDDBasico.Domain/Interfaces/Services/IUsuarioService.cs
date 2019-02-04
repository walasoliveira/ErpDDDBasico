using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario BuscaUsuario(string usuario, string senha);
        bool PossuiAcessoRh(Usuario usuario);
        bool PossuiAcessoVendas(Usuario usuario);
    }
}
