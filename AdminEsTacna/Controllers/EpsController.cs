using AdminEsTacna.Models;
using AdminEsTacna.Repositories;
using AdminEsTacna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminEsTacna.Controllers
{
    public class EpsController : Controller
    {
        private readonly EstablecimientoSaludRepositoryImpl objClinicaRepo = new EstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly EpsEstablecimientoSaludRepositoryImpl objEpsClinicaRepo = new EpsEstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly EpsRepositoryImpl objEpsRepo = new EpsRepositoryImpl(new EsTacnaContext());
        private readonly UnitOfWorkEst objClinicaUnit = new UnitOfWorkEst(new EsTacnaContext());
        private readonly UnitOfWorkEps objEpsUnit = new UnitOfWorkEps(new EsTacnaContext());
        private readonly UnitOfWorkEpsCli objEpClisUnit = new UnitOfWorkEpsCli(new EsTacnaContext());
        public IActionResult VerEps()
        {
            var listEstablecimiento = new List<Ep>();
            listEstablecimiento = objEpsRepo.ListarEps().ToList();
            return View(listEstablecimiento);
        }

        [HttpGet]
        public IActionResult RegistrarEps()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEps(Ep objEps)
        {
            try
            {
                objEpsRepo.Registrar(objEps);
                objEpsUnit.SaveChanges();
                return Redirect("~/Eps/VerEps");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar la Clínica.", ex);
            }
        }
        public IActionResult AgregarClinica(int pagina = 1, int? epsIdSeleccionado = null, int? clinicaSeleccionada = null)
        {
            EstablecimientoSaludViewModel objEpsClinicaVm = new EstablecimientoSaludViewModel();

            var todasLasEps = objEpsRepo.ListarEps();
            objEpsClinicaVm.TotalElementos = todasLasEps.Count;
            objEpsClinicaVm.PaginaActual = pagina;
            objEpsClinicaVm.listEstablecimiento = objClinicaRepo.ListarClinicas();

            var epsAMostrar = todasLasEps
                .Skip((pagina - 1) * objEpsClinicaVm.ElementosPorPagina)
                .Take(objEpsClinicaVm.ElementosPorPagina)
                .ToList();

            objEpsClinicaVm.listEps = epsAMostrar;

            var establecimientosPorEps = new Dictionary<int, List<EstablecimientoSalud>>();

            var epsEstablecimientos = objEpsClinicaRepo.Listar();

            foreach (var eps in epsAMostrar)
            {
                var establecimientos = epsEstablecimientos
                    .Where(e => e.EpsId == eps.Id)
                    .Select(e => objClinicaRepo.BuscarId(e.EstablecimientoId))
                    .ToList();

                establecimientosPorEps[eps.Id] = establecimientos;
            }

            objEpsClinicaVm.EstablishmentsByEps = establecimientosPorEps;

            objEpsClinicaVm.SelectListClinicas = objEpsClinicaVm.listEstablecimiento
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre })
                .ToList();

            return View(objEpsClinicaVm);
        }

        [HttpPost]
        public IActionResult AgregarClinicaEps(int epsId, int clinicaId)
        {
            try
            {
                var objEpsClinica = new EpsEstablecimientoSalud
                {
                    EpsId = epsId,
                    EstablecimientoId = clinicaId
                };
                objEpsClinicaRepo.Registrar(objEpsClinica);
                objEpClisUnit.SaveChanges();

                TempData["SuccessMessage"] = "La clínica se ha registrado en la EPS exitosamente.";
                return RedirectToAction("AgregarClinica");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al registrar la clínica en la EPS: " + ex.Message;
                return RedirectToAction("AgregarClinica");
            }
        }

        [HttpPost]
        public IActionResult Borrar(int epsId)
        {
            try
            {
                objEpsClinicaRepo.BorrarPorEpsId(epsId);
                objEpsRepo.Borrar(epsId);

                objEpsUnit.SaveChanges();
                TempData["SuccessMessage"] = "La EPS ha sido borrada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al borrar la EPS: " + ex.Message;
            }
            return RedirectToAction("VerEps");
        }
    }
}
