using EsTacna.Models;
using EsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;

/**
* Controlador para la gestión de inicio de sesión de usuarios.
*/

namespace EsTacna.Controllers
{
    public class IniciarSesionController : Controller
    {
        // Repositorio utilizado por el controlador
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());

        /**
        * Acción que maneja la vista de inicio de sesión.
        * @return Vista de inicio de sesión.
        */
        public IActionResult Index()
        {
            return View();
        }

        /**
        * Acción que maneja el proceso de inicio de sesión de los usuarios.
        * @param objUsuario Objeto Usuario que contiene las credenciales del usuario.
        * @return Redirección a la página principal si el inicio de sesión es exitoso, de lo contrario retorna la vista de inicio de sesión.
        */
        [HttpPost]
        public IActionResult IniciarSesion(Usuario objUsuario)
        {
            Usuario logUsuario = objUsuarioRepo.Login(objUsuario.Email, objUsuario.Contrasena);

            if (logUsuario != null)
            {
                HttpContext.Session.SetString("UsuarioNombre", logUsuario.Nombre);
                HttpContext.Session.SetString("UsuarioId", logUsuario.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        /**
        * Acción que maneja la vista de inicio de sesión mediante solicitud GET.
        * @return Vista de inicio de sesión.
        */
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        /**
        * Acción que maneja el proceso de cierre de sesión.
        * @return Redirección a la página principal después de cerrar sesión.
        */
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
