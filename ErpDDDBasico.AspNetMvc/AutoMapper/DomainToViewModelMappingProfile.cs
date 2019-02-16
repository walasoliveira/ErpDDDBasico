using AutoMapper;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;

namespace ErpDDDBasico.AspNetMvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<Usuario, UsuarioModel>();

            CreateMap<Usuario, UsuarioModel>()
                .ForMember(destino => destino.UsuarioId, origem => origem.MapFrom(u => u.UsuarioId))
                .ForMember(destino => destino.UsuarioLogin, origem => origem.MapFrom(u => u.UsuarioLogin))
                .ForMember(destino => destino.UsuarioSenha, origem => origem.MapFrom(u => u.UsuarioSenha));

            CreateMap<Funcionario, FuncionarioModel>()
                .ForMember(destino => destino.Pagamentos, origem => origem.MapFrom(u => u.Pagamento))
                .ForMember(destino => destino.Logradouro, origem => origem.MapFrom(u => u.Endereco.Logradouro))
                .ForMember(destino => destino.Numero, origem => origem.MapFrom(u => u.Endereco.Numero))
                .ForMember(destino => destino.Complemento, origem => origem.MapFrom(u => u.Endereco.Complemento))
                .ForMember(destino => destino.Bairro, origem => origem.MapFrom(u => u.Endereco.Bairro))
                .ForMember(destino => destino.Cidade, origem => origem.MapFrom(u => u.Endereco.Cidade));

            CreateMap<Cliente, ClienteModel>()
                .ForPath(destino => destino.Logradouro, origem => origem.MapFrom(c => c.Endereco.Logradouro))
                .ForPath(destino => destino.Numero, origem => origem.MapFrom(c => c.Endereco.Numero))
                .ForPath(destino => destino.Complemento, origem => origem.MapFrom(c => c.Endereco.Complemento))
                .ForPath(destino => destino.Bairro, origem => origem.MapFrom(c => c.Endereco.Bairro))
                .ForPath(destino => destino.Cidade, origem => origem.MapFrom(c => c.Endereco.Cidade));

            CreateMap<Pedido, PedidoViewModel>()
                .ForPath(destino => destino.ListaPedidoDetalhe, origem => origem.MapFrom(p => p.PedidoDetalhes))
                .ForPath(destino => destino.PedidoDetalhe, origem => origem.Ignore());

            CreateMap<PedidoDetalhes, PedidoDetalheViewModel>()
                .ForPath(destino => destino.ProdutoModel, origem => origem.MapFrom(p => p.Produto));

            CreateMap<Produto, ProdutoModel>();
            CreateMap<Modulo, ModuloModel>();
            CreateMap<TipoPagamento, TipoPagamentoModel>();
            CreateMap<Pagamento, PagamentoViewModel>();
        }
    }
}