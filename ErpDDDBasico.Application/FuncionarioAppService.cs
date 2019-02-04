using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.Domain.Entities;
using ErpDDDBasico.Domain.Interfaces.Services;

namespace ErpDDDBasico.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioAppService(IFuncionarioService funcionarioService):base(funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
    }
}
