using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionTienda.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult RestorePassword()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente obj)
        {
            int result;
            string mensaje = string.Empty;

            ViewData["Nombres"] = string.IsNullOrEmpty(obj.Nombres) ? "" : obj.Nombres;
            ViewData["Apellidos"] = string.IsNullOrEmpty(obj.Apellidos) ? "" : obj.Apellidos;
            ViewData["Correo"] = string.IsNullOrEmpty(obj.Correo) ? "": obj.Correo;

            if(obj.Clave != obj.ConfirmarClave)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            result = new CN_Cliente().Add(obj, out mensaje);

            if(result > 0)
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

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Cliente xclient = null;

            xclient = new CN_Cliente().Fetch().Where(item => item.Correo == correo && item.Clave == CN_Recursos.ConvertToSha256(clave)).FirstOrDefault();

            if(xclient == null)
            {
                ViewBag.Error = "Email o Password incorrectos";
                return View();
            }
            else
            {
                if (xclient.Reestablecer)
                {
                    TempData["IdCliente"] = xclient.IdCliente;
                    return RedirectToAction("ChangePassword", "Acceso");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(xclient.Correo, false);
                    Session["Cliente"] = xclient;

                    ViewBag.Error = null;
                    return RedirectToAction("Index", "Tienda");
                }
            }
        }

        [HttpPost]
        public ActionResult RestorePassword(string correo)
        {
            Cliente xclient = new Cliente();

            xclient = new CN_Cliente().Fetch().Where(item => item.Correo == correo).FirstOrDefault();

            if(xclient == null)
            {
                ViewBag.Error = "No se encontre un cliente asociado al email";
                return View();
            }

            string mensaje = string.Empty;
            bool rpta = new CN_Cliente().RestorePass(xclient.IdCliente, correo, out mensaje);

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

        [HttpPost]
        public ActionResult ChangePassword(string idCliente, string claveActual, string newPass, string confirmPass)
        {
            Cliente xclient = new Cliente();
            xclient = new CN_Cliente().Fetch().Where(u => u.IdCliente == int.Parse(idCliente)).FirstOrDefault();

            if(xclient.Clave != CN_Recursos.ConvertToSha256(claveActual))
            {
                TempData["IdCliente"] = idCliente;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }else if(newPass != confirmPass)
            {
                TempData["IdCliente"] = idCliente;
                ViewData["vclave"] = claveActual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }
            ViewData["vclave"] = "";

            newPass = CN_Recursos.ConvertToSha256(newPass);

            string mensaje = string.Empty;
            bool rpta = new CN_Cliente().ChangePassword(int.Parse(idCliente), newPass, out mensaje);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdCliente"] = idCliente;
                ViewBag.Error = mensaje;
                return View();
            }
        }

        public ActionResult CloseSession()
        {
            Session["Cliente"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }














    }
}