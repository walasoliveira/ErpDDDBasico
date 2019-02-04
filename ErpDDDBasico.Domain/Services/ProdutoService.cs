using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repositoryProduto;

        public ProdutoService(IProdutoRepository repositoryProduto) : base(repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }
    }
}
