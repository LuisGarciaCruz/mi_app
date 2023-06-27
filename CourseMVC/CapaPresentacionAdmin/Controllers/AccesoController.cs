using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

using System.Web.Security;

namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuario oUser = new Usuario();
            oUser = new CN_Usuario().Listar().Where(u => u.Correo == correo && u.Clave == CN_Recursos.ConvertToSha256(clave)).FirstOrDefault();

            if (oUser == null)
            {
                ViewBag.Error = "Correo o Password incorrectos";
                return View();

            }
            else
            {
                //ViewBag.Error = null;
                //return RedirectToAction("Index", "Home");
                if (oUser.Reestablecer)
                {
                    TempData["IdUsuario"] = oUser.IdUsuario;
                    return RedirectToAction("ChangePassword");
                }

                FormsAuthentication.SetAuthCookie(oUser.Correo, false);

                ViewBag.Error = null;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(string idUsuario, string claveActual, string nuevaClave, string confirmaClave)
        {
            Usuario oUser = new Usuario();

            oUser = new CN_Usuario().Listar().Where(u => u.IdUsuario == int.Parse(idUsuario)).FirstOrDefault();

            if (oUser.Clave != CN_Recursos.ConvertToSha256(claveActual))
            {
                TempData["IdUsuario"] = idUsuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "La clave actual no es la correcta";
                return View();
            }
            else if (nuevaClave != confirmaClave)
            {
                TempData["IdUsuario"] = idUsuario;
                ViewData["vclave"] = claveActual;
                ViewBag.Error = "Las passwords no coinciden";
                return View();
            }
            ViewData["vclave"] = "";

            nuevaClave = CN_Recursos.ConvertToSha256(nuevaClave);

            string mensaje = string.Empty;

            bool rpta = new CN_Usuario().ChangePassword(int.Parse(idUsuario), nuevaClave, out mensaje);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdUsuario"] = idUsuario;

                ViewBag.Error = mensaje;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Reestablecer(string mail)
        {
            Usuario oUser = new Usuario();

            oUser = new CN_Usuario().Listar().Where(item => item.Correo == mail).FirstOrDefault();


            if(oUser == null)
            {
                ViewBag.Error = "No existe un usuario asociado a ese email";
                return View();
            }

            string mensaje = string.Empty;
            bool rpta = new CN_Usuario().ReestablecerPass(oUser.IdUsuario, mail, out mensaje);

            if (rpta)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }

        public ActionResult CloseSession()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Acceso");
        }


    }
}