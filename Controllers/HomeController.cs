using PharmaCO_MVC.DAO;
using PharmaCO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaCO_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UsuarioLogado"] != null)
            {
                return View("Detalhes", (Usuario)Session["UsuarioLogado"]);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario usuario)
        {
            if (!UsuarioDAO.VerificaEmail(usuario.Email))
            {
                //Aqui deveríamos verificar se o usuário já esta registrado
                UsuarioDAO.InsertUsuario(usuario);
                usuario = null;
                ViewBag.Message = "Usuário registrado com sucesso.";

            }
            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            usuario = UsuarioDAO.VerificaLogin(usuario.Login, usuario.Senha);
            if (usuario != null)
            {
                Session["UsuarioLogado"] = usuario;
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
    }
}