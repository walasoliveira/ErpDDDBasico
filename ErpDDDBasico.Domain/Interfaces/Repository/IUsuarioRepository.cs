using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscaUsuario(string usuario, string senha);
        bool PossuiAcessoRh(Usuario usuario);
        bool PossuiAcessoVendas(Usuario usuario);
    }
}
