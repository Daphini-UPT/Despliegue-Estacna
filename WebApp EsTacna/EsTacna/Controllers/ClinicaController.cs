using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Mvc;

/**
* Controlador para la gestión de Clinicas.
*/

namespace EsTacna.Controllers
{
    public class ClinicaController : Controller
    {
        // Repositorios utilizados por el controlador
        private readonly ClinicaRepositoryImpl objClinicaRepo = new ClinicaRepositoryImpl(new EsTacnaContext());
        private readonly BusquedaRepositoryImpl objBusquedaRepo = new BusquedaRepositoryImpl(new EsTacnaContext());
        private readonly EpsRepositoryImpl objEpsRepo = new EpsRepositoryImpl(new EsTacnaContext());
        private readonly EpsClinicaRepositoryImpl objEpsClinicaRepo = new EpsClinicaRepositoryImpl(new EsTacnaContext());
        private readonly ValoracionRepositoryImpl objValoracionRepo = new ValoracionRepositoryImpl(new EsTacnaContext());

        /**
        * Método para buscar Clinicas basado en un criterio y un id de EPS.
        * @param criterio El criterio de búsqueda.
        * @param epsid El id de la EPS.
        * @return Vista con la lista de las clinicas encontrados.
        */
        public IActionResult Buscar(string criterio, int epsid)
        {
            Busquedum objBuscar = new Busquedum();
            List<ClinicaViewModel> listClinicaVm = new List<ClinicaViewModel>();
            var listClinica = new List<EstablecimientoSalud>();
            if (criterio == "" || criterio == null)
            {
                listClinica = objClinicaRepo.Listar(epsid).ToList();
            }
            else
            {
                listClinica = objClinicaRepo.Buscar(criterio, epsid).ToList();
            }
            foreach (var item in listClinica)
            {
                ClinicaResponse objClinicaResponse = new ClinicaResponse();
                ClinicaViewModel objClinicaVm = new ClinicaViewModel();
                objClinicaVm.clinica = item;
                objClinicaVm.eps = objEpsRepo.BuscarId(objEpsClinicaRepo.BuscarId(item.Id).EpsId);
                listClinicaVm.Add(objClinicaVm);
            }
            objBuscar.TerminoBusqueda = objEpsRepo.BuscarId(epsid).Nombre + " " + criterio;
            objBuscar.UsuarioId = Convert.ToInt32(HttpContext.Session.GetString("UsuarioId") ?? "1");
            objBuscar.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            objBusquedaRepo.Registrar(objBuscar);
            return View(listClinicaVm);
        }

        /**
        * Método para obtener los detalles de una clinica.
        * @param ClinicaId El id de la clinica.
        * @return Vista con los detalles de la clinica.
        */
        public IActionResult Detalle(int ClinicaId)
        {
            ClinicaViewModel objClinicaVm = new ClinicaViewModel();
            var clinicaId = objClinicaRepo.BuscarId(ClinicaId);
            objClinicaVm.clinica = clinicaId;
            objClinicaVm.eps = objEpsClinicaRepo.BuscarIdEps(ClinicaId);
            objClinicaVm.listValoracion = objValoracionRepo.ListarPorClinicaId(clinicaId.Id);
            objClinicaVm.totalValoraciones = (objClinicaVm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objClinicaVm.listValoracion.Sum(x => x.Calificacion) / objClinicaVm.listValoracion.Count());
            return View(objClinicaVm);
        }

        /**
        * Método para valorar una clinica.
        * @param objValoracion La valoración realizada.
        * @return Redirección a la vista de detalles de la clinica valorada.
        */
        [HttpPost]
        public IActionResult Valorar(Valoracion objValoracion)
        {
            objValoracionRepo.Guardar(objValoracion);
            return RedirectToAction("Detalle", new { clinicaId = objValoracion.EstablecimientoId });
        }

        /**
        * Método para listar todas las clínicas.
        * @return Vista con la lista de clínicas.
        */
        public IActionResult Clinicas()
        {
            var listClinica = new List<EstablecimientoSalud>();
            listClinica = objClinicaRepo.ListarClinicas().ToList();
            return View(listClinica);
        }
    }
}
