using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MercaditoLujanWEB.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }
        public ActionResult Page404()
        {
            return View();
        }
        public ActionResult Carrito()
        {
            return View();
        }

        public ActionResult DetalleProducto()
        {
            return View();
        }
    }
}

