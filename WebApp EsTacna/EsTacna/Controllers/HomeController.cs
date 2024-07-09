using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/**
* Controlador para la p�gina principal de la aplicaci�n.
*/

namespace EsTacna.Controllers
{
    public class HomeController : Controller
    {
        // Repositorios utilizados por el controlador
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicaRepositoryImpl objClinicaRepo = new ClinicaRepositoryImpl(new EsTacnaContext());
        private readonly EpsRepositoryImpl objEpsRepo = new EpsRepositoryImpl(new EsTacnaContext());

        /**
        * Constructor del controlador.
        * @param logger Logger para registrar informaci�n y errores.
        */
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /**
        * Acci�n que maneja la vista principal del sitio.
        * @return Vista con la informaci�n de las clinicas y EPS.
        */
        public IActionResult Index()
        {
            ClinicaViewModel objClinicaVm = new ClinicaViewModel();
            ClinicaResponse objClinicaResponse = new ClinicaResponse();
            objClinicaVm.listClinica = objClinicaRepo.ListarMap();
            objClinicaVm.listEps = objEpsRepo.Listar();
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                var idUsuario = HttpContext.Session.GetString("UsuarioId");
                objClinicaVm.recoClinica = objClinicaResponse.GetClinica(Convert.ToInt32(idUsuario)).Result;
            }
            return View(objClinicaVm);
        }

        /**
        * Acci�n que maneja la vista de privacidad.
        * @return Vista de privacidad.
        */
        public IActionResult Privacy()
        {
            return View();
        }

        /**
        * Acci�n que maneja la vista de errores.
        * @return Vista de errores con el modelo de error.
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
