using AdminEsTacna.Models;
using AdminEsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminEsTacna.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(Usuario objUsuario)
        {
            Usuario logUsuario = objUsuarioRepo.IniciarSesion(objUsuario.Email, objUsuario.Contrasena);

            if (logUsuario != null && logUsuario.Email.ToLower() == "admin@estacna.pe")
            {
                HttpContext.Session.SetString("UsuarioNombre", logUsuario.Nombre);
                HttpContext.Session.SetString("UsuarioId", logUsuario.Id.ToString());
                TempData["SuccessMessage"] = "Inicio de sesión exitoso.";
                return RedirectToAction("Mantenimiento", "Mantenimiento");
            }
            else
            {
                TempData["ErrorMessage"] = "Correo electrónico o contraseña incorrectos.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
