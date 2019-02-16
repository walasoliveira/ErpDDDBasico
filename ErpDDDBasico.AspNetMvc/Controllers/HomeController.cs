using AutoMapper;
using ErpDDDBasico.Application.Interfaces;
using ErpDDDBasico.AspNetMvc.Models;
using ErpDDDBasico.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace ErpDDDBasico.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IProdutoAppService _produtoAppService;

        public HomeController(IUsuarioAppService usuarioAppService, IProdutoAppService produtoAppService)
        {
            _usuarioAppService = usuarioAppService;
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            ViewBag.Produtos = Mapper.Map<List<Produto>, List<ProdutoModel>>(_produtoAppService.GetAll());
            return View(usuarioModel);
        }

        [HttpPost]
        public ActionResult Login(string returnUrl, UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
                return View(usuarioModel);

            UsuarioModel model = Mapper.Map<Usuario, UsuarioModel>(_usuarioAppService.BuscaUsuario(usuarioModel.UsuarioLogin, usuarioModel.UsuarioSenha));
            
            if (model == null)
                return View(usuarioModel);            

            //List<string> permissoes = new List<string>();

            //foreach (var item in model.UsuarioPermissaoModuloModel)
            //{
            //    permissoes.Add(item.Modulo.Nome);
            //}

            //ViewBag.Permissoes = permissoes;
            
            FormsAuthentication.SetAuthCookie(model.UsuarioLogin, true);

            if (returnUrl == null)
                return RedirectToAction("Index", "Home");
            else
                return Redirect(returnUrl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public PartialViewResult VerificarAcessosAreas()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}