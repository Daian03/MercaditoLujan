using MercaditoLujanWEB.Entities;
using MercaditoLujanWEB.Services;
using MercaditoLujanWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercaditoLujanWEB.Controllers
{
    public class UsuariosController(IUsuariosModel _usuarioModel, IUtilitariosModel _utilitariosModel) : Controller
    {

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            if (HttpContext.Session.GetString("Login") != null && HttpContext.Session.GetString("Login") == "true")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuarios entidad)
        {
            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            var resp = _usuarioModel.IniciarSesion(entidad);

            if (resp?.Codigo == "00")
            {
                HttpContext.Session.SetString("Correo", resp?.Dato?.Correo!);
                HttpContext.Session.SetString("Nombre", resp?.Dato?.Nombre!);
                HttpContext.Session.SetString("Token", resp?.Dato?.Token!);
                HttpContext.Session.SetString("IdRol", resp?.Dato?.IdRol.ToString()!);
                HttpContext.Session.SetString("NombreRol", resp?.Dato?.NombreRol!);
                if ((bool)(resp?.Dato?.EsTemporal!))
                {
                    return RedirectToAction("CambiarContrasenna", "Usuarios");
                }
                else
                {
                    HttpContext.Session.SetString("Login", "true");

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

        [Seguridad]
        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("IniciarSesion", "Usuarios");
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuarios entidad)
        {
            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            var resp = _usuarioModel.RegistrarUsuario(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("IniciarSesion", "Usuarios");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

        [HttpGet]
        public IActionResult RecuperarAcceso()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RecuperarAcceso(Usuarios entidad)
        {
            var resp = _usuarioModel.RecuperarAcceso(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("IniciarSesion", "Usuario");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

        [HttpGet]
        public IActionResult CambiarContrasenna()
        {
            var entidad = new Usuarios();
            entidad.Correo = HttpContext.Session.GetString("Correo");
            return View(entidad);
        }

        [HttpPost]
        public IActionResult CambiarContrasenna(Usuarios entidad)
        {
            if (entidad.Contrasenna?.Trim() == entidad.ContrasennaTemporal?.Trim())
            {
                ViewBag.MsjPantalla = "Debe utilizar una contraseña distinta";
                return View();
            }

            entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
            entidad.ContrasennaTemporal = _utilitariosModel.Encrypt(entidad.ContrasennaTemporal!);
            var resp = _usuarioModel.CambiarContrasenna(entidad);

            if (resp?.Codigo == "00")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }
    }
}