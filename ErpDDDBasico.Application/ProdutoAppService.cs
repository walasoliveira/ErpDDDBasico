using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
            _produtoService = produtoService;
        }
    }
}
