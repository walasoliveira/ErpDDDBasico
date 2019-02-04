using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario BuscaUsuario(string usuario, string senha);
        bool PossuiAcessoRh(Usuario usuario);
        bool PossuiAcessoVendas(Usuario usuario);
    }
}
