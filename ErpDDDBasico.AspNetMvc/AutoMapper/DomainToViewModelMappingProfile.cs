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
                .ForMember(destino => destino.Logradouro, origem => origem.MapFrom(u => u.Endereco.Logradouro))
                .ForMember(destino => destino.Numero, origem => origem.MapFrom(u => u.Endereco.Numero))
                .ForMember(destino => destino.Complemento, origem => origem.MapFrom(u => u.Endereco.Complemento))
                .ForMember(destino => destino.Bairro, origem => origem.MapFrom(u => u.Endereco.Bairro))
                .ForMember(destino => destino.Cidade, origem => origem.MapFrom(u => u.Endereco.Cidade));

            CreateMap<Produto, ProdutoModel>();
            CreateMap<Modulo, ModuloModel>();
            CreateMap<TipoPagamento, TipoPagamentoModel>();
            CreateMap<Pagamento, PagamentoViewModel>()
                .ForPath(destino => destino.Funcionario.FuncionarioId, origem => origem.MapFrom(u => u.FuncionarioId))
                .ForPath(destino => destino.Funcionario.Nome, origem => origem.MapFrom(u => u.Funcionario.Nome))
                .ForPath(destino => destino.Funcionario.SobreNome, origem => origem.MapFrom(u => u.Funcionario.SobreNome))
                .ForPath(destino => destino.TipoPagamento.TipoPagamentoId, origem => origem.MapFrom(u => u.TipoPagamentoId))
                .ForPath(destino => destino.TipoPagamento.Descricao, origem => origem.MapFrom(u => u.TipoPagamento.Descricao));
        }
    }
}