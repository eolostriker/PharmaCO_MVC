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
            ViewBag.Title = "Index";
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario _usuario)
        {
            if (!UsuarioDAO.VerificaEmail(_usuario.Email))
            {
                //Aqui deveríamos verificar se o usuário já esta registrado
                UsuarioDAO.InsertUsuario(_usuario);
                _usuario = null;
                ViewBag.Message = "Usuário registrado com sucesso.";

            }
            return View(_usuario);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}