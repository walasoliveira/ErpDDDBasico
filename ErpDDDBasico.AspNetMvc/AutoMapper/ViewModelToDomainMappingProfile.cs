using AutoMapper;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.AspNetMvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<UsuarioModel, Usuario>()
                .ForMember(destino => destino.UsuarioId, origem => origem.MapFrom(u => u.UsuarioId))
                .ForMember(destino => destino.UsuarioLogin, origem => origem.MapFrom(u => u.UsuarioLogin))
                .ForMember(destino => destino.UsuarioSenha, origem => origem.MapFrom(u => u.UsuarioSenha));

            CreateMap<FuncionarioModel, Funcionario>()
                .ForPath(destino => destino.Endereco.Logradouro, origem => origem.MapFrom(u => u.Logradouro))
                .ForPath(destino => destino.Endereco.Numero, origem => origem.MapFrom(u => u.Numero))
                .ForPath(destino => destino.Endereco.Complemento, origem => origem.MapFrom(u => u.Complemento))
                .ForPath(destino => destino.Endereco.Bairro, origem => origem.MapFrom(u => u.Bairro))
                .ForPath(destino => destino.Endereco.Cidade, origem => origem.MapFrom(u => u.Cidade));

            CreateMap<PedidoViewModel,Pedido>()
                .ForPath(destino => destino.Cliente, origem => origem.MapFrom(u => u.Cliente))
                .ForPath(destino => destino.UsuarioId, origem => origem.MapFrom(u => u.Usuario.UsuarioId))
                .ForPath(destino => destino.PedidoDetalhes, origem => origem.Ignore());

            CreateMap<ProdutoModel, Produto>();
            CreateMap<ModuloModel, Modulo>();
            CreateMap<TipoPagamentoModel, TipoPagamento>();
            CreateMap<PagamentoViewModel, Pagamento>()
                .ForPath(destino => destino.FuncionarioId, origem => origem.MapFrom(u => u.Funcionario.FuncionarioId))
                .ForPath(destino => destino.TipoPagamentoId, origem => origem.MapFrom(u => u.TipoPagamento.TipoPagamentoId))
                .ForPath(destino => destino.TipoPagamento.Descricao, origem => origem.Ignore())
                .ForPath(destino => destino.Funcionario.Endereco, origem => origem.Ignore())
                .ForPath(destino => destino.Funcionario.NumeroBilheteUnico, origem => origem.Ignore())
                .ForPath(destino => destino.Funcionario.NumeroValeRefeicao, origem => origem.Ignore());
        }
    }
}