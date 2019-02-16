using AutoMapper;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace ErpDDDBasico.AspNetMvc.Areas.Vendas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IPedidoAppService _pedidoAppService;

        public HomeController(IProdutoAppService produtoAppService, IPedidoAppService pedidoAppService)
        {
            _produtoAppService = produtoAppService;
            _pedidoAppService = pedidoAppService;
        }

        // GET: Vendas/Home
        public ActionResult Index()
        {
            TempData["Menu"] = "home";
            var pedidos = Mapper.Map<List<Pedido>, List<PedidoViewModel>>(_pedidoAppService.GetAll());
            ViewBag.Vendas = pedidos;
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialInputsPedidoDetalhes()
        {
            if (TempData.TryGetValue("PedidoDetalheAdicionado", out object pedidoDetalheAdicionado))
                ViewBag.PedidoDetalheAdicionado = (JObject)pedidoDetalheAdicionado;

            PedidoDetalheViewModel pedidoDetalheViewModel = new PedidoDetalheViewModel();
            ViewBag.Produtos = Mapper.Map<List<Produto>, List<ProdutoModel>>(_produtoAppService.GetAll());
            return PartialView("PartialInputsPedidoDetalhes", pedidoDetalheViewModel);
        }

        [HttpPost]
        public ActionResult AdicionarOuAtualizarProduto(PedidoDetalheViewModel pedidoDetalheViewModel, string idPedidoDetalhe)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Produtos = Mapper.Map<List<Produto>, List<ProdutoModel>>(_produtoAppService.GetAll());
                return PartialView("PartialInputsPedidoDetalhes", pedidoDetalheViewModel);
            }

            Guid guid = (string.IsNullOrEmpty(idPedidoDetalhe)) ? Guid.NewGuid() : Guid.Parse(idPedidoDetalhe);

            List<KeyValuePair<Guid, PedidoDetalheViewModel>> lista = (List<KeyValuePair<Guid, PedidoDetalheViewModel>>)Session["Produtos"];

            var r = lista.Remove(lista.Find((x) => x.Key == guid));

            KeyValuePair<Guid, PedidoDetalheViewModel> produto = new KeyValuePair<Guid, PedidoDetalheViewModel>(guid, pedidoDetalheViewModel);

            lista.Add(produto);

            Session.Remove("Produtos");

            Session.Add("Produtos", lista);

            var prd = _produtoAppService.GetById(pedidoDetalheViewModel.ProdutoId);

            JObject result = JObject.FromObject(new
            {
                GuidPedidoDetalhe = guid,
                ProdutoId = prd.ProdutoId,
                Nome = prd.Nome,
                ValorUnitario = Convert.ToString(prd.Preco),
                ValorDesconto = pedidoDetalheViewModel.ValorDesconto,
                ValorFinal = pedidoDetalheViewModel.ValorFinal
            });

            TempData["PedidoDetalheAdicionado"] = result;
            return RedirectToAction("PartialInputsPedidoDetalhes");
        }

        [HttpPost]
        public string RemoverProduto(string guidPedidoDetalhe)
        {
            List<KeyValuePair<Guid, PedidoDetalheViewModel>> lista = (List<KeyValuePair<Guid, PedidoDetalheViewModel>>)Session["Produtos"];

            var produto = lista.Find((x) => x.Key == Guid.Parse(guidPedidoDetalhe));

            lista.Remove(produto);

            Session.Remove("Produtos");

            Session.Add("Produtos", lista);

            return JsonConvert.SerializeObject(new { GuidPedidoDetalhe = guidPedidoDetalhe, message = "Removido com sucesso." });
        }

        public ActionResult EfetuarPedido()
        {
            TempData["Menu"] = "efetuar-pedido";
            Session["Produtos"] = new List<KeyValuePair<Guid, PedidoDetalheViewModel>>();
            ViewBag.Produtos = Mapper.Map<List<Produto>, List<ProdutoModel>>(_produtoAppService.GetAll());
            PedidoViewModel pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.Usuario = new UsuarioModel { UsuarioId = 2 };
            return View(pedidoViewModel);
        }

        [HttpPost]
        public ActionResult EfetuarPedido(PedidoViewModel pedidoViewModel)
        {
            TempData["Menu"] = "efetuar-pedido";
            if (!ModelState.IsValid)
                return View(pedidoViewModel);

            try
            {
                var lista = (List<KeyValuePair<Guid, PedidoDetalheViewModel>>)Session["Produtos"];

                Pedido pedido = Mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);

                foreach (var item in lista)
                {
                    if (item.Value.ValorFinal != null)
                    {
                        pedido.ValorTotal = pedido.ValorTotal + Convert.ToDecimal(item.Value.ValorFinal);
                    }
                }

                _pedidoAppService.Add(pedido);

                List<PedidoDetalhes> pedidoDetalhes = new List<PedidoDetalhes>();

                foreach (var item in lista)
                {
                    item.Value.PedidoId = pedido.PedidoId;
                    pedidoDetalhes.Add(Mapper.Map<PedidoDetalheViewModel, PedidoDetalhes>(item.Value));
                }

                _pedidoAppService.AddPedidoDetalheRange(pedidoDetalhes);
            }
            catch (DbEntityValidationException ex)
            {
                string errors = "";
                foreach (var eve in ex.EntityValidationErrors)
                {
                    errors += "Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errors += "- Property: " + ve.PropertyName + ", Error: " + ve.ErrorMessage + "\n";
                    }
                }
                throw new Exception(errors);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        public decimal BuscarValorProduto(int id)
        {
            return _produtoAppService.GetById(id).Preco;
        }

        public ActionResult HistoricoPedidos()
        {
            TempData["Menu"] = "historico-pedidos";
            return View();
        }

        [HttpGet]
        public PartialViewResult GridPedidos(string ordenacao, string filtroAtual, int? pagina, string stringPesquisa)
        {
            ViewBag.ClienteOrdenacao = string.IsNullOrEmpty(ordenacao) ? "cliente_desc" : "";
            ViewBag.ValorFinalOrdenacao = ordenacao == "valor_final_desc" ? "valor_final_cre" : "valor_final_desc";
            ViewBag.DataPedidoOrdenacao = ordenacao == "data_pedido_desc" ? "data_pedido_cre" : "data_pedido_desc";

            List<PedidoViewModel> pedidoViewModels = Mapper.Map<List<Pedido>, List<PedidoViewModel>>(_pedidoAppService.GetAll());

            if (stringPesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                stringPesquisa = filtroAtual;
            }

            ViewBag.FiltroAtual = filtroAtual;

            switch (ordenacao)
            {
                case "cliente_desc":
                    pedidoViewModels = pedidoViewModels.OrderByDescending(p => p.Cliente.Nome).ToList();
                    break;
                case "valor_final_desc":
                    pedidoViewModels = pedidoViewModels.OrderByDescending(p => p.ValorTotal).ToList();
                    break;
                case "valor_final_cre":
                    pedidoViewModels = pedidoViewModels.OrderBy(p => p.ValorTotal).ToList();
                    break;
                case "data_pedido_desc":
                    pedidoViewModels = pedidoViewModels.OrderByDescending(p => p.DataCadastro).ToList();
                    break;
                case "data_pedido_cre":
                    pedidoViewModels = pedidoViewModels.OrderBy(p => p.DataCadastro).ToList();
                    break;
                default:
                    pedidoViewModels = pedidoViewModels.OrderBy(p => p.Cliente.Nome).ToList();
                    break;
            }

            int paginaTamanho = 5;
            int paginaNumero = (pagina ?? 1);

            return PartialView(pedidoViewModels.ToPagedList(paginaNumero, paginaTamanho));
        }
    }
}