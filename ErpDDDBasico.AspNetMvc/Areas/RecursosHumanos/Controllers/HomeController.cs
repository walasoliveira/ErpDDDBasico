using AutoMapper;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace ErpDDDBasico.AspNetMvc.Areas.RecursosHumanos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IPagamentoAppService _pagamentoAppService;

        public HomeController(IUsuarioAppService usuarioAppService,
            IFuncionarioAppService funcionarioAppService,
            IPagamentoAppService pagamentoAppService)
        {
            _usuarioAppService = usuarioAppService;
            _funcionarioAppService = funcionarioAppService;
            _pagamentoAppService = pagamentoAppService;
        }

        // GET: RecursosHumanos/Home
        public ActionResult Index()
        {
            TempData["Menu"] = "home";
            ViewBag.Funcionarios = _funcionarioAppService.GetAll().OrderBy(f => f.DataCadastro).Take(5);
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarFuncionario()
        {
            TempData["Menu"] = "funcionarios";
            FuncionarioModel funcionarioModel = new FuncionarioModel();
            return View(funcionarioModel);
        }

        [HttpPost]
        public ActionResult CadastrarFuncionario(FuncionarioModel funcionarioModel)
        {
            TempData["Menu"] = "funcionarios";
            Funcionario funcionario = Mapper.Map<FuncionarioModel, Funcionario>(funcionarioModel);
            try
            {
                _funcionarioAppService.Add(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("BuscarTodosFuncionarios");
        }

        public ActionResult DeletarFuncionario(int id)
        {
            Funcionario funcionario = null;
            try
            {
                funcionario = _funcionarioAppService.GetById(id);
                _funcionarioAppService.Remove(funcionario);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("BuscarTodosFuncionarios");
        }

        [HttpGet]
        public ActionResult EditarFuncionario(int id)
        {
            TempData["Menu"] = "funcionarios";
            FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(_funcionarioAppService.GetById(id));
            return View(funcionarioModel);
        }

        [HttpPost]
        public ActionResult EditarFuncionario(FuncionarioModel funcionarioModel)
        {
            Funcionario funcionario = Mapper.Map<FuncionarioModel, Funcionario>(funcionarioModel);

            _funcionarioAppService.Update(funcionario);

            return RedirectToAction("BuscarTodosFuncionarios", "Home");
        }

        public ActionResult DetalharFuncionario(int id)
        {
            TempData["Menu"] = "funcionarios";
            FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(_funcionarioAppService.GetById(id));
            return View(funcionarioModel);
        }

        public ActionResult BuscarTodosFuncionarios()
        {
            TempData["Menu"] = "funcionarios";
            List<FuncionarioModel> funcionarioModels = new List<FuncionarioModel>();

            funcionarioModels = Mapper.Map<List<Funcionario>, List<FuncionarioModel>>(_funcionarioAppService.GetAll());

            return View(funcionarioModels);
        }

        public ActionResult HistoricoPagamentos()
        {
            TempData["Menu"] = "pagamentos";
            List<PagamentoViewModel> pagamentoViewModels = new List<PagamentoViewModel>();

            try
            {
                pagamentoViewModels = Mapper.Map<List<Pagamento>, List<PagamentoViewModel>>(_pagamentoAppService.GetAll());
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
            return View(pagamentoViewModels);
        }

        [HttpGet]
        public ActionResult RealizarPagamento()
        {
            TempData["Menu"] = "pagamentos";
            PagamentoViewModel pagamentoViewModel = new PagamentoViewModel()
            {
                ListaFuncionarios = Mapper.Map<List<Funcionario>, List<FuncionarioModel>>(_funcionarioAppService.GetAll()),
                ListaTiposPagamento = Mapper.Map<List<TipoPagamento>, List<TipoPagamentoModel>>(_pagamentoAppService.BuscarTiposPagamento()),
            };
            return View(pagamentoViewModel);
        }

        [HttpPost]
        public ActionResult RealizarPagamento(PagamentoViewModel pagamentoViewModel)
        {
            TempData["Menu"] = "pagamentos";
            if (!ModelState.IsValid)
                return View(pagamentoViewModel);

            try
            {
                pagamentoViewModel.DataPagamento = DateTime.Now;
                Pagamento pagamento = Mapper.Map<PagamentoViewModel, Pagamento>(pagamentoViewModel);
                _pagamentoAppService.Add(pagamento);
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
            return RedirectToAction("HistoricoPagamentos");
        }
    }
}