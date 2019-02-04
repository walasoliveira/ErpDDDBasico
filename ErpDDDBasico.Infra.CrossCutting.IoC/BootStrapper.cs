using ErpDDDBasico.Application;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Domain.Interfaces.Services;
using ErpDDDBasico.Domain.Services;
using ErpDDDBasico.Infra.Data.Repositories;
using SimpleInjector;

namespace ErpDDDBasico.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IFuncionarioAppService, FuncionarioAppService>(Lifestyle.Scoped);
            container.Register<IPagamentoAppService, PagamentoAppService>(Lifestyle.Scoped);
            container.Register<IPedidoAppService, PedidoAppService>(Lifestyle.Scoped);

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IFuncionarioService, FuncionarioService>(Lifestyle.Scoped);
            container.Register<IPagamentoService, PagamentoService>(Lifestyle.Scoped);
            container.Register<IPedidoService, PedidoService>(Lifestyle.Scoped);
            
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IFuncionarioRepository, FuncionarioRepository>(Lifestyle.Scoped);
            container.Register<IPagamentoRepository, PagamentoRepository>(Lifestyle.Scoped);
            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
        }
    }
}
