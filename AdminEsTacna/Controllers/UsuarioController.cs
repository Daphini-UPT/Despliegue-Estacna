using AdminEsTacna.Models;
using AdminEsTacna.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdminEsTacna.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());
        private readonly ValorarRepositoryImpl objValorarRepo = new ValorarRepositoryImpl(new EsTacnaContext());
        private readonly BusquedaRepositoryImpl objBusquedaRepo = new BusquedaRepositoryImpl(new EsTacnaContext());
        private readonly UnitOfWork objUsuarioUnit = new UnitOfWork(new EsTacnaContext());

        public IActionResult VerUsuarios()
        {
            var listUsuario = new List<Usuario>();
            listUsuario = objUsuarioRepo.ListarUsuarios().ToList();
            return View(listUsuario);
        }
        [HttpPost]
        public IActionResult Borrar(int usuarioId)
        {
            try
            {
                objValorarRepo.BorrarPorUsuarioId(usuarioId);

                objBusquedaRepo.BorrarPorUsuarioId(usuarioId);

                objUsuarioRepo.Borrar(usuarioId);

                objUsuarioUnit.SaveChanges();
                TempData["SuccessMessage"] = "El usuario se ha borrado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al borrar el usuario: " + ex.Message;
            }
            return RedirectToAction("VerUsuarios");
        }
    }
}
