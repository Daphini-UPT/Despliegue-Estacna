using Microsoft.AspNetCore.Mvc;
using AdminEsTacna.Models;
using AdminEsTacna.Repositories;
using AdminEsTacna.ViewModels;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminEsTacna.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly EstablecimientoSaludRepositoryImpl objClinicaRepo = new EstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly EpsRepositoryImpl objEpsRepo = new EpsRepositoryImpl(new EsTacnaContext());
        private readonly EpsEstablecimientoSaludRepositoryImpl objEpsClinicaRepo = new EpsEstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly UnitOfWorkEst objClinicaUnit = new UnitOfWorkEst(new EsTacnaContext());

        public IActionResult VerClinicas()
        {
            var listEstablecimiento = new List<EstablecimientoSalud>();
            listEstablecimiento = objClinicaRepo.ListarClinicas().ToList();
            return View(listEstablecimiento);
        }

        [HttpGet]
        public IActionResult RegistrarClinicas()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarClinicas(EstablecimientoSalud objClinica)
         {
            try
            {
                objClinicaRepo.Registrar(objClinica);
                objClinicaUnit.SaveChanges();
                TempData["SuccessMessage"] = "La clínica se ha registrado exitosamente.";
                return RedirectToAction("VerClinicas");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al registrar la clínica en la EPS: " + ex.Message;
                return RedirectToAction("VerClinicas");
            }
         }

        [HttpGet]
        public IActionResult Editar(int clinicaId)
        {
            var resultado = objClinicaRepo.BuscarId(clinicaId);
            return View(resultado);
        }

        [HttpPost]
        public IActionResult Editar(EstablecimientoSalud objClinica)
        {
            objClinicaRepo.Registrar(objClinica);
            objClinicaUnit.SaveChanges();
            TempData["SuccessMessage"] = "La clínica se ha editado exitosamente.";
            return Redirect("~/Clinicas/VerClinicas");
        }

        [HttpPost]
        public IActionResult Borrar(int clinicaId)
        {
            try
            {
                // Borrar enlaces de la clínica en la tabla Eps_EstablecimientoSalud
                objEpsClinicaRepo.BorrarPorClinicaId(clinicaId);

                // Borrar la clínica
                objClinicaRepo.Borrar(clinicaId);

                objClinicaUnit.SaveChanges();
                TempData["SuccessMessage"] = "La clínica se ha borrado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al borrar la clínica: " + ex.Message;
            }
            return RedirectToAction("VerClinicas");
        }

    }
}
