using EsTacna.Models;
using EsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;

/**
* Controlador para la gestión de usuarios.
*/

namespace EsTacna.Controllers
{
    public class UsuarioController : Controller
    {
        // Repositorio y unidad de trabajo utilizados por el controlador
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());
        private readonly UnitOfWork objUsuarioUnit = new UnitOfWork(new EsTacnaContext());

        /**
        * Acción que maneja la vista del perfil del usuario.
        * @return Vista del perfil del usuario.
        */
        public IActionResult Perfil()
        {
            return View();
        }

        /**
        * Acción que maneja la vista de registro de usuarios mediante solicitud GET.
        * @return Vista de registro de usuarios.
        */
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        /**
        * Acción que maneja el proceso de registro de un nuevo usuario.
        * @param objUsuario Objeto Usuario que contiene la información del nuevo usuario.
        * @return Redirección a la página principal si el registro es exitoso.
        */
        [HttpPost]
        public IActionResult Registrar(Usuario objUsuario)
        {
            try
            {
                objUsuarioRepo.Registrar(objUsuario);
                objUsuarioUnit.SaveChanges();
                return Redirect("~/Home/Index");
                
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar el usuario.", ex);
            }
        }

        /**
        * Acción que maneja la vista del perfil del usuario con un id específico mediante solicitud GET.
        * @param idUsuario El id del usuario cuyo perfil se va a mostrar.
        * @return Vista del perfil del usuario.
        */
        [HttpGet]
        public IActionResult Perfil(int idUsuario)
        {
            var resultado = objUsuarioRepo.BuscarId(idUsuario);
            return View(resultado);
        }

        /**
        * Acción que maneja la actualización del perfil del usuario.
        * @param objUsuario Objeto Usuario que contiene la información actualizada del usuario.
        * @return Redirección a la vista del perfil del usuario después de actualizar.
        */
        [HttpPost]
        public IActionResult Perfil(Usuario objUsuario)
        {
            objUsuarioRepo.Registrar(objUsuario);
            objUsuarioUnit.SaveChanges();
            return Redirect("~/Usuario/Perfil?idUsuario=" + objUsuario.Id);
        }
    }
}
