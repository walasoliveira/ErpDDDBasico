using AutoMapper;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.AspNetMvc.ViewModels;
using ErpDDDBasico.Domain.Entities;
using PagedList;
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
            return View();
        }

        [HttpGet]
        public PartialViewResult GridFuncionarios(string ordenacao, string stringPesquisa, string filtroAtual, int? pagina)
        {
            ViewBag.OrdernacaoAtual = ordenacao;
            ViewBag.NomeOrdernacao = string.IsNullOrEmpty(ordenacao) ? "nome_desc" : "";
            ViewBag.DataCadastroOrdernacao = ordenacao == "data_cad_desc" ? "data_cad_cre" : "data_cad_desc";
            ViewBag.SetorOrdenacao = ordenacao == "setor_desc" ? "setor_cre" : "setor_desc";

            TempData["Menu"] = "funcionarios";
            List<FuncionarioModel> funcionarioModels = new List<FuncionarioModel>();

            if (stringPesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                stringPesquisa = filtroAtual;
            }

            ViewBag.FiltroAtual = stringPesquisa;

            funcionarioModels = Mapper.Map<List<Funcionario>, List<FuncionarioModel>>(_funcionarioAppService.GetAll());

            if (!String.IsNullOrEmpty(stringPesquisa))
            {
                funcionarioModels = funcionarioModels.Where(s => s.Nome.Contains(stringPesquisa)).ToList();
            }

            switch (ordenacao)
            {
                case "nome_desc":
                    funcionarioModels = funcionarioModels.OrderByDescending(f => f.Nome).ToList();
                    break;
                case "data_cad_desc":
                    funcionarioModels = funcionarioModels.OrderByDescending(f => f.Nome).ToList();
                    break;
                case "setor_desc":
                    funcionarioModels = funcionarioModels.OrderByDescending(f => f.Setor).ToList();
                    break;
                case "setor_cre":
                    funcionarioModels = funcionarioModels.OrderBy(f => f.Setor).ToList();
                    break;
                case "data_cad_cre":
                    funcionarioModels = funcionarioModels.OrderBy(f => f.Nome).ToList();
                    break;
                default:
                    funcionarioModels = funcionarioModels.OrderBy(f => f.Nome).ToList();
                    break;
            }

            int paginaTamanho = 5;
            int paginaNumero = (pagina ?? 1);

            return PartialView(funcionarioModels.ToPagedList(paginaNumero, paginaTamanho));
        }

        public ActionResult HistoricoPagamentos()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GridPagamentos(string ordenacao, string stringPesquisa, int? pagina, string filtroAtual)
        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.NomeOrdenacao = string.IsNullOrEmpty(ordenacao) ? "nome_desc" : "";
            ViewBag.TipoPagamentoOrdernacao = ordenacao == "tipo_pag_desc" ? "tipo_pag_cre" : "tipo_pag_desc";
            ViewBag.ValorOrdernacao = ordenacao == "valor_desc" ? "valor_cre" : "valor_desc";
            ViewBag.DataPagamentoOrdernacao = ordenacao == "data_pag_desc" ? "data_pag_cre" : "data_pag_desc";

            if (stringPesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                stringPesquisa = filtroAtual;
            }

            ViewBag.FiltroAtual = stringPesquisa;

            TempData["Menu"] = "pagamentos";

            List<PagamentoViewModel> pagamentoViewModels = new List<PagamentoViewModel>();

            try
            {
                var pag = _pagamentoAppService.GetAll();
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
            catch (AutoMapperMappingException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            switch (ordenacao)
            {
                case "nome_desc":
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.Funcionario.Nome).ToList();
                    break;
                case "nome_cre":
                    pagamentoViewModels = pagamentoViewModels.OrderBy(f => f.Funcionario.Nome).ToList();
                    break;
                case "tipo_pag_desc":
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.TipoPagamento.Descricao).ToList();
                    break;
                case "tipo_pag_cre":
                    pagamentoViewModels = pagamentoViewModels.OrderBy(f => f.TipoPagamento.Descricao).ToList();
                    break;
                case "data_pag_desc":
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.DataPagamento).ToList();
                    break;
                case "data_pag_cre":
                    pagamentoViewModels = pagamentoViewModels.OrderBy(f => f.DataPagamento).ToList();
                    break;
                case "setor_desc":
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.Funcionario.Setor).ToList();
                    break;
                case "setor_cre":
                    pagamentoViewModels = pagamentoViewModels.OrderBy(f => f.Funcionario.Setor).ToList();
                    break;
                case "valor_desc":
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.Valor).ToList();
                    break;
                case "valor_cre":
                    pagamentoViewModels = pagamentoViewModels.OrderBy(f => f.Valor).ToList();
                    break;
                default:
                    pagamentoViewModels = pagamentoViewModels.OrderByDescending(f => f.Funcionario.Nome).ToList();
                    break;
            }

            int paginaTamanho = 5;
            int paginaNumero = (pagina ?? 1);

            return PartialView(pagamentoViewModels.ToPagedList(paginaNumero, paginaTamanho));
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