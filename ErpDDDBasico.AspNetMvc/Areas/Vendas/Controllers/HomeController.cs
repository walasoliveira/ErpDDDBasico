using AutoMapper;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult EfetuarPedido()
        {
            TempData["Menu"] = "efetuar-pedido";
            ViewBag.Produtos = Mapper.Map<List<Produto>, List<ProdutoModel>>(_produtoAppService.GetAll());
            PedidoViewModel pedidoViewModel = new PedidoViewModel();
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
                Pedido pedido = Mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);
                _pedidoAppService.Add(pedido);
                PedidoDetalhes pedidoDetalhes = Mapper.Map<PedidoDetalheViewModel, PedidoDetalhes>(pedidoViewModel.PedidoDetalhe);
                pedidoDetalhes.PedidoId = pedido.PedidoId;
                _pedidoAppService.AddPedidoDetalhe(pedidoDetalhes);
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
    }
}